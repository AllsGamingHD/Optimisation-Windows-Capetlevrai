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
using Microsoft.Win32;

namespace Optimisation_Windows_Capet.Base
{
    public partial class PBLenteur : DevExpress.XtraEditors.XtraUserControl
    {
        public PBLenteur()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelControl3.Text = "Utilisation des HHD's " + string.Format("{0}%", performanceCounter2.NextValue()) + " (Valeur de tous les disque dur)";
            labelControl2.Text = "Utilisation du CPU : " + string.Format("{0}%", performanceCounter1.NextValue()) + " CPU (Valeur utilisateur, pas celle général !)";
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\ThrottleStop\");
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\ThrottleStop.exe", Properties.Resources.ThrottleStop);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0.dll", Properties.Resources.WinRingDLL);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0.sys", Properties.Resources.WinRingSys);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0x64.dll", Properties.Resources.WinRing0x64DLL);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0x64.sys", Properties.Resources.WinRing0x64Sys);
            Process.Start(Application.StartupPath.ToString() + @"\ThrottleStop\ThrottleStop.exe");
            simpleButton2.Text = "ThrottleStop";
            simpleButton2.ForeColor = Color.Green;
            TrottleStopTimer.Start();
        }

        private void TrottleStopTimer_Tick(object sender, EventArgs e)
        {
            string exedir = Application.StartupPath.ToString() + @"\ThrottleStop\";

            Process[] pname = Process.GetProcessesByName("ThrottleStop");
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
                Directory.Delete(Application.StartupPath.ToString() + @"\ThrottleStop\");
                simpleButton2.Text = "ThrottleStop";
                simpleButton2.ForeColor = Color.Red;
                TrottleStopTimer.Stop();
            }
            else
            {
                simpleButton2.Text = "ThrottleStop";
                simpleButton2.ForeColor = Color.Green;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "/c net start WinDefend"
                }
            };
            process.Start();
            var process1 = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "-command \"Set-Service -Name WinDefend -StartupType Enabled\""
                }
            };
            process1.Start();
            try
            {
                RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\", true);
                RegKey.DeleteValue("DisableAntiSpyware");
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Null");
                }
            }
            simpleButton4.ForeColor = Color.Green;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
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

        private void MsConfigCheck_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("msconfig");
            if (pname.Length == 0)
            {

                simpleButton3.ForeColor = Color.Red;
                MsConfigCheck.Stop();
            }
            else
            {
                simpleButton3.ForeColor = Color.Green;
            }
        }

        private void PBLenteur_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = @"Si vous sentez des lenteurs ou que votre jeu tourne moins bien qu’avant, surveillez dans le gestionnaire des tâches plusieurs choses. Est ce que votre utilisation processeur dépasse les 20 ou 30% même si vous ne faites rien ? Est ce que le disque dur est sollicité à 100% ?
Vous pouvez tenter de terminer les tâches qui posent problème en cliquant dessus et en cliquant sur fin de tâche comme ceci. 


C’est un bon réflexe à prendre quand vous sentez que le PC ne va pas bien, il peut être intéressant de chercher à désinstaller le logiciel ou couper le service qui fait que votre processeur est sollicité à 100%.

2ème chose, dans l’onglet PERFORMANCE cette fois du gestionnaire des tâches il se peut que votre processeur se soit mis en mode sécurité. EN gros il se bride tout seul. 
Un autre abonné à vu son processeur plafonner à 0.8GHz, pour débloquer ça il faut installer le logiciel TrottleStop, puis une fois lancer décocher “BD PROSHOT” c’est pour désactiver le processeur qui se met en mode sécurité. Image AVANT puis APRES ! :) 


Vous pouvez avoir également Windows Defender qui fait des siennes : réactivez le dans les paramètres.


Dans Msconfig le fait de remettre la gestion des coeurs par défaut dans msconfig > onglet “démarrer” > Options avancées… > décochez “nombre de processeurs” peut aussi régler le problème, ça a été le cas de 2 témoignages.";
                simpleButton1.Location = new Point(8, 137);
                labelControl2.Location = new Point(154, 116);
                labelControl3.Location = new Point(154, 145);
                simpleButton2.Location = new Point(215, 364);
                simpleButton4.Location = new Point(134, 460);
                simpleButton3.Location = new Point(134, 559);
                simpleButton1.Text = "Gestionnaire de Tâches";
                simpleButton2.Text = "Ouvrir Throttle Stop";
                simpleButton4.Text = "Réactiver Windows DEFENDER";
                simpleButton3.Text = "MSCONFIG";
                labelControl2.Text = "Utilisation du CPU : 0%";
                labelControl3.Text = "Utilisation des HDD's : 0%";
                timer1FR.Start();
            }
            else
            {
                labelControl1.Text = @"If you feel slow or your game is not working as well, check the task manager for several things. Does your CPU usage exceed 20 or 30% even if you do nothing? Is the hard disk 100% solicited?
You can attempt to complete the problematic tasks by clicking on them and clicking End Task like this.



This is a good reflex to take when you feel that the PC is not going well, it may be interesting to try to uninstall the software or cut the service that makes your processor is solicited at 100%.

2nd thing, in the PERFORMANCE tab this time of the task manager it may be that your processor went into security mode. Basically, he is all alone.
Another subscriber saw his CPU capped at 0.8GHz, to unlock it must install the software TrottleStop, then once launch uncheck 'BD PROSHOT' is to disable the processor that goes into security mode. Image BEFORE then AFTER! :)


You can also have Windows Defender doing its own: re-enable it in the settings.


In Msconfig, putting default heart management back in msconfig> tab 'start'> Advanced options ...> unchecking 'number of processors' can also solve the problem, as was the case with 2 testimonials.";
                simpleButton2.Location = new Point(219, 344);
                simpleButton4.Location = new Point(164, 414);
                simpleButton3.Location = new Point(134, 530);
                simpleButton1.Text = "Task Mgr";
                simpleButton2.Text = "Open Throtthle Stop";
                simpleButton4.Text = "Reactivate Windows DEFENDER";
                simpleButton3.Text = "MSCONFIG";
                labelControl2.Text = "CPU Usage : 0%";
                labelControl3.Text = "HHDs Usage : 0%";
                timer2EN.Start();
            }
        }

        private void timer2EN_Tick(object sender, EventArgs e)
        {
            labelControl3.Text = "HHDs Usage " + string.Format("{0}%", performanceCounter2.NextValue()) + " (Value of all hard drives)";
            labelControl2.Text = "CPU Usage : " + string.Format("{0}%", performanceCounter1.NextValue()) + " (User value, not the general value !)";
        }
    }
}
