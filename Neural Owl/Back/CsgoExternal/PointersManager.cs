using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal
{
    public static class CsgoStructs
    {
        public const Int32 szEntity = Netvars.m_bSpottedByMask + 0x4;
        public const Int32 szWeapon = Netvars.m_iItemDefinitionIndex + 0x4;
        public const Int32 szPlayer = Netvars.m_iGlowIndex + 0x4;
        public const Int32 szLocalPlayer = Netvars.m_iCrosshairId + 0x4;
        public const Int32 szRadarBase = 0x6C + 0x4;
        public const Int32 szPlayerResourcePerPlayer = 0x4;
        public const Int32 szEntityListPerEntity = 0x10;
        public const Int32 szGlowObjectManagerPerEntity = 0x38;
    }
    public static class Netvars
    {
        public const Int32 m_ArmorValue = 0xB324;
        public const Int32 m_Collision = 0x31C;
        public const Int32 m_CollisionGroup = 0x474;
        public const Int32 m_Local = 0x2FBC;
        public const Int32 m_MoveType = 0x25C;
        public const Int32 m_OriginalOwnerXuidHigh = 0x31B4;
        public const Int32 m_OriginalOwnerXuidLow = 0x31B0;
        public const Int32 m_aimPunchAngle = 0x302C;
        public const Int32 m_aimPunchAngleVel = 0x3038;
        public const Int32 m_bGunGameImmunity = 0x3928;
        public const Int32 m_bHasDefuser = 0xB334;
        public const Int32 m_bHasHelmet = 0xB318;
        public const Int32 m_bInReload = 0x3285;
        public const Int32 m_bIsDefusing = 0x3914;
        public const Int32 m_bIsScoped = 0x390A;
        public const Int32 m_bSpotted = 0x93D;
        public const Int32 m_bSpottedByMask = 0x980;
        public const Int32 m_clrRender = 0x70;
        public const Int32 m_dwBoneMatrix = 0x26A8;
        public const Int32 m_fAccuracyPenalty = 0x3304;
        public const Int32 m_fFlags = 0x104;
        public const Int32 m_flC4Blow = 0x2990;
        public const Int32 m_flDefuseCountDown = 0x29AC;
        public const Int32 m_flDefuseLength = 0x29A8;
        public const Int32 m_flFallbackWear = 0x31C0;
        public const Int32 m_flFlashDuration = 0xA3E0;
        public const Int32 m_flFlashMaxAlpha = 0xA3DC;
        public const Int32 m_flNextPrimaryAttack = 0x3218;
        public const Int32 m_flTimerLength = 0x2994;
        public const Int32 m_hActiveWeapon = 0x2EF8;
        public const Int32 m_hMyWeapons = 0x2DF8;
        public const Int32 m_hObserverTarget = 0x3388;
        public const Int32 m_hOwner = 0x29CC;
        public const Int32 m_hOwnerEntity = 0x14C;
        public const Int32 m_iAccountID = 0x2FC8;
        public const Int32 m_iClip1 = 0x3244;
        public const Int32 m_iCompetitiveRanking = 0x1A84;
        public const Int32 m_iCompetitiveWins = 0x1B88;
        public const Int32 m_iCrosshairId = 0xB390;
        public const Int32 m_iEntityQuality = 0x2FAC;
        public const Int32 m_iFOVStart = 0x31E8;
        public const Int32 m_iGlowIndex = 0xA3F8;
        public const Int32 m_iHealth = 0x100;
        public const Int32 m_iItemDefinitionIndex = 0x2FAA;
        public const Int32 m_iItemIDHigh = 0x2FC0;
        public const Int32 m_iObserverMode = 0x3374;
        public const Int32 m_iShotsFired = 0xA370;
        public const Int32 m_iState = 0x3238;
        public const Int32 m_iTeamNum = 0xF4;
        public const Int32 m_lifeState = 0x25F;
        public const Int32 m_nFallbackPaintKit = 0x31B8;
        public const Int32 m_nFallbackSeed = 0x31BC;
        public const Int32 m_nFallbackStatTrak = 0x31C4;
        public const Int32 m_nForceBone = 0x268C;
        public const Int32 m_nTickBase = 0x342C;
        public const Int32 m_rgflCoordinateFrame = 0x444;
        public const Int32 m_szCustomName = 0x303C;
        public const Int32 m_szLastPlaceName = 0x35B0;
        public const Int32 m_thirdPersonViewAngles = 0x31D8;
        public const Int32 m_vecOrigin = 0x138;
        public const Int32 m_vecVelocity = 0x114;
        public const Int32 m_vecViewOffset = 0x108;
        public const Int32 m_viewPunchAngle = 0x3020;
    }
    public static class Signatures
    {
        public static Int32 clientstate_choked_commands = 0x4CB0;
        public static Int32 clientstate_delta_ticks = 0x174;
        public static Int32 clientstate_last_outgoing_command = 0x4CAC;
        public static Int32 clientstate_net_channel = 0x9C;
        public static Int32 convar_name_hash_table = 0x2F0F8;
        public static Int32 dwClientState = 0x58AC24;
        public static Int32 dwClientState_GetLocalPlayer = 0x180;
        public static Int32 dwClientState_IsHLTV = 0x4CC8;
        public static Int32 dwClientState_Map = 0x28C;
        public static Int32 dwClientState_MapDirectory = 0x188;
        public static Int32 dwClientState_MaxPlayer = 0x310;
        public static Int32 dwClientState_PlayerInfo = 0x5240;
        public static Int32 dwClientState_State = 0x108;
        public static Int32 dwClientState_ViewAngles = 0x4D10;
        public static Int32 dwEntityList = 0x4CC36D4;
        public static Int32 dwForceAttack = 0x30F4D8C;
        public static Int32 dwForceAttack2 = 0x30F4D98;
        public static Int32 dwForceBackward = 0x30F4DC8;
        public static Int32 dwForceForward = 0x30F4DA4;
        public static Int32 dwForceJump = 0x5166818;
        public static Int32 dwForceLeft = 0x30F4DBC;
        public static Int32 dwForceRight = 0x30F4DE0;
        public static Int32 dwGameDir = 0x628D70;
        public static Int32 dwGameRulesProxy = 0x51D8B54;
        public static Int32 dwGetAllClasses = 0xCD7604;
        public static Int32 dwGlobalVars = 0x58A928;
        public static Int32 dwGlowObjectManager = 0x5203420;
        public static Int32 dwInput = 0x510E468;
        public static Int32 dwInterfaceLinkList = 0x8961B4;
        public static Int32 dwLocalPlayer = 0xCB3694;
        public static Int32 dwMouseEnable = 0xCB91E0;
        public static Int32 dwMouseEnablePtr = 0xCB91B0;
        public static Int32 dwPlayerResource = 0x30F313C;
        public static Int32 dwRadarBase = 0x50F8414;
        public static Int32 dwSensitivity = 0xCB907C;
        public static Int32 dwSensitivityPtr = 0xCB9050;
        public static Int32 dwSetClanTag = 0x894F0;
        public static Int32 dwViewMatrix = 0x4CB5104;
        public static Int32 dwWeaponTable = 0x510EF2C;
        public static Int32 dwWeaponTableIndex = 0x323C;
        public static Int32 dwYawPtr = 0xCB8E40;
        public static Int32 dwZoomSensitivityRatioPtr = 0xCBE080;
        public static Int32 dwbSendPackets = 0xD1FEA;
        public static Int32 dwppDirect3DDevice9 = 0xA3F40;
        public static Int32 m_pStudioHdr = 0x294C;
        public static Int32 m_pitchClassPtr = 0x50F86C8;
        public static Int32 m_yawClassPtr = 0xCB8E40;
    }

    public static class PointersManager
    {
        private static byte[] dumpedRegionClient;
        private static byte[] dumpedRegionEngine;

        public static string GetDebugSignatures()
        {
            return $"{Signatures.dwClientState}\n" +
                $"{Signatures.dwClientState_GetLocalPlayer}\n" +
                $"{Signatures.dwClientState_IsHLTV}\n" +
                $"{Signatures.dwClientState_Map}\n" +
                $"{Signatures.dwClientState_MapDirectory}\n" +
                $"{Signatures.dwClientState_MaxPlayer}\n" +
                $"{Signatures.dwClientState_PlayerInfo}\n" +
                $"{Signatures.dwClientState_State}\n" +
                $"{Signatures.dwClientState_ViewAngles}\n" +
                $"{Signatures.dwEntityList}\n" +
                $"{Signatures.dwForceAttack}\n" +
                $"{Signatures.dwForceAttack2}\n" +
                $"{Signatures.dwForceJump}\n" +
                $"{Signatures.dwGlowObjectManager}\n" +
                $"{Signatures.dwLocalPlayer}\n" +
                $"{Signatures.dwMouseEnable}\n" +
                $"{Signatures.dwMouseEnablePtr}\n" +
                $"{Signatures.dwPlayerResource}\n" +
                $"{Signatures.dwRadarBase}\n" +
                $"{Signatures.dwbSendPackets}\n";
        }

        public static void ScanSignatures(MemoryReader reader, ProcessPointers pointers)
        {
            DumpMemory(reader, pointers);

            IntPtr address = IntPtr.Zero;

            Signatures.clientstate_delta_ticks = GetAddress(reader, FindPatternEngine("C7 87 ? ? ? ? ? ? ? ? FF 15 ? ? ? ? 83 C4 08"), 0, 2, (int)pointers.pEngine, false);
            Signatures.dwClientState = GetAddress(reader, FindPatternEngine("A1 ? ? ? ? 33 D2 6A 00 6A 00 33 C9 89 B0"), 0, 1, (int)pointers.pEngine, true);
            Signatures.dwClientState_GetLocalPlayer = GetAddress(reader, FindPatternEngine("8B 80 ? ? ? ? 40 C3"), 0, 2, (int)pointers.pEngine, false);
            Signatures.dwClientState_IsHLTV = GetAddress(reader, FindPatternEngine("80 BF ? ? ? ? ? 0F 84 ? ? ? ? 32 DB"), 0, 2, (int)pointers.pEngine, false);
            Signatures.dwClientState_Map = GetAddress(reader, FindPatternEngine("05 ? ? ? ? C3 CC CC CC CC CC CC CC A1"), 0, 1, (int)pointers.pEngine, false);
            Signatures.dwClientState_MapDirectory = GetAddress(reader, FindPatternEngine("05 ? ? ? ? C3 CC CC CC CC CC CC CC 80 3D"), 0, 1, (int)pointers.pEngine, false);
            Signatures.dwClientState_MaxPlayer = GetAddress(reader, FindPatternEngine("A1 ? ? ? ? 8B 80 ? ? ? ? C3 CC CC CC CC 55 8B EC 8A 45 08"), 0, 7, (int)pointers.pEngine, false);
            Signatures.dwClientState_PlayerInfo = GetAddress(reader, FindPatternEngine("8B 89 ? ? ? ? 85 C9 0F 84 ? ? ? ? 8B 01"), 0, 1, (int)pointers.pEngine, false);
            Signatures.dwClientState_State = GetAddress(reader, FindPatternEngine("83 B8 ? ? ? ? ? 0F 94 C0 C3"), 0, 2, (int)pointers.pEngine, false);
            Signatures.dwClientState_ViewAngles = GetAddress(reader, FindPatternEngine("F3 0F 11 80 ? ? ? ? D9 46 04 D9 05"), 0, 4, (int)pointers.pEngine, false);
            Signatures.dwEntityList = GetAddress(reader, FindPatternClient("BB ? ? ? ? 83 FF 01 0F 8C ? ? ? ? 3B F8"), 0, 1, (int)pointers.pClient, true);
            Signatures.dwForceAttack = GetAddress(reader, FindPatternClient("89 0D ? ? ? ? 8B 0D ? ? ? ? 8B F2 8B C1 83 CE 04"), 0, 2, (int)pointers.pClient, true);
            Signatures.dwForceAttack2 = GetAddress(reader, FindPatternClient("89 0D ? ? ? ? 8B 0D ? ? ? ? 8B F2 8B C1 83 CE 04"), 12, 2, (int)pointers.pClient, true);
            Signatures.dwForceJump = GetAddress(reader, FindPatternClient("8B 0D ? ? ? ? 8B D6 8B C1 83 CA 02"), 0, 2, (int)pointers.pClient, true);
            Signatures.dwGlowObjectManager = GetAddress(reader, FindPatternClient("A1 ? ? ? ? A8 01 75 4B"), 4, 1, (int)pointers.pClient, true);
            //Signatures.dwLocalPlayer = GetAddress(reader, FindPatternClient("A3 ? ? ? ? C7 05 ? ? ? ? ? ? ? ? E8 ? ? ? ? 59 C3 6A ?"), 16, 1, (int)pointers.pClient, true);
            Signatures.dwMouseEnable = GetAddress(reader, FindPatternClient("B9 ? ? ? ? FF 50 34 85 C0 75 10"), 48, 1, (int)pointers.pClient, true);
            Signatures.dwMouseEnablePtr = GetAddress(reader, FindPatternClient("B9 ? ? ? ? FF 50 34 85 C0 75 10"), 0, 1, (int)pointers.pClient, true);
            Signatures.dwPlayerResource = GetAddress(reader, FindPatternClient("8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7"), 0, 2, (int)pointers.pClient, true);
            Signatures.dwRadarBase = GetAddress(reader, FindPatternClient("A1 ? ? ? ? 8B 0C B0 8B 01 FF 50 ? 46 3B 35 ? ? ? ? 7C EA 8B 0D"), 0, 1, (int)pointers.pClient, true);
            Signatures.dwbSendPackets = GetAddress(reader, FindPatternEngine("B3 01 8B 01 8B 40 10 FF D0 84 C0 74 0F 80 BF ? ? ? ? ? 0F 84"), 0, 1, (int)pointers.pEngine, true);

            Array.Clear(dumpedRegionClient, 0, dumpedRegionClient.Length);
            Array.Clear(dumpedRegionEngine, 0, dumpedRegionEngine.Length);
        }

        private static Int32 GetAddress(MemoryReader reader, IntPtr pattern, int extra, int offset, int pModule, bool isRelative)
        {
            IntPtr address = pattern + pModule + offset;
            int read = reader.ReadInt32(address);
            if (!isRelative)
                return read + extra;
            int final = read - pModule + extra;
            return final;
        }

        private static void DumpMemory(MemoryReader reader, ProcessPointers pointers)
        {
            dumpedRegionClient = reader.ReadRaw(pointers.pClient, pointers.sClient);
            dumpedRegionEngine = reader.ReadRaw(pointers.pEngine, pointers.sEngine);
        }

        private static bool MaskCheckClient(int nOffset, byte[] btPattern, string strMask, bool wNonZero = false)
        {
            for (int x = 0; x < btPattern.Length; x++)
            {
                if (strMask[x] == '?')
                    if (wNonZero && dumpedRegionClient[nOffset + x] == 0x00)
                        return false;
                    else
                        continue;

                if ((strMask[x] == 'x') && (btPattern[x] != dumpedRegionClient[nOffset + x]))
                    return false;
            }

            return true;
        }
        private static bool MaskCheckEngine(int nOffset, byte[] btPattern, string strMask, bool wNonZero = false)
        {
            for (int x = 0; x < btPattern.Length; x++)
            {
                if (strMask[x] == '?')
                    if (wNonZero && dumpedRegionEngine[nOffset + x] == 0x00)
                        return false;
                    else
                        continue;

                if ((strMask[x] == 'x') && (btPattern[x] != dumpedRegionEngine[nOffset + x]))
                    return false;
            }

            return true;
        }

        private static void ParsePattern(string pattern, out byte[] btPattern, out string strMask)
        {
            string[] split = pattern.Split(" "[0]);
            byte[] btOut = new byte[split.Length];
            string strOut = string.Empty;

            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == "?")
                {
                    btOut[i] = 0x00;
                    strOut += "?";
                }
                else
                {
                    btOut[i] = Convert.ToByte(split[i], 16);
                    strOut += "x";
                }
            }
            btPattern = btOut;
            strMask = strOut;
        }

        public static IntPtr FindPatternClient(string pattern)
        {
            try
            {
                if (dumpedRegionClient == null || dumpedRegionClient.Length == 0)
                    return IntPtr.Zero;

                byte[] btPattern;
                string strMask;

                ParsePattern(pattern, out btPattern, out strMask);

                for (int x = 0; x < dumpedRegionClient.Length; x++)
                {
                    if (MaskCheckClient(x, btPattern, strMask, false))
                    {
                        return new IntPtr(x);
                    }
                }

                return IntPtr.Zero;
            }
            catch
            {
                return IntPtr.Zero;
            }
        }
        public static IntPtr FindPatternEngine(string pattern)
        {
            try
            {
                if (dumpedRegionEngine == null || dumpedRegionEngine.Length == 0)
                    return IntPtr.Zero;

                byte[] btPattern;
                string strMask;

                ParsePattern(pattern, out btPattern, out strMask);

                for (int x = 0; x < dumpedRegionEngine.Length; x++)
                {
                    if (MaskCheckEngine(x, btPattern, strMask, false))
                    {
                        return new IntPtr(x);
                    }
                }

                return IntPtr.Zero;
            }
            catch
            {
                return IntPtr.Zero;
            }
        }
    }
}
