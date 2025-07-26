namespace LearningSoftware
{
    partial class AdvMethods
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
            this.previousPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.quiz = new System.Windows.Forms.Button();
            this.showslides = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).BeginInit();
            this.SuspendLayout();
            // 
            // backPage
            // 
            this.backPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.backPage.Location = new System.Drawing.Point(12, 20);
            this.backPage.Name = "backPage";
            this.backPage.Size = new System.Drawing.Size(128, 35);
            this.backPage.TabIndex = 26;
            this.backPage.Text = "Πίσω";
            this.backPage.UseVisualStyleBackColor = true;
            this.backPage.Click += new System.EventHandler(this.backPage_Click);
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.back.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.back.Location = new System.Drawing.Point(31, -54);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(128, 35);
            this.back.TabIndex = 25;
            this.back.Text = "Πίσω";
            this.back.UseVisualStyleBackColor = true;
            // 
            // previousPage
            // 
            this.previousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.previousPage.Location = new System.Drawing.Point(325, 600);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(173, 42);
            this.previousPage.TabIndex = 27;
            this.previousPage.Text = "Προηγούμενη σελίδα";
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.nextPage.Location = new System.Drawing.Point(610, 600);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(172, 42);
            this.nextPage.TabIndex = 28;
            this.nextPage.Text = "Επόμενη σελίδα";
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // quiz
            // 
            this.quiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.quiz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.quiz.Location = new System.Drawing.Point(27, 600);
            this.quiz.Name = "quiz";
            this.quiz.Size = new System.Drawing.Size(191, 35);
            this.quiz.TabIndex = 24;
            this.quiz.Text = "Τεστ αυτοαξιολόγησης";
            this.quiz.UseVisualStyleBackColor = true;
            this.quiz.Click += new System.EventHandler(this.quiz_Click);
            // 
            // showslides
            // 
            this.showslides.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showslides.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.showslides.Location = new System.Drawing.Point(12, 61);
            this.showslides.Name = "showslides";
            this.showslides.Size = new System.Drawing.Size(811, 509);
            this.showslides.TabIndex = 23;
            this.showslides.TabStop = false;
            // 
            // AdvMethods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 660);
            this.Controls.Add(this.backPage);
            this.Controls.Add(this.back);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.quiz);
            this.Controls.Add(this.showslides);
            this.Name = "AdvMethods";
            this.Text = "Προχωρημένο υλικό στις μεθόδους";
            this.Load += new System.EventHandler(this.AdvMethods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backPage;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button quiz;
        private System.Windows.Forms.PictureBox showslides;
    }
}