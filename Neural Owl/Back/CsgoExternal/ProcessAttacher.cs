using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal
{
    #region Structures
    public class ProcessPointers
    {
        public int idProcess;

        public IntPtr pProcess;
        public IntPtr pOpenProcess;
        public IntPtr pClient;
        public IntPtr pEngine;
        public IntPtr pWindow;

        public int sClient;
        public int sEngine;
    }
    #endregion

    public static class ProcessAttacher
    {

        #region Const
        public const string Const_GameProcessName = "csgo";
        public const string Const_ClientDllName = "client_panorama.dll";
        public const string Const_EngineDllName = "engine.dll";
        #endregion

        public static ProcessPointers Pointers;

        public static MemoryReader AttachToGame()
        {
            Process gameProcess = GetGameProcess();
            if (gameProcess == null)
            {
                System.Threading.Thread.Sleep(1000); //Optimize while(true) loop
                return null;
            }
            SetProcessPointers(gameProcess, out Pointers);
            var memoryReader = new MemoryReader(Pointers);
            return memoryReader;
        }

        private static void SetProcessPointers(Process gameProc, out ProcessPointers processPointers)
        {
            processPointers = new ProcessPointers();

            foreach (ProcessModule module in gameProc.Modules)
            {
                switch (module.ModuleName)
                {
                    case Const_ClientDllName:
                        processPointers.pClient = module.BaseAddress;
                        processPointers.sClient = module.ModuleMemorySize;
                        break;

                    case Const_EngineDllName:
                        processPointers.pEngine = module.BaseAddress;
                        processPointers.sEngine = module.ModuleMemorySize;
                        break;
                }
            }

            processPointers.pWindow = gameProc.MainWindowHandle;
            processPointers.pProcess = gameProc.Handle;
            processPointers.idProcess = gameProc.Id;

            //Check for wrong pointers
            if (processPointers.pClient == IntPtr.Zero ||
                processPointers.pEngine == IntPtr.Zero ||
                processPointers.pProcess == IntPtr.Zero ||
                processPointers.pWindow == IntPtr.Zero)
                throw new NoGameModulesFoundOwlException();
        }
        private static Process GetGameProcess()
        {
            var pcs = Process.GetProcessesByName(Const_GameProcessName);
            if (pcs.Length < 1)
                return null;
            return pcs[0];
        }

    }
}
