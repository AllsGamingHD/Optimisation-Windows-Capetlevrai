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

namespace Optimisation_Windows_Capet.Base
{
    public partial class PBCrashFortnite : DevExpress.XtraEditors.XtraUserControl
    {
        public PBCrashFortnite()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("COCHEZ BIEN “MASQUEZ TOUS LES SERVICES MICROSOFT” SINON VOUS RISQUEZ DE FAIRE DES BÊTISES ! ", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Check 'HIDE ALL MICROSOFT SERVICES' OTHERWISE YOU CAN DO BADIES ! ", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(Environment.SystemDirectory, "msconfig.exe"),
                    Arguments = "/3"
                }
            };
            process.Start();
            MsConfigCheck.Start();
            simpleButton1.ForeColor = Color.Green;
        }

        private void MsConfigCheck_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("msconfig");
            if (pname.Length == 0)
            {

                simpleButton1.ForeColor = Color.Red;
                MsConfigCheck.Stop();
            }
            else
            {
                simpleButton1.ForeColor = Color.Green;
            }
        }

        private void PBCrashFortnite_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = @"Vous avez peut être désactivé le service EasyAntiCheat dans msconfig > services. Réactivez
le et redémarrez votre PC pour régler le problème.";
            }
            else
            {
                labelControl1.Text = @"You may have disabled the EasyAntiCheat service in msconfig> services. Reactivate
and restart your PC to fix the problem.";
            }
        }
    }
}
