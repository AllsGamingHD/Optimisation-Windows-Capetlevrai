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
using System.Threading;
using Optimisation_Windows_Capet.Base;

namespace Optimisation_Windows_Capet
{
    public partial class Accueil : DevExpress.XtraEditors.XtraForm
    {
        public Accueil()
        {
            InitializeComponent();
        }

        int counter = 0;
        int len = 0;
        string txt;
        public string texte3 = "Capetlevrai : \nGérant du projet “Optimisations de Windows“ et participation au codage de l'application \n\n\n\n\nAllsGamingHD :\nIdée du projet de l'application et codage du projet";

        private void Accueil_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark"); //Set du thèmes
            SelectLang SL = new SelectLang(); //Création de la fenêtre de selection de langue
            DevExpress.XtraEditors.XtraDialog.Show(SL, "Veuillez saisir votre langue / Please set your languages", MessageBoxButtons.OK); //Ouverture de la fenêtre en MessageBox avec un bouton "OK"
            SetLang(); //Défini la langue avec l'appel de la fonction SetLang() plus bas
            txt = labelControl17.Text; // le string "txt" aura comme texte celui du labelControl17
            len = txt.Length; // "len" sera la valeur de la longueur du texte du string "txt"
            labelControl17.Text = ""; // le labelControl17 sera sans texte
            timer1.Start(); // Lancement du timer1 qui correpons au défilement du texte
        }

        public void SetLang() // Défini la langue selon la langue choisis
        {
            if (Properties.Settings.Default.Lang == "FR")
            {
                this.Text = "Accueil";
                labelControl16.Text = @"Bienvenue sur le logiciel d'optimisation créer spécialement pour la série de vidéo de Capetlevrai

                Dans celui-ci vous aurez juste à cliquez sur des boutons pour que le logiciel effectue la tâche que vous
                 lui avez demander,
                pour 90% des cas ils sont automatiques et ne requis aucune manipulations de votre part !


                Pourquoi certains manipulations seront manuel ? 
                Car je ne peut choisir ce que vous voulez désactiver ou non et dépend de ce que la personnes à 
                comme logiciels/services sur son PC ";
                labelControl16.Left = (this.ClientSize.Width - labelControl16.Size.Width) / 2;

                simpleButton16.Text = "Entrer sur le logiciel";
                labelControl17.Text = @"Capetlevrai :
Gérant du projet " + '\u0022' + @"Optimisations de Windows" + '\u0022' + @"et participation au codage de l'application




AllsGamingHD :
Idée du projet de l'application et codage du projet";
                texte3 = "Capetlevrai : \nGérant du projet “Optimisations de Windows“ et participation au codage de l'application \n\n\n\n\nAllsGamingHD :\nIdée du projet de l'application et codage du projet";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                this.Text = "Home";
                labelControl16.Text = @"Welcome to the optimization software specially created for the Capetlevrai video serie's

                In this one you'll just have to click on buttons for the software to perform the task you asked him,
                for 90% of the cases they are automatic and do not require any manipulation of you!


                Why some manipulations will be manual?
                Because I can not choose what you want to disable or not and depends on what people have 
                software / services on your PC ";
                labelControl16.Left = (this.ClientSize.Width - labelControl16.Size.Width) / 2;
                simpleButton16.Text = "Enter to software";
                labelControl17.Text = @"Capetlevrai : 
Manager of the “Windows Optimization“ project and participation in the coding of the application




AllsGamingHD : 
Idea of the project of the application and coding of the project";
                texte3 = "Capetlevrai : \nManager of the “Windows Optimization“ project and participation in the coding of the application\n\n\n\n\nAllsGamingHD :\nIdea of the project of the application and coding of the project";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)// Défilement du texte
        {
            if (labelControl17.Text == texte3)
            {
                timer1.Stop();
            }
            else
            {
                counter++;

                if (counter > len)
                {
                    counter = 0;
                    labelControl17.Text = texte3;
                }

                else
                {

                    labelControl17.Text = txt.Substring(0, counter);
                }
            }            
        }

        private async void simpleButton16_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchAccueil = "Ouvert"; // La propriétés "LaunchAccueil" est défini sur Ouvert
            Properties.Settings.Default.Save(); // Sauvegarde de la propriétés
            Form1 F1 = new Form1(); // Création d'une nouvelle fenêtre "Form1"
            F1.Show(); // Affichage de la fenêtre créer auparavant
            await Task.Delay(250); // Attende de 250ms avec de continuer
            this.Hide(); // Cache la fenêtre actuel ( Accueil )
        }
    }
}