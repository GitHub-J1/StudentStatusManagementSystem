namespace studentStatusManagementSyatem
{
    partial class AddClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.classId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.className = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.teacher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.emplain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.major = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(65, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "班级号";
            // 
            // classId
            // 
            this.classId.Location = new System.Drawing.Point(149, 40);
            this.classId.Name = "classId";
            this.classId.Size = new System.Drawing.Size(164, 25);
            this.classId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(345, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "班级名称";
            // 
            // className
            // 
            this.className.Location = new System.Drawing.Point(436, 40);
            this.className.Name = "className";
            this.className.Size = new System.Drawing.Size(164, 25);
            this.className.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(65, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "班主任";
            // 
            // teacher
            // 
            this.teacher.Location = new System.Drawing.Point(149, 101);
            this.teacher.Name = "teacher";
            this.teacher.Size = new System.Drawing.Size(164, 25);
            this.teacher.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(345, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "班级人数";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(436, 101);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(164, 25);
            this.count.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(65, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "所属专业";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(65, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "说明";
            // 
            // emplain
            // 
            this.emplain.Location = new System.Drawing.Point(149, 244);
            this.emplain.Multiline = true;
            this.emplain.Name = "emplain";
            this.emplain.Size = new System.Drawing.Size(451, 130);
            this.emplain.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(186, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(392, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 40);
            this.button2.TabIndex = 13;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // major
            // 
            this.major.FormattingEnabled = true;
            this.major.Location = new System.Drawing.Point(149, 165);
            this.major.Name = "major";
            this.major.Size = new System.Drawing.Size(451, 23);
            this.major.TabIndex = 14;
            // 
            // AddClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 450);
            this.Controls.Add(this.major);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emplain);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.count);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.teacher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.className);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.classId);
            this.Controls.Add(this.label1);
            this.Name = "AddClass";
            this.Text = " 添加班级";
            this.Load += new System.EventHandler(this.AddClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox classId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox className;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox teacher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emplain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox major;
    }
}