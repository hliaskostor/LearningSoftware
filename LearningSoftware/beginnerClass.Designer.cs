namespace LearningSoftware
{
    partial class beginnerClass
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
            this.backPage = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.showslides = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).BeginInit();
            this.SuspendLayout();
            // 
            // backPage
            // 
            this.backPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.backPage.Location = new System.Drawing.Point(21, 12);
            this.backPage.Name = "backPage";
            this.backPage.Size = new System.Drawing.Size(128, 35);
            this.backPage.TabIndex = 20;
            this.backPage.Text = "Πίσω";
            this.backPage.UseVisualStyleBackColor = true;
            this.backPage.Click += new System.EventHandler(this.backPage_Click);
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.back.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.back.Location = new System.Drawing.Point(54, -62);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(128, 35);
            this.back.TabIndex = 19;
            this.back.Text = "Πίσω";
            this.back.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(21, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Τεστ αυτοαξιολόγησης";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nextPage
            // 
            this.nextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.nextPage.Location = new System.Drawing.Point(633, 592);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(172, 42);
            this.nextPage.TabIndex = 22;
            this.nextPage.Text = "Επόμενη σελίδα";
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // previousPage
            // 
            this.previousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.previousPage.Location = new System.Drawing.Point(348, 592);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(173, 42);
            this.previousPage.TabIndex = 21;
            this.previousPage.Text = "Προηγούμενη σελίδα";
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // showslides
            // 
            this.showslides.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showslides.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.showslides.Location = new System.Drawing.Point(21, 53);
            this.showslides.Name = "showslides";
            this.showslides.Size = new System.Drawing.Size(811, 509);
            this.showslides.TabIndex = 15;
            this.showslides.TabStop = false;
            // 
            // beginnerClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 639);
            this.Controls.Add(this.backPage);
            this.Controls.Add(this.back);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showslides);
            this.Name = "beginnerClass";
            this.Text = "Βοηθητικό υλικό στις κλάσεις-αντικείμενα";
            this.Load += new System.EventHandler(this.beginnerClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button backPage;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.PictureBox showslides;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button previousPage;
    }
}