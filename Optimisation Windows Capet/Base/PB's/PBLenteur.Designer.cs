namespace Optimisation_Windows_Capet.Base
{
    partial class PBLenteur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PBLenteur));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.timer1FR = new System.Windows.Forms.Timer(this.components);
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.TaskMgrCheck = new System.Windows.Forms.Timer(this.components);
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.TrottleStopTimer = new System.Windows.Forms.Timer(this.components);
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.MsConfigCheck = new System.Windows.Forms.Timer(this.components);
            this.timer2EN = new System.Windows.Forms.Timer(this.components);
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(797, 500);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = resources.GetString("labelControl1.Text");
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(154, 86);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(152, 25);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Tag = "";
            this.labelControl2.Text = "Utilisation du CPU : 0%";
            // 
            // timer1FR
            // 
            this.timer1FR.Interval = 1000;
            this.timer1FR.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(154, 115);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(170, 25);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Tag = "";
            this.labelControl3.Text = "Utilisation des HDD\'s : 0%";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(8, 96);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(128, 33);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Gestionnaire de Tâches";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // TaskMgrCheck
            // 
            this.TaskMgrCheck.Interval = 1000;
            this.TaskMgrCheck.Tick += new System.EventHandler(this.TaskMgrCheck_Tick);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(219, 344);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(393, 28);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Ouvrir Throttle Stop";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // TrottleStopTimer
            // 
            this.TrottleStopTimer.Interval = 1000;
            this.TrottleStopTimer.Tick += new System.EventHandler(this.TrottleStopTimer_Tick);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(134, 414);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(532, 33);
            this.simpleButton4.TabIndex = 6;
            this.simpleButton4.Text = "Réactiver Windows DEFENDER";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(134, 530);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(532, 33);
            this.simpleButton3.TabIndex = 7;
            this.simpleButton3.Text = "MSCONFIG";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // MsConfigCheck
            // 
            this.MsConfigCheck.Interval = 1000;
            this.MsConfigCheck.Tick += new System.EventHandler(this.MsConfigCheck_Tick);
            // 
            // timer2EN
            // 
            this.timer2EN.Interval = 1000;
            this.timer2EN.Tick += new System.EventHandler(this.timer2EN_Tick);
            // 
            // performanceCounter1
            // 
            this.performanceCounter1.CategoryName = "Processor";
            this.performanceCounter1.CounterName = "% Processor Time";
            this.performanceCounter1.InstanceName = "_Total";
            // 
            // performanceCounter2
            // 
            this.performanceCounter2.CategoryName = "PhysicalDisk";
            this.performanceCounter2.CounterName = "% Disk Time";
            this.performanceCounter2.InstanceName = "_Total";
            // 
            // PBLenteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.LookAndFeel.SkinName = "Metropolis Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "PBLenteur";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.PBLenteur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Timer timer1FR;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Timer TaskMgrCheck;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Timer TrottleStopTimer;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.Timer MsConfigCheck;
        private System.Windows.Forms.Timer timer2EN;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Diagnostics.PerformanceCounter performanceCounter2;
    }
}
