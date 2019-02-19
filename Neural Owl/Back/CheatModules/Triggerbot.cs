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
    public class Triggerbot : CheatModule
    {
        public Triggerbot() : base(1) { }

        private bool readyToShoot = false;

        internal override void Update()
        {
            readyToShoot = TriggerbotUpdate();
        }

        private bool CheckBoneDistance(Player plr, LocalPlayer local, Config.TriggerbotWeaponConfig cfg)
        {
            var localPos = local.ViewPosition;
            var targetPos = plr.GetBonePosition(cfg.Bone);
            var angle = Math3.CalcAngle(localPos, targetPos);
            var fov = Math3.AngleBetweenVec2(CheatMain.clientState.ViewAngles, angle);
            var dist = Vector3.Distance(localPos, targetPos);

            if (cfg.DynamicFov)
                fov = Math3.GetDistanceFov((float)fov, (float)dist) * 1.4f;

            if (fov <= cfg.Fov)
                return true;
            else
                return false;
        }

        private bool TriggerbotUpdate()
        {
            if (!Config.Triggerbot.Enabled)
                return false;
 
            if (Config.Triggerbot.Key != 0 && GetAsyncKeyState((Keys)Config.Triggerbot.Key) >= 0)
                return false;
        

            if (CheatMain.clientState.State != GameStates.Full)
                return false;

            var localPlayer = CheatMain.client.GetLocalPlayer();
            if (localPlayer.Dead)
                return false;

            var entityList = CheatMain.client.GetEntityList();
            var plrWeapon = entityList.FindWeaponByID(localPlayer.ActiveWeaponID - 1);
            var cfgId = Array.IndexOf(Config.TriggerbotWeaponConfig.TriggerbotWeapons, (int)plrWeapon.WeaponID);

            if (cfgId == -1)
                return false;

            var cfg = Config.Triggerbot.WeaponsCfg[cfgId];

            if (!cfg.Enabled)
                return false;

            if (Enum.IsDefined(typeof(Snipers), (int)plrWeapon.WeaponID) &&
                !localPlayer.Scoped)
                return false;

            var crosshairPlr = entityList.FindPlayerByID(localPlayer.CrosshairID - 1);

            if (crosshairPlr == null)
                return false;

            if (crosshairPlr.ClassId != ClassIDs.CCSPlayer)
                return false;

            if (!Config.Triggerbot.FFA && crosshairPlr.Team == localPlayer.Team)
                return false;

            if (Config.Triggerbot.Type == Config.TriggerbotConfig.TriggerbotType.Fov)
            {
                if (!CheckBoneDistance(crosshairPlr, localPlayer, cfg))
                    return false;
            }

            if (!readyToShoot)
            {
                if (Config.Triggerbot.RandomizeDelay)
                    Thread.Sleep(cfg.DelayBefore + CheatMain.random.Next(16));
                else
                    Thread.Sleep(cfg.DelayBefore);
                return true;
            }
            if (CheatMain.client.ForceAttack != 5)
                CheatMain.client.ForceAttack = 6;
            if (Config.Triggerbot.RandomizeDelay)
                Thread.Sleep(cfg.DelayAfter + CheatMain.random.Next(16));
            else
                Thread.Sleep(cfg.DelayAfter);

            return false;
        }
    }
}
