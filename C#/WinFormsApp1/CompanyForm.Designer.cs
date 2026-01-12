namespace WinFormsApp1
{
    partial class CompanyForm
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
            button1 = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            comboBox_vacancy = new System.Windows.Forms.ComboBox();
            Mydata = new System.Windows.Forms.Button();
            button_data_change = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(269, 368);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(146, 42);
            button1.TabIndex = 0;
            button1.Text = "Мои вакансии";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(621, 268);
            dataGridView1.TabIndex = 1;
            // 
            // comboBox_vacancy
            // 
            comboBox_vacancy.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBox_vacancy.FormattingEnabled = true;
            comboBox_vacancy.Location = new System.Drawing.Point(12, 319);
            comboBox_vacancy.Name = "comboBox_vacancy";
            comboBox_vacancy.Size = new System.Drawing.Size(286, 33);
            comboBox_vacancy.TabIndex = 2;
            // 
            // Mydata
            // 
            Mydata.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Mydata.Location = new System.Drawing.Point(639, 12);
            Mydata.Name = "Mydata";
            Mydata.Size = new System.Drawing.Size(145, 42);
            Mydata.TabIndex = 3;
            Mydata.Text = "Мои данные";
            Mydata.UseVisualStyleBackColor = true;
            Mydata.Click += Mydata_Click;
            // 
            // button_data_change
            // 
            button_data_change.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_data_change.Location = new System.Drawing.Point(640, 65);
            button_data_change.Name = "button_data_change";
            button_data_change.Size = new System.Drawing.Size(144, 61);
            button_data_change.TabIndex = 4;
            button_data_change.Text = "Изменить данные";
            button_data_change.UseVisualStyleBackColor = true;
            button_data_change.Click += button_data_change_Click;
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(66, 368);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(146, 61);
            button2.TabIndex = 5;
            button2.Text = "Добавить вакансию";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(346, 283);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 25);
            label1.TabIndex = 6;
            label1.Text = "Зарплата";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(66, 291);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(167, 25);
            label2.TabIndex = 7;
            label2.Text = "Вид деятельности";
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox1.Location = new System.Drawing.Point(318, 319);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(145, 32);
            textBox1.TabIndex = 8;
            // 
            // button3
            // 
            button3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.Location = new System.Drawing.Point(646, 225);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(138, 55);
            button3.TabIndex = 9;
            button3.Text = "Транзакции";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // CompanyForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(796, 444);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button_data_change);
            Controls.Add(Mydata);
            Controls.Add(comboBox_vacancy);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "CompanyForm";
            Text = "CompanyForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_vacancy;
        private System.Windows.Forms.Button Mydata;
        private System.Windows.Forms.Button button_data_change;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
    }
}