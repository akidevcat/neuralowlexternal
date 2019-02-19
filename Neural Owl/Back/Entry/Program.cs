using System;
using System.Threading;
using System.Windows.Forms;

using NeuralOwl.Configuration;
using NeuralOwl.Front.Forms.Main;
using NeuralOwl.Back.Main;
using NeuralOwl.Front.Forms.NOO;

namespace NeuralOwl.Back.Entry
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Config.ImportFromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory) + Config.Const_DefaultPath);

            CheatMain.InitializeEntryPoint();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new NOOForm());
            Application.Run(new MainForm());
        }
    }
}
