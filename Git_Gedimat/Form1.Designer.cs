namespace Git_Gedimat
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Actualiser = new System.Windows.Forms.Button();
            this.list_cli = new System.Windows.Forms.ListBox();
            this.Envoyer = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Actualiser
            // 
            this.Actualiser.Location = new System.Drawing.Point(441, 44);
            this.Actualiser.Name = "Actualiser";
            this.Actualiser.Size = new System.Drawing.Size(144, 62);
            this.Actualiser.TabIndex = 0;
            this.Actualiser.Text = "Actualiser";
            this.Actualiser.UseVisualStyleBackColor = true;
            this.Actualiser.Click += new System.EventHandler(this.Actualiser_Click);
            // 
            // list_cli
            // 
            this.list_cli.FormattingEnabled = true;
            this.list_cli.Location = new System.Drawing.Point(12, 8);
            this.list_cli.Name = "list_cli";
            this.list_cli.Size = new System.Drawing.Size(398, 433);
            this.list_cli.TabIndex = 1;
            // 
            // Envoyer
            // 
            this.Envoyer.Location = new System.Drawing.Point(624, 44);
            this.Envoyer.Name = "Envoyer";
            this.Envoyer.Size = new System.Drawing.Size(144, 62);
            this.Envoyer.TabIndex = 2;
            this.Envoyer.Text = "Envoyer dans la base de donée";
            this.Envoyer.UseVisualStyleBackColor = true;
            this.Envoyer.Click += new System.EventHandler(this.Envoyer_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(441, 213);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(327, 144);
            this.message.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.message);
            this.Controls.Add(this.Envoyer);
            this.Controls.Add(this.list_cli);
            this.Controls.Add(this.Actualiser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Actualiser;
        private System.Windows.Forms.ListBox list_cli;
        private System.Windows.Forms.Button Envoyer;
        private System.Windows.Forms.TextBox message;
    }
}

