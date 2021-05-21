namespace ComputerRepairView
{
    partial class FormSecondRec
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
            this.dataGridViewFirstReq = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameEmpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirstReq)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFirstReq
            // 
            this.dataGridViewFirstReq.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewFirstReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFirstReq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.surnameEmpl,
            this.surnameCust,
            this.work});
            this.dataGridViewFirstReq.Location = new System.Drawing.Point(-1, -3);
            this.dataGridViewFirstReq.Name = "dataGridViewFirstReq";
            this.dataGridViewFirstReq.Size = new System.Drawing.Size(350, 467);
            this.dataGridViewFirstReq.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // surnameEmpl
            // 
            this.surnameEmpl.HeaderText = "Фамилия исполнителя";
            this.surnameEmpl.Name = "surnameEmpl";
            // 
            // surnameCust
            // 
            this.surnameCust.HeaderText = "Фамили заказчика";
            this.surnameCust.Name = "surnameCust";
            // 
            // work
            // 
            this.work.HeaderText = "Работа";
            this.work.Name = "work";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Создать запрос";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormSecondRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewFirstReq);
            this.Name = "FormSecondRec";
            this.Text = "FormSecondRec";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirstReq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFirstReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameEmpl;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn work;
        private System.Windows.Forms.Button button1;
    }
}