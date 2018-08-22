using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Optimisation_Windows_Capet.Base.PB_s;
using Optimisation_Windows_Capet.Base;

namespace Optimisation_Windows_Capet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");
            UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                    
            BonusSkins.Register();
            Application.Run(new Optimisation_Windows_Capet.Base.UserControl.BETAFORM());
           /* if (Properties.Settings.Default.LaunchAccueil == "PasOuvert")
            {
                Application.Run(new Accueil());
            }
            else
            {
                Application.Run(new Form1());
            }*/
        }
    }
}
