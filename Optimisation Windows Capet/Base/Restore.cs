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
using System.Diagnostics;
using System.Management;

namespace Optimisation_Windows_Capet.Base
{
    public partial class Restore : DevExpress.XtraEditors.XtraForm
    {
        public Restore()
        {
            InitializeComponent();
        }

        private void Restore_Load(object sender, EventArgs e)
        {
            ManagementScope ManScope = new ManagementScope(@"\\localhost\root\default");
            ManagementPath ManPath = new ManagementPath("SystemRestore");
            ObjectGetOptions ManOptions = new ObjectGetOptions();
            ManagementClass ManClass = new ManagementClass(ManScope, ManPath, ManOptions);

            foreach (ManagementObject mo in ManClass.GetInstances())
            {
                string time = mo["CreationTime"].ToString();
                time = time.Remove(14);
                string year = "";
                string day = "";
                string month = "";
                string Heure = "";
                string minutes = "";
                string seconde = "";

                year = time.Remove(4);
                month = time.Remove(6);
                month = month.Substring(4);
                day = time.Remove(8);
                day = day.Substring(6);
                Heure = time.Remove(10);
                Heure = Heure.Substring(8);
                int heuretot = Convert.ToInt32(Heure);
                heuretot = heuretot + 2;
                minutes = time.Remove(12);
                minutes = minutes.Substring(10);
                seconde = time;
                seconde = time.Substring(12);

                time = day + "/" + month + "/" + year + " " + heuretot + ":" + minutes + ":" + seconde;
                //DateTime myDate = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm:ss,fff",
                //                                     System.Globalization.CultureInfo.InvariantCulture);
                //string realtime = myDate.ToString("yyyy-MM-dd HH:mm:ss,fff", CultureInfo.CurrentCulture);
                //20180821180316
                //vssadmin list shadows > C:\test.txt
                dataGridView1.Rows.Add(time, mo["Description"].ToString(), mo["SequenceNumber"]);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Process.Start("rstrui.exe");
        }

        private async void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Êtes vous sur de vouloir supprimée tous les points de restauration ?\n\nVous ne pourrais plus les récupérer après cette action !", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                var process = new Process
                {
                    StartInfo =
                    {
                        FileName = "powershell.exe",
                        Arguments = "vssadmin delete shadows /For=C: /all /quiet"
                    }
                };
                process.Start();
                await Task.Delay(1500);
                dataGridView1.Rows.Clear();
                ManagementScope ManScope = new ManagementScope(@"\\localhost\root\default");
                ManagementPath ManPath = new ManagementPath("SystemRestore");
                ObjectGetOptions ManOptions = new ObjectGetOptions();
                ManagementClass ManClass = new ManagementClass(ManScope, ManPath, ManOptions);

                foreach (ManagementObject mo in ManClass.GetInstances())
                {
                    string time = mo["CreationTime"].ToString();
                    time = time.Remove(14);
                    string year = "";
                    string day = "";
                    string month = "";
                    string Heure = "";
                    string minutes = "";
                    string seconde = "";

                    year = time.Remove(4);
                    month = time.Remove(6);
                    month = month.Substring(4);
                    day = time.Remove(8);
                    day = day.Substring(6);
                    Heure = time.Remove(10);
                    Heure = Heure.Substring(8);
                    int heuretot = Convert.ToInt32(Heure);
                    heuretot = heuretot + 2;
                    minutes = time.Remove(12);
                    minutes = minutes.Substring(10);
                    seconde = time;
                    seconde = time.Substring(12);

                    time = day + "/" + month + "/" + year + " " + heuretot + ":" + minutes + ":" + seconde;
                    //DateTime myDate = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm:ss,fff",
                    //                                     System.Globalization.CultureInfo.InvariantCulture);
                    //string realtime = myDate.ToString("yyyy-MM-dd HH:mm:ss,fff", CultureInfo.CurrentCulture);
                    //20180821180316
                    //vssadmin list shadows > C:\test.txt
                    dataGridView1.Rows.Add(time, mo["Description"].ToString(), mo["SequenceNumber"]);
                }
            }
            else
            {

            }

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ManagementScope ManScope = new ManagementScope(@"\\localhost\root\default");
            ManagementPath ManPath = new ManagementPath("SystemRestore");
            ObjectGetOptions ManOptions = new ObjectGetOptions();
            ManagementClass ManClass = new ManagementClass(ManScope, ManPath, ManOptions);

            foreach (ManagementObject mo in ManClass.GetInstances())
            {
                string time = mo["CreationTime"].ToString();
                time = time.Remove(14);
                string year = "";
                string day = "";
                string month = "";
                string Heure = "";
                string minutes = "";
                string seconde = "";

                year = time.Remove(4);
                month = time.Remove(6);
                month = month.Substring(4);
                day = time.Remove(8);
                day = day.Substring(6);
                Heure = time.Remove(10);
                Heure = Heure.Substring(8);
                int heuretot = Convert.ToInt32(Heure);
                heuretot = heuretot + 2;
                minutes = time.Remove(12);
                minutes = minutes.Substring(10);
                seconde = time;
                seconde = time.Substring(12);

                time = day + "/" + month + "/" + year + " " + heuretot + ":" + minutes + ":" + seconde;
                //DateTime myDate = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm:ss,fff",
                //                                     System.Globalization.CultureInfo.InvariantCulture);
                //string realtime = myDate.ToString("yyyy-MM-dd HH:mm:ss,fff", CultureInfo.CurrentCulture);
                //20180821180316
                //vssadmin list shadows > C:\test.txt
                dataGridView1.Rows.Add(time, mo["Description"].ToString(), mo["SequenceNumber"]);
            }
        }
    }
}