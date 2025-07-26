namespace LearningSoftware
{
    partial class StartJava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartJava));
            this.showslides = new System.Windows.Forms.PictureBox();
            this.quiz = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).BeginInit();
            this.SuspendLayout();
            // 
            // showslides
            // 
            resources.ApplyResources(this.showslides, "showslides");
            this.showslides.Name = "showslides";
            this.showslides.TabStop = false;
            this.showslides.Click += new System.EventHandler(this.showslides_Click_1);
            // 
            // quiz
            // 
            resources.ApplyResources(this.quiz, "quiz");
            this.quiz.Name = "quiz";
            this.quiz.UseVisualStyleBackColor = true;
            this.quiz.Click += new System.EventHandler(this.quiz_Click);
            // 
            // nextPage
            // 
            resources.ApplyResources(this.nextPage, "nextPage");
            this.nextPage.Name = "nextPage";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // previousPage
            // 
            resources.ApplyResources(this.previousPage, "previousPage");
            this.previousPage.Name = "previousPage";
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click_1);
            // 
            // back
            // 
            resources.ApplyResources(this.back, "back");
            this.back.Name = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // StartJava
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.quiz);
            this.Controls.Add(this.showslides);
            this.Name = "StartJava";
            this.Load += new System.EventHandler(this.StartJava_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showslides)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox showslides;
        private System.Windows.Forms.Button quiz;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Button back;
    }
}