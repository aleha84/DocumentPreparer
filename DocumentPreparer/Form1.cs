using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using DocumentPreparer.Processers;
using Novacode;
using DocumentPreparer.Retrievers;

namespace DocumentPreparer
{
    public partial class Form1 : Form
    {
        private readonly string applicationDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        IProcesser _processer;
        ITemplateProcesser _templateProcesser;

        public Form1()
        {
            InitializeComponent();
            _processer = new PdfProcesser(new PropertiesRetrievers());
            _templateProcesser = new TemplateProcesser();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofdPdf.InitialDirectory = applicationDirectory;
            ofdPdf.Filter = "pdf файлы (*.pdf)|*.pdf";
            ofdPdf.Multiselect = false;

            ofdDocx.InitialDirectory = applicationDirectory;
            ofdDocx.Filter = "DocX файлы (*.docx)|*.docx";
            ofdDocx.Multiselect = false;

            var pdfsInRoot = System.IO.Directory.GetFiles(applicationDirectory, "*.pdf");
            if (pdfsInRoot.Any())
            {
                tbInputPdfPath.Text = pdfsInRoot.FirstOrDefault();
            }

            if(System.IO.File.Exists(applicationDirectory + "\\template.docx"))
            {
                tbTemplatePath.Text = applicationDirectory + "\\template.docx";
            }
        }

        private void btnSelectPdf_Click(object sender, EventArgs e)
        {
            if (ofdPdf.ShowDialog() == DialogResult.OK)
            {
                tbInputPdfPath.Text = ofdPdf.FileName;
            }
        }

        private void btnSelectTemplate_Click(object sender, EventArgs e)
        {
            if (ofdDocx.ShowDialog() == DialogResult.OK)
            {
                tbTemplatePath.Text = ofdDocx.FileName;
            }
        }

        private void ValidateInput()
        {
            if (string.IsNullOrEmpty(tbTemplatePath.Text))
                throw new ArgumentException("Файл шаблона не выбран!");

            if (string.IsNullOrEmpty(tbInputPdfPath.Text))
                throw new ArgumentException("Исходный файл не выбран!");

            if (!System.IO.File.Exists(tbTemplatePath.Text))
                throw new ArgumentException("Файл шаблона не существует!");

            if (!System.IO.File.Exists(tbInputPdfPath.Text))
                throw new ArgumentException("Исходный файл не существует!");

            if (!System.IO.Path.GetExtension(tbTemplatePath.Text).Equals(".docx", StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentException("Файл шаблона должен иметь расширение DOCX!");

            if (!System.IO.Path.GetExtension(tbInputPdfPath.Text).Equals(".pdf", StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentException("Исходный файл должен иметь расширение PDF!");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                var documentModel = _processer.Process(tbInputPdfPath.Text);

                var docx = _templateProcesser.Process(tbTemplatePath.Text, documentModel);

                var savePath = applicationDirectory + "\\" + System.IO.Path.GetFileNameWithoutExtension(tbInputPdfPath.Text) + ".docx";
                if (System.IO.File.Exists(savePath))
                {
                    if(MessageBox.Show(string.Format("Файл '{0}' уже существует, заменить?", savePath), "Заменить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.IO.File.Delete(savePath);
                    }
                    else
                    {
                        savePath = applicationDirectory + "\\" + System.IO.Path.GetFileNameWithoutExtension(tbInputPdfPath.Text) + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".docx";
                    }
                }  

                docx.SaveAs(savePath);

                MessageBox.Show(string.Format("Файл '{0}' создан", savePath), "Файл создан", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
