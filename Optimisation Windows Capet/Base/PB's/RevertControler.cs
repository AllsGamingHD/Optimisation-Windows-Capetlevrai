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
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace Optimisation_Windows_Capet.Base.PB_s
{
    public partial class RevertControler : DevExpress.XtraEditors.XtraUserControl
    {
        public RevertControler()
        {
            InitializeComponent();
        }

        #region Ouvrir le gestionnaire de tache sur startup & Check si il est ouvert
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            TaskMgrCheck.Start();
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "Taskmgr.exe",
                    Arguments = "/7 /startup"
                }
            };
            if (Properties.Settings.Default.Lang == "FR")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Je vous pris de bien vouloir vérifiée ce que vous avez désactivée si vous avez des problèmes !", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("I kindly ask you to check what you have disabled if you have problems !", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            process.Start();
        }

        private void TaskMgrCheck_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Taskmgr");
            if (pname.Length == 0)
            {

                labelControl3.Text = "Vérifier les programmes que vous avez désactiver au démarrages ( Manuel ) ( Stopped )";
                labelControl3.ForeColor = Color.Red;
                TaskMgrCheck.Stop();
            }
            else
            {
                labelControl3.Text = "Vérifier les programmes que vous avez désactiver au démarrages ( Manuel ) ( Launched )";
                labelControl3.ForeColor = Color.Green;
            }
        }
        #endregion

        #region les services MSCONFIG & Check si il est ouvert
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("COCHEZ BIEN “MASQUEZ TOUS LES SERVICES MICROSOFT” SINON VOUS RISQUEZ DE FAIRE DES BÊTISES ! ", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Check 'HIDE ALL MICROSOFT SERVICES' OTHERWISE YOU CAN DO BADIES ! ", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            MsConfigCheck.Start();
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(Environment.SystemDirectory, "msconfig.exe"),
                    Arguments = "/3"
                }
            };
            process.Start();
        }

        private void MsConfigCheck_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("msconfig");
            if (pname.Length == 0)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    labelControl4.Text = "Vérifier ce que vous avez désactivé dans les Services au démarrage (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    labelControl4.Text = "Check what you have disabled in Startup Services (Manuel)";
                }
                labelControl4.ForeColor = Color.Red;
                MsConfigCheck.Stop();
            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    labelControl4.Text = "Vérifier ce que vous avez désactivé dans les Services au démarrage (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    labelControl4.Text = "Check what you have disabled in Startup Services (Manuel)";
                }
                labelControl4.ForeColor = Color.Green;
            }
        }
        #endregion

        #region Passez les performances en normal
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powercfg.exe",
                    Arguments = "/setactive 381b4222-f694-41f0-9685-ff5bb260df2e"
                }
            };
            process.Start();
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl8.Text = "Passer en performances normal (Alimentations) - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl8.Text = "Set the profile normal (Power supplies) - OK";
            }
            labelControl8.ForeColor = Color.Green;
        }
        #endregion

        #region remettre le disque de s'arreter a 20min
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powercfg.exe",
                    Arguments = "/SETACVALUEINDEX SCHEME_CURRENT 0012ee47-9041-4b5d-9b77-535fba8b1442 6738e2c4-e8a5-4a42-b16a-e040e769756e 1200"
                }
            };
            process.Start();
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl5.Text = "Remettre l'arrêt du disque dur au bout de 20 minutes - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl5.Text = "Put the hard drive back in 20 minutes - OK";
            }
            labelControl5.ForeColor = Color.Green;
        }
        #endregion

        #region activée la suspension séléctive USB
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powercfg.exe",
                    Arguments = "/SETACVALUEINDEX SCHEME_CURRENT 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 1"
                }
            };
            process.Start();
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl6.Text = "Ré-activer la suspension séléctive USB - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl6.Text = "Re-enable USB Selective Suspension - OK";
            }
            labelControl6.ForeColor = Color.Green;
        }
        #endregion

        #region Optimiser le démarrage avec MSCONFIG & Check si il est ouvert
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "bcdedit /timeout 30"
                }
            };
            process.Start();
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("bcdedit /set {current} quietboot No");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            if (Properties.Settings.Default.Lang == "FR")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Le logiciel vient de désactivé “Ne pas démarrer la GUI” & à mis le délai à 30 secondes comme par défaut !", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The software has just disabled 'Do not start the GUI' & set the delay to 30 seconds as default!", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl10.Text = "Remettre les paramètres par défaut pour l'Optimiser de démarrage de Windows";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl10.Text = "Reset the default settings for Windows Startup Optimizer";
            }
            labelControl10.ForeColor = Color.Green;
            /*MsConfigCheck2.Start();
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(Environment.SystemDirectory, "msconfig.exe"),
                    Arguments = "/2 /services"
                }
            };
            process.Start();*/

        }
        private void MsConfigCheck2_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("msconfig");
            if (pname.Length == 0)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    labelControl10.Text = "Remettre les paramètres par défaut pour l'Optimiser de démarrage de Windows";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    labelControl10.Text = "Reset the default settings for Windows Startup Optimizer";
                }
                labelControl10.ForeColor = Color.Red;
                MsConfigCheck2.Stop();
            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    labelControl10.Text = "Remettre les paramètres par défaut pour l'Optimiser de démarrage de Windows";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    labelControl10.Text = "Reset the default settings for Windows Startup Optimizer";
                }
                labelControl10.ForeColor = Color.Green;
            }
        }
        #endregion

        #region Creation et ouverture de DWT & Check si il est ouvert
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\DisableWinTracking\");
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe", Properties.Resources.DisableWinTracking);
            Process.Start(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe");
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl11.Text = "DisableWinTracking.exe faire Revert";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl11.Text = "DisableWinTracking.exe to do Revert";
            }
            labelControl11.ForeColor = Color.Green;
            DisableWinTrackCheck.Start();
        }

        private void DisableWinTrackCheck_Tick(object sender, EventArgs e)
        {
            string exedir = Application.StartupPath.ToString() + @"\DisableWinTracking\";

            Process[] pname = Process.GetProcessesByName("DisableWinTracking");
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
                Directory.Delete(Application.StartupPath.ToString() + @"\DisableWinTracking\");
                if (Properties.Settings.Default.Lang == "FR")
                {
                    labelControl11.Text = "DisableWinTracking.exe faire Revert";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    labelControl11.Text = "DisableWinTracking.exe to do Revert";
                } 
                labelControl11.ForeColor = Color.Red;
                DisableWinTrackCheck.Stop();
            }
        }

        #endregion

        #region Désactiver veille prolongée et activer F8
        private void simpleButton13_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "bcdedit /set bootmenupolicy standard"
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
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl12.Text = "Ré-activer l’option de mise en veille prolongée  + désactiver F8 au démarrage - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl12.Text = "Re-enable the hibernate option + disable F8 at startup - OK";
            }
            labelControl12.ForeColor = Color.Green;
        }
        #endregion

        private void simpleButton14_Click(object sender, EventArgs e)
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
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl13.Text = "Ré-activer windows defender - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl13.Text = "Reactivate windows defender - OK";
            }
            labelControl13.ForeColor = Color.Green;
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 0);
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl15.Text = "Ré-activer cortana - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl15.Text = "Reactivate cortana - OK";
            }
            labelControl15.ForeColor = Color.Green;
        }





        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", 1);

            //Disable Service
            RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config", true);
            key3.SetValue("DODownloadMode", 1);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\dmwappushservice", true);
            key.SetValue("Start", 1);
            Process sc = Process.Start("sc.exe", "config dmwappushservice start= enabled");
            RegistryKey key1 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\DiagTrack", true);
            key1.SetValue("Start", 1);
            Process sc1 = Process.Start("sc.exe", "config DiagTrack start= enabled");

            StreamWriter file = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts"));
            file.Write(@"# Copyright (c) 1993-2009 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host

# localhost name resolution is handled within DNS itself.
#	127.0.0.1       localhost
#	::1             localhost");
            file.Close();

        }

        private async void RevertControler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && (e.Control))
            {
                this.Enabled = false;
                await Task.Delay(5);
                labelControl3.Visible = false;
                await Task.Delay(5);
                labelControl4.Visible = false;
                await Task.Delay(5);
                labelControl5.Visible = false;
                await Task.Delay(5);
                labelControl6.Visible = false;
                await Task.Delay(5);
                labelControl8.Visible = false;
                await Task.Delay(5);
                labelControl10.Visible = false;
                await Task.Delay(5);
                labelControl11.Visible = false;
                await Task.Delay(5);
                labelControl12.Visible = false;
                await Task.Delay(5);
                labelControl13.Visible = false;
                await Task.Delay(5);
                labelControl15.Visible = false;
                await Task.Delay(5);
                simpleButton3.Visible = false;
                await Task.Delay(5);
                simpleButton4.Visible = false;
                await Task.Delay(5);
                simpleButton5.Visible = false;
                await Task.Delay(5);
                simpleButton6.Visible = false;
                await Task.Delay(5);
                simpleButton7.Visible = false;
                await Task.Delay(5);
                simpleButton9.Visible = false;
                await Task.Delay(5);
                simpleButton11.Visible = false;
                await Task.Delay(5);
                simpleButton12.Visible = false;
                await Task.Delay(5);
                simpleButton13.Visible = false;
                await Task.Delay(5);
                simpleButton14.Visible = false;
                await Task.Delay(5);
                simpleButton15.Visible = false;
                SendKeys.Send("^R");
                this.Enabled = true;
                labelControl3.Visible = true;
                labelControl4.Visible = true;
                labelControl5.Visible = true;
                labelControl6.Visible = true;
                labelControl8.Visible = true;
                labelControl10.Visible = true;
                labelControl11.Visible = true;
                labelControl12.Visible = true;
                labelControl13.Visible = true;
                labelControl15.Visible = true;
                simpleButton3.Visible = true;
                simpleButton4.Visible = true;
                simpleButton5.Visible = true;
                simpleButton6.Visible = true;
                simpleButton7.Visible = true;
                simpleButton9.Visible = true;
                simpleButton11.Visible = true;
                simpleButton12.Visible = true;
                simpleButton13.Visible = true;
                simpleButton14.Visible = true;
                simpleButton15.Visible = true;
            }
        }

        private void RevertControler_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = "Pour masquer le menu refaite 'CTRL + R'";
                labelControl3.Text = "Vérifier les programmes que vous avez désactiver au démarrages (Manuel)";
                labelControl4.Text = "Vérifier ce que vous avez désactivée dans les Services au démarrage (Manuel)";
                labelControl8.Text = "Passer en mode normal (Alimentations)";
                labelControl5.Text = "Remettre l'arrêt du disque dur au bout de 20 minutes";
                labelControl6.Text = "Ré-activer la suspension séléctive USB";
                labelControl10.Text = "Remettre les paramètres par défaut pour l'Optimiser de démarrage de Windows";
                labelControl11.Text = "DisableWinTracking.exe faire Revert";
                labelControl12.Text = "Ré-activer l’option de mise en veille prolongée  + désactiver F8 au démarrage";
                labelControl13.Text = "Ré-activer windows defender";
                labelControl15.Text = "Ré-activer cortana";
                simpleButton3.Text = "Exécuter";
                simpleButton4.Text = "Exécuter";
                simpleButton5.Text = "Exécuter";
                simpleButton6.Text = "Exécuter";
                simpleButton7.Text = "Exécuter";
                simpleButton9.Text = "Exécuter (Création Maison)";
                simpleButton11.Text = "Exécuter";
                simpleButton12.Text = "Exécuter";
                simpleButton13.Text = "Exécuter";
                simpleButton14.Text = "Exécuter";
                simpleButton15.Text = "Exécuter";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = "To hide the menu made CTRL + R";
                labelControl3.Text = "Check the programs you have disabled at startup (Manual)";
                labelControl4.Text = "Check what you have disabled in Startup Services (Manual) ";
                labelControl8.Text = "Switch to normal mode (Power Supplies) ";
                labelControl5.Text = "Put the hard drive back in 20 minutes";
                labelControl6.Text = "Re-enable USB Selective Suspension";
                labelControl10.Text = "Reset the default settings for Windows Startup Optimizer";
                labelControl11.Text = "DisableWinTracking.exe Do Revert";
                labelControl12.Text = "Re-enable the hibernate option + disable F8 at startup";
                labelControl13.Text = "Reactivate windows defender";
                labelControl15.Text = "Reactivate cortana";
                simpleButton3.Text = "Launch";
                simpleButton4.Text = "Launch";
                simpleButton5.Text = "Launch";
                simpleButton6.Text = "Launch";
                simpleButton7.Text = "Launch";
                simpleButton9.Text = "Launch (House Creation)";
                simpleButton11.Text = "Launch";
                simpleButton12.Text = "Launch";
                simpleButton13.Text = "Launch";
                simpleButton14.Text = "Launch";
                simpleButton15.Text = "Launch";
            }
        }

        private void RevertControler_VisibleChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = "Pour masquer le menu refaite 'CTRL + R'";
                labelControl3.Text = "Vérifier les programmes que vous avez désactiver au démarrages (Manuel)";
                labelControl4.Text = "Vérifier ce que vous avez désactivée dans les Services au démarrage (Manuel)";
                labelControl8.Text = "Passer en mode normal (Alimentations)";
                labelControl5.Text = "Remettre l'arrêt du disque dur au bout de 20 minutes";
                labelControl6.Text = "Ré-activer la suspension séléctive USB";
                labelControl10.Text = "Remettre les paramètres par défaut pour l'Optimiser de démarrage de Windows";
                labelControl11.Text = "DisableWinTracking.exe faire Revert";
                labelControl12.Text = "Ré-activer l’option de mise en veille prolongée  + désactiver F8 au démarrage";
                labelControl13.Text = "Ré-activer windows defender";
                labelControl15.Text = "Ré-activer cortana";
                simpleButton3.Text = "Exécuter";
                simpleButton4.Text = "Exécuter";
                simpleButton5.Text = "Exécuter";
                simpleButton6.Text = "Exécuter";
                simpleButton7.Text = "Exécuter";
                simpleButton9.Text = "Exécuter (Création Maison)";
                simpleButton11.Text = "Exécuter";
                simpleButton12.Text = "Exécuter";
                simpleButton13.Text = "Exécuter";
                simpleButton14.Text = "Exécuter";
                simpleButton15.Text = "Exécuter";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = "To hide the menu made CTRL + R";
                labelControl3.Text = "Check the programs you have disabled at startup (Manual)";
                labelControl4.Text = "Check what you have disabled in Startup Services (Manual) ";
                labelControl8.Text = "Switch to normal mode (Power Supplies) ";
                labelControl5.Text = "Put the hard drive back in 20 minutes";
                labelControl6.Text = "Re-enable USB Selective Suspension";
                labelControl10.Text = "Reset the default settings for Windows Startup Optimizer";
                labelControl11.Text = "DisableWinTracking.exe Do Revert";
                labelControl12.Text = "Re-enable the hibernate option + disable F8 at startup";
                labelControl13.Text = "Reactivate windows defender";
                labelControl15.Text = "Reactivate cortana";
                simpleButton3.Text = "Launch";
                simpleButton4.Text = "Launch";
                simpleButton5.Text = "Launch";
                simpleButton6.Text = "Launch";
                simpleButton7.Text = "Launch";
                simpleButton9.Text = "Launch (House Creation)";
                simpleButton11.Text = "Launch";
                simpleButton12.Text = "Launch";
                simpleButton13.Text = "Launch";
                simpleButton14.Text = "Launch";
                simpleButton15.Text = "Launch";
            }
        }
        /*            Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "Erreur");
                    Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ndu", "Erreur");
                    Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TimeBrokerSvc", "Erreur");
                    Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "Erreur");

         * 
         * 
         * 
         * 
         * 
         * 
         */
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", 10);
            simpleButton1.ForeColor = Color.Green;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ndu", "Start", Properties.Settings.Default.REGNDU);
            simpleButton2.ForeColor = Color.Green;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TimeBrokerSvc", "Start", Properties.Settings.Default.REGTimeBroker);
            simpleButton8.ForeColor = Color.Green;
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "EnablePrefetcher", Properties.Settings.Default.REGPrefetech);
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(@"sc config sysmain start=auto");
            cmd.StandardInput.Flush();
            cmd.StandardInput.WriteLine(@"net.exe start superfetch");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            simpleButton10.ForeColor = Color.Green;
        }
    }
}
