namespace WinFormsApp1
{
    partial class AdminForm
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
            button_AddUser = new System.Windows.Forms.Button();
            button_DeleteUser = new System.Windows.Forms.Button();
            button_AllUser = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            comboBox_Role = new System.Windows.Forms.ComboBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            run = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button_AddUser
            // 
            button_AddUser.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_AddUser.Location = new System.Drawing.Point(37, 342);
            button_AddUser.Name = "button_AddUser";
            button_AddUser.Size = new System.Drawing.Size(149, 74);
            button_AddUser.TabIndex = 0;
            button_AddUser.Text = "Добавить пользователя";
            button_AddUser.UseVisualStyleBackColor = true;
            button_AddUser.Click += button_AddUser_Click;
            // 
            // button_DeleteUser
            // 
            button_DeleteUser.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_DeleteUser.Location = new System.Drawing.Point(234, 342);
            button_DeleteUser.Name = "button_DeleteUser";
            button_DeleteUser.Size = new System.Drawing.Size(149, 74);
            button_DeleteUser.TabIndex = 1;
            button_DeleteUser.Text = "Удалить пользователя";
            button_DeleteUser.UseVisualStyleBackColor = true;
            button_DeleteUser.Click += button_DeleteUser_Click;
            // 
            // button_AllUser
            // 
            button_AllUser.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_AllUser.Location = new System.Drawing.Point(434, 342);
            button_AllUser.Name = "button_AllUser";
            button_AllUser.Size = new System.Drawing.Size(149, 74);
            button_AllUser.TabIndex = 2;
            button_AllUser.Text = "Все пользователи";
            button_AllUser.UseVisualStyleBackColor = true;
            button_AllUser.Click += button_ChangeUser_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(37, 284);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 25);
            label1.TabIndex = 4;
            label1.Text = "Роль";
            // 
            // comboBox_Role
            // 
            comboBox_Role.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBox_Role.FormattingEnabled = true;
            comboBox_Role.Location = new System.Drawing.Point(129, 276);
            comboBox_Role.Name = "comboBox_Role";
            comboBox_Role.Size = new System.Drawing.Size(254, 33);
            comboBox_Role.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(25, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(572, 226);
            dataGridView1.TabIndex = 8;
            // 
            // run
            // 
            run.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            run.Location = new System.Drawing.Point(434, 264);
            run.Name = "run";
            run.Size = new System.Drawing.Size(149, 60);
            run.TabIndex = 9;
            run.Text = "Выполнить";
            run.UseVisualStyleBackColor = true;
            run.Click += run_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(623, 450);
            Controls.Add(run);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox_Role);
            Controls.Add(label1);
            Controls.Add(button_AllUser);
            Controls.Add(button_DeleteUser);
            Controls.Add(button_AddUser);
            Name = "AdminForm";
            Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_AddUser;
        private System.Windows.Forms.Button button_DeleteUser;
        private System.Windows.Forms.Button button_AllUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Role;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button run;
    }
}