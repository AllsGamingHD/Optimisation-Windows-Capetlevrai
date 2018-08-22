namespace Optimisation_Windows_Capet
{
    partial class Accueil
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Optimisation_Windows_Capet.Lancement), true, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton16 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 1000;
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Appearance.Options.UseTextOptions = true;
            this.labelControl17.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl17.Location = new System.Drawing.Point(184, 303);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(604, 206);
            this.labelControl17.TabIndex = 11;
            this.labelControl17.Text = "Capetlevrai :\r\nGérant du projet \"Optimisations de Windows\" et participation au co" +
    "dage de l\'application\r\n\r\n\r\n\r\n\r\nAllsGamingHD :\r\nIdée du projet de l\'application e" +
    "t codage du projet\r\n";
            // 
            // simpleButton16
            // 
            this.simpleButton16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton16.Appearance.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton16.Appearance.Options.UseFont = true;
            this.simpleButton16.Location = new System.Drawing.Point(12, 259);
            this.simpleButton16.Name = "simpleButton16";
            this.simpleButton16.Size = new System.Drawing.Size(776, 38);
            this.simpleButton16.TabIndex = 8;
            this.simpleButton16.Text = "Entrer sur le logiciel";
            this.simpleButton16.Click += new System.EventHandler(this.simpleButton16_Click);
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Appearance.Options.UseTextOptions = true;
            this.labelControl16.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl16.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.labelControl16.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl16.LineVisible = true;
            this.labelControl16.Location = new System.Drawing.Point(49, 3);
            this.labelControl16.LookAndFeel.SkinName = "Metropolis Dark";
            this.labelControl16.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(702, 250);
            this.labelControl16.TabIndex = 7;
            this.labelControl16.Text = resources.GetString("labelControl16.Text");
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit1.EditValue = global::Optimisation_Windows_Capet.Properties.Resources.photo;
            this.pictureEdit1.Location = new System.Drawing.Point(78, 303);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ErrorImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.ErrorImageOptions.Image")));
            this.pictureEdit1.Properties.InitialImageOptions.Image = global::Optimisation_Windows_Capet.Properties.Resources.photo;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(100, 100);
            this.pictureEdit1.TabIndex = 13;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit2.EditValue = global::Optimisation_Windows_Capet.Properties.Resources.photo__1_;
            this.pictureEdit2.Location = new System.Drawing.Point(78, 409);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.ErrorImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pictureEdit2.Properties.ErrorImageOptions.Image")));
            this.pictureEdit2.Properties.InitialImageOptions.Image = global::Optimisation_Windows_Capet.Properties.Resources.photo;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new System.Drawing.Size(100, 100);
            this.pictureEdit2.TabIndex = 14;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.ControlBox = false;
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.simpleButton16);
            this.Controls.Add(this.labelControl16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Metropolis Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Accueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Accueil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.SimpleButton simpleButton16;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
    }
}