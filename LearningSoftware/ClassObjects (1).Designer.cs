namespace LearningSoftware
{
    partial class ClassObjects
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
            this.back = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.quiz = new System.Windows.Forms.Button();
            this.begButton = new System.Windows.Forms.Button();
            this.advButton = new System.Windows.Forms.Button();
            this.showslides = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.back.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.back.Location = new System.Drawing.Point(25, 13);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(135, 35);
            this.back.TabIndex = 11;
            this.back.Text = "Πίσω";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // previousPage
            // 
            this.previousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.previousPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.previousPage.Location = new System.Drawing.Point(359, 541);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(209, 38);
            this.previousPage.TabIndex = 10;
            this.previousPage.Text = "Προηγούμενη διαφάνεια";
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nextPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nextPage.Location = new System.Drawing.Point(632, 541);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(172, 38);
            this.nextPage.TabIndex = 9;
            this.nextPage.Text = "Επόμενη διαφάνεια";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // quiz
            // 
            this.quiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.quiz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.quiz.Location = new System.Drawing.Point(37, 541);
            this.quiz.Name = "quiz";
            this.quiz.Size = new System.Drawing.Size(199, 38);
            this.quiz.TabIndex = 8;
            this.quiz.Text = "Τεστ αυτοαξιολόγησης";
            this.quiz.UseVisualStyleBackColor = true;
            this.quiz.Click += new System.EventHandler(this.quiz_Click);
            // 
            // begButton
            // 
            this.begButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.begButton.Location = new System.Drawing.Point(253, 14);
            this.begButton.Name = "begButton";
            this.begButton.Size = new System.Drawing.Size(150, 34);
            this.begButton.TabIndex = 14;
            this.begButton.Text = "Βοηθητικό υλικό ";
            this.begButton.UseVisualStyleBackColor = true;
            this.begButton.Visible = false;
            this.begButton.Click += new System.EventHandler(this.begButton_Click);
            // 
            // advButton
            // 
            this.advButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.advButton.Location = new System.Drawing.Point(469, 14);
            this.advButton.Name = "advButton";
            this.advButton.Size = new System.Drawing.Size(169, 34);
            this.advButton.TabIndex = 15;
            this.advButton.Text = "Προχωρημένο υλικό";
            this.advButton.UseVisualStyleBackColor = true;
            this.advButton.Visible = false;
            this.advButton.Click += new System.EventHandler(this.advButton_Click);
            // 
            // showslides
            // 
            this.showslides.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showslides.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.showslides.Location = new System.Drawing.Point(12, 54);
            this.showslides.Name = "showslides";
            this.showslides.Size = new System.Drawing.Size(779, 443);
            this.showslides.TabIndex = 7;
            this.showslides.TabStop = false;
            // 
            // ClassObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 591);
            this.Controls.Add(this.advButton);
            this.Controls.Add(this.begButton);
            this.Controls.Add(this.back);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.quiz);
            this.Controls.Add(this.showslides);
            this.Name = "ClassObjects";
            this.Text = "Κλάσεις-αντικείμενα";
            this.Load += new System.EventHandler(this.ClassObjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button quiz;
        private System.Windows.Forms.PictureBox showslides;
        private System.Windows.Forms.Button begButton;
        private System.Windows.Forms.Button advButton;
    }
}