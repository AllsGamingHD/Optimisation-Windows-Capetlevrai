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
using System.IO;
using System.Diagnostics;

namespace Optimisation_Windows_Capet.Base
{
    public partial class PBsChauffe : DevExpress.XtraEditors.XtraUserControl
    {
        public PBsChauffe()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\HWMonitor\");
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\HWMonitor\HWMonitor_x64.exe", Properties.Resources.HWMonitor_x64);
            Process.Start(Application.StartupPath.ToString() + @"\HWMonitor\HWMonitor_x64.exe");
            simpleButton1.Text = "HWMonitor";
            simpleButton1.ForeColor = Color.Green;
            HWCheck.Start();
        }

        private void MsConfigCheck_Tick(object sender, EventArgs e)
        {
            string exedir = Application.StartupPath.ToString() + @"\HWMonitor\";

            Process[] pname = Process.GetProcessesByName("HWMonitor_x64");
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
                Directory.Delete(Application.StartupPath.ToString() + @"\HWMonitor\");
                simpleButton1.Text = "HWMonitor";
                simpleButton1.ForeColor = Color.Red;
                HWCheck.Stop();
            }
        }

        private void PBsChauffe_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = "Vérifiez avec l’aide de logiciels comme HWMonitor que vos composants ne chauffent pas trop. Dans ce cas le mieux est de changer les paramètres d’alimentation de votre PC de nouveau et repasser à “utilisation normale” pour les PC portables ou les PC fixes qui sont très mal ventilés ou un peu vieux. !";
                simpleButton1.Text = "Exécuter";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = "Check with the help of software like HWMonitor that your components do not overheat. In this case the best is to change the power settings of your PC again and return to 'normal use' for laptops or PCs that are very poorly ventilated or a little old.";
                simpleButton1.Text = "Launch";
            }
        }
    }
}
