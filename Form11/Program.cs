using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JonLibrary.Common;
using JonLibrary.Automatic;
using MicroDAQ;
namespace Form11
{
    static class Program
    {
        public static CycleTask RemoteCycle;
        public static MachineManager MeterManager = new MachineManager();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
