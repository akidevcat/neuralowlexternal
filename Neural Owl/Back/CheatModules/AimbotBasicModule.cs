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
    public class AimbotBasic : CheatModule
    {
        public AimbotBasic() : base(1) { }

        bool enemyFound = false;
        Vector2 lastPunchAngles = new Vector2();
        Player lastEnemy;
        int enemyFoundTicks = 0;
        internal override void Update()
        {
            if (!Config.AimbotBasic.Enabled)
                return;

            if (CheatMain.clientState.State != GameStates.Full)
                return;

            if (enemyFoundTicks < 1000)
                enemyFoundTicks++;

            Player newEnemy = null;

            switch (Config.AimbotBasic.Type)
            {
                case Config.AimbotBasicConfig.AimbotBasicType.LerpCross:
                    newEnemy = AimbotLerpCrossUpdate();
                    break;
                case Config.AimbotBasicConfig.AimbotBasicType.LerpFov:
                    newEnemy = AimbotLerpFovUpdate();
                    break;
                case Config.AimbotBasicConfig.AimbotBasicType.RCS:
                    newEnemy = RcsUpdate();
                    break;
            }

            if (newEnemy != lastEnemy)
                enemyFoundTicks = 0;

            lastEnemy = newEnemy;
        }
        
        private Player AimbotLerpCrossUpdate()
        {
            if (Config.AimbotBasic.Key != 0 && GetAsyncKeyState((Keys)Config.AimbotBasic.Key) >= 0)
                return null;

            var localPlayer = CheatMain.client.GetLocalPlayer();
            if (localPlayer.Dead)
                return null;

            var entityList = CheatMain.client.GetEntityList();
            var plrWeapon = entityList.FindWeaponByID(localPlayer.ActiveWeaponID - 1);
            var cfgId = Array.IndexOf(Config.TriggerbotWeaponConfig.TriggerbotWeapons, (int)plrWeapon.WeaponID);

            if (cfgId == -1)
                return null;

            var cfg = Config.AimbotBasic.WeaponsCfg[cfgId];

            if (!cfg.Enabled)
                return null;

            if (Enum.IsDefined(typeof(Snipers), (int)plrWeapon.WeaponID) &&
                !localPlayer.Scoped)
                return null;

            var crosshairPlr = entityList.FindPlayerByID(localPlayer.CrosshairID - 1);

            if (crosshairPlr == null)
                return null;

            if (crosshairPlr.ClassId != ClassIDs.CCSPlayer)
                return null;

            if (!Config.AimbotBasic.FFA && crosshairPlr.Team == localPlayer.Team)
                return null;

            if (enemyFoundTicks < Config.AimbotBasic.DelayBefore)
                return crosshairPlr;

            var view = CheatMain.clientState.ViewAngles;
            var target = crosshairPlr.GetBonePosition(8);
            var pos = localPlayer.ViewPosition;
            var dist = Vector3.Distance(pos, target);

            var targetView = Math3.CalcAngle(pos, target);
            //var targetFov = Math3.AngleBetweenVec2(view, targetView);
            var punch = localPlayer.PunchAngles;

            CheatMain.clientState.ViewAngles = Math3.Slerp(view, targetView - 2f * cfg.Rcs * punch, cfg.Smooth * .1f);

            return crosshairPlr;
        }

        private Player AimbotLerpFovUpdate()
        {
            if (Config.AimbotBasic.Key != 0 && GetAsyncKeyState((Keys)Config.AimbotBasic.Key) >= 0)
                return null;

            var localPlayer = CheatMain.client.GetLocalPlayer();
            if (localPlayer.Dead)
                return null;
            
            var entityList = CheatMain.client.GetEntityList();
            var plrWeapon = entityList.FindWeaponByID(localPlayer.ActiveWeaponID - 1);
            var cfgId = Array.IndexOf(Config.TriggerbotWeaponConfig.TriggerbotWeapons, (int)plrWeapon.WeaponID);

            if (cfgId == -1)
                return null;

            var cfg = Config.AimbotBasic.WeaponsCfg[cfgId];

            if (!cfg.Enabled)
                return null;

            if (Enum.IsDefined(typeof(Snipers), (int)plrWeapon.WeaponID) &&
                !localPlayer.Scoped)
                return null;

            var view = CheatMain.clientState.ViewAngles;
            var players = entityList.FindVisiblePlayers(localPlayer);
            double fov;
            var targetPlr = entityList.FindFovPlayer(localPlayer, players, view - 2f * lastPunchAngles, out fov, Config.AimbotBasic.FFA, cfg.Bone);
            if (targetPlr == null)
                return null;

            if (enemyFoundTicks < Config.AimbotBasic.DelayBefore)
                return targetPlr;

            var target = targetPlr.GetBonePosition(cfg.Bone);
            var pos = localPlayer.ViewPosition;
            var dist = Vector3.Distance(pos, target);

            var targetView = Math3.CalcAngle(pos, target);
            var punch = localPlayer.PunchAngles;

            if (cfg.DynamicFov)
                fov = Math3.GetDistanceFov((float)fov, (float)dist) * 1.4f;

            if (fov <= cfg.Fov)
                CheatMain.clientState.ViewAngles = Math3.Slerp(view, targetView - 2f * cfg.Rcs * punch, cfg.Smooth * .1f);

            return targetPlr;
        }

        private Player RcsUpdate()
        {
            if (Config.AimbotBasic.Key != 0 && GetAsyncKeyState((Keys)Config.AimbotBasic.Key) >= 0)
                return null;

            var localPlayer = CheatMain.client.GetLocalPlayer();
            if (localPlayer.Dead)
                return null;

            var entityList = CheatMain.client.GetEntityList();
            var plrWeapon = entityList.FindWeaponByID(localPlayer.ActiveWeaponID - 1);
            var cfgId = Array.IndexOf(Config.TriggerbotWeaponConfig.TriggerbotWeapons, (int)plrWeapon.WeaponID);

            if (cfgId == -1)
                return null;

            var cfg = Config.AimbotBasic.WeaponsCfg[cfgId];

            if (!cfg.Enabled)
                return null;

            if (Enum.IsDefined(typeof(Snipers), (int)plrWeapon.WeaponID))
                return null;

            var view = CheatMain.clientState.ViewAngles;
            var players = entityList.FindVisiblePlayers(localPlayer);
            double fov;
            var targetPlr = entityList.FindFovPlayer(localPlayer, players, view - 2f * lastPunchAngles, out fov, Config.AimbotBasic.FFA, cfg.Bone);
            if (targetPlr == null)
                return null;

            if (enemyFoundTicks < Config.AimbotBasic.DelayBefore)
                return targetPlr;
            var target = targetPlr.GetBonePosition(8);
            var pos = localPlayer.ViewPosition;
            var dist = Vector3.Distance(pos, target);

            var targetView = Math3.CalcAngle(pos, target);
            var punch = localPlayer.PunchAngles;

            if (cfg.DynamicFov)
                fov = Math3.GetDistanceFov((float)fov, (float)dist) * 1.4f;

            if (fov <= cfg.Fov && punch != lastPunchAngles)
                CheatMain.clientState.ViewAngles = view - 2f * punch + 2f * lastPunchAngles;

            lastPunchAngles = punch;
            return targetPlr;
        }
    }
}
