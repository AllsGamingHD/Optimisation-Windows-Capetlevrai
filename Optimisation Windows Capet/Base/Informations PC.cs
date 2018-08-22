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
using System.Management;
using System.Threading;
using System.IO;

namespace Optimisation_Windows_Capet.Base
{
    public partial class Informations_PC : DevExpress.XtraEditors.XtraForm
    {
        public Informations_PC()
        {
            InitializeComponent();
        }
        private string DeviceInformation(string stringIn)
        {
            StringBuilder StringBuilder1 = new StringBuilder(string.Empty);
            try
            {
                ManagementClass ManagementClass1 = new ManagementClass(stringIn);
                //Create a ManagementObjectCollection to loop through
                ManagementObjectCollection ManagemenobjCol = ManagementClass1.GetInstances();
                //Get the properties in the class
                PropertyDataCollection properties = ManagementClass1.Properties;
                foreach (ManagementObject obj in ManagemenobjCol)
                {
                    foreach (PropertyData property in properties)
                    {
                        try
                        {
                            StringBuilder1.AppendLine(property.Name + ":  " + obj.Properties[property.Name].Value.ToString());
                        }
                        catch
                        {
                            //Add codes to manage more informations
                        }
                    }
                    StringBuilder1.AppendLine();
                }
            }
            catch
            {
                //Win 32 Classes Which are not defined on client system
            }
            return StringBuilder1.ToString();
        }


        private async void Informations_PC_Load(object sender, EventArgs e)
        {
            string sixquatre = "";
            if (Environment.Is64BitOperatingSystem)
            {
                sixquatre = "64 Bit Operating System";
            }
            else
            { 
                sixquatre = "32 Bit Operating System";
            }

            listView1.Items.Add("Operation System: " + Environment.OSVersion);
            listView1.Items.Add(sixquatre);
            listView1.Items.Add("Nom du PC : " + Environment.UserDomainName);
            listView1.Items.Add("Nom de l'utilisateur : " + Environment.UserName);

            StreamWriter file2 = new StreamWriter(Application.StartupPath.ToString() + @"\Processor.txt");
            file2.Write(DeviceInformation("Win32_Processor"));
            file2.Close();

            StreamWriter file3 = new StreamWriter(Application.StartupPath.ToString() + @"\Disk.txt");
            file3.Write(DeviceInformation("Win32_LogicalDisk"));
            file3.Close();

            StreamWriter file4 = new StreamWriter(Application.StartupPath.ToString() + @"\GPU.txt");
            file4.Write(DeviceInformation("Win32_VideoController"));
            file4.Close();

            await Task.Delay(1000);

            String[] lines2 = System.IO.File.ReadAllLines(Application.StartupPath.ToString() + @"\Processor.txt");
            foreach (String line1 in lines2)
            {
                ListViewItem item1 = new ListViewItem(line1);
                listView2.Items.Add(item1);
            }

            String[] lines3 = System.IO.File.ReadAllLines(Application.StartupPath.ToString() + @"\Disk.txt");
            foreach (String line2 in lines3)
            {
                ListViewItem item2 = new ListViewItem(line2);
                listView3.Items.Add(item2);
            }

            String[] lines4 = System.IO.File.ReadAllLines(Application.StartupPath.ToString() + @"\GPU.txt");
            foreach (String line3 in lines4)
            {
                ListViewItem item3 = new ListViewItem(line3);
                listView4.Items.Add(item3);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            string ind1 = listView1.SelectedIndices[0].ToString();
            int ind2 = Convert.ToInt16(ind1);
            string item = listView1.Items[ind2].Text; //here I got the string of selected item
            Clipboard.SetDataObject(item);
        }


        private void listView2_ItemActivate(object sender, EventArgs e)
        {
            string ind1 = listView2.SelectedIndices[0].ToString();
            int ind2 = Convert.ToInt16(ind1);
            string item = listView2.Items[ind2].Text; //here I got the string of selected item
            Clipboard.SetDataObject(item);
        }

        private void listView3_ItemActivate(object sender, EventArgs e)
        {
            string ind1 = listView3.SelectedIndices[0].ToString();
            int ind2 = Convert.ToInt16(ind1);
            string item = listView3.Items[ind2].Text; //here I got the string of selected item
            Clipboard.SetDataObject(item);
        }

        private void listView4_ItemActivate(object sender, EventArgs e)
        {
            string ind1 = listView4.SelectedIndices[0].ToString();
            int ind2 = Convert.ToInt16(ind1);
            string item = listView4.Items[ind2].Text; //here I got the string of selected item
            Clipboard.SetDataObject(item);
        }

        private void Informations_PC_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(Application.StartupPath.ToString() + @"\Base.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\Base.txt");
            }
            if (File.Exists(Application.StartupPath.ToString() + @"\Disk.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\Disk.txt");
            }
            if (File.Exists(Application.StartupPath.ToString() + @"\GPU.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\GPU.txt");
            }
            if (File.Exists(Application.StartupPath.ToString() + @"\Processor.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\Processor.txt");
            }
        }

        private void Informations_PC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(Application.StartupPath.ToString() + @"\Base.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\Base.txt");
            }
            if (File.Exists(Application.StartupPath.ToString() + @"\Disk.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\Disk.txt");
            }
            if (File.Exists(Application.StartupPath.ToString() + @"\GPU.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\GPU.txt");
            }
            if (File.Exists(Application.StartupPath.ToString() + @"\Processor.txt"))
            {
                File.Delete(Application.StartupPath.ToString() + @"\Processor.txt");
            }
        }
    }
}