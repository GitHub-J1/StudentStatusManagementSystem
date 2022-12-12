namespace studentStatusManagementSyatem
{
    partial class UpdateSocore
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
            this.button1 = new System.Windows.Forms.Button();
            this.Score = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.courseId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.studentId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(265, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Score
            // 
            this.Score.Location = new System.Drawing.Point(131, 102);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(137, 25);
            this.Score.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(56, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "成绩：";
            // 
            // courseId
            // 
            this.courseId.Location = new System.Drawing.Point(407, 53);
            this.courseId.Name = "courseId";
            this.courseId.Size = new System.Drawing.Size(165, 25);
            this.courseId.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(312, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "课程号：";
            // 
            // studentId
            // 
            this.studentId.Location = new System.Drawing.Point(131, 58);
            this.studentId.Name = "studentId";
            this.studentId.Size = new System.Drawing.Size(137, 25);
            this.studentId.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "学号：";
            // 
            // UpdateSocore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 245);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.courseId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentId);
            this.Controls.Add(this.label1);
            this.Name = "UpdateSocore";
            this.Text = "修改成绩";
            this.Load += new System.EventHandler(this.UpdateSocore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Score;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox courseId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox studentId;
        private System.Windows.Forms.Label label1;
    }
}