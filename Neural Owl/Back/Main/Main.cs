using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralOwl.Back.CsgoExternal;
using NeuralOwl.Back.CsgoExternal.Game;
using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.Main
{

    public static class CheatMain
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public static Random random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));

        public static MemoryReader Reader;
        public static ProcessPointers Pointers;

        public static Client client;
        public static ClientState clientState;
        public static Engine engine;

        public static int ingameTick { get; private set; }

        public static void InitializeEntryPoint() => new Thread(() => Initialize()).Start();

        private static void Initialize()
        {
            Thread.CurrentThread.IsBackground = true;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            while (Reader == null)
                Reader = ProcessAttacher.AttachToGame();
            Pointers = ProcessAttacher.Pointers;
            PointersManager.ScanSignatures(Reader, ProcessAttacher.Pointers);

            client = new Client(Pointers.pClient, Reader);
            engine = new Engine(Pointers.pEngine, Reader);
            clientState = engine.GetClientState();

            do
            {
                Console.WriteLine("Searching for the game...");
                Console.WriteLine("View Angles: " + clientState.ViewAngles);
                Console.WriteLine("Game State: " + clientState.State);
                Thread.Sleep(1000);
                Reader.Update();
            } while (clientState.State != GameStates.Full);

            new CheatModules.ESP();
            new CheatModules.Triggerbot();
            new CheatModules.AimbotBasic();
            new CheatModules.Misc();
            new CheatModules.PlayersList();

            while (true)
            {
                var temp = Reader.ReadInt32Uncached(client.address + Signatures.dwLocalPlayer);
                var currentTick = Reader.ReadInt32Uncached((IntPtr)temp + Netvars.m_nTickBase);

                if (ingameTick != currentTick)
                {
                    Reader.Update();
                    ingameTick = currentTick;
                }

                Thread.Sleep(1);
            }
        }


    }
}
