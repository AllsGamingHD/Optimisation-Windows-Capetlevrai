using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Management;
using System.ServiceProcess;
using Optimisation_Windows_Capet.Base;
using Optimisation_Windows_Capet.PB_s;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Net;
using DevExpress.XtraEditors;
using Optimisation_Windows_Capet.Base.UserControl;

namespace Optimisation_Windows_Capet
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        #region restorepoint
        private void CreateRestorePoint(string description)
        {
            ManagementScope oScope = new ManagementScope("\\\\localhost\\root\\default");
            ManagementPath oPath = new ManagementPath("SystemRestore");
            ObjectGetOptions oGetOp = new ObjectGetOptions();
            ManagementClass oProcess = new ManagementClass(oScope, oPath, oGetOp);

            ManagementBaseObject oInParams =
                 oProcess.GetMethodParameters("CreateRestorePoint");
            oInParams["Description"] = description;
            oInParams["RestorePointType"] = 0; // MODIFY_SETTINGS
            oInParams["EventType"] = 100;

            ManagementBaseObject oOutParams =
                 oProcess.InvokeMethod("CreateRestorePoint", oInParams, null);
        }
            #endregion

        #region Démarrage,Init & close
        private async void Form1_Load(object sender, EventArgs e)
        {


            // Attend 2.5 secondes avant de lancée l'applis
            Thread.Sleep(2500);


            //Choix du thèmes au départ
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");

            // Récupération de la langues qui était définies si un démarrages à déjà était fait
            if (Properties.Settings.Default.Lang == "FR") 
            {
                // Si la langue est FR alors définir la comboBox sur 0 ( 0 étant FR )
                comboBoxEdit1.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                // Si la langue est FR alors définir la comboBox sur 1 ( 1 étant EN )
                comboBoxEdit1.SelectedIndex = 1;
            }

            //Ce mets sur la Tab 0 'Accueil' au lancement
            xtraTabControl1.SelectedTabPageIndex = 0;

            //Execute l'action GetLang() qui récupère la langue choisis au tous premier départ
            GetLang();

            //Attend 1 seconde sans 'Freeze l'application'
            await Task.Delay(250);

            //Change la langue de l'application selon ce que GetLang() à récupérer
            SetLang();

            Properties.Settings.Default.REGSystemRespons = Convert.ToString(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", "Erreur"));
            Properties.Settings.Default.REGNDU = Convert.ToString(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ndu", "Start", "Erreur"));
            Properties.Settings.Default.REGTimeBroker = Convert.ToString(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TimeBrokerSvc", "Start", "Erreur"));
            Properties.Settings.Default.REGPrefetech = Convert.ToString(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "EnablePrefetcher", "Erreur"));
        }
        public Form1()
        {
            InitializeComponent();
        }

        #region Fermeture De L'app
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) 
        {
            //Sauvegarde le paramètres RestorePoint à non pour qu'au prochain démarrage il demande de nouveau
            // Défini la propriétés "RestorePoint" sur non
            Properties.Settings.Default.RestorePoint = "Non";
            // Sauvegarde les propriétés changés
            Properties.Settings.Default.Save();
            // Ouvre un CMD sans fenêtre et supprime le dossier NvidiaDriverChecker
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(@"RMDIR /S /Q " + "\u0022" + Application.StartupPath.ToString() + @"\NvidiaDriverChecker" + "\u0022");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            File.Delete(Application.StartupPath.ToString() + @"\HtmlAgilityPack.dll");
            // Ferme l'application complétement
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) 
        {
            //Sauvegarde le paramètres RestorePoint à non pour qu'au prochain démarrage il demande de nouveau
            // Défini la propriétés "RestorePoint" sur non
            Properties.Settings.Default.RestorePoint = "Non";
            // Sauvegarde les propriétés changés
            Properties.Settings.Default.Save();
            // Ouvre un CMD sans fenêtre et supprime le dossier NvidiaDriverChecker
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(@"RMDIR /S /Q " + "\u0022" + Application.StartupPath.ToString() + @"\NvidiaDriverChecker" + "\u0022");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            File.Delete(Application.StartupPath.ToString() + @"\HtmlAgilityPack.dll");
            // Ferme l'application complétement
            Application.Exit();
        }
        #endregion
        #endregion

        #region Défilement des textes de crédits 
        // Code peut utiles donc je ne vait pas le commenter cette section ^^
        int counter = 0;
        int len = 0;
        string txt;
        public string texte2;
        public string texte1 = "AllsGamingHD :\nIdée du projet de l'application \net \ncodage du projet";

        private void LabelPres_Tick(object sender, EventArgs e)
        {
            lblPresCapet.Visible = true;
            if (lblPresCapet.Text == texte2)
            {
                txt = lblPresAlls.Text;
                len = txt.Length;
                lblPresAlls.Text = "";
                LabelPres.Stop();
                LabelPres1.Start();
                lblPresAlls.Visible = true;
            }
            else
            {
                counter++;

                if (counter > len)
                {
                    counter = 0;
                    lblPresCapet.Text = texte2;
                }

                else
                {

                    lblPresCapet.Text = txt.Substring(0, counter);
                }
            }
        }

        private void LabelPres1_Tick(object sender, EventArgs e)
        {
            if (lblPresAlls.Text == texte1)
            {
                LabelPres1.Stop();
            }
            else
            {
                counter++;

                if (counter > len)
                {
                    counter = 0;
                    lblPresAlls.Text = texte1;
                }

                else
                {

                    lblPresAlls.Text = txt.Substring(0, counter);
                }
            }
        }

        #endregion 

        #region PARTIE 1
        #region Supprimer Les Fichiers Temporaires
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Créer et défini le string folderPath
            string folderPath = @"C:\Users\" + Environment.UserName.ToString() + @"\AppData\Local\Temp";

            // Si possible faire ce code
            try
            {
                // défini la var "dir" en créant un directoryInfo du dossier défini plus haut "folderPath"
                var dir = new DirectoryInfo(folderPath);
                // Défini les attributs pour le dossier et les fichiers
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                // Supprime le dossier
                dir.Delete(true);
                // Si langue FR faire le code ci-dessous
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(folderPath + " les fichiers temporaires ont était supprimées !");
                    lblSuppresionTemporaires.Text = "Suppresion des fichiers temporaires ( Clear )";
                }
                else // Si non faire celui-ci
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(folderPath + " temporary files have been deleted !");
                    lblSuppresionTemporaires.Text = "Deleting temporary files ( Clear )";

                }
                // Le label change de couleur pour le vert
                lblSuppresionTemporaires.ForeColor = Color.Green;
                // Si le dossier existe faire le code ci-dessous
                if (Directory.Exists(folderPath))
                {
                    // Pas besoin de code donc normal qu'il n'y est rien :D
                }
                else
                {
                    // Créer un dossier à l'emplacement défini au départ ( folderPath )
                    Directory.CreateDirectory(folderPath);
                }
            }
                // Si il y à un problèmes faire une exeception
            catch (Exception ex)
            {
                // Si l'exeception est du à un problème à la suppresion du fichier faire ce code ci-dessous
                if (ex is IOException)
                {
                    if (Properties.Settings.Default.Lang == "FR")
                    {
                        lblSuppresionTemporaires.Text = "Suppresion des fichiers temporaires ( Clear but still some files )";
                        lblSuppresionTemporaires.ForeColor = Color.Orange;
                        DevExpress.XtraEditors.XtraMessageBox.Show("Cette erreur peut être normal ! \n\nPourquoi ?\n\nCar les fichiers peuvent être en train d'être utiliser et malgrès le sytèmes que j'utilise quelques fichiers restent encore mais tous ceux qui a pu être supprimez la était ! \n\nEt que même vous manuellement ne pourriez pas les supprimez ! \n\n\n\nVoici la source du problèmes ! : \n\n" + ex.Message + "\n\n" + ex.GetType(), "Informations sur la suppression de fichiers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblSuppresionTemporaires.Text = "Suppresion des fichiers temporaires ( Clear but still some files )";
                        lblSuppresionTemporaires.ForeColor = Color.Orange;
                        DevExpress.XtraEditors.XtraMessageBox.Show("This error can be normal! \n\nWhy? \n\nCar files may be in use and despite the systems I use some files still remain but all who could be deleted was! \n\nAnd even you manually could not delete them! \n\n\n\nHere's the source of the problems! : \n\n" + ex.Message + "\n\n" + ex.GetType(), "Information about deleting files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // Si non faire celui-ci
                {
                    if (Properties.Settings.Default.Lang == "FR")
                    {
                        lblSuppresionTemporaires.Text = "Suppression de fichiers temporaires - OK";
                    }
                    else
                    {
                        lblSuppresionTemporaires.Text = "Deleting temporary files - OK";
                    }

                    // Le label change de couleur pour le vert
                    lblSuppresionTemporaires.ForeColor = Color.Green;
                }
            }
        }
        #endregion

        #region Supprimer les fichiers PREFETCH
        // Exactement le même code que pour les fichiers Temp. sauf que c'est le dossier PREFETCH qui est assignée au string
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Windows\Prefetch";

            try
            {
                var dir = new DirectoryInfo(folderPath);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(true);
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(folderPath + " les fichiers PREFETCH ont été supprimées.");
                    lblSuppresionsDesPrefetch.Text = "Suppression des fichiers PREFETCH ( Clear )";
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(folderPath + " PREFETCH files have been removed.");
                    lblSuppresionsDesPrefetch.Text = "Deleting PREFETCH files ( Clear )";
                }

                lblSuppresionsDesPrefetch.ForeColor = Color.Green;
                if (Directory.Exists(folderPath))
                {

                }
                else
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    if (Properties.Settings.Default.Lang == "FR")
                    {
                        lblSuppresionsDesPrefetch.Text = "Suppresion des fichiers temporaires ( Effacer mais encore quelques fichiers )";
                        lblSuppresionsDesPrefetch.ForeColor = Color.Orange;
                        DevExpress.XtraEditors.XtraMessageBox.Show("Cette erreur peut être normal ! \n\nPourquoi ?\n\nCar les fichiers peuvent être en train d'être utiliser et malgrès le sytèmes que j'utilise quelques fichiers restent encore mais tous ceux qui a pu être supprimez la était ! \n\nEt que même vous manuellement ne pourriez pas les supprimez ! \n\n\n\nVoici la source du problèmes ! : \n\n" + ex.Message + "\n\n" + ex.GetType(), "Informations sur la suppresion de fichiers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblSuppresionsDesPrefetch.Text = "Delete temporary files (Deleted but still some files)";
                        lblSuppresionsDesPrefetch.ForeColor = Color.Orange;
                        DevExpress.XtraEditors.XtraMessageBox.Show("This error can be normal! \n\nWhy? \n\nfiles may be in use and despite the systems I use some files still remain but all who could be deleted was! \n\nAnd even you manually could not delete them! \n\n\n\nHere's the source of the problems! : \n\n" + ex.Message + "\n\n" + ex.GetType(), "Informations sur la suppresion de fichiers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (Properties.Settings.Default.Lang == "FR")
                    {
                        lblSuppresionsDesPrefetch.Text = "Suppression des fichiers PREFETCH - OK";
                        lblSuppresionsDesPrefetch.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblSuppresionsDesPrefetch.Text = "Deleting PREFETCH files - OK";
                        lblSuppresionsDesPrefetch.ForeColor = Color.Green;
                    }

                }
            }
        }
        #endregion

        #region Ouvrir le gestionnaire de tache sur startup & Check si il est ouvert
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Démarre le timer TaskMgrCheck
            TaskMgrCheck.Start();
            //Ouvre le processus avec les arguments pour ouvrir sur la tabpages voulu
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "Taskmgr.exe",
                    Arguments = "/7 /startup"
                }
            };
            process.Start();
        }

        private void TaskMgrCheck_Tick(object sender, EventArgs e)
        {
            // Regarde dans la liste des process pour voir si le gestionnaire de taches et ouvert
            Process[] pname = Process.GetProcessesByName("Taskmgr");
            // Si le processus est fermée faire le code ci-dessous
            if (pname.Length == 0)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    lblTaskMgr1.Text = "Désactiver des programmes au démarrages (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblTaskMgr1.Text = "Disable startup programs (Manual)";
                }
                lblTaskMgr1.ForeColor = Color.Red;
                TaskMgrCheck.Stop();
            }
            else // Si il est ouvert faire celui-ci
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    lblTaskMgr1.Text = "Désactiver des programmes au démarrages (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblTaskMgr1.Text = "Disable startup programs (Manual)";
                }
                lblTaskMgr1.ForeColor = Color.Green;
            }
        }
        #endregion

        #region Désactiver les services MSCONFIG & Check si il est ouvert
        // Je ne vous ré-explique pas nous plus c'est similaires au code qui est au dessus !
        public string msconfwarnmsg = "";
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(msconfwarnmsg, "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    lblServicesAuDemarrages.Text = "Désactiver les Services au démarrage (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblServicesAuDemarrages.Text = "Disable Startup Services (Manual)";
                }
                lblServicesAuDemarrages.ForeColor = Color.Red;
                MsConfigCheck.Stop();
            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    lblServicesAuDemarrages.Text = "Désactiver les Services au démarrage (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblServicesAuDemarrages.Text = "Disable Startup Services (Manual)";
                }
                lblServicesAuDemarrages.ForeColor = Color.Green;
            }
        }
        #endregion

        #region Passez les performances en élevées
        private void simpleButton36_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Attention ! \n\nSa débloque pour le moment juste le profil !\n\nVous devez l'activer manuellement dans le panneau de configuration ( Paramêtres D'alimentation )", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Ouvre le processus avec les arguments pour débloquer le mode Ultimate performance
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powercfg.exe",
                    Arguments = "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61"
                }
            };
            process.Start();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //Ouvre le processus avec les arguments pour set les performances sur élevées
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powercfg.exe",
                    Arguments = "/setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c"
                }
            };
            process.Start();
            // Si la langue est FR faire le code ci-dessous
            if (Properties.Settings.Default.Lang == "FR")
            {
                lblPerfEleve.Text = "Changer le profil d'alimentations - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN") // Si anglais faire celui-ci
            {
                lblPerfEleve.Text = "Change the power profile - OK";
            }

            // Définir la couleur du label sur rouge
            lblPerfEleve.ForeColor = Color.Green;
        }
        #endregion

        #region Empecher le disque de s'arreter
        // Encore une fois c'est le même code que en haut mais avec un arguments différents pour empecher le disque de s'arreter
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powercfg.exe",
                    Arguments = "/SETACVALUEINDEX SCHEME_CURRENT 0012ee47-9041-4b5d-9b77-535fba8b1442 6738e2c4-e8a5-4a42-b16a-e040e769756e 0"
                }
            };
            process.Start();
            if (Properties.Settings.Default.Lang == "FR")
            {
                lblEmpecherLeDisque.Text = "Empêcher le disque dur de s'arrêter au bout de 20 minutes - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                lblEmpecherLeDisque.Text = "Prevent the hard drive from shutting down after 20 minutes - OK";
            }
            lblEmpecherLeDisque.ForeColor = Color.Green;
        }
        #endregion

        #region Désactiver la suspension séléctive USB
        // Encore une fois c'est le même code que en haut mais avec un arguments différents pour désactiver la suspension USB
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powercfg.exe",
                    Arguments = "/SETACVALUEINDEX SCHEME_CURRENT 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 0"
                }
            };
            process.Start();
            if (Properties.Settings.Default.Lang == "FR")
            {
                lblSupensionUSB.Text = "Désactiver la suspension séléctive USB - OK";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                lblSupensionUSB.Text = "Disable USB Selective Suspension - OK";
            }
            lblSupensionUSB.ForeColor = Color.Green;
        }
        #endregion

        #region Creer les fichier Throttle et ouvrir & Check si il est ouvert
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            // Créer le dossier à l'emplacement défini
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\ThrottleStop\");
            // Créer les fichier à partir des ressources du projet à l'emplacement défini
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\ThrottleStop.exe", Properties.Resources.ThrottleStop);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0.dll", Properties.Resources.WinRingDLL);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0.sys", Properties.Resources.WinRingSys);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0x64.dll", Properties.Resources.WinRing0x64DLL);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\ThrottleStop\WinRing0x64.sys", Properties.Resources.WinRing0x64Sys);
            // Après avoir créer tous les fichier ouvertures du processus
            Process.Start(Application.StartupPath.ToString() + @"\ThrottleStop\ThrottleStop.exe");
            //simpleButton8.Text = "ThrottleStop ( Launched )";
            //simpleButton8.ForeColor = Color.Green;
            // Démarrage du timer
            TrottleStopTimer.Start();
        }

        private void TrottleStopTimer_Tick(object sender, EventArgs e)
        {
            // Création du string et défini un emplacement
            string exedir = Application.StartupPath.ToString() + @"\ThrottleStop\";

            // Regarde dans la liste des process pour voir si le gestionnaire de taches et ouvert
            Process[] pname = Process.GetProcessesByName("ThrottleStop");
            // Si le processus est fermée faire le code ci-dessous
            if (pname.Length == 0)
            {
                // Supprimes les fichiers dans le dossier défini avant
                foreach (string filePath in Directory.GetFiles(exedir))
                {
                    if (filePath != exedir)
                    {
                        File.Delete(filePath);
                    }
                }
                // Supprime le dossier une fois que tous les fichiers sont supprimées
                Directory.Delete(Application.StartupPath.ToString() + @"\ThrottleStop\");
                // Défini le text et la couleur du label du boutou
                simpleButton8.Text = "ThrottleStop";
                simpleButton8.ForeColor = Color.Red;
                // Arret du timer
                TrottleStopTimer.Stop();
            }
            else // Si ouvert faire celui-ci
            {                
                // Défini le text et la couleur du label du boutou
                simpleButton8.Text = "ThrottleStop";
                simpleButton8.ForeColor = Color.Green;
            }
        }
        #endregion

        #endregion

        #region PictureBox D'aides Part1&2

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Créer et ouvre une fenêtre
            Infos_Partie1 IP1 = new Infos_Partie1();
            IP1.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Créer et ouvre une fenêtre
            Infos_Partie2 IP2 = new Infos_Partie2();
            IP2.Show();
        }
        #endregion

        #region PARTIE 2
        #region Regler les effets visuels Win & Check si il est ouvert
        public string msgregview = "";
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(msgregview, "Question?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                GIFRegEffetsVisu PPR = new GIFRegEffetsVisu();
                PPR.Show();
                var process = new Process
                {
                    StartInfo =
                    {
                        FileName = "SystemPropertiesPerformance.exe",
                        Arguments = "/7 /startup"
                    }
                };
                process.Start();
            }
            else if (dialogResult == DialogResult.No)
            {
                var process = new Process
                {
                    StartInfo =
                    {
                        FileName = "SystemPropertiesPerformance.exe",
                        Arguments = "/7 /startup"
                    }
                };
                process.Start();
            }
            SysProp.Start();
        }

        private void SysProp_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("SystemPropertiesPerformance");
            if (pname.Length == 0)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    lblReglagesVisu.Text = "Réglages des effets visuels de Windows";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblReglagesVisu.Text = "Visual Effects Settings for Windows";
                }
                lblReglagesVisu.ForeColor = Color.Red;
                SysProp.Stop();
            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    lblReglagesVisu.Text = "Réglages des effets visuels de Windows";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblReglagesVisu.Text = "Visual Effects Settings for Windows";
                }
                lblReglagesVisu.ForeColor = Color.Green;
            }
        }

        #endregion

        #region Optimiser le démarrage avec MSCONFIG & Check si il est ouvert
        public string optidemmsconfmsg = "";
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "bcdedit /timeout 10"
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

            cmd.StandardInput.WriteLine("bcdedit /set {current} quietboot Yes");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            DevExpress.XtraEditors.XtraMessageBox.Show(optidemmsconfmsg, "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblOptiDemarrages.ForeColor = Color.Green;
            if (Properties.Settings.Default.Lang == "FR")
            {
                lblOptiDemarrages.Text = "Optimiser le démarrage de Windows - OK";
            }
            else
            {
                lblOptiDemarrages.Text = "Optimize Windows startup - OK";
            }
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
                    lblOptiDemarrages.Text = "Optimiser le démarrage de Windows (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblOptiDemarrages.Text = "Optimize Windows startup (Manual)";
                }
                lblOptiDemarrages.ForeColor = Color.Red;
                MsConfigCheck2.Stop();
            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    lblOptiDemarrages.Text = "Optimiser le démarrage de Windows (Manuel)";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    lblOptiDemarrages.Text = "Optimize Windows startup (Manual)";
                }
                lblOptiDemarrages.ForeColor = Color.Green;
            }
        }
        #endregion

        #region Creation et ouverture de DWT & Check si il est ouvert
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\DisableWinTracking\");
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe", Properties.Resources.DisableWinTracking);
            Process.Start(Application.StartupPath.ToString() + @"\DisableWinTracking\DisableWinTracking.exe");
            lblDWT.ForeColor = Color.Green;
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
                if(File.Exists(Application.StartupPath.ToString() + @"\dwt.log"))
                {
                    File.Delete(Application.StartupPath.ToString() + @"\dwt.log");
                }
                lblDWT.ForeColor = Color.Red;
                DisableWinTrackCheck.Stop();
            }
        }

        #endregion

        #region Désactiver veille prolongée et activer F8
        private void simpleButton13_Click(object sender, EventArgs e)
        {
            if (checkVeille.Checked == true)
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
                if (Properties.Settings.Default.Lang == "FR")
                {
                    checkVeille.Text = "Désactiver le mode mise en veille prolongé - OK";
                }
                else
                {
                    checkVeille.Text = "Disable extended sleep mode - OK";
                }
                checkVeille.ForeColor = Color.Green;
            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    checkVeille.Text = "Désactiver le mode mise en veille prolongé - Deactivated";
                }
                else
                {
                    checkVeille.Text = "Disable extended sleep mode - Deactivated";
                }
                checkVeille.ForeColor = Color.Red;
            }

            if (checkF8.Checked == true)
            {
                var process = new Process
                {
                    StartInfo =
                    {
                        FileName = "powershell.exe",
                        Arguments = "powercfg -h off"
                    }
                };
                process.Start();
                if (Properties.Settings.Default.Lang == "FR")
                {
                    checkF8.Text = "activé la fonction F8 au démarrage - OK";
                }
                else
                {
                    checkF8.Text = "Enabled the F8 function at startup... - OK";
                }
                checkF8.ForeColor = Color.Green;
            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    checkF8.Text = "Ré-activé la fonction F8 au démarrage - Deactivated";
                }
                else
                {
                    checkF8.Text = "Re-enabled the F8 function at startup... - Deactivated";
                }
                checkF8.ForeColor = Color.Red;
            }

        }
        #endregion

        #region Désactiver Windows Defender
        private void simpleButton14_Click(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "/c net stop WinDefend"
                }
            };
            process.Start();
            //RunCmd("/c net stop WinDefend");
            var process1 = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = "-command \"Set-Service -Name WinDefend -StartupType Disabled\""
                }
            };
            process1.Start();

            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", 1);
            if (Properties.Settings.Default.Lang == "FR")
            {
                lblDisCortana.Text = "Désactiver windows defender - OK";
            }
            else
            {
                lblDisCortana.Text = "Disable windows defender - OK";
            }
            lblDisCortana.ForeColor = Color.Green;
        }
        #endregion

        #region Désactiver Windows Cortana
        private void simpleButton15_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 1);
            if (Properties.Settings.Default.Lang == "FR")
            {
                lblDisCortana.Text = "Désactiver cortana - OK";
            }
            else
            {
                lblDisCortana.Text = "Disable cortana - OK";
            }
            lblDisCortana.ForeColor = Color.Green;
        }
        #endregion
        #endregion

        #region DWT Maison
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            checkDWTMaison1.Visible = true;
            checkDWTMaison1.BringToFront();
            /*DevExpress.XtraEditors.XtraMessageBox.Show("Alors, \nLa tu as une version test du DWT que j'ai codée seul le Wi-Fi Sense n'est pas inclus dedans comparais à l'autre !\nTelemetry, DiagTrak Log, Services, Block IP's, OneDrive Uninstall ne feront plus partie du PC !\nJe rajouterais plus tard avec des case à cocher pour choisir ;)", "infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Telemetry
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", 0);

            //DiagTrack Log Delete
            string folderPath = @"C:\ProgramData\Microsoft\Diagnosis\ETLLogs\AutoLogger";

            try
            {
                var dir = new DirectoryInfo(folderPath);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(true);
                DevExpress.XtraEditors.XtraMessageBox.Show(folderPath + " les fichiers logs ont était supprimées !");
                if (Directory.Exists(folderPath))
                {

                }
                else
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Cette erreur peut être normal ! \n\nPourquoi ?\n\nCar les fichiers peuvent être en train d'être utiliser et malgrès le sytèmes que j'utilise quelques fichiers restent encore mais tous ceux qui a pu être supprimez la était ! \n\nEt que même vous manuellement ne pourriez pas les supprimez ! \n\n\n\nVoici la source du problèmes ! : \n\n" + ex.Message + "\n\n" + ex.GetType(), "Informations sur la suppresion de fichiers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Disable Service
            RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config", true);
            key3.SetValue("DODownloadMode", 0);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\dmwappushservice", true);
            key.SetValue("Start", 4);
            Process sc = Process.Start("sc.exe", "config dmwappushservice start= disabled");
            RegistryKey key1 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\DiagTrack", true);
            key1.SetValue("Start", 4);
            Process sc1 = Process.Start("sc.exe", "config DiagTrack start= disabled");

            //IP Block
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
            if (System.IO.File.ReadAllText(path).Contains(@"0.0.0.0 a.ads1.msn.com
                        0.0.0.0 a.ads2.msads.net
                        0.0.0.0 a.ads2.msn.com
                        0.0.0.0 a.rad.msn.com
                        0.0.0.0 a-0001.a-msedge.net
                        0.0.0.0 a-0002.a-msedge.net
                        0.0.0.0 a-0003.a-msedge.net
                        0.0.0.0 a-0004.a-msedge.net
                        0.0.0.0 a-0005.a-msedge.net
                        0.0.0.0 a-0006.a-msedge.net
                        0.0.0.0 a-0007.a-msedge.net
                        0.0.0.0 a-0008.a-msedge.net
                        0.0.0.0 a-0009.a-msedge.net
                        0.0.0.0 ac3.msn.com
                        0.0.0.0 ad.doubleclick.net
                        0.0.0.0 adnexus.net
                        0.0.0.0 adnxs.com
                        0.0.0.0 ads.msn.com
                        0.0.0.0 ads1.msads.net
                        0.0.0.0 ads1.msn.com
                        0.0.0.0 aidps.atdmt.com
                        0.0.0.0 aka-cdn-ns.adtech.de
                        0.0.0.0 a-msedge.net
                        0.0.0.0 az361816.vo.msecnd.net
                        0.0.0.0 az512334.vo.msecnd.net
                        0.0.0.0 b.ads1.msn.com
                        0.0.0.0 b.ads2.msads.net
                        0.0.0.0 b.rad.msn.com
                        0.0.0.0 bs.serving-sys.com
                        0.0.0.0 c.atdmt.com
                        0.0.0.0 c.msn.com
                        0.0.0.0 cdn.atdmt.com
                        0.0.0.0 cds26.ams9.msecn.net
                        0.0.0.0 choice.microsoft.com
                        0.0.0.0 choice.microsoft.com.nsatc.net
                        0.0.0.0 compatexchange.cloudapp.net
                        0.0.0.0 corp.sts.microsoft.com
                        0.0.0.0 corpext.msitadfs.glbdns2.microsoft.com
                        0.0.0.0 cs1.wpc.v0cdn.net
                        0.0.0.0 db3aqu.atdmt.com
                        0.0.0.0 df.telemetry.microsoft.com
                        0.0.0.0 diagnostics.support.microsoft.com
                        0.0.0.0 ec.atdmt.com
                        0.0.0.0 feedback.microsoft-hohm.com
                        0.0.0.0 feedback.search.microsoft.com
                        0.0.0.0 feedback.windows.com
                        0.0.0.0 flex.msn.com
                        0.0.0.0 g.msn.com
                        0.0.0.0 h1.msn.com
                        0.0.0.0 i1.services.social.microsoft.com
                        0.0.0.0 i1.services.social.microsoft.com.nsatc.net
                        0.0.0.0 lb1.www.ms.akadns.net
                        0.0.0.0 live.rads.msn.com
                        0.0.0.0 m.adnxs.com
                        0.0.0.0 msedge.net
                        0.0.0.0 msftncsi.com
                        0.0.0.0 msnbot-65-55-108-23.search.msn.com
                        0.0.0.0 msntest.serving-sys.com
                        0.0.0.0 oca.telemetry.microsoft.com
                        0.0.0.0 oca.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 pre.footprintpredict.com
                        0.0.0.0 preview.msn.com
                        0.0.0.0 rad.live.com
                        0.0.0.0 rad.msn.com
                        0.0.0.0 redir.metaservices.microsoft.com
                        0.0.0.0 reports.wes.df.telemetry.microsoft.com
                        0.0.0.0 schemas.microsoft.akadns.net
                        0.0.0.0 secure.adnxs.com
                        0.0.0.0 secure.flashtalking.com
                        0.0.0.0 services.wes.df.telemetry.microsoft.com
                        0.0.0.0 settings-sandbox.data.microsoft.com
                        0.0.0.0 settings-win.data.microsoft.com
                        0.0.0.0 sls.update.microsoft.com.akadns.net
                        0.0.0.0 sqm.df.telemetry.microsoft.com
                        0.0.0.0 sqm.telemetry.microsoft.com
                        0.0.0.0 sqm.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 ssw.live.com
                        0.0.0.0 static.2mdn.net
                        0.0.0.0 statsfe1.ws.microsoft.com
                        0.0.0.0 statsfe2.ws.microsoft.com
                        0.0.0.0 telecommand.telemetry.microsoft.com
                        0.0.0.0 telecommand.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 telemetry.appex.bing.net
                        0.0.0.0 telemetry.microsoft.com
                        0.0.0.0 telemetry.urs.microsoft.com
                        0.0.0.0 v10.vortex-win.data.microsoft.com
                        0.0.0.0 vortex.data.glbdns2.microsoft.com
                        0.0.0.0 vortex.data.microsoft.com
                        0.0.0.0 vortex-bn2.metron.live.com.nsatc.net
                        0.0.0.0 vortex-cy2.metron.live.com.nsatc.net
                        0.0.0.0 vortex-sandbox.data.microsoft.com
                        0.0.0.0 vortex-win.data.metron.live.com.nsatc.net
                        0.0.0.0 vortex-win.data.microsoft.com
                        0.0.0.0 watson.live.com
                        0.0.0.0 web.vortex.data.microsoft.com
                        0.0.0.0 www.msftncsi.com
                        0.0.0.0 apps.skype.com
                        0.0.0.0 fe2.update.microsoft.com.akadns.net
                        0.0.0.0 m.hotmail.com
                        0.0.0.0 pricelist.skype.com
                        0.0.0.0 s.gateway.messenger.live.com
                        0.0.0.0 s0.2mdn.net
                        0.0.0.0 statsfe2.update.microsoft.com.akadns.net
                        0.0.0.0 survey.watson.microsoft.com
                        0.0.0.0 ui.skype.com
                        0.0.0.0 view.atdmt.com
                        0.0.0.0 watson.microsoft.com
                        0.0.0.0 watson.ppe.telemetry.microsoft.com
                        0.0.0.0 watson.telemetry.microsoft.com
                        0.0.0.0 watson.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 wes.df.telemetry.microsoft.com"))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Le fichier HOSTS contient déjà les IP's !");
            }
            else
            {
                using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts")))
                {
                    w.WriteLine(@"0.0.0.0 a.ads1.msn.com
                        0.0.0.0 a.ads2.msads.net
                        0.0.0.0 a.ads2.msn.com
                        0.0.0.0 a.rad.msn.com
                        0.0.0.0 a-0001.a-msedge.net
                        0.0.0.0 a-0002.a-msedge.net
                        0.0.0.0 a-0003.a-msedge.net
                        0.0.0.0 a-0004.a-msedge.net
                        0.0.0.0 a-0005.a-msedge.net
                        0.0.0.0 a-0006.a-msedge.net
                        0.0.0.0 a-0007.a-msedge.net
                        0.0.0.0 a-0008.a-msedge.net
                        0.0.0.0 a-0009.a-msedge.net
                        0.0.0.0 ac3.msn.com
                        0.0.0.0 ad.doubleclick.net
                        0.0.0.0 adnexus.net
                        0.0.0.0 adnxs.com
                        0.0.0.0 ads.msn.com
                        0.0.0.0 ads1.msads.net
                        0.0.0.0 ads1.msn.com
                        0.0.0.0 aidps.atdmt.com
                        0.0.0.0 aka-cdn-ns.adtech.de
                        0.0.0.0 a-msedge.net
                        0.0.0.0 az361816.vo.msecnd.net
                        0.0.0.0 az512334.vo.msecnd.net
                        0.0.0.0 b.ads1.msn.com
                        0.0.0.0 b.ads2.msads.net
                        0.0.0.0 b.rad.msn.com
                        0.0.0.0 bs.serving-sys.com
                        0.0.0.0 c.atdmt.com
                        0.0.0.0 c.msn.com
                        0.0.0.0 cdn.atdmt.com
                        0.0.0.0 cds26.ams9.msecn.net
                        0.0.0.0 choice.microsoft.com
                        0.0.0.0 choice.microsoft.com.nsatc.net
                        0.0.0.0 compatexchange.cloudapp.net
                        0.0.0.0 corp.sts.microsoft.com
                        0.0.0.0 corpext.msitadfs.glbdns2.microsoft.com
                        0.0.0.0 cs1.wpc.v0cdn.net
                        0.0.0.0 db3aqu.atdmt.com
                        0.0.0.0 df.telemetry.microsoft.com
                        0.0.0.0 diagnostics.support.microsoft.com
                        0.0.0.0 ec.atdmt.com
                        0.0.0.0 feedback.microsoft-hohm.com
                        0.0.0.0 feedback.search.microsoft.com
                        0.0.0.0 feedback.windows.com
                        0.0.0.0 flex.msn.com
                        0.0.0.0 g.msn.com
                        0.0.0.0 h1.msn.com
                        0.0.0.0 i1.services.social.microsoft.com
                        0.0.0.0 i1.services.social.microsoft.com.nsatc.net
                        0.0.0.0 lb1.www.ms.akadns.net
                        0.0.0.0 live.rads.msn.com
                        0.0.0.0 m.adnxs.com
                        0.0.0.0 msedge.net
                        0.0.0.0 msftncsi.com
                        0.0.0.0 msnbot-65-55-108-23.search.msn.com
                        0.0.0.0 msntest.serving-sys.com
                        0.0.0.0 oca.telemetry.microsoft.com
                        0.0.0.0 oca.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 pre.footprintpredict.com
                        0.0.0.0 preview.msn.com
                        0.0.0.0 rad.live.com
                        0.0.0.0 rad.msn.com
                        0.0.0.0 redir.metaservices.microsoft.com
                        0.0.0.0 reports.wes.df.telemetry.microsoft.com
                        0.0.0.0 schemas.microsoft.akadns.net
                        0.0.0.0 secure.adnxs.com
                        0.0.0.0 secure.flashtalking.com
                        0.0.0.0 services.wes.df.telemetry.microsoft.com
                        0.0.0.0 settings-sandbox.data.microsoft.com
                        0.0.0.0 settings-win.data.microsoft.com
                        0.0.0.0 sls.update.microsoft.com.akadns.net
                        0.0.0.0 sqm.df.telemetry.microsoft.com
                        0.0.0.0 sqm.telemetry.microsoft.com
                        0.0.0.0 sqm.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 ssw.live.com
                        0.0.0.0 static.2mdn.net
                        0.0.0.0 statsfe1.ws.microsoft.com
                        0.0.0.0 statsfe2.ws.microsoft.com
                        0.0.0.0 telecommand.telemetry.microsoft.com
                        0.0.0.0 telecommand.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 telemetry.appex.bing.net
                        0.0.0.0 telemetry.microsoft.com
                        0.0.0.0 telemetry.urs.microsoft.com
                        0.0.0.0 v10.vortex-win.data.microsoft.com
                        0.0.0.0 vortex.data.glbdns2.microsoft.com
                        0.0.0.0 vortex.data.microsoft.com
                        0.0.0.0 vortex-bn2.metron.live.com.nsatc.net
                        0.0.0.0 vortex-cy2.metron.live.com.nsatc.net
                        0.0.0.0 vortex-sandbox.data.microsoft.com
                        0.0.0.0 vortex-win.data.metron.live.com.nsatc.net
                        0.0.0.0 vortex-win.data.microsoft.com
                        0.0.0.0 watson.live.com
                        0.0.0.0 web.vortex.data.microsoft.com
                        0.0.0.0 www.msftncsi.com
                        0.0.0.0 apps.skype.com
                        0.0.0.0 fe2.update.microsoft.com.akadns.net
                        0.0.0.0 m.hotmail.com
                        0.0.0.0 pricelist.skype.com
                        0.0.0.0 s.gateway.messenger.live.com
                        0.0.0.0 s0.2mdn.net
                        0.0.0.0 statsfe2.update.microsoft.com.akadns.net
                        0.0.0.0 survey.watson.microsoft.com
                        0.0.0.0 ui.skype.com
                        0.0.0.0 view.atdmt.com
                        0.0.0.0 watson.microsoft.com
                        0.0.0.0 watson.ppe.telemetry.microsoft.com
                        0.0.0.0 watson.telemetry.microsoft.com
                        0.0.0.0 watson.telemetry.microsoft.com.nsatc.net
                        0.0.0.0 wes.df.telemetry.microsoft.com");

                    //check x64 et Uninstall Onedrive
                    if (Environment.Is64BitOperatingSystem)
                    {
                        var process = new Process
                        {
                            StartInfo =
                            {
                                FileName = @"C:\Windows\SysWOW64\OneDriveSetup.exe",
                                Arguments = "/uninstall"
                            }
                        };
                        process.Start();
                    }
                    else
                    {
                        var process = new Process
                        {
                            StartInfo =
                            {
                                FileName = @"C:\Windows\System32\OneDriveSetup.exe",
                                Arguments = "/uninstall"
                            }
                        };
                        process.Start();
                    }

                }
            }*/
        }
        #endregion

        #region StartupPB
        public string textemsg = "";
        public string textemsg1 = "";
        public string textemsg2 = "";
        public string textemsg3 = "";
        public string textemsg4 = "";
        public string textemsg5 = "";
        public string textemsg6 = "";
        public string textemsg7 = "";
        public string textemsg8 = "";
        public string textemsg9 = "";
        public string textemsg10 = "";
        private void simpleButton16_Click(object sender, EventArgs e)
        {

            PBEcranNoir EcranNoir = new PBEcranNoir();
            DevExpress.XtraEditors.XtraDialog.Show(EcranNoir, textemsg, MessageBoxButtons.OK);
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            PBs_Ecran_Bleu EcranBleu = new PBs_Ecran_Bleu();
            DevExpress.XtraEditors.XtraDialog.Show(EcranBleu, textemsg1, MessageBoxButtons.OK);
        }
        private void simpleButton18_Click(object sender, EventArgs e)
        {
            PBsChauffe PBC = new PBsChauffe();
            DevExpress.XtraEditors.XtraDialog.Show(PBC, textemsg2, MessageBoxButtons.OK);
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            PBLenteur PBL = new PBLenteur();
            DevExpress.XtraEditors.XtraDialog.Show(PBL, textemsg3, MessageBoxButtons.OK);
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            PBMicroCam PBMC = new PBMicroCam();
            DevExpress.XtraEditors.XtraDialog.Show(PBMC, textemsg4, MessageBoxButtons.OK);
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            PBPerduFichierDoc PBPFD = new PBPerduFichierDoc();
            DevExpress.XtraEditors.XtraDialog.Show(PBPFD, textemsg5, MessageBoxButtons.OK);
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            PBClavierLumLaptop PBCLL = new PBClavierLumLaptop();
            DevExpress.XtraEditors.XtraDialog.Show(PBCLL, textemsg6, MessageBoxButtons.OK);

        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            PBPhoto PBP = new PBPhoto();
            DevExpress.XtraEditors.XtraDialog.Show(PBP, textemsg7, MessageBoxButtons.OK);

        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            PBCrashFortnite PBCF = new PBCrashFortnite();
            DevExpress.XtraEditors.XtraDialog.Show(PBCF, textemsg8, MessageBoxButtons.OK);
        }
        private void simpleButton25_Click(object sender, EventArgs e)
        {
            PBSteam PBS = new PBSteam();
            DevExpress.XtraEditors.XtraDialog.Show(PBS, textemsg9, MessageBoxButtons.OK);
        }
        private void simpleButton26_Click(object sender, EventArgs e)
        {
            PBSon PBS = new PBSon();
            DevExpress.XtraEditors.XtraDialog.Show(PBS, textemsg10, MessageBoxButtons.OK);
        }
        #endregion

        #region Restauration Système & Check si il est fini
        public string restorepointmsg = "";
        public string restorepointmsgtitle = "";
        private async void timer2_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RestorePoint == "Non")
            {
                Restauration.Stop();
                if (Properties.Settings.Default.FirstLunchBetamsg == "PasOuvert")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bienvenue sur l'application ! \n\nTestez la de fond en comble et dîtes moi si vous rencontrer des bugs\n\nSi vous rencontrer un bug merci de m'envoyer un message sur discord \nAccompagner d'une screenshot si possible ou encore une vidéos sur YouTube", restorepointmsgtitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Properties.Settings.Default.FirstLunchBetamsg = "Ouvert";
                    Properties.Settings.Default.Save();
                }

                DialogResult dialogResult = XtraMessageBox.Show("Voulez-vous créer un point de restauration ?\n\nJe vous recommande dans créer même si vous trouvez sa inutile !\n\nEn cas de problèmes ou de bug sur votre PC vous aurez juste à le restaurer", "Créer un point de restauration ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                xtraTabControl1.Enabled = false;
                progressPanel1.Visible = true;
                if (dialogResult == DialogResult.Yes)
                {
                    var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = "powershell.exe",
                            Arguments = richTextBox1.Text
                        }
                    };
                    process.Start();
                    await Task.Delay(1500);
                    CreateRestorePoint("Optimisation Windows - " + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                    txt = lblPresCapet.Text;
                    len = txt.Length;
                    lblPresCapet.Text = "";
                    LabelPres.Start();
                    progressPanel1.Visible = false;
                    xtraTabControl1.Enabled = true;

                }
                else
                {
                    progressPanel1.Visible = false;
                    txt = lblPresCapet.Text;
                    len = txt.Length;
                    lblPresCapet.Text = "";
                    LabelPres.Start();
                    xtraTabControl1.Enabled = true;
                }


            }
            else
            {

            }

        }
        private void CheckRestorePoint_Tick(object sender, EventArgs e)
        {


        }
        #endregion

        #region Récupération CTRL+R et Changement de couleur du titre de la TabPages


        private void ShortcutRecovery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && (e.Control))
            {
                if (xtraTabPage4.PageVisible == true)
                {
                    xtraTabPage4.PageVisible = false;
                }
                else
                {
                    xtraTabPage4.PageVisible = true;
                    Colorlbl.Start();
                    Colorlbl2.Start();
                }
            }
            if (e.KeyCode == Keys.I && (e.Control))
            {
                Informations_PC IPC = new Informations_PC();
                IPC.Show();

            }
        }
        private void xtraTabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && (e.Control))
            {
                if (xtraTabPage4.PageVisible == true)
                {
                    xtraTabPage4.PageVisible = false;
                }
                else
                {
                    xtraTabPage4.PageVisible = true;
                    Colorlbl.Start();
                    Colorlbl2.Start();
                }

            }
            if (e.KeyCode == Keys.I && (e.Control))
            {
                Informations_PC IPC = new Informations_PC();
                IPC.Show();
            }
        }
        public int countertick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            countertick++;

            Random labelcolor = new Random();
            int R = labelcolor.Next(0, 255);
            int G = labelcolor.Next(0, 255);
            int B = labelcolor.Next(0, 255);
            int A = labelcolor.Next(0, 255);
            xtraTabPage4.Appearance.Header.ForeColor = Color.FromArgb(R, G, B, A);
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (countertick == 10)  //or whatever your limit is
            {
                xtraTabPage4.Appearance.Header.ForeColor = Color.Red;
                Colorlbl.Stop();
                Colorlbl2.Stop();
            }
        }
        #endregion

        #region Langue et paramètres
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLang();
        }


        public void SetLang()
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                xtraTabPage1.Text = "P1 : Optimisations Windows";
                xtraTabPage2.Text = "P2 : Optimisations Windows";
                Accueil.Text = "Accueil";
                xtraTabPage4.Text = "Récupération";
                xtraTabPage5.Text = "Réparer les problèmes Windows";
                this.Text = "Optimisation de Windows | CTRL + R pour accéder au menu de récupération";
                lblBienvenue.Text = @"Bienvenue sur le logiciel d'optimisation créer spécialement pour la série de vidéo de Capetlevrai

                Dans celui-ci vous aurez juste à cliquez sur des boutons pour que le logiciel effectue la tâche que vous
                 lui avez demander,
                pour 90% des cas ils sont automatiques et ne requis aucune manipulations de votre part !


                Pourquoi certains manipulations seront manuel ? 
                Car je ne peut choisir ce que vous voulez désactiver ou non et dépend de ce que la personnes à 
                comme logiciels/services sur son PC ";
                lblPresCapet.Text = @"Capetlevrai :
