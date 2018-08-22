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
    public partial class Infos_Partie1 : DevExpress.XtraEditors.XtraForm
    {
        public Infos_Partie1()
        {
            InitializeComponent();
        }

        private void Infos_Partie2_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                richTextBox1.Text = @"Assurez vous que la gestion de l’alimentation du processeur est au moins à 70 voir 80% dans “état minimal du processeur”, idéalement 100% si vous avez un PC fixe ça permet d’avoir un framerate stable sur les jeux comme CSGO, H1Z1 ou PubG

Attention tout de même si votre PC chauffe déjà beaucoup il chauffera plus, jouer sur l’état minimal et maximal du processeur pour réduire la chauffe si c’est le cas. 

Certains abonnés m’ont remonté des soucis après avoir fait ce TUTO, si votre PC bug alors qu’il ne buggait pas avant il se peut que WIndows s’est permis de faire quelques dépendances entres les fichiers PREFECH et le système ce qui peut créer des comportements étranges, c’est pour cela que ça le fait un 1%d’entres vous et pas aux autres. Pour remettre le PC d'aplomb utilisez l’outil de vérification des fichiers Windows : disponible en cliquant ici

J’ai constaté sur un abonné que SUPERFETCH faisait des siennes, vous pouvez terminer la tâche superftech via le gestionnaire des tâches en cliquant dessus puis en cliquant sur “fin de tache” en bas à droite, tant que votre disque dur est exploité à 80~100% vous aurez des bugs. 

Un autre abonné à vu son processeur plafonner à 0.8GHz, pour débloquer ça il faut installer le logiciel TrottleStop ( Disponible en cliquand sur le bouton dans le logiciel ! ) , puis une fois lancer décocher “BD PROSHOT” c’est pour désactiver le processeur qui se met en mode sécurité. Image AVANT puis APRES ! :)";
            }
            else
            {
                richTextBox1.Text = @"Make sure that the processor power management is at least 70% or 80% in 'minimal processor state', ideally 100% if you have a fixed PC it allows to have a stable framerate on games like CSGO, H1Z1 or PubG

Be careful though if your PC is already heating up a lot it will heat up more, play on the minimum and maximum state of the processor to reduce the heating if that's the case.

Some subscribers made me worry after doing this TUTO, if your PC bug while it did not bug before it may be that WIndows allowed himself to make some dependencies between PREFECH files and the system which can create strange behaviors, that's why it does a 1% of you and not to others. To put the PC back in place use the Windows file verification tool: available by clicking here

I noticed on a subscriber that SUPERFETCH was doing its own, you can finish the task superftech via the task manager by clicking on it and then clicking on 'end of task' at the bottom right, as long as your hard drive is operated at 80 ~ 100% you will have bugs.

Another subscriber saw his processor capped at 0.8GHz, to unlock it you have to install the software TrottleStop (Available by clicking the button in the software!), Then once launch uncheck 'BD PROSHOT' is to disable the processor which goes into security mode. Image BEFORE then AFTER! :)";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}