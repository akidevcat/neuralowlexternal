using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.Main;
using NeuralOwl.Configuration;
using NeuralOwl.Back.CsgoExternal;
using NeuralOwl.Back.CsgoExternal.Game;
using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CheatModules
{
    public struct PlayerData
    {
        public IntPtr Address;
        public int Health;
        public Weapons HandsWeapon;
        public int Id;
        public string Name;
        public bool Enemy;
        public Ranks Rank;
        public int Wins;
        public Color GlowColor; //Empty color <=> default

        public static PlayerData Find(IntPtr address, PlayerData[] array)
        {
            for (int p = 0; p < array.Length; p++)
                if (array[p].Address == address)
                    return array[p];
            return new PlayerData();
        }
        public static Color GetColor(IntPtr address, PlayerData[] array)
        {
            for (int p = 0; p < array.Length; p++)
                if (array[p].Address == address)
                    return array[p].GlowColor;
            return Color.Empty;
        }
    }

    public class PlayersList : CheatModule
    {

        public static PlayerData[] Players = new PlayerData[0];

        public PlayersList() : base(100) { }

        internal override void Update()
        {
            var localPlayer = CheatMain.client.GetLocalPlayer();
            var entityList = CheatMain.client.GetEntityList(CheatMain.clientState.MaxPlayer);
            var radar = CheatMain.client.GetRadarBase();
            var resource = CheatMain.client.GetPlayerResource();
            var players = entityList.FindAllPlayers(false);

            var list = new List<PlayerData>();

            foreach (var p in players)
            {
                var playerData = new PlayerData();
                var i = p.Index;
                var name = radar.GetPlayerNickname(i);

                playerData.Address = p.address;
                playerData.Name = name;
                playerData.Enemy = p.Team != localPlayer.Team;
                playerData.Id = i - 1;
                playerData.Rank = resource.GetPlayerRank(i);
                playerData.Wins = resource.GetPlayerWins(i);
                playerData.Health = p.Health;

                var weaponEnt = entityList.FindWeaponByID(p.ActiveWeaponID);
                playerData.HandsWeapon = weaponEnt == null ? Weapons.NONE : weaponEnt.WeaponID;

                playerData.GlowColor = Color.Empty;
                if (Config.PlayerList.Players != null)
                    for (int x = 0; x < Config.PlayerList.Players.Length; x++)
                        if (name.Contains(Config.PlayerList.Players[x].Name))
                            playerData.GlowColor = Config.PlayerList.Players[x].GlowColor;

                list.Add(playerData);
            }

            Players = list.ToArray();
        }

    }
}