Gérant du projet " + '\u0022' + @"Optimisations de Windows" + '\u0022' + @"
et
participation au codage de l'application
                ";
                lblPresAlls.Text = @"AllsGamingHD : 
Idée du projet de l'application
et
codage du projet";
                texte2 = "Capetlevrai : \nGérant du projet 'Optimisations de Windows' \net \nparticipation au codage de l'application";
                texte1 = "AllsGamingHD :\nIdée du projet de l'application \net \ncodage du projet";
                lblReparerPB.Left = (this.ClientSize.Width - lblReparerPB.Size.Width) / 2;
                lblBienvenue.Left = (this.ClientSize.Width - lblBienvenue.Size.Width) / 2;
                lblSuppresionTemporaires.Text = "Supprimer les fichiers temporaires";
                lblSuppresionsDesPrefetch.Text = "Supprimer les fichiers PREFETCH";
                lblTaskMgr1.Text = "Désactiver des programmes au démarrages (Manuel)";
                lblServicesAuDemarrages.Text = "Désactiver les Services au démarrage (Manuel)";
                lblPerfEleve.Text = "Changez le profil d'alimentations";
                lblEmpecherLeDisque.Text = "Empêcher le disque dur de s'arrêter au bout de 20 minutes";
                lblSupensionUSB.Text = "Désactiver la suspension séléctive USB";
                lblFaireTriIcone.Text = "Faire le tri des icônes sur le bureau (à faire vous même)";
                lblReglagesVisu.Text = "Réglages des effets visuels de Windows";
                lblOptiDemarrages.Text = "Optimiser le démarrage de Windows";
                lblDWT.Text = "Désactiver les espions windows...";
                groupBox1.Text = "Mise en veille prolongée et F8 au démarrage";
                lblVeilleProlon.Text = @"Désactiver l’option de mise en veille prolongée qui prend 
