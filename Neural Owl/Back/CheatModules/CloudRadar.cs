using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using NeuralOwl.Back.Main;
using NeuralOwl.Configuration;
using NeuralOwl.Back.CsgoExternal;
using NeuralOwl.Back.CsgoExternal.Game;
using NeuralOwl.Back.CsgoExternal.Math;

using System.Net;

namespace NeuralOwl.Back.CheatModules
{
    public class CloudRadar : CheatModule
    {
        private const string htmlPage = @"<!DOCTYPE html>
<html>
<body>

<canvas id=""canvas"" width=screen.width height=screen.height></canvas>

<script>
document.addEventListener('DOMContentLoaded', function()
        {
            onLoad();
        }, false);

async function onLoad()
        {
            draw();
            location.reload();
        }

        function draw()
        {
            var canvas = document.getElementById('canvas');
            if (canvas.getContext)
            {
                var ctx = canvas.getContext('2d');

                ctx.fillRect(OUTSIDE_PosX, OUTSIDE_PosY, 5, 5)  }
        }
</script>

</body>
</html> ";

        private class PlayersCoordsPacket
        {
           
        };

        static HttpListener Listener;
        private static Vector3 pos;

        public CloudRadar() : base(100) {

            Listener = new HttpListener();
            Listener.Prefixes.Add("http://+:3070/");
            Listener.Start();
            // Begin waiting for requests.
            Listener.BeginGetContext(GetContextCallback, null);
            //listener.Stop();
        }

        static void GetContextCallback(IAsyncResult ar)
        {
            // Get the context
            var context = Listener.EndGetContext(ar);

            // listen for the next request
            Listener.BeginGetContext(GetContextCallback, null);

            // get the request
            var NowTime = DateTime.UtcNow;

            Console.WriteLine(pos);
            byte[] buffer = Encoding.UTF8.GetBytes(htmlPage.Replace("OUTSIDE_PosX", Math.Floor(pos.x / 40f).ToString()).Replace("OUTSIDE_PosY", Math.Floor(pos.y / 40f).ToString()));
            var response = context.Response;
            response.ContentType = "text/html";
            response.ContentLength64 = buffer.Length;
            response.StatusCode = 200;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
            
            //response.OutputStream.Close();
        }

        internal override void Update()
        {
            if (CheatMain.clientState.State != GameStates.Full)
                return;

            var packet = new PlayersCoordsPacket();

            var localPlayer = CheatMain.client.GetLocalPlayer();
            var entityList = CheatMain.client.GetEntityList();
            var players = entityList.FindAllPlayers();
            var glowManager = CheatMain.client.GetGlowObjectManager();

            pos = localPlayer.Position;

            foreach (var p in players)
            {
                if (p.Dead)
                    continue;

                bool isTeammate = p.Team == localPlayer.Team;

                if (!Config.ESP.ShowEnemies && !isTeammate)
                    continue;
                if (!Config.ESP.ShowTeammates && isTeammate)
                    continue;
                if (Config.ESP.VelocityMode && p.Velocity.magnitude < 130)
                    continue;

                var pos = p.Position;
                var pPosition = new int[2] { (int)pos.x, (int)pos.y };
            }
        }

        
    }
}
