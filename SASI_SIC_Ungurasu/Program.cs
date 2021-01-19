using System;
using System.Windows.Forms;

namespace appUngurasuCriptography
{
    static class Program
    {
        /// <summary>
        /// ENTRY POINT.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new initialForm());
        }
    }
}