beaucoup de place sur le disque dur / SSD + réactiver F8 
au démarrage pour avoir accès au mode sans échec.";
                checkVeille.Text = "Désactiver le mode mise en veille prolongé";
                checkF8.Text = "Activé la fonction F8 au démarrage";
                lblDisWindowsDef.Text = "Désactiver windows defender";
                lblDisCortana.Text = "Désactiver cortana";
                lblWarnNotifications.Text = @"Système : Notification et actions > désactiver “obtenir les notifications des applications
Confidentialité : Presque tout désactiver, laissez activer MICROPHONE et CAMERA pour éviter des 
soucis, je vois que pas mal de gens ont des soucis sur Teamspeak ou Discord après désactivation. 
Si votre Webcam ou votre micro ne fonctionnent plus après désactivation réactivez les dans : 
Windows -> Confidentialité -> Caméra - Windows -> Confidentialité -> Microphone";
                lblReparerPB.Text = @"A la suite des tutoriels 1 et 2 que j’ai sorti sur ma chaine, certains d‘entres vous ont constatés des 
instabilité sur leur système Windows.
Je vais essayer de maintenir cette doc à jour pour que tout rentre dans l’ordre, 
vos témoignages sont les bienvenus dans les commentaires et sur mon Twitter.";
                simpleButton16.Text = "1- J’ai un écran noir";
                simpleButton17.Text = "2- J’ai un écran bleu / j’ai des bugs";
                simpleButton18.Text = "3- Je pense que mon PC chauffe trop";
                simpleButton19.Text = "4- Mon PC est plus lent qu’avant";
                simpleButton20.Text = "5- Mon micro et/ou ma webcam ne fonctionnent plus";
                simpleButton21.Text = "6- J’ai perdu mes fichiers dans mes documents WTF ?!";
                simpleButton22.Text = "7- Le clavier lumineux de mon PC portable ne fonctionne plus";
                simpleButton23.Text = "8- Application photo qui ne s’ouvre pas ? ";
                simpleButton24.Text = "9- J’ai ds crash sur Fortnite ! ";
                simpleButton25.Text = "10- J’ai des problèmes sur mes jeux Steam";
                simpleButton26.Text = "11- J’ai plus de son que faire ?";
                simpleButton1.Text = "Exécuter";
                simpleButton2.Text = "Exécuter";
                simpleButton3.Text = "Exécuter";
                simpleButton4.Text = "Exécuter";
                simpleButton5.Text = "Mode " + '\u0022' + "Performances Elevées" + '\u0022';
                simpleButton36.Text = "Débloquer " + '\u0022' + "Performance Ultime" + '\u0022';
                simpleButton6.Text = "Exécuter";
                simpleButton7.Text = "Exécuter";
                simpleButton9.Text = "Exécuter (version intégrée)";
                simpleButton10.Text = "Exécuter";
                simpleButton11.Text = "Exécuter";
                simpleButton12.Text = "Exécuter";
                simpleButton13.Text = "Exécuter";
                simpleButton14.Text = "Exécuter";
                simpleButton15.Text = "Exécuter";
                textemsg = "Comment faire si vous avez un écran noir ?";
                textemsg1 = "Comment faire si vous avez un écran bleu ou des bugs ?";
                textemsg2 = "Votre PC chauffe ? regardez vos températures sur HW Monitor !";
                textemsg3 = "Votre PC est lent ? Regardez l'utilisation CPU en premier temps !";
                textemsg4 = "Un problèmes avec votre micro ou caméra suivez ces étapes !";
                textemsg5 = "Vous avez perdu vos fichiers ? la solution devra être celle-ci !";
                textemsg6 = "Le clavier lumineux ne fonctionne pas ?";
                textemsg7 = "Votre appli photo ne s'ouvre pas ? Un clique suffira ! ! ";
                textemsg8 = "Fortnite crash ou ne se lance pas ?";
                textemsg9 = "Des problèmes avec steam ?";
                textemsg10 = "Vous n'avez plus de son ? verifier les services et application que vous avez désactiver !";
                restorepointmsg = "Je vous recommande vivement de créer un point de restauration systèmes !\nCelui-ci servirat au cas où vous auriez des problèmes !\nC'est pour votre sécurité c'est à vous de voir :)\n\nUne fenêtre va s'ouvrir dans celle-ci cliquez sur 'Créer' -> Entrez 'Optimisations Windows' dans la nouvelle fenêtre -> Cliquez sur le bouton 'Créer'\n\nSi jamais vous ne pouvez pas créer le point de restauration verifiée que votre disque qui contient windows soit marquée activée dans 'Protection'";
                restorepointmsgtitle = @"/!\ Avertissement /!\";
                optidemmsconfmsg = "Le logiciel vient d'activé “Ne pas démarrer la GUI” & à mis le délai à 10 secondes";
                msconfwarnmsg = "Cochez bien “MASQUEZ TOUS LES SERVICES MICROSOFT” \nSINON VOUS RISQUEZ DE FAIRE DES BÊTISES ! ";
                msgregview = "Voulez vous voir le réglages conseillers ou vous voulez régler par vous mêmes ?";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                xtraTabPage1.Text = "P1 : Windows optimizations";
                xtraTabPage2.Text = "P2 : Windows optimizations";
                Accueil.Text = "Home";
                xtraTabPage4.Text = "Recovery";
                xtraTabPage5.Text = "Repair Windows problems";
                this.Text = "Optimization of Windows | CTRL + R to access the recovery menu";
                lblBienvenue.Text = @"Welcome to the optimization software specially created for the Capetlevrai video serie's

                In this one you'll just have to click on buttons for the software to perform the task you asked him,
                for 90% of the cases they are automatic and do not require any manipulation of you!


                Why some manipulations will be manual?
                Because I can not choose what you want to disable or not and depends on what people have 
                software / services on your PC";
                lblPresCapet.Text = @"Capetlevrai : 
