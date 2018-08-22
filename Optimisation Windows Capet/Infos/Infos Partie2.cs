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

namespace Optimisation_Windows_Capet
{
    public partial class Infos_Partie2 : DevExpress.XtraEditors.XtraForm
    {
        public Infos_Partie2()
        {
            InitializeComponent();
        }

        private void Infos_Partie1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                richTextBox1.Text = @"Désactiver Windows Defender : cet antivirus est un vrai gouffre, tout le monde ne sera pas d’accord avec moi mais je préfère 1000 fois AVAST gratuit qui est très léger, si vous souhaitez de la protection payante efficace, pour les gamers je conseil ESET NODE 32 pour garder les performances sur le PC, et Kaspersky Antivirus (existe en gratuit) ou BitDefender si vous voulez avoir le meilleur antivirus pour vous protéger. 


Un utilisateur a eu des soucis lié à la désactivation de la surcouche Windows via le logiciel “DisableWintracker” vous pouvez faire machine arrière en cliquant sur REVERT comme ceci : https://twitter.com/BugzCoz/status/1019685475118931969 ça a réglé son souci";
            }
            else
            {
                richTextBox1.Text = @"Disable Windows Defender: this antivirus is a real sinkhole, everyone will not agree with me but I prefer 1000 times AVAST free which is very light, if you want effective pay protection, for gamers I advice ESET NODE 32 to keep performance on the PC, and Kaspersky Antivirus (exists for free) or BitDefender if you want to have the best antivirus to protect you.


A user has had problems with the disabling of the Windows overlay via the 'DisableWintracker' software you can backtrack by clicking REVERT like this: https://twitter.com/BugzCoz/status/1019685475118931969 that solved his concern";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}