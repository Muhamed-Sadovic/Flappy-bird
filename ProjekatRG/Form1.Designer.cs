namespace ProjekatRG
{
    partial class Form1
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
            this.tajmer = new System.Windows.Forms.Timer(this.components);
            this.rezultat = new System.Windows.Forms.Label();
            this.ptica1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptica1)).BeginInit();
            this.SuspendLayout();
            // 
            // tajmer
            // 
            this.tajmer.Enabled = true;
            this.tajmer.Interval = 25;
            this.tajmer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rezultat
            // 
            this.rezultat.AutoSize = true;
            this.rezultat.Location = new System.Drawing.Point(1019, 44);
            this.rezultat.Name = "rezultat";
            this.rezultat.Size = new System.Drawing.Size(68, 16);
            this.rezultat.TabIndex = 4;
            this.rezultat.Text = "Rezultat: 0";
            // 
            // ptica1
            // 
            this.ptica1.Image = global::ProjekatRG.Properties.Resources.ptica;
            this.ptica1.Location = new System.Drawing.Point(12, 307);
            this.ptica1.Name = "ptica1";
            this.ptica1.Size = new System.Drawing.Size(100, 76);
            this.ptica1.TabIndex = 5;
            this.ptica1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 953);
            this.Controls.Add(this.ptica1);
            this.Controls.Add(this.rezultat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ptica1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tajmer;
        private System.Windows.Forms.Label rezultat;
        private System.Windows.Forms.PictureBox ptica1;
    }
}

