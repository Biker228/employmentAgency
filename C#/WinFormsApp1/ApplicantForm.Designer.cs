using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class ApplicantForm
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
            dataGridView1 = new DataGridView();
            button_Date_User = new Button();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(26, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(432, 309);
            dataGridView1.TabIndex = 0;
            // 
            // button_Date_User
            // 
            button_Date_User.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_Date_User.Location = new System.Drawing.Point(476, 23);
            button_Date_User.Name = "button_Date_User";
            button_Date_User.Size = new System.Drawing.Size(140, 56);
            button_Date_User.TabIndex = 1;
            button_Date_User.Text = "Мои данные";
            button_Date_User.UseVisualStyleBackColor = true;
            button_Date_User.Click += button_Date_User_Click;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(477, 98);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(139, 62);
            button1.TabIndex = 2;
            button1.Text = "Изменить данные";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(26, 352);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(134, 59);
            button2.TabIndex = 3;
            button2.Text = "Вакансии";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox1.Location = new System.Drawing.Point(477, 300);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(130, 32);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(464, 250);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(152, 20);
            label1.TabIndex = 5;
            label1.Text = "Код понравившейся";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(499, 270);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 20);
            label2.TabIndex = 6;
            label2.Text = "вакансии";
            // 
            // button3
            // 
            button3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.Location = new System.Drawing.Point(476, 351);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(129, 60);
            button3.TabIndex = 7;
            button3.Text = "Заключить сделку";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ApplicantForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(626, 428);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button_Date_User);
            Controls.Add(dataGridView1);
            Name = "ApplicantForm";
            Text = "ApplicantForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button_Date_User;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button button3;
    }
}