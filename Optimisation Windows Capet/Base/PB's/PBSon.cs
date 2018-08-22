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
    public partial class PBSon : DevExpress.XtraEditors.XtraUserControl
    {
        public PBSon()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "Taskmgr.exe",
                    Arguments = "/7 /startup"
                }
            };
            process.Start();
            TaskMgrCheck.Start();
            simpleButton1.ForeColor = Color.Green;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("COCHEZ BIEN “MASQUEZ TOUS LES SERVICES MICROSOFT” SINON VOUS RISQUEZ DE FAIRE DES BÊTISES ! ", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Check 'HIDE ALL MICROSOFT SERVICES' OTHERWISE YOU CAN DO BADIES ! ", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(Environment.SystemDirectory, "msconfig.exe"),
                    Arguments = "/3"
                }
            };
            process.Start();
            MsConfigCheck.Start();
            simpleButton2.ForeColor = Color.Green;
        }

        private void TaskMgrCheck_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Taskmgr");
            if (pname.Length == 0)
            {

                simpleButton1.ForeColor = Color.Red;
                TaskMgrCheck.Stop();
            }
            else
            {
                simpleButton1.ForeColor = Color.Green;
            }
        }

        private void MsConfigCheck_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("msconfig");
            if (pname.Length == 0)
            {

                simpleButton2.ForeColor = Color.Red;
                MsConfigCheck.Stop();
            }
            else
            {
                simpleButton2.ForeColor = Color.Green;
            }
        }

        private void PBSon_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = @"J’ai eu un cas d’un abonné qui a désactivé la gestion audio realtek dans les programmes du démarrage sur son PC. 

Je vous conseil de garder ce programme activé au démarrage pour éviter les problèmes. 

Il se peut également que si vous avez de la surcouche logiciel MSI / ASUS / Gigabyte / EVGA ou autre avec votre carte mère qui se lance au démarrage, il soit mieux des les garder car j’ai peur que ça crée des soucis (je détester ces surcouches logiciels, ça crée plus de problèmes que ça en règle…)";
                labelControl2.Text = "Je vous invite donc à vérifier ce que vous avez désactiver et laisser activer !";
                simpleButton1.Text = "Gestionnaire de tâches";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = @"I had a case of a subscriber who disabled realtek audio management in startup programs on his PC.

I advise you to keep this program activated at startup to avoid problems.

It is also possible that if you have overlay software MSI / ASUS / Gigabyte / EVGA or other with your motherboard that starts at startup, it is better to keep them because I'm afraid it creates problems (I hate these software overlays, it creates more problems than that in rule ...)";
                labelControl2.Text = "I invite you to check what you have disabled and let it activate!";

                simpleButton1.Text = "Task Manager";
            }
        }
    }
}
