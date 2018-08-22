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
using System.Net;
using System.IO;

namespace Optimisation_Windows_Capet.Base.UserControl
{
    public partial class Report : DevExpress.XtraEditors.XtraForm
    {
        public Report()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string message = "Nom : " + textEdit1.Text + Environment.NewLine + Environment.NewLine + "Message : " + Environment.NewLine + Environment.NewLine + richTextBox1.Text + Environment.NewLine + Environment.NewLine + "Contact : " + textEdit2.Text; ;
            Properties.Settings.Default.chatReport = message;
            // Get the object used to communicate with the server.
            Random aleatoire = new Random();
            int entier = aleatoire.Next(); //Génère un entier aléatoire positif
            string name = ("report_" + entier + ".txt");
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.lossantoscityfr.esy.es/report/" + name);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("u585647664.admin", "azertyuiop02");

            // Copy the contents of the file to the request stream.
            byte[] fileContents = Encoding.UTF8.GetBytes(Properties.Settings.Default.chatReport);
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();


            response.Close();
            XtraMessageBox.Show("Votre report à était envoyée avec succès !\nNous vous répondrons le plus rapidement possibles !", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}