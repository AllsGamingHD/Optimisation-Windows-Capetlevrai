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
    public partial class PBPhoto : DevExpress.XtraEditors.XtraUserControl
    {
        public PBPhoto()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                DialogResult dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Tu veux supprimer ( oui ) ou reinstaller ( non ) l'application photos ?", "Voulez vous supprimer ou reinstaller ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = "powershell.exe",
                            Arguments = "get-appxpackage *Microsoft.Windows.Photos* | remove-appxpackage"
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
                            FileName = "powershell.exe",
                            Arguments = "get-appxpackage *Microsoft.Windows.Photos* | remove-appxpackage"
                        }
                    };
                    process.Start();
                    Process.Start("https://www.microsoft.com/fr-fr/p/photos-microsoft/9wzdncrfjbh4");
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vous avez juste à cliquez sur installer et l'application devrait se reinstaller !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to delete (yes) or reinstall (no) the photos application?", "Do you want to remove or reinstall ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = "powershell.exe",
                            Arguments = "get-appxpackage *Microsoft.Windows.Photos* | remove-appxpackage"
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
                            FileName = "powershell.exe",
                            Arguments = "get-appxpackage *Microsoft.Windows.Photos* | remove-appxpackage"
                        }
                    };
                    process.Start();
                    Process.Start("https://www.microsoft.com/fr-fr/p/photos-microsoft/9wzdncrfjbh4");
                    DevExpress.XtraEditors.XtraMessageBox.Show("You just have to click install and the application should reinstall itself !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void PBPhoto_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = "Si ton application photo ne fonctionne plus il te suffit juste d'appuyer sur le bouton et le problèmes devrait être régler :) !";
                simpleButton1.Text = "Exécuter";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = "If your photo application does not work anymore you just have to press the button and the problem should be fixed :)!";
                simpleButton1.Text = "Launch";
            }
        }
    }
}
