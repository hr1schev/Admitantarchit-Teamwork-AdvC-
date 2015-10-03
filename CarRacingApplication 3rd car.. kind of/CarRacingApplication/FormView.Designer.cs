namespace CarRacingApplication
{
    partial class FormView
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
            this.timerRacing = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerRacing
            // 
            this.timerRacing.Enabled = true;
            this.timerRacing.Interval = 50;
            this.timerRacing.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 375);
            this.DoubleBuffered = true;
            this.Name = "FormView";
            this.Text = "Car Racing";
            this.Load += new System.EventHandler(this.FormView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormView_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormView_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormView_MouseDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerRacing;
    }
}

