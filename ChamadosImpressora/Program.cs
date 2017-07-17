using System;
using System.Windows.Forms;

namespace ChamadosImpressora
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formSplashScreen());
            Application.Run(new formPrincipal());
        }
    }
}
