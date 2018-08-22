namespace Optimisation_Windows_Capet.Base
{
    partial class PBCrashFortnite
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
            this.components = new System.ComponentModel.Container();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.MsConfigCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(11, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(637, 50);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Vous avez peut être désactivé le service EasyAntiCheat dans msconfig > services. " +
    "Réactivez le et redémarrez votre PC pour régler le problème.";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(147, 58);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(364, 43);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "MSCONFIG";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // MsConfigCheck
            // 
            this.MsConfigCheck.Interval = 1000;
            this.MsConfigCheck.Tick += new System.EventHandler(this.MsConfigCheck_Tick);
            // 
            // PBCrashFortnite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.LookAndFeel.SkinName = "Metropolis Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "PBCrashFortnite";
            this.Size = new System.Drawing.Size(658, 106);
            this.Load += new System.EventHandler(this.PBCrashFortnite_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Timer MsConfigCheck;
    }
}
