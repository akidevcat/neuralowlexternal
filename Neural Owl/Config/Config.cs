using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using NeuralOwl.Back.CsgoExternal.Game;
using System.Windows.Forms;

namespace NeuralOwl.Configuration
{
    public static class Config
    {
        [Serializable]
        public class NeuralOwlConfig
        {
            public ESPConfig esp;
            public TriggerbotConfig triggerbot;
            public AimbotBasicConfig aimbotBasic;
            public MiscConfig misc;
            public PlayerListConfig playerList;
            public PreferencesConfig preferences;
        }

        #region Config Values
        public static ESPConfig ESP;
        public static CloudRadarConfig CloudRadar;
        public static TriggerbotConfig Triggerbot;
        public static AimbotBasicConfig AimbotBasic;
        public static MiscConfig Misc;
        public static PlayerListConfig PlayerList;
        public static PreferencesConfig Preferences;

        [Serializable]
        public struct ESPConfig
        {
            public bool Enabled;
            public bool FullBloom;
            public bool ShowEnemies;
            public bool ShowTeammates;
            public Color EnemyColor;
            public Color TeammateColor;
            public bool ClrRender;
            public bool VelocityMode;
            public bool PulseStyle;
        }
        [Serializable]
        public struct TriggerbotConfig
        {
            public enum TriggerbotType { Cross, Fov }

            public bool Enabled;
            public TriggerbotType Type;
            public bool FFA;
            public bool RandomizeDelay;
            public int Key;
            public TriggerbotWeaponConfig[] WeaponsCfg;

            public void Reset()
            {
                foreach (var c in WeaponsCfg)
                {
                    c.DelayAfter = 0;
                    c.DelayBefore = 0;
                    c.Bone = 0;
                    c.DynamicFov = true;
                    c.Fov = 7;
                    c.Enabled = false;
                }
            }
        }
        [Serializable]
        public struct AimbotBasicConfig
        {
            public enum AimbotBasicType { LerpCross, LerpFov, RCS };

            public bool Enabled;
            public AimbotBasicType Type;
            public bool FFA;
            public int Key;
            public short DelayBefore;
            public AimbotBasicWeaponConfig[] WeaponsCfg;

            public void Reset()
            {
                foreach (var c in WeaponsCfg)
                {
                    c.Enabled = false;
                    c.Bone = 8;
                    c.Fov = 30;
                    c.Rcs = 0;
                    c.Smooth = .1f;
                    c.DynamicFov = true;
                }
            }
        }
        [Serializable]
        public struct CloudRadarConfig
        {
            public ushort port;
        }
        [Serializable]
        public struct MiscConfig
        {
            public bool BhopEnabled;
        }
        [Serializable]
        public struct PlayerListConfig
        {
            public OverridedPlayerColor[] Players;
        }
        [Serializable]
        public struct PreferencesConfig
        {
            public string ConfigFilePath; //Directory.GetParent(Environment.CurrentDirectory) + Const_DefaultPath
            public int ToggleKey; //(int)System.Windows.Forms.Keys.Home
        }
        #endregion
        #region Other Structs and Classes
        [Serializable]
        public struct OverridedPlayerColor
        {
            public string Name;
            public Color GlowColor;
        }
        [Serializable]
        public class TriggerbotWeaponConfig
        {
            public bool Enabled;
            public bool DynamicFov;
            public short Fov;
            public short Bone;
            public short DelayBefore;
            public short DelayAfter;

            internal static readonly int[] TriggerbotWeapons =
            {
                1,
                2,
                3,
                4,
                7,
                8,
                9,
                10,
                11,
                13,
                14,
                16,
                17,
                19,
                24,
                25,
                26,
                27,
                28,
                29,
                30,
                31,
                32,
                33,
                34,
                35,
                36,
                38,
                39,
                40,
                60,
                61,
                63,
                64,
                65
            };
        }
        [Serializable]
        public class AimbotBasicWeaponConfig
        {
            public bool Enabled;
            public short Bone;
            public short Fov;
            public bool DynamicFov;
            public float Smooth;
            public float Rcs;
        }
        #endregion


        #region Const
        public const string Const_DefaultPath = "\\Configurations\\default.cfg";
        #endregion

        public static void Save() => ExportToFile(GetDefaultPath());
        public static void ExportToFile(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            if (File.Exists(path))
                File.Delete(path);
            var stream = File.Create(path);
            var formatter = new BinaryFormatter();
            var cfg = new NeuralOwlConfig() { esp = ESP, triggerbot = Triggerbot, aimbotBasic = AimbotBasic, misc = Misc, playerList = PlayerList, preferences = Preferences };
            formatter.Serialize(stream, cfg);
            stream.Close();
        }
        public static void ImportFromFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    var stream = File.OpenRead(path);
                    var cfg = (NeuralOwlConfig)formatter.Deserialize(stream);
                    stream.Close();
                    ESP = cfg.esp;
                    Triggerbot = cfg.triggerbot;
                    AimbotBasic = cfg.aimbotBasic;
                    Misc = cfg.misc;
                    PlayerList = cfg.playerList;
                    Preferences = cfg.preferences;
                    return;
                } catch (Exception ex) { MessageBox.Show("Well, an error occured while reading cfg file: \n" + ex.Message + "\n We'll create a new one..."); }
            }
            //Load Default cfg
            #region ESP
            ESP.ShowEnemies = true;
            ESP.ShowTeammates = true;
            ESP.FullBloom = true;
            ESP.EnemyColor = new Color(.9f, .3f, 0, .25f);
            ESP.TeammateColor = new Color(.2f, .7f, 0, .25f);
            #endregion
            #region Triggerbot
            Triggerbot.Key = (int)Keys.Alt;
            Triggerbot.WeaponsCfg = new TriggerbotWeaponConfig[TriggerbotWeaponConfig.TriggerbotWeapons.Length];
            AimbotBasic.Key = 0;
            AimbotBasic.WeaponsCfg = new AimbotBasicWeaponConfig[TriggerbotWeaponConfig.TriggerbotWeapons.Length];
            for (int i = 0; i < Triggerbot.WeaponsCfg.Length; i++)
            {
                Triggerbot.WeaponsCfg[i] = new TriggerbotWeaponConfig();
                AimbotBasic.WeaponsCfg[i] = new AimbotBasicWeaponConfig();
            }
            #endregion
            #region Preferences
            //Preferences.ConfigFilePath = Directory.GetParent(Environment.CurrentDirectory) + Const_DefaultPath;
            Preferences.ToggleKey = (int)Keys.Home;
            #endregion
            ExportToFile(path);
        }
        public static string GetDefaultPath() => Directory.GetParent(Environment.CurrentDirectory) + Config.Const_DefaultPath;

        #region Some Funcs
        public static TriggerbotWeaponConfig FindWeaponCfg(int id) => Triggerbot.WeaponsCfg[Array.Find(TriggerbotWeaponConfig.TriggerbotWeapons, w => w == id)];
        #endregion
    }
   
}
