using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net.Sockets;
using System.Net;
using System.Net.WebSockets;

namespace Optimisation_Windows_Capet.Base.UserControl
{
    public partial class BETAFORM : DevExpress.XtraEditors.XtraForm
    {
        UdpClient server = new UdpClient();
        WebClient client = new WebClient();
        string URL = "APIURL Private";
        public BETAFORM()
        {
            InitializeComponent();
        }

        private void BETAFORM_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");

            if (Properties.Settings.Default.CheckBeta == "Unchecked")
            {
                checkEdit1.Checked = false;
            }
            else
            {
                checkEdit1.Checked = true;
                textEdit1.Text = Properties.Settings.Default.PassBeta;
                textEdit2.Text = Properties.Settings.Default.UserBeta;
                simpleButton1.PerformClick();
            }
            textEdit3.Text = getUniqueID("C");
        }

        private string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();

            //Mix them up and remove some useless 0's
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            progressPanel2.Visible = true;
                  if (checkEdit1.Checked == true)
                  {
                      Properties.Settings.Default.CheckBeta = checkEdit1.CheckState.ToString();
                      Properties.Settings.Default.PassBeta = textEdit1.Text;
                      Properties.Settings.Default.UserBeta = textEdit2.Text;
                      Properties.Settings.Default.Save();
                  }
                  else
                  {
                      Properties.Settings.Default.CheckBeta = "Unchecked";
                      Properties.Settings.Default.Save();

                  }
                  await Task.Delay(500);
                  try
                  {
                      string thisguid = getUniqueID("C");
                      server.Connect("localhost", 80);
                      string loginusername = textEdit1.Text;
                      string loginpassword = textEdit2.Text;
                      if (client.DownloadString(URL + "api.php?type=login&username=" + textEdit1.Text + "&password=" + textEdit2.Text + "&hwid=" + thisguid).Contains("0x05"))
                      {
                          progressPanel2.Visible = false;

                          XtraMessageBox.Show("Connecté bon test !", "Succès!");
                          if (Properties.Settings.Default.LaunchAccueil == "PasOuvert")
                          {
                              Accueil AC = new Accueil();
                              this.Hide();
                              AC.Show();
                          }
                          else
                          {
                              Form1 F1 = new Form1();
                              this.Hide();
                              F1.Show();
                          }
                          //Open form, or do whatever people do here.

                      }
                      else if (client.DownloadString(URL + "api.php?type=login&username=" + textEdit1.Text + "&password=" + textEdit2.Text + "&hwid=" + thisguid).Contains("0x01"))
                      {
                          progressPanel2.Visible = false;


                          XtraMessageBox.Show("HWID ne correspond pas :(", "Erreur");
                      }
                      else if (client.DownloadString(URL + "api.php?type=login&username=" + textEdit1.Text + "&password=" + textEdit2.Text + "&hwid=" + thisguid).Contains("0x02"))
                      {
                          progressPanel2.Visible = false;

                          XtraMessageBox.Show("Veuillez remplir toutes les cases.", "Erreur");
                      }
                      else if (client.DownloadString(URL + "api.php?type=login&username=" + textEdit1.Text + "&password=" + textEdit2.Text + "&hwid=" + thisguid).Contains("0x03"))
                      {
                          progressPanel2.Visible = false;

                          XtraMessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur");
                      }
                      else if (client.DownloadString(URL + "api.php?type=login&username=" + textEdit1.Text + "&password=" + textEdit2.Text + "&hwid=" + thisguid).Contains("0x04"))
                      {
                          progressPanel2.Visible = false;

                          XtraMessageBox.Show("Vous êtes banni.", "Erreur");
                      }
                  }
                  catch (WebSocketException)
                  {
                      progressPanel2.Visible = false;
                      XtraMessageBox.Show("Serveur pas disponible", "Erreur Serveur", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                  }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                textEdit2.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                textEdit2.Properties.UseSystemPasswordChar = true;

            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit3.Checked == true)
            {
                textEdit3.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                textEdit3.Properties.UseSystemPasswordChar = true;
            }
        }

        private async void BETAFORM_KeyPress(object sender, KeyPressEventArgs e)
        {
            simpleButton1.PerformClick();
        }
    }
}
