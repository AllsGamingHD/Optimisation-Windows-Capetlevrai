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
using Optimisation_Windows_Capet.PB_s;

namespace Optimisation_Windows_Capet.Base
{
    public partial class PBs_Ecran_Bleu : DevExpress.XtraEditors.XtraUserControl
    {
        public PBs_Ecran_Bleu()
        {
            InitializeComponent();
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\DisableWinTracking\");
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe", Properties.Resources.DisableWinTracking);
            //File.WriteAllBytes(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe", Properties.Resources.COPYING);
            //File.WriteAllBytes(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe", Properties.Resources.COPYING1);
            Process.Start(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe");
            simpleButton3.ForeColor = Color.Green;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "bcdedit /set bootmenupolicy legacy"
                }
            };
            process.Start();
            var process1 = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "powercfg -h on"
                }
            };
            process1.Start();
            simpleButton5.ForeColor = Color.Green;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

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

        private void DisableWinTrackCheck_Tick(object sender, EventArgs e)
        {
            /*Process[] pname = Process.GetProcessesByName("msconfig");
            if (pname.Length == 0)
            {

                simpleButton2.Text = "Désactiver les Services au démarrage ( Manuel ) ( Stopped )";
                simpleButton2.ForeColor = Color.Red;
                MsConfigCheck.Stop();
            }
            else
            {
                simpleButton2.Text = "Désactiver les Services au démarrage ( Manuel ) ( Launched )";
                simpleButton2.ForeColor = Color.Green;
            }*/
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

        private void PBs_Ecran_Bleu_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = @"Généralement les écrans bleus sont liés à une instabilité sur le système Windows, cela peut être un driver manquant ou corrompu, un service ou un programme du démarrage qui a été désactivé ou qui rentre en conflit avec un autre ou simplement une manipulation à la main ou lié à un logiciel qui a mis le bazard dans le système et à fait perdre les pédales à votre PC. On peut aussi avoir des soucis de matériel mais nous ne touchons pas au matériel dans mes tutos donc nous n’en parlerons pas ici. 

Je vous propose de remettre tous les réglages par défaut comme si vous n’aviez jamais réalisé mon tuto. Testez étape par étape pour essayer de cerner d'où vient le problème: 

Réactiver tous les logiciels du démarrage et les services au démarrage dans le gestionnaire des tâches et MSCONFIG en recochant les services et en redémarrant votre ordinateur. Si le PC ne bug plus, vous aviez peut être des logiciels qui sont vitaux au bon fonctionnement de votre machine. Remettez les coeurs par défaut en décochant le nombre de coeurs que vous avez forcé dans msconfig > onglet “démarrer” > Options avancées… > décochez “nombre de processeurs” et redémarrez.


Il se peut que le logiciel pour désinstaller les programmes Windows ait fait des bêtises, pour remettre les réglages par défaut faites comme indiqué dans                          c’est à dire : cliquez sur                        puis faites go. 

Vous pouvez avoir également Windows Defender qui fait des siennes : réactivez le. 

Désactiver F8 et remettre le mode de mise en veille prolongé en suivant la manipulation indiqué dans ma documentation en bas


Utiliser les outils de Windows pour réparer les fichiers endommagés en suivant ce lien

Si cela ne règle pas votre problème suivez à la lettre les explications de ce monsieur,  il vous parle de WhoCrashed et BlueScreenview qui servent à analyser les erreurs liés aux écrans bleu ainsi que les manipulation pour réparer les fichiers corrompus sur le disque (lié à la suppression de certaines dépenses de PREFETCH) en utilisant l’outil de vérification de fichiers systèmes";
                simpleButton1.Text = "Gestionnaire de tâches";
                simpleButton2.Text = "MSCONFIG";
                hyperlinkLabelControl1.Text = "ce tweet";
                hyperlinkLabelControl2.Text = "REVERT";
                simpleButton3.Text = "Ouvrir DWT";
                simpleButton4.Text = "Réactiver Windows DEFENDER";
                simpleButton5.Text = "Désactiver F8 et réactiver Mise en veille prolongée";
                hyperlinkLabelControl3.Text = "en suivant ce lien";
                hyperlinkLabelControl4.Text = "les explications de ce monsieur,";
                hyperlinkLabelControl5.Text = "WhoCrashed";
                hyperlinkLabelControl6.Text = "BlueScreenview";
                hyperlinkLabelControl7.Text = "l'outil de vérification de fichiers systèmes";
                hyperlinkLabelControl8.Text = "Tweet de Windows France en complément";
                simpleButton1.Location = new Point(408, 288);
                simpleButton2.Location = new Point(542, 288);
                hyperlinkLabelControl1.Location = new Point(43, 378);
                hyperlinkLabelControl2.Location = new Point(284, 378);
                simpleButton3.Location = new Point(448, 381);
                simpleButton4.Location = new Point(567, 429);
                simpleButton5.Location = new Point(606, 505);
                hyperlinkLabelControl3.Location = new Point(475, 552);
                hyperlinkLabelControl4.Location = new Point(367, 603);
                hyperlinkLabelControl5.Location = new Point(698, 603);
                hyperlinkLabelControl6.Location = new Point(805, 603);
                hyperlinkLabelControl7.Location = new Point(319, 653);
                hyperlinkLabelControl8.Location = new Point(3, 700);
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = @"Generally the blue screens are related to instability on the Windows system, it can be a missing or corrupted driver, a service or a program of the startup which has been disabled or which conflicts with another one or simply a manipulation with the hand or linked to software that has put the bazard in the system and lost the pedals to your PC. We can also have hardware problems but we do not touch the material in my tutorials so we will not talk about it here.

I propose you to reset all the default settings as if you had never done my tutorial. Test step by step to try to pin down where the problem comes from:

Re-enable all Startup Software and Startup Services in Task Manager and MSCONFIG by recapping the services and restarting your computer. If the PC does not bug anymore, you may have software that is vital to the proper functioning of your machine. Reset the default cores by unchecking the number of cores you forced into msconfig> start tab> Advanced Options ...> uncheck 'number of processors' and reboot.


It may be that the little software to uninstall WIndows programs has done some nonsense, to reset the default settings as indicated in this tweet : click on REVERT then go.

You can also have Windows Defender doing its own: reactivate it.

Re-enable F8 and return to the extended standby mode as instructed in my documentation below

Use Windows tools to repair damaged files by following this link

If this does not solve your problem, follow the explanations of this gentleman, it tells you about WhoCrashed and BlueScreenview which are used to analyze the errors related to blue screens as well as the handling to repair the corrupted files on the disk (linked to the removal of some expenses from PREFETCH) using the system file check tool";
                simpleButton1.Text = "Task manager";
                simpleButton2.Text = "MSCONFIG";
                hyperlinkLabelControl1.Text = "by following this link";
                hyperlinkLabelControl2.Text = "explanations of this gentleman";
                simpleButton3.Text = "Open DWT";
                simpleButton4.Text = "Reactivate Windows DEFENDER";
                simpleButton5.Text = "Disable F8 and enable Hibernation";
                hyperlinkLabelControl3.Text = "this tweet";
                hyperlinkLabelControl4.Text = "REVERT";
                hyperlinkLabelControl5.Text = "WhoCrashed";
                hyperlinkLabelControl6.Text = "BlueScreenview";
                hyperlinkLabelControl7.Text = "the system file check tool";
                hyperlinkLabelControl8.Text = "Tweet Windows in addition (FR)";
                simpleButton1.Location = new Point(403, 262);
                simpleButton2.Location = new Point(547, 262);

                hyperlinkLabelControl3.Location = new Point(926, 303);
                hyperlinkLabelControl4.Location = new Point(59, 328);
                hyperlinkLabelControl1.Location = new Point(296, 478);
                hyperlinkLabelControl2.Location = new Point(316, 528);
                simpleButton3.Location = new Point(204, 332);
                simpleButton4.Location = new Point(456, 376);
                simpleButton5.Location = new Point(677, 426);
                hyperlinkLabelControl5.Location = new Point(656, 527);
                hyperlinkLabelControl6.Location = new Point(775, 527);
                hyperlinkLabelControl7.Location = new Point(155, 578);
                hyperlinkLabelControl8.Location = new Point(3, 700);
            }
        }

        private void hyperlinkLabelControl3_Click(object sender, EventArgs e)
        {
            TweetPBEcranBleu TweetEcranBleu = new TweetPBEcranBleu();
            DevExpress.XtraEditors.XtraDialog.Show(TweetEcranBleu, "Tweet", MessageBoxButtons.OKCancel);
        }

        private void hyperlinkLabelControl4_Click(object sender, EventArgs e)
        {
            RevertImage RI = new RevertImage();
            DevExpress.XtraEditors.XtraDialog.Show(RI, "Revert", MessageBoxButtons.OKCancel);
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            Process.Start("https://support.microsoft.com/fr-fr/help/929833/use-the-system-file-checker-tool-to-repair-missing-or-corrupted-system");
        }

        private void hyperlinkLabelControl2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=ipS4JVyXL9w");
        }

        private void hyperlinkLabelControl5_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.clubic.com/telecharger-fiche317674-whocrashed.html");
        }

        private void hyperlinkLabelControl6_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.nirsoft.net/utils/blue_screen_view.html");
        }

        private void hyperlinkLabelControl7_Click(object sender, EventArgs e)
        {
            Process.Start("https://support.microsoft.com/fr-fr/help/929833/use-the-system-file-checker-tool-to-repair-missing-or-corrupted-system");
        }

        private void hyperlinkLabelControl8_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/WindowsFrance/status/1020362379761266688");
        }
    }
}
