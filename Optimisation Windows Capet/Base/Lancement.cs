using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.IO;

namespace Optimisation_Windows_Capet
{
    public partial class Lancement : SplashScreen
    {
        public Lancement()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");

            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void EcranDeChargement_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(Application.StartupPath.ToString() + @"\languages-resources.ini"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    if (line == "FR")
                    {
                        labelControl2.Text = "Lancement en cours...";
                        labelControl2.Left = (this.ClientSize.Width - labelControl2.Size.Width) / 2;
                    }
                    else if (line == "EN")
                    {
                        labelControl2.Text = "Launch in progress...";
                        labelControl2.Left = (this.ClientSize.Width - labelControl2.Size.Width) / 2;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    labelControl2.Text = "Launch in progress...";
                    labelControl2.Left = (this.ClientSize.Width - labelControl2.Size.Width) / 2;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Erreur lors de l'obtention du fichier langue de l'application !\n\nError getting the application language file" + ex);
                }
            }
        }
    }
}