using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertLoader
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        public bool delete;
        public bool viewpdf;
   

        private void EditForm_Load(object sender, EventArgs e)
        {
            delete = false;
            viewpdf = false;

        }

        private void ViewPDFbtn_Click(object sender, EventArgs e)
        {

            viewpdf = true;
            this.Close();


        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            delete = true;
            this.Close();

        }
    }
}
