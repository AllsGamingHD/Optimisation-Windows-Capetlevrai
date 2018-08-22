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
    public partial class AttenteRestore : DevExpress.XtraEditors.XtraUserControl
    {
        public AttenteRestore()
        {
            InitializeComponent();
        }

        private void AttenteRestore_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR") // Défini le texte selon la langue choisis auparavant
            {
                labelControl1.Text = @"                   En attente de la création du point de restauration !
Veuillez fermer les fenêtres qui ont était ouvertes pour continuer :)";
                labelControl1.Left = (this.ClientSize.Width - labelControl1.Size.Width) / 2;
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                labelControl1.Text = @"                   Waiting for the creation of the restore point!
Please close the windows that were opened to continue :)";
                labelControl1.Left = (this.ClientSize.Width - labelControl1.Size.Width) / 2;
            }
        }
    }
}
