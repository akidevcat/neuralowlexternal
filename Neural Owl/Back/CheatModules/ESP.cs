using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralOwl.Back.Main;
using NeuralOwl.Configuration;
using NeuralOwl.Back.CsgoExternal;
using NeuralOwl.Back.CsgoExternal.Game;
using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CheatModules
{

    public class ESP : CheatModule
    {
        public ESP() : base(1) { }

        internal override void Update()
        {
            if (!Config.ESP.Enabled)
                return;
            
            if (CheatMain.clientState.State != GameStates.Full)
                return;

            var localPlayer = CheatMain.client.GetLocalPlayer();
            var entityList = CheatMain.client.GetEntityList();
            var players = entityList.FindAllPlayers();
            var glowManager = CheatMain.client.GetGlowObjectManager();

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

                

                var glow = glowManager.FindGlowObjectByID(p.GlowIndex);
                Color color;

                var overridedColor = PlayerData.GetColor(p.address, PlayersList.Players);
                if (overridedColor != Color.Empty)
                    color = overridedColor;
                else
                    color = isTeammate ? Config.ESP.TeammateColor : Config.ESP.EnemyColor;

                glow.RenderWhenUnoccluded = false;
                glow.RenderWhenOccluded = true;
                glow.FullBloomRender = Config.ESP.FullBloom;
                glow.GlowStyle = Config.ESP.PulseStyle ? 1 : 0;
                //glow.BloomAmount = 1f;
                if (Config.ESP.ClrRender)
                    p.ClearRender = new Color();

                if (glow.FullBloomRender && glow.GlowStyle == 0)
                    color.a = .7f;
                glow.GlowColor = color;

                glowManager.WriteGlowObjectByID(p.GlowIndex, glow);
            }
        }

    }
}
