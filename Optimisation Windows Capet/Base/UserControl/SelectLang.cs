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

namespace Optimisation_Windows_Capet.Base
{
    public partial class SelectLang : DevExpress.XtraEditors.XtraUserControl
    {
        public SelectLang()
        {
            InitializeComponent();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLang();
        }
        public void GetLang()
        {
            if (comboBoxEdit1.SelectedIndex == 0)
            {
                string text = "FR";
                // WriteAllText creates a file, writes the specified string to the file,
                // and then closes the file.    You do NOT need to call Flush() or Close().
                System.IO.File.WriteAllText(Application.StartupPath.ToString() + @"\languages-resources.ini", text);
                Properties.Settings.Default.Lang = "FR";
                Properties.Settings.Default.Save();
            }
            else if (comboBoxEdit1.SelectedIndex == 1)
            {
                string text = "EN";
                System.IO.File.WriteAllText(Application.StartupPath.ToString() + @"\languages-resources.ini", text);
                Properties.Settings.Default.Lang = "EN";
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Aucune langue n'a été sélectionnée ou données invalide ! Veuillez réessayer\nNo language was selected or data invalid! Try Again", "Informations !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SelectLang_Load(object sender, EventArgs e)
        {
            GetLang();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