Manager of the “Windows Optimization“ project
and 
participation in the coding of the application";
                lblPresAlls.Text = @"AllsGamingHD : 
Idea of the project of the application 
and 
coding of the project";
                lblReparerPB.Left = (this.ClientSize.Width - lblReparerPB.Size.Width) / 2;
                lblBienvenue.Left = (this.ClientSize.Width - lblBienvenue.Size.Width) / 2;
                texte2 = "Capetlevrai : \nManager of the “Windows Optimization“ project \nand \nparticipation in the coding of the application";
                texte1 = "AllsGamingHD :\nIdea of the project of the application \nand \ncoding of the project";
                lblSuppresionTemporaires.Text = "Delete temporary files";
                lblSuppresionsDesPrefetch.Text = "Delete PREFETCH files";
                lblTaskMgr1.Text = "Disable startup programs  (Manual)";
                lblServicesAuDemarrages.Text = "Disable Startup Services (Manual)";
                lblPerfEleve.Text = "Change the power profile";
                lblEmpecherLeDisque.Text = "Prevent the hard drive from shutting down after 20 minutes";
                lblSupensionUSB.Text = "Disable USB Selective Suspension";
                lblFaireTriIcone.Text = "Sorting the icons on the desktop (to do it yourself)";
                lblReglagesVisu.Text = "Visual Effects Settings for Windows";
                lblOptiDemarrages.Text = "Optimize Windows startup";
                lblDWT.Text = "Disable windows espion";
                groupBox1.Text = "Hibernate and F8 on startup";
                lblVeilleProlon.Text = @"Disable the hibernate option that takes
a lot of room on the hard drive / SSD + reactivate F8
at startup to gain access to safe mode.";
                checkVeille.Text = "Disable extended sleep mode";
                checkF8.Text = "Activated the F8 function at startup";
                lblDisWindowsDef.Text = "Disable windows defender";
                lblDisCortana.Text = "Disable cortana";
                lblWarnNotifications.Text = @"System: Notification and Actions> Disable  “Get Apps Notifications“
Privacy: Almost everything off, let activate MICROPHONE and CAMERA to avoid
worries, I see that a lot of people have concerns about Teamspeak or Discord after deactivation.
If your webcam or microphone does not work after deactivation reactivate them in:
Windows -> Privacy -> Camera - Windows -> Privacy -> Microphone";
                lblReparerPB.Text = @"Following tutorials 1 and 2 that I released on my channel, some of you have noticed
instability on their Windows system.
I will try to keep this doc up to date so that everything goes in order,
your testimonials are welcome in the comments and on my Twitter.";
                simpleButton16.Text = "1- I have a black screen";
                simpleButton17.Text = "2- I have a blue screen / I have bugs";
                simpleButton18.Text = "3- I think my PC is heating up too much";
                simpleButton19.Text = "4- My PC is slower than before";
                simpleButton20.Text = "5- My microphone and / or my webcam no longer work";
                simpleButton21.Text = "6- I lost my files in my documents WTF?!";
                simpleButton22.Text = "7- The light keyboard of my laptop does not work anymore";
                simpleButton23.Text = "8- Photo application that does not open ? ";
                simpleButton24.Text = "9- I crashed on Fortnite ! ";
                simpleButton25.Text = "10- I have problems with my Steam games";
                simpleButton26.Text = "11- I have no sound than I do? ?";
                simpleButton1.Text = "Launch";
                simpleButton2.Text = "Launch";
                simpleButton3.Text = "Launch";
                simpleButton4.Text = "Launch";
                simpleButton5.Text = "Mode " + '\u0022' + "High Performances" + '\u0022';
                simpleButton36.Text = "Unlock " + '\u0022' + "Ultimate Performance" + '\u0022'; 
                simpleButton6.Text = "Launch";
                simpleButton7.Text = "Launch";
                simpleButton9.Text = "Launch (integrated version)";
                simpleButton10.Text = "Launch";
                simpleButton11.Text = "Launch";
                simpleButton12.Text = "Launch";
                simpleButton13.Text = "Launch";
                simpleButton14.Text = "Launch";
                simpleButton15.Text = "Launch";
                textemsg = "How to do it if you have a black screen ?";
                textemsg1 = "How to do it if you have a blue screen or bugs ?";
                textemsg2 = "Your PC heats up? watch your temperatures on HWMonitor !";
                textemsg3 = "Your PC is slow? Look at CPU usage in the first time !";
                textemsg4 = "A problem with your microphone or camera follow these steps !";
                textemsg5 = "You lost your files? the solution will have to be this one !";
                textemsg6 = "The illuminated keyboard does not work ?";
                textemsg7 = "Your photo app does not open? A clique will suffice! ! ";
                textemsg8 = "Fortnite crash or do not run ?";
                textemsg9 = "Problems with steam ?";
                textemsg10 = "You have no more sound? check which services and app you have turned off !";
                restorepointmsg = "I strongly recommend that you create a system restore point! \nThis will be useful in case you have problems! \nThat is for your security it's up to you to see:) \n \nA window will open in this one click on 'Create' -> Enter 'Windows Optimizations' in the new window -> Click on the button 'Create' \n \nIf you can not create the verified restore point as your disk which contains windows be marked activated in 'Protection'";
                restorepointmsgtitle = @"/!\ Warning /!\";
                optidemmsconfmsg = "The software has just activated 'Do not start the GUI' & set the delay to 10 seconds";
                msconfwarnmsg = "Check 'MASK ALL MICROSOFT SERVICES' \nOTHERWISE YOU CAN DO BADIES!!";
                msgregview = "Do you want to see the advisor settings or do you want to adjust by yourself?";
            }
        }


        public void GetLang()
        {
            if (comboBoxEdit1.SelectedIndex == 0)
            {
                Properties.Settings.Default.Lang = "FR";
                Properties.Settings.Default.Save();
                SetLang();
                string text = "FR";
                System.IO.File.WriteAllText(Application.StartupPath.ToString() + @"\languages-resources.ini", text);
                Properties.Settings.Default.Lang = "FR";
                Properties.Settings.Default.Save();
            }
            else if (comboBoxEdit1.SelectedIndex == 1)
            {
                Properties.Settings.Default.Lang = "EN";
                Properties.Settings.Default.Save();
                SetLang();
                string text = "EN";
                System.IO.File.WriteAllText(Application.StartupPath.ToString() + @"\languages-resources.ini", text);
                Properties.Settings.Default.Lang = "EN";
                Properties.Settings.Default.Save();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Aucune langue n'a été sélectionnée ou données invalide ! Veuillez réessayer\nNo language was selected or data invalid! Try Again", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Centrer les texte nécessaire quand ils à un changement de langues
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            lblReparerPB.Left = (this.ClientSize.Width - lblReparerPB.Size.Width) / 2;
            lblBienvenue.Left = (this.ClientSize.Width - lblBienvenue.Size.Width) / 2;
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            lblReparerPB.Left = (this.ClientSize.Width - lblReparerPB.Size.Width) / 2;
            lblBienvenue.Left = (this.ClientSize.Width - lblBienvenue.Size.Width) / 2;
        }
        #endregion


        #region CheckDriver et installation
        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\");
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\Nvidia Driver Checker.exe", Properties.Resources.TinyNvidiaUpdateChecker);
            File.WriteAllBytes(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\HtmlAgilityPack.dll", Properties.Resources.HtmlAgilityPack);
            var process = new Process
            {
                StartInfo =
                    {
                        FileName = Application.StartupPath.ToString() + @"\NvidiaDriverChecker\Nvidia Driver Checker.exe",
                        Arguments = "--quiet"
                    }
            };
            process.Start();
            WaitForm1 W = new WaitForm1();
            W.Show();
            xtraTabControl1.Enabled = false;
            TinyUpCheck.Start();
            GPUinfos.Start();
        }

        private async void download_Driver1_VisibleChanged(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            if (download_Driver1.Visible == false)
            {

                simpleButton27.Enabled = false;
            }
        }

        private void TinyUpCheck_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\DriversInfos.ini"))
            {
                labelControl1.Visible = true;
                labelControl2.Visible = true;

                try
                {   // Open the text file using a stream reader.
                    using (StreamReader srr = new StreamReader(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\DriversInfos.ini"))
                    {
                        // Read the stream to a string, and write the string to the console.
                        String line = srr.ReadToEnd();
                        if (line == "uptodate")
                        {
                            xtraTabControl1.Enabled = true;
                            TinyUpCheck.Stop();
                            XtraMessageBox.Show("Votre pilotes est à jour !", "Informations GPU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            simpleButton30.Visible = true;
                            simpleButton29.Visible = true;

                        }
                        else
                        {
                            if (line == "notuptodate")
                            {
                                TinyUpCheck.Stop();
                                DialogResult dialogResult = XtraMessageBox.Show("Votre pilotes n'est pas a jour voulez vous le mettre à jour ?", "Informations GPU", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    download_Driver1.Visible = true;
                                    simpleButton27.Enabled = true;
                                    DDUDriverCheckafter.Start();
                                    xtraTabControl1.Enabled = true;

                                }
                                else if (dialogResult == DialogResult.No)
                                {

                                }
                            }
                            else if (line == "nogpu")
                            {
                                TinyUpCheck.Stop();
                                xtraTabControl1.Enabled = true;
                                XtraMessageBox.Show("Nous trouvons pas votre carte graphique ou aucun pilotes n'est installée \nVeuillez le télécharger manuellement !", "Informations GPU", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is FileNotFoundException)
                    {
                        TinyUpCheck.Stop();
                        XtraMessageBox.Show("Données irrécupérables", "Informations GPU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xtraTabControl1.Enabled = true;

                    }
                    else
                    {
                        TinyUpCheck.Stop();
                        XtraMessageBox.Show("Erreur lors de l'obtention du fichier de données" + ex, "Informations GPU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xtraTabControl1.Enabled = true;

                    }
                }
            }
        }

        private void DDUDriverCheckafter_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DownDDULaunch == "1")
            {
                groupBox2.Visible = true;
                DDUDriverCheckafter.Stop();
                simpleButton28.PerformClick();
            }
            else
            {
                groupBox2.Visible = true;
            }
        }

        private void CheckInstall_Tick(object sender, EventArgs e)
        {
            Process[] pname1 = Process.GetProcessesByName("NvidiaLastDrivers");
            if (pname1.Length == 0)
            {
                labelControl4.Visible = true;
                labelControl4.Text = "Status de l'extraction : Fermée";
            }
            else
            {
                labelControl4.Visible = true;
                labelControl4.Text = "Status de l'extraction : Ouvert";
            }
            if (Directory.Exists(@"C:\NVIDIA"))
            {
                labelControl3.Visible = true;
                labelControl3.Text = "Installation en cours...";
            }
            else
            {
                if (Directory.Exists(@"C:\Program Files (x86)\NVIDIA Corporation"))
                {
                    labelControl3.Visible = true;
                    labelControl3.Text = "Installation presque terminée... (Besoin de rédémarrer le PC pour finir l'installation)";
                    if (File.Exists(@"C:\Program Files\NVIDIA Corporation\Control Panel Client\nvcplui.exe"))
                    {
                        labelControl3.Visible = true;
                        labelControl3.Text = "Installation terminée";
                    }
                }
            }
        }
        #endregion

        #region DDU
        private async void simpleButton28_Click(object sender, EventArgs e)
        {
            WaitForm1 W = new WaitForm1();
            W.Show();
            xtraTabControl1.Enabled = false;
            string exedir = @"C:\Temp Display Drivers Uninstaller";
            
            if (Directory.Exists(@"C:\Temp Display Drivers Uninstaller"))
            {
                clearFolder(exedir);
                await Task.Delay(500);
                Directory.CreateDirectory(@"C:\Temp Display Drivers Uninstaller\");

                File.WriteAllBytes(@"C:\Temp Display Drivers Uninstaller\DDU.zip", Properties.Resources.DDU);

                string zipPath = @"C:\Temp Display Drivers Uninstaller\DDU.zip";
                string extractPath = @"C:\Temp Display Drivers Uninstaller\";

                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

                if (Properties.Settings.Default.Lang == "FR") // Récupération de la langues qui était définies si un démarrages à déjà était fait
                {
                    File.WriteAllText(@"C:\Temp Display Drivers Uninstaller\settings\Settings.xml", Properties.Resources.SettingsFR);
                }
                else
                {
                    File.WriteAllText(@"C:\Temp Display Drivers Uninstaller\settings\Settings.xml", Properties.Resources.SettingsEN);
                }
                File.Delete(zipPath);
                await Task.Delay(3000);
            }
            else
            {
                Directory.CreateDirectory(@"C:\Temp Display Drivers Uninstaller\");

                File.WriteAllBytes(@"C:\Temp Display Drivers Uninstaller\DDU.zip", Properties.Resources.DDU);

                string zipPath = @"C:\Temp Display Drivers Uninstaller\DDU.zip";
                string extractPath = @"C:\Temp Display Drivers Uninstaller\";

                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

                if (Properties.Settings.Default.Lang == "FR") // Récupération de la langues qui était définies si un démarrages à déjà était fait
                {
                    File.WriteAllText(@"C:\Temp Display Drivers Uninstaller\settings\Settings.xml", Properties.Resources.SettingsFR);
                }
                else
                {
                    File.WriteAllText(@"C:\Temp Display Drivers Uninstaller\settings\Settings.xml", Properties.Resources.SettingsEN);
                }
                File.Delete(zipPath);
                
                await Task.Delay(3000);
            }
            W.Visible = false;
            xtraTabControl1.Enabled = true;
            dduCommand1.Visible = true;
        }

        private async void timer4_Tick(object sender, EventArgs e)
        {
            string exedir = @"C:\Temp Display Drivers Uninstaller\";

            Process[] pname = Process.GetProcessesByName("Display Driver Uninstaller");
            if (pname.Length == 0)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    simpleButton28.Text = "Display Driver Uninstaller fermée";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    simpleButton28.Text = "Display Driver Uninstaller fermée";
                }
                DDUCheck.Stop();

                simpleButton28.ForeColor = Color.Red;
                await Task.Delay(5000);
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine(@"RMDIR /S /Q " + "\u0022" + @"C:\Temp Display Drivers Uninstaller\" + "\u0022" + @"RMDIR / S / Q " + "\u0022" + @"C:\Program Files(x86)\NVIDIA Corporation" + "\u0022\n" + @"RMDIR / S / Q " + "\u0022" + @"C:\Program Files\NVIDIA Corporation" + "\u0022\n" + @"RMDIR / S / Q " + "\u0022" + @"C: \User\" + Environment.UserName + @"\AppData\Local\NVIDIA" + "\u0022\n" + @"RMDIR / S / Q " + "\u0022" + @"C: \User\" + Environment.UserName + @"\AppData\Local\NVIDIA Corporation" + "\u0022\n");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                DialogResult dialogResult = XtraMessageBox.Show("Voulez-vous procéder à l'installation immédiatement ?\n\nOu si vous voulez la lancée plus tard elle se trouve à cette emplacement : \n" + Application.StartupPath.ToString() + @"\NvidiaLastDrivers.exe" + "\n\n\nSi le pilotes est marquée en presque installée c'est qu'il faut que vous redemarrer votre PC pour que le pilotes finissent sont installation !", "Informations GPU", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = Application.StartupPath.ToString() + @"\NvidiaLastDrivers.exe",
                            Arguments = "/s"
                        }
                    };
                    process.Start();
                    xtraTabControl1.Enabled = true;
                    CheckInstall.Start();
                }
                else if (dialogResult == DialogResult.No)
                {
                    xtraTabControl1.Enabled = true;
                }

            }
            else
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    simpleButton28.Text = "Display Driver Uninstaller ( Désinstallation en cours + Nettoyage des restes )";
                }
                else if (Properties.Settings.Default.Lang == "EN")
                {
                    simpleButton28.Text = "Display Driver Uninstaller ( Désinstallation en cours + Clean files )";
                }

                simpleButton28.ForeColor = Color.Green;
            }
        }

        

        private async void dduCommand1_VisibleChanged(object sender, EventArgs e)
        {
            if (dduCommand1.Visible == false)
            {
                xtraTabControl1.Enabled = false;
                await Task.Delay(2000);
                DDUCheck.Start();
            }
        }



        private void simpleButton30_Click(object sender, EventArgs e)
        {
            download_Driver1.Visible = true;
            simpleButton27.Enabled = true;
            DDUDriverCheckafter.Start();
        }
        #endregion

        #region NVDIA Inspector
        private async void simpleButton29_Click(object sender, EventArgs e)
        {
            if (xtraFolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(xtraFolderBrowserDialog1.SelectedPath.ToString() + @"\INSPECTOR.zip", Properties.Resources.NVIDIAINSPECTOR);

                string zipPath = xtraFolderBrowserDialog1.SelectedPath.ToString() + @"\INSPECTOR.zip";
                string extractPath = xtraFolderBrowserDialog1.SelectedPath.ToString();

                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

                await Task.Delay(500);
                File.Delete(xtraFolderBrowserDialog1.SelectedPath.ToString() + @"\INSPECTOR.zip");
                await Task.Delay(250);
                Process.Start(xtraFolderBrowserDialog1.SelectedPath.ToString() + @"\nvidiaProfileInspector.exe");
                labelControl5.Visible = true;
            }
        }
        #endregion

        private void download_Driver1_Load(object sender, EventArgs e)
        {

        }

        private void GPUinfos_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\DriversInfos.ini"))
            {
                using (StreamReader srr = new StreamReader(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\DriversInfos.ini"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = srr.ReadToEnd();
                    if (line == "nogpu")
                    {
                        GPUinfos.Stop();
                        TinyUpCheck.Stop();
                        XtraMessageBox.Show("Nous trouvons pas votre carte graphique ou aucun pilotes n'est installée \nVeuillez le télécharger manuellement !", "Informations GPU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        simpleButton30.Visible = true;
                        simpleButton29.Visible = true;
                        labelControl2.Text = "Pas de GPU";

                    }
                    else
                    {
                        GPUinfos.Stop();
                        using (StreamReader srr1 = new StreamReader(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\GPUInfos.ini"))
                        {
                            String line2 = srr1.ReadToEnd();
                            labelControl2.Text = line2;
                            labelControl1.Left = (this.ClientSize.Width - labelControl1.Size.Width) / 2;
                            labelControl2.Left = (this.ClientSize.Width - labelControl2.Size.Width) / 2;
                        }
                    }
                }
            }
            else if (File.Exists(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\GPUInfos.ini"))
            {
                GPUinfos.Stop();
                using (StreamReader srr1 = new StreamReader(Application.StartupPath.ToString() + @"\NvidiaDriverChecker\GPUInfos.ini"))
                {
                    String line2 = srr1.ReadToEnd();
                    labelControl2.Text = line2;
                    labelControl1.Left = (this.ClientSize.Width - labelControl1.Size.Width) / 2;
                    labelControl2.Left = (this.ClientSize.Width - labelControl2.Size.Width) / 2;
                }
            }
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", 0);
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl7.Text = @"Augmenter un peu les images par secondes 
( Non conseillée pour les record de vidéos et streamers ) - OK";
            }
            else
            {
                labelControl7.Text = @"Increase a little the images per second 
(Not recommended for video recordings and streamers) - OK";
            }
        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ndu", "Start", 4);
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl6.Text = @"Désactiver NDU - OK";
            }
            else
            {
                labelControl6.Text = @"Disable NDU - OK";
            }
        }

        private void simpleButton33_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TimeBrokerSvc", "Start", 4);
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl9.Text = @"Désactiver RuntinBroker - OK";
            }
            else
            {
                labelControl9.Text = @"Disable RuntinBroker - OK";
            }
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "EnablePrefetcher", 0);
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(@"net.exe stop superfetch");
            cmd.StandardInput.Flush();
            cmd.StandardInput.WriteLine(@"sc config sysmain start=disabled");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl8.Text = @"Désactiver Prefetech && Superfetch - OK";
            }
            else
            {
                labelControl8.Text = @"Disable Prefetech && Superfetch - OK";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Suppresion_des_fichier_temp sdft = new Suppresion_des_fichier_temp();
            XtraDialog.Show(sdft, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Supp_Prefetch Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Supp_Prefetch();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Désac_Prog_Dem Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Désac_Prog_Dem();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Désac_Serv_Dem Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Désac_Serv_Dem();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Dis_USB Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P1.Dis_USB();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P2.EffetVisu Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P2.EffetVisu();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P2.OptiDem Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P2.OptiDem();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P2.DesacProg Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P2.DesacProg();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P2.F8Veille Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P2.F8Veille();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Optimisation_Windows_Capet.Base.UserControl.Infos.P2.DésacWinDef Form = new Optimisation_Windows_Capet.Base.UserControl.Infos.P2.DésacWinDef();
            XtraDialog.Show(Form, "Informations", MessageBoxButtons.OK);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton35_Click(object sender, EventArgs e)
        {
            Report R = new Report();
            R.Show();
        }

        private void Form1_ForeColorChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton37_Click(object sender, EventArgs e)
        {
            Restore R = new Restore();
            R.Show();
        }
    }
}