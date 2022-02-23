
namespace CertLoader
{
    partial class EditForm
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
            this.ViewPDFbtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewPDFbtn
            // 
            this.ViewPDFbtn.Location = new System.Drawing.Point(49, 18);
            this.ViewPDFbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ViewPDFbtn.Name = "ViewPDFbtn";
            this.ViewPDFbtn.Size = new System.Drawing.Size(140, 29);
            this.ViewPDFbtn.TabIndex = 0;
            this.ViewPDFbtn.Text = "View PDF";
            this.ViewPDFbtn.UseVisualStyleBackColor = true;
            this.ViewPDFbtn.Click += new System.EventHandler(this.ViewPDFbtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(49, 59);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(140, 29);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "Delete Record";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 114);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.ViewPDFbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ViewPDFbtn;
        private System.Windows.Forms.Button DeleteBtn;
    }
}