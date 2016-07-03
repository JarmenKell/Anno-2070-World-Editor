using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Anno_2070_World_Editor
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Editor(args));
        }
    }
}
