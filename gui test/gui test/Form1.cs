using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

using System.IO; //input and output

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace gui_test
{
    public partial class Form1 : Form
    {
        int[] com_mem = new int[5];

        public Form1()
        {
            InitializeComponent();
        }


        private void frankieBox_CheckedChanged(object sender, EventArgs e)
        {
            if (frankieBox.Checked)
                com_mem[0] = 1;
        }

        private void jackBox_CheckedChanged(object sender, EventArgs e)
        {
            if (jackBox.Checked)
                com_mem[1] = 1;
        }

        private void janBox_CheckedChanged(object sender, EventArgs e)
        {
            if (janBox.Checked)
                com_mem[2] = 1;
        }

        private void nikBox_CheckedChanged(object sender, EventArgs e)
        {
            if (nikBox.Checked)
                com_mem[3] = 1;
        }

        private void tomBox_CheckedChanged(object sender, EventArgs e)
        {
            if (tomBox.Checked)
                com_mem[4] = 1;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            string nameText = nameBox.Text;
            string whereText = whereBox.Text;
            string whenText = whenBox.Text;



            string memText = "";

            if (com_mem[0] == 1)
                memText = memText + frankieBox.Text + ',';
            if (com_mem[1] == 1)
                memText = memText + jackBox.Text + ',';
            if (com_mem[2] == 1)
                memText = memText + janBox.Text + ',';
            if (com_mem[3] == 1)
                memText = memText + nikBox.Text + ',';
            if (com_mem[4] == 1)
                memText = memText + tomBox.Text;

            string attText = attBox.Text;

            string prepText = prepBox.Text;

            string exeText = exeBox.Text;

            string recText = recBox.Text;

            string conText = conBox.Text;

            
            string[] passString = { nameText, whereText, whenText, memText, attText, prepText, exeText, recText, conText };
            pdfTestSharp(passString);


        }

        enum field { what=0, where, when, who, att, prep, exe, rec, con };
        private void pdfTestSharp(string[] passString)
        {
            //string path = @"D:\c_sharp_tests\";

            string whenFile = passString[(int)field.when].Replace("/", "-");
            string fileName = passString[(int)field.what] + passString[(int)field.when] + ".pdf";
            //FileStream fs = new FileStream(path+fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            int cols = 3;
            PdfPTable table = new PdfPTable(cols);
            PdfPCell titleCell = new PdfPCell(new Phrase("Event report"));
            titleCell.Colspan = cols;
            titleCell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(titleCell);

            PdfPCell whatCell = new PdfPCell(new Phrase("Name of the event"));
            table.AddCell(whatCell);
            PdfPCell whatEntryCell = new PdfPCell(new Phrase(passString[(int) field.what]));
            whatEntryCell.Colspan = cols - 1;
            table.AddCell(whatEntryCell);

            PdfPCell whenCell = new PdfPCell(new Phrase("When"));
            table.AddCell(whenCell);
            PdfPCell whenEntryCell = new PdfPCell(new Phrase(passString[(int)field.when]));
            whenEntryCell.Colspan = cols - 1;
            table.AddCell(whenEntryCell);

            PdfPCell whereCell = new PdfPCell(new Phrase("Where"));
            table.AddCell(whereCell);
            PdfPCell whereEntryCell = new PdfPCell(new Phrase(passString[(int)field.where]));
            whereEntryCell.Colspan = cols - 1;
            table.AddCell(whereEntryCell);

            PdfPCell whoCell = new PdfPCell(new Phrase("Who"));
            table.AddCell(whoCell);
            PdfPCell whoEntryCell = new PdfPCell(new Phrase(passString[(int)field.who]));
            whoEntryCell.Colspan = cols - 1;
            table.AddCell(whoEntryCell);

            PdfPCell attCell = new PdfPCell(new Phrase("Attendance"));
            table.AddCell(attCell);
            PdfPCell attEntryCell = new PdfPCell(new Phrase(passString[(int)field.att]));
            attEntryCell.Colspan = cols - 1;
            table.AddCell(attEntryCell);

            PdfPCell prepCell = new PdfPCell(new Phrase("Preparation"));
            table.AddCell(prepCell);
            PdfPCell prepEntryCell = new PdfPCell(new Phrase(passString[(int)field.prep]));
            prepEntryCell.Colspan = cols - 1;
            table.AddCell(prepEntryCell);

            PdfPCell exeCell = new PdfPCell(new Phrase("Execution"));
            table.AddCell(exeCell);
            PdfPCell exeEntryCell = new PdfPCell(new Phrase(passString[(int)field.exe]));
            exeEntryCell.Colspan = cols - 1;
            table.AddCell(exeEntryCell);

            PdfPCell recCell = new PdfPCell(new Phrase("Recommendation"));
            table.AddCell(recCell);
            PdfPCell recEntryCell = new PdfPCell(new Phrase(passString[(int)field.rec]));
            recEntryCell.Colspan = cols - 1;
            table.AddCell(recEntryCell);

            PdfPCell conCell = new PdfPCell(new Phrase("Conclusion"));
            table.AddCell(conCell);
            PdfPCell conEntryCell = new PdfPCell(new Phrase(passString[(int)field.con]));
            conEntryCell.Colspan = cols - 1;
            table.AddCell(conEntryCell);

            doc.Add(table);
            doc.Close();
        }

    }

    

}

