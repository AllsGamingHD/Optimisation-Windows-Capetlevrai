namespace Optimisation_Windows_Capet.Base
{
    partial class CheckDWTMaison
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit5 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkEdit1.Location = new System.Drawing.Point(248, 166);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Bloquer la télémétrie";
            this.checkEdit1.Size = new System.Drawing.Size(130, 19);
            this.checkEdit1.TabIndex = 0;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkEdit2.Location = new System.Drawing.Point(248, 191);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Supprimer les logs DiagTrack";
            this.checkEdit2.Size = new System.Drawing.Size(156, 19);
            this.checkEdit2.TabIndex = 0;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkEdit3.Location = new System.Drawing.Point(248, 216);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "Désactiver les services";
            this.checkEdit3.Size = new System.Drawing.Size(143, 19);
            this.checkEdit3.TabIndex = 0;
            // 
            // checkEdit4
            // 
            this.checkEdit4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkEdit4.Location = new System.Drawing.Point(248, 241);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Caption = "Bloquer les IP\'s";
            this.checkEdit4.Size = new System.Drawing.Size(107, 19);
            this.checkEdit4.TabIndex = 0;
            this.checkEdit4.CheckedChanged += new System.EventHandler(this.checkEdit4_CheckedChanged);
            // 
            // checkEdit5
            // 
            this.checkEdit5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkEdit5.Location = new System.Drawing.Point(248, 266);
            this.checkEdit5.Name = "checkEdit5";
            this.checkEdit5.Properties.Caption = "Désinstaller OneDrive";
            this.checkEdit5.Size = new System.Drawing.Size(125, 19);
            this.checkEdit5.TabIndex = 0;
            this.checkEdit5.CheckedChanged += new System.EventHandler(this.checkEdit4_CheckedChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton1.Location = new System.Drawing.Point(248, 291);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(188, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Exécuter";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton2.Location = new System.Drawing.Point(612, 0);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(72, 20);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Fermer";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // CheckDWTMaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.checkEdit5);
            this.Controls.Add(this.checkEdit4);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit1);
            this.LookAndFeel.SkinName = "Metropolis Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "CheckDWTMaison";
            this.Size = new System.Drawing.Size(684, 481);
            this.Load += new System.EventHandler(this.CheckDWTMaison_Load);
            this.VisibleChanged += new System.EventHandler(this.CheckDWTMaison_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.CheckEdit checkEdit5;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
