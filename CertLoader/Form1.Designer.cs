
namespace CertLoader
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ImportJson = new System.Windows.Forms.Button();
            this.sntxt = new System.Windows.Forms.TextBox();
            this.modtxt = new System.Windows.Forms.TextBox();
            this.caltxt = new System.Windows.Forms.TextBox();
            this.cyctxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.serviceType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(410, 39);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(748, 395);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ImportJson
            // 
            this.ImportJson.Location = new System.Drawing.Point(178, 28);
            this.ImportJson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ImportJson.Name = "ImportJson";
            this.ImportJson.Size = new System.Drawing.Size(90, 28);
            this.ImportJson.TabIndex = 1;
            this.ImportJson.Text = "File..";
            this.ImportJson.UseVisualStyleBackColor = true;
            this.ImportJson.Click += new System.EventHandler(this.ImportJson_Click);
            // 
            // sntxt
            // 
            this.sntxt.Location = new System.Drawing.Point(136, 38);
            this.sntxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sntxt.Name = "sntxt";
            this.sntxt.Size = new System.Drawing.Size(132, 22);
            this.sntxt.TabIndex = 2;
            // 
            // modtxt
            // 
            this.modtxt.Location = new System.Drawing.Point(136, 70);
            this.modtxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modtxt.Name = "modtxt";
            this.modtxt.Size = new System.Drawing.Size(132, 22);
            this.modtxt.TabIndex = 3;
            // 
            // caltxt
            // 
            this.caltxt.Location = new System.Drawing.Point(136, 102);
            this.caltxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.caltxt.Name = "caltxt";
            this.caltxt.Size = new System.Drawing.Size(132, 22);
            this.caltxt.TabIndex = 4;
            // 
            // cyctxt
            // 
            this.cyctxt.Location = new System.Drawing.Point(136, 134);
            this.cyctxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cyctxt.Name = "cyctxt";
            this.cyctxt.Size = new System.Drawing.Size(132, 22);
            this.cyctxt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "SN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cal Val:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Service:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cycles:";
            // 
            // serviceType
            // 
            this.serviceType.FormattingEnabled = true;
            this.serviceType.Location = new System.Drawing.Point(136, 167);
            this.serviceType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serviceType.Name = "serviceType";
            this.serviceType.Size = new System.Drawing.Size(132, 24);
            this.serviceType.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.sntxt);
            this.groupBox1.Controls.Add(this.serviceType);
            this.groupBox1.Controls.Add(this.modtxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.caltxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cyctxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(38, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(324, 310);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add a Record";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(180, 257);
            this.addBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(90, 28);
            this.addBtn.TabIndex = 13;
            this.addBtn.Text = "Add";
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ImportJson);
            this.groupBox2.Location = new System.Drawing.Point(40, 357);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(322, 77);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import JSON Record";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Select a JSON File:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "MainForm";
            this.Text = "CertLoader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ImportJson;
        private System.Windows.Forms.TextBox sntxt;
        private System.Windows.Forms.TextBox modtxt;
        private System.Windows.Forms.TextBox caltxt;
        private System.Windows.Forms.TextBox cyctxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox serviceType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
    }
}

