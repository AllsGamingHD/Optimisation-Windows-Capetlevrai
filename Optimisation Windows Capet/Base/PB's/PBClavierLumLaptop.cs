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
    public partial class PBClavierLumLaptop : DevExpress.XtraEditors.XtraUserControl
    {
        public PBClavierLumLaptop()
        {
            InitializeComponent();
        }

        private void PBClavierLumLaptop_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = @"Tu as désactivé le service qui gère la lumière de ton clavier. 
Réactive le, pour les PC ASUS RoG ça donne ça. Une fois réactivé,
redémarre le PC et c’est parti :)";
            }
            else
            {
                labelControl1.Text = @"You have disabled the service that manages the light of your keyboard.
Reactivate it, for ASUS RoG PCs that gives that. Once reactivated,
Restart the PC and go away :)";
            }
        }
    }
}
