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

namespace Optimisation_Windows_Capet
{
    public partial class PBEcranNoir : DevExpress.XtraEditors.XtraUserControl
    {
        public PBEcranNoir()
        {
            InitializeComponent();
        }

        private void PBEcranNoir_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                labelControl1.Text = @"Parfois Windows est capricieux et n'affiche pas d’interface graphique c’est à dire que vous n’avez plus
la barre des tâches, ni accès à l’explorateur de fichier ou au menu démarrer. 

Manipulation automatique : 

Manipulation manuel :
Vous pouvez tenter de forcer le démarrage de l’interface graphique via le gestionnaire des tâches 
(CTRL + ALT + SUPR), une fois démarrés, tout en haut à gauche vous avez “fichier” -> 
cliquez dessus -> executer une nouvelle tâche -> exécutez la tâches explorer.exe

Avec un peu de chance ça va afficher l’interface, c’est pratique si vous ne voulez pas redémarrer 
votre ordinateur après un écran noir.";
                simpleButton1.Text = "Exécuter";
            }
            else
            {
                labelControl1.Text = @"Sometimes Windows is capricious and does not display GUI that is to say that you do not have any more
the taskbar, or access to the file explorer or the start menu.

Automatic manipulation:

Manual manipulation:
You can try to force GUI startup through the Task Manager
(CTRL + ALT + SUPR), once started, at the top left you have 'file' ->
click on it -> run a new task -> execute the explorer.exe task

With a little luck it will show the interface, it is convenient if you do not want to restart
your computer after a black screen.";
                simpleButton1.Text = "Launch";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe");
            simpleButton1.ForeColor = Color.Green;
        }
    }
}
