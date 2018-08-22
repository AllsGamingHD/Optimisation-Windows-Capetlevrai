using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.IO;

namespace Optimisation_Windows_Capet.Base
{
    public partial class PBSteam : DevExpress.XtraEditors.XtraUserControl
    {
        public PBSteam()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\SteamInstall\");
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\SteamInstall\SteamSetup.exe", Properties.Resources.SteamSetup);
            Process.Start(Application.StartupPath.ToString() + @"\SteamInstall\SteamSetup.exe");
            simpleButton1.Text = "Steam.exe";
            simpleButton1.ForeColor = Color.Green;
            DisableWinTrackCheck.Start();
        }

        private void DisableWinTrackCheck_Tick(object sender, EventArgs e)
        {
            string exedir = Application.StartupPath.ToString() + @"\SteamInstall\";

            Process[] pname = Process.GetProcessesByName("SteamSetup");
            if (pname.Length == 0)
            {
                //Répertoire de l'exécutable
                foreach (string filePath in Directory.GetFiles(exedir))
                {
                    if (filePath != exedir)
                    {
                        File.Delete(filePath);
                    }
                }
                Directory.Delete(Application.StartupPath.ToString() + @"\SteamInstall");
                simpleButton1.Text = "Steam.exe";
                simpleButton1.ForeColor = Color.Red;
                DisableWinTrackCheck.Stop();
            }
        }

        private void PBSteam_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = "Un abonné a perdu les droits en écritures sur tout son répertoire steam, sans vous mentir on sait pas comment ça se fait mais je soupçonne que ce soit lié à l’installation d’un antivirus qui est parti en sucette. Le mieux, même si c’est chiant, c’est de désinstaller et réinstaller Steam. Pensez avant ça à garder vos configs de jeux dans un autre répertoire pour les remettre si vous ne voulez pas les perdre.";
                simpleButton1.Text = "Installez steam";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = "A subscriber has lost the rights in writing on all his steam directory, without lying to you we do not know how it is done but I suspect that it is related to the installation of an antivirus that went in lollipop. Best of all, even if it's annoying, is to uninstall and reinstall Steam. Think before that to keep your games configs in another directory to put them back if you do not want to lose them.";
                simpleButton1.Text = "Install steam";
            }
        }
    }
}
