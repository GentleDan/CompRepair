namespace ComputerRepairView
{
    partial class FormThirdReq
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
            this.surnameCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.surnameCust,
            this.price});
            this.dataGridViewFirstReq.Location = new System.Drawing.Point(12, -7);
            this.dataGridViewFirstReq.Name = "dataGridViewFirstReq";
            this.dataGridViewFirstReq.Size = new System.Drawing.Size(249, 467);
            this.dataGridViewFirstReq.TabIndex = 3;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // surnameCust
            // 
            this.surnameCust.HeaderText = "Фамилия заказчика";
            this.surnameCust.Name = "surnameCust";
            // 
            // price
            // 
            this.price.HeaderText = "Затраты";
            this.price.Name = "price";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "Создать запрос";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormThirdReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewFirstReq);
            this.Name = "FormThirdReq";
            this.Text = "FormThirdReq";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirstReq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFirstReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.Button button1;
    }
}