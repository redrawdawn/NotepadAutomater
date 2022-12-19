using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotebookAutomater
{
    internal class Program
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        static void Main(string[] args)
        {
            Process p = Process.GetProcessesByName("notepad").FirstOrDefault();
            if (p == null)
            {
                p = Process.Start("C:\\Windows\\notepad.exe");
                Thread.Sleep(100);
            }            

            IntPtr h = p.MainWindowHandle;
            SetForegroundWindow(h);
            SendKeys.SendWait("^+n");
            Thread.Sleep(100);
            SendKeys.SendWait("Hello World");
            SendKeys.SendWait("^+s");            
            SendKeys.SendWait("C:\\workspace\\helloworld.txt");
            SendKeys.SendWait("%s");
            SendKeys.SendWait("%y");
            SendKeys.SendWait("^w");
            
        }
    }
}
