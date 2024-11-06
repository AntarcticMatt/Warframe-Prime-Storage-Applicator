using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warframe_Prime_Storage_Applicator
{
    static class Program
    {

        public static bool f1Show = true;

        public static Form f1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            f1 = new Form1();

            Application.Run(f1);
        }

        public static void F1Toggle()
        {
            f1.Visible = !f1.Visible;
        }
        


    }
}
