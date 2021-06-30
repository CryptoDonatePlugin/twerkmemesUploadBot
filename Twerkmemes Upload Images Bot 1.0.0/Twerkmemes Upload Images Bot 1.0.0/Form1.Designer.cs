namespace Twerkmemes_Upload_Images_Bot_1._0._0
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoBot = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // AutoBot
            // 
            this.AutoBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoBot.Location = new System.Drawing.Point(0, 0);
            this.AutoBot.MinimumSize = new System.Drawing.Size(20, 20);
            this.AutoBot.Name = "AutoBot";
            this.AutoBot.Size = new System.Drawing.Size(1184, 611);
            this.AutoBot.TabIndex = 0;
            this.AutoBot.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.LoginToPage);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.AddMedia);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.AutoBot);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twerkmemes Upload Images Bot 1.0.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser AutoBot;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

