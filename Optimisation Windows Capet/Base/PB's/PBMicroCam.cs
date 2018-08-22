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

namespace Optimisation_Windows_Capet.PB_s
{
    public partial class PBMicroCam : DevExpress.XtraEditors.XtraUserControl
    {
        public PBMicroCam()
        {
            InitializeComponent();
        }

        private void PBMicroCam_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = @"No stress il faut juste les réactiver dans les paramètres comme je l’ai indiqué dans mon second tuto à l’oral 
Windows -> Confidentialité -> Caméra 
Windows -> Confidentialité -> Microphone

Cela devrait régler le problème. ";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = @"No stress just reactivate them in the parameters as I indicated in my second tutorial
Windows -> Privacy -> Camera
Windows -> Privacy -> Microphone

This should solve the problem.";
            }
        }
    }
}
