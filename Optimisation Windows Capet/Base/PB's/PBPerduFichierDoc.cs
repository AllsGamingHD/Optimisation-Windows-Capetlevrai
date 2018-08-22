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

namespace Optimisation_Windows_Capet.Base
{
    public partial class PBPerduFichierDoc : DevExpress.XtraEditors.XtraUserControl
    {
        public PBPerduFichierDoc()
        {
            InitializeComponent();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            Process.Start("https://onedrive.live.com/about/fr-fr/");
        }

        private void PBPerduFichierDoc_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = "En fait les fichiers étaient stockés sur Microsoft OneDrive , réinstaller le et tu devrais récupérer l’accès à tes fichiers.";
                hyperlinkLabelControl1.Location = new Point(266, 3);
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = "In fact the files were stored on Microsoft OneDrive, reinstall it and you should recover access to your files.";
                hyperlinkLabelControl1.Location = new Point(215, 3);
            }
        }
    }
}
