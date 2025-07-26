namespace LearningSoftware
{
    partial class Interface
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
            this.showslides = new System.Windows.Forms.PictureBox();
            this.begButton = new System.Windows.Forms.Button();
            this.advButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.back.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.back.Location = new System.Drawing.Point(22, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(135, 42);
            this.back.TabIndex = 0;
            this.back.Text = "Πίσω";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // previousPage
            // 
            this.previousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.previousPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.previousPage.Location = new System.Drawing.Point(347, 513);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(202, 38);
            this.previousPage.TabIndex = 10;
            this.previousPage.Text = "Προηγούμενη διαφάνεια";
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nextPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nextPage.Location = new System.Drawing.Point(584, 513);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(160, 38);
            this.nextPage.TabIndex = 9;
            this.nextPage.Text = "Επόμενη διαφάνεια";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // quiz
            // 
            this.quiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.quiz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.quiz.Location = new System.Drawing.Point(41, 513);
            this.quiz.Name = "quiz";
            this.quiz.Size = new System.Drawing.Size(193, 38);
            this.quiz.TabIndex = 8;
            this.quiz.Text = "Τεστ αυτοαξιολόγησης";
            this.quiz.UseVisualStyleBackColor = true;
            this.quiz.Click += new System.EventHandler(this.quiz_Click);
            // 
            // showslides
            // 
            this.showslides.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showslides.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.showslides.Location = new System.Drawing.Point(22, 60);
            this.showslides.Name = "showslides";
            this.showslides.Size = new System.Drawing.Size(748, 447);
            this.showslides.TabIndex = 7;
            this.showslides.TabStop = false;
            // 
            // begButton
            // 
            this.begButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.begButton.Location = new System.Drawing.Point(239, 16);
            this.begButton.Name = "begButton";
            this.begButton.Size = new System.Drawing.Size(150, 34);
            this.begButton.TabIndex = 15;
            this.begButton.Text = "Βοηθητικό υλικό ";
            this.begButton.UseVisualStyleBackColor = true;
            this.begButton.Visible = false;
            this.begButton.Click += new System.EventHandler(this.begButton_Click);
            // 
            // advButton
            // 
            this.advButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.advButton.Location = new System.Drawing.Point(446, 16);
            this.advButton.Name = "advButton";
            this.advButton.Size = new System.Drawing.Size(169, 34);
            this.advButton.TabIndex = 16;
            this.advButton.Text = "Προχωρημένο υλικό";
            this.advButton.UseVisualStyleBackColor = true;
            this.advButton.Visible = false;
            this.advButton.Click += new System.EventHandler(this.advButton_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 568);
            this.Controls.Add(this.advButton);
            this.Controls.Add(this.begButton);
            this.Controls.Add(this.back);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.quiz);
            this.Controls.Add(this.showslides);
            this.Name = "Interface";
            this.Text = "Interface";
            this.Load += new System.EventHandler(this.Interface_Load);
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