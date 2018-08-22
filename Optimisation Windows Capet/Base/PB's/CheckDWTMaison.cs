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
    public partial class CheckDWTMaison : DevExpress.XtraEditors.XtraUserControl
    {
        public CheckDWTMaison()
        {
            InitializeComponent();
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", 0);
            }
            if (checkEdit2.Checked == true)
            {
                string folderPath = @"C:\ProgramData\Microsoft\Diagnosis\ETLLogs\AutoLogger";

                try
                {
                    var dir = new DirectoryInfo(folderPath);
                    dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                    dir.Delete(true);
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
                    if (Properties.Settings.Default.Lang == "FR")
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Cette erreur peut être normal ! \n\nPourquoi ?\n\nCar les fichiers peuvent être en train d'être utiliser et malgrès le sytèmes que j'utilise quelques fichiers restent encore mais tous ceux qui a pu être supprimez la était ! \n\nEt que même vous manuellement ne pourriez pas les supprimez ! \n\n\n\nVoici la source du problèmes ! : \n\n" + ex.Message + "\n\n" + ex.GetType(), "Informations sur la suppression de fichiers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("This error can be normal! \n\nWhy? \n\nFiles may be in use and despite the systems I use some files still remain but all who could be deleted was! \n\nAnd even you manually could not delete them! \n\n\n\nHere's the source of the problems! : \n\n" + ex.Message + "\n\n" + ex.GetType(), "Information about deleting files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (checkEdit3.Checked == true)
            {
                RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config", true);
                key3.SetValue("DODownloadMode", 0);
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\dmwappushservice", true);
                key.SetValue("Start", 4);
                Process sc = Process.Start("sc.exe", "config dmwappushservice start= disabled");
                RegistryKey key1 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\DiagTrack", true);
                key1.SetValue("Start", 4);
                Process sc1 = Process.Start("sc.exe", "config DiagTrack start= disabled");
            }
            if (checkEdit4.Checked == true)
            {
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
                    DevExpress.XtraEditors.XtraMessageBox.Show("Le fichier HOSTS contient déjà les IP's !", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                }
                if (checkEdit5.Checked == true)
                {
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
            }

            if (checkEdit1.Checked == true & checkEdit2.Checked == false & checkEdit3.Checked == false & checkEdit4.Checked == false & checkEdit5.Checked == false)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Désactivé avec Succès", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Disable Successfully", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Hide();
            }

            if (checkEdit1.Checked == true & checkEdit2.Checked == true & checkEdit3.Checked == false & checkEdit4.Checked == false & checkEdit5.Checked == false)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Désactivé avec Succès\nLogs DiagTrack supprimée avec Succès", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Disable Successfully \nLogs DiagTrack Removed Successfully", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Hide();
            }

            if (checkEdit1.Checked == true & checkEdit2.Checked == true & checkEdit3.Checked == true & checkEdit4.Checked == false & checkEdit5.Checked == false)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Désactivé avec Succès\nLogs DiagTrack supprimée avec Succès\nServices désactivée avec Succès", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Successfully Disable \nLogs Successfully Removed DiagTrack \nServices Successfully Disabled", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Hide();
            }

            if (checkEdit1.Checked == true & checkEdit2.Checked == true & checkEdit3.Checked == true & checkEdit4.Checked == true & checkEdit5.Checked == false)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Désactivé avec Succès\nLogs DiagTrack supprimée avec Succès\nServices désactivée avec Succès\nIP's Bloquée avec Succès", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Successfully Disable \nLogs Successfully Removed DiagTrack \nServices Successfully Disabled\nIP's Blocked Successfully", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Hide();
            }

            if (checkEdit1.Checked == true & checkEdit2.Checked == true & checkEdit3.Checked == true & checkEdit4.Checked == true & checkEdit5.Checked == true)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Désactivé avec Succès\nLogs DiagTrack supprimée avec Succès\nServices désactivée avec Succès\nIP's Bloquée avec Succès\nOneDrive Désinstaller avec Succès", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Telemetry Successfully Disable \nLogs Successfully Removed DiagTrack \nServices Successfully Disabled\nIP's Blocked Successfully\nOneDrive Uninstall Successfully", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Hide();
            }
            if (checkEdit1.Checked == false & checkEdit2.Checked == false & checkEdit3.Checked == false & checkEdit4.Checked == false & checkEdit5.Checked == false)
            {
                if (Properties.Settings.Default.Lang == "FR")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Aucun élément n'a été séléctionnée ! ", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("No items were selected ! ", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CheckDWTMaison_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                checkEdit1.Text = "Bloquer la télémétrie";
                checkEdit2.Text = "Supprimer les logs DiagTrack";
                checkEdit3.Text = "Désactiver les services";
                checkEdit4.Text = "Bloquer les IP's";
                checkEdit5.Text = "Désinstaller OneDrive";
                simpleButton1.Text = "Exécuter";
                simpleButton2.Text = "Fermer";
            }
            else
            {
                checkEdit1.Text = "Block telemetry";
                checkEdit2.Text = "Delete DiagTrack logs";
                checkEdit3.Text = "Disable services";
                checkEdit4.Text = "Block IP's";
                checkEdit5.Text = "Uninstall OneDrive";
                simpleButton1.Text = "Launch";
                simpleButton2.Text = "Close";
            }
        }

        private void CheckDWTMaison_VisibleChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                checkEdit1.Text = "Bloquer la télémétrie";
                checkEdit2.Text = "Supprimer les logs DiagTrack";
                checkEdit3.Text = "Désactiver les services";
                checkEdit4.Text = "Bloquer les IP's";
                checkEdit5.Text = "Désinstaller OneDrive";
                simpleButton1.Text = "Exécuter";
                simpleButton2.Text = "Fermer";
            }
            else
            {
                checkEdit1.Text = "Block telemetry";
                checkEdit2.Text = "Delete DiagTrack logs";
                checkEdit3.Text = "Disable services";
                checkEdit4.Text = "Block IP's";
                checkEdit5.Text = "Uninstall OneDrive";
                simpleButton1.Text = "Launch";
                simpleButton2.Text = "Close";
            }
        }
    }
}