using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CertLoader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string selectFilePath(string extensionFilter)
        {
            //uses file dialog to return selected file path, filters for parameter string
            string path;
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "Files | *" + extensionFilter + "*";
            file.ShowDialog();
            path = file.FileName;


            return path;

        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            //add service type options to combobox
            serviceType.Items.Add("PM and Cal");
            serviceType.Items.Add("Cal");
            serviceType.Items.Add("Repair");

            //Pull data from DB to datagridview
            UpdateGrid();
        }


        private int price(string service)
        {

            //Return price of service from combo box
            if (service == "PM and Cal")
            {

                return 250;
            }
            if (service == "Cal")
            {

                return 150;
            }
            if (service == "Repair")
            {

                return 350;
            }
            else
            {

                return 0;
            }



        }


        private bool ExistsInTable(string checkItem, string tableName, string columnName)
        {

            bool check = false;

            //check if cert and order numbers exist in DB
            SqlConnection conn = new SqlConnection("Data Source=.; Initial Catalog=Atlas;Integrated Security=true;");
            conn.Open();
            String query = "Select " + columnName + " FROM " + tableName;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string num = dataReader.GetString(0);

                if (checkItem == num)
                {
                    check = true;

                }


            }

            return check;


        }




        private void addBtn_Click(object sender, EventArgs e)
        {


            //Generate cert and order No's, match service to price,  store in container
            Random rnd = new Random();



            //Check to see if generated cert and order numbers exist in DB
            RetryCert:
                int certno = rnd.Next(10000000, 20000000);
                if (ExistsInTable(certno.ToString(), "CERTS", "Cert_No"))
                {

                    goto RetryCert;

                }

            RetryOrder:
                int orderno = rnd.Next(80000000, 90000000);
                if (ExistsInTable(orderno.ToString(), "ORDERS", "Order_No"))
                {

                    goto RetryOrder;

                }
                if (ExistsInTable(sntxt.Text, "TOOLS", "Serial_No"))
                {
                    MessageBox.Show("Record already exists for this tool", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //Returns price of service via combobox selection
                int cost = price(serviceType.Text);


                //add items
                CertData items = new CertData();
                items.orderNo = orderno.ToString();
                items.certNo = certno.ToString();
                items.serialNo = sntxt.Text;
                items.modelNo = modtxt.Text;
                items.cycles = cyctxt.Text;
                items.calVal = caltxt.Text;
                items.servDate = DateTime.Today.Date.ToString();
                items.servType = serviceType.Text;
                items.cost = cost.ToString();



                //Temp path for JSON
                String path = @"C:\Users\Public\" + items.serialNo + ".json";
                
                //Transfer items from container to json file
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string json = jss.Serialize(items);
                File.WriteAllText(path, json);

                //Upload Json (SP)
                uploadJSON(path);

                //delete json from temp location
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                //create pdf from container
                string pdfPath = CreatePDF(items);
                
                //Upload PDF (SP)
                uploadPDF(pdfPath, items.certNo);

                //Refresh Grid
                UpdateGrid();

        }

        private void ImportJson_Click(object sender, EventArgs e)
        {

            //Choose file, return path
            string jsonPath = selectFilePath(".json");

            //transfer to container
            CertData json = getJsonContainer(jsonPath);


            //boolean, true if data exists in DB
            if (ExistsInTable(json.serialNo, "TOOLS", "Serial_No"))
            {
                MessageBox.Show("Record already exists for this tool", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ExistsInTable(json.certNo, "CERTS", "Cert_No"))
            {
                MessageBox.Show("Record already exists for this tool", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ExistsInTable(json.orderNo, "ORDERS", "Order_No"))
            {
                MessageBox.Show("Record already exists for this tool", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //create pdf from container
            string pdfPath = CreatePDF(json);

            


            //Upload JSON, (SP)
            uploadJSON(jsonPath);

            //Upload PDF (SP)
            uploadPDF(pdfPath, json.certNo);


            UpdateGrid();


        }



        private void uploadPDF(string path, string certNo)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Atlas;Integrated Security=true;"))
            {
                con.Open();

                //Read file to byte array
                FileStream fStream = File.OpenRead(path);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                fStream.Close();

                //Use SP to Upload, passing byte array and cert number
                using (SqlCommand cmd = new SqlCommand("InsertPDF", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@file", contents);
                    cmd.Parameters.AddWithValue("@cert", certNo);
                    cmd.ExecuteNonQuery();

                }

            }
        }
        private void uploadJSON(string path)
        {

            //Upload JSON to DB, use stored procudure to add rows
            using (SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Atlas;Integrated Security=true;"))
            {
                using (SqlCommand cmd = new SqlCommand("insertJSON", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@file", path);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }
        private void UpdateGrid()
        {
            //wipe datagrid
            dataGridView1.DataSource = null;

            //Query to get standard view from DB
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Atlas;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("SELECT CERTS.Cert_No,ORDERS.Order_No, TOOLS.Serial_No," +
                                            " TOOLS.Model_No, ORDERS.Serv_Type, ORDERS.Serv_Cost,CERTS.Serv_Date " +
                                            " FROM CERTS JOIN TOOLS on CERTS.Serial_No = TOOLS.Serial_No " +
                                            "JOIN ORDERS on CERTS.Order_No = ORDERS.Order_No", con);


            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            //fill data table
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            //update datagrid
            dataGridView1.DataSource = dt;

        }


        private CertData getJsonContainer(string path)
        {

            CertData Items;

            //Read Json, transfer items to CertData container
            using (StreamReader r = new StreamReader(path))
            {

                string json = r.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Items = jss.Deserialize<CertData>(json);

                //for debugging
                //Debug.Print(Items.certNo);
                //Debug.Print(Items.serialNo);
                //Debug.Print(Items.orderNo);

                r.Close();
            }

            return Items;
        }

        private string CreatePDF(CertData Items)
        {


            string pdfPath = @"C:\Users\Public\calcert# " + Items.certNo + ".pdf";

            PdfWriter writer = new PdfWriter(pdfPath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Header
            Paragraph header = new Paragraph("CALIBRATION CERTIFICATE")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            // New line
            Paragraph newline = new Paragraph(new Text("\n"));

            document.Add(newline);
            document.Add(header);

            // Add sub-header
            Paragraph subheader = new Paragraph("Cert #: " + Items.certNo)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Add paragraph1
            Paragraph paragraph1 = new Paragraph("This is not a real cert, simply a demonstration of capability.  Picture is meaningless, data from Json in below table. ");
            document.Add(paragraph1);

            // Add image
            iText.Layout.Element.Image img = new Image(ImageDataFactory
               .Create(@"C:\Users\Public\image.jpg"))
               .SetTextAlignment(TextAlignment.CENTER);
            document.Add(img);

            // Table
            Table table = new Table(5, false);
            Cell cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Model"));
            Cell cell12 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Serial"));

            Cell cell13 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Cal Value"));
            Cell cell14 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Cycles"));

            Cell cell15 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Date"));

            Cell cell21 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(Items.modelNo));
            Cell cell22 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(Items.serialNo));
            Cell cell23 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(Items.calVal));
            Cell cell24 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(Items.cycles));
            Cell cell25 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(Items.servDate));


            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);
            table.AddCell(cell15);

            table.AddCell(cell21);
            table.AddCell(cell22);
            table.AddCell(cell23);
            table.AddCell(cell24);
            table.AddCell(cell25);


            document.Add(newline);
            document.Add(table);

            // Hyper link
            Link link = new Link("click here",
               PdfAction.CreateURI("https://www.dontclickonthis.com"));
            Paragraph hyperLink = new Paragraph("Please ")
               .Add(link.SetBold().SetUnderline()
               .SetItalic().SetFontColor(ColorConstants.BLUE))
               .Add(" to go a fake website (don't click)");

            document.Add(newline);
            document.Add(hyperLink);

     

            // Close document
            document.Close();

            //return pdf path
            return pdfPath;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //Primary Keys for DB use
            string certno = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string orderno = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string serialno = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


            EditForm Options = new EditForm();

            Options.ShowDialog();

            if (Options.viewpdf)
            {

                string pdfPath = @"C:\Users\Public\" + certno + ".pdf";

                SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Atlas;Integrated Security=true;");
                
                con.Open();

                //Select PDF with matching Cert Number
                SqlCommand cmd = new SqlCommand("SELECT Pdf FROM CERTS WHERE CERTS.Cert_No = " + certno, con);
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
                    
                //read from db to byte array
                if (dr.Read())
                {
                    byte[] fileData = (byte[])dr.GetValue(0);


                    //Write PDF to path
                    FileStream fs = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
                    BinaryWriter bw = new System.IO.BinaryWriter(fs);
                    bw.Write(fileData);
                    bw.Close();          
                }

                dr.Close();

                //Open PDF
                System.Diagnostics.Process.Start(pdfPath);

            }


            if (Options.delete)
            {
                //Delete Record (SP), pass order and cert numbers
                using (SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Atlas;Integrated Security=true;"))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteCert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@orderno", orderno);
                        cmd.Parameters.AddWithValue("@serialno", serialno);

                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                }

            }

            UpdateGrid();

        }





    }





}
