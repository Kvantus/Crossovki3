using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace Crossovki3
{
    public partial class Form1 : Form
    {
        Data_BaseEntities_Unrecognized content = new Data_BaseEntities_Unrecognized();
        public List<f_REPORT_Mega_Base_Unrecognized__Result> MyList { get; set; }
        public List<f_REPORT_Mega_Base_Unrecognized__Result> MyFilteredList { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void BRefresh_Click(object sender, EventArgs e)
        {
            LabelMain.Text = "Подключение к базе...";
            System.Windows.Forms.Application.DoEvents();
            var myQuery = from items in content.f_REPORT_Mega_Base_Unrecognized_(null)
                          select items;
            MyList = myQuery.ToList();
            foreach (var row in MyList)
            {
                if (row.Supplier == "АвтоСпутник_1-2" ||
                    row.Supplier == "АвтоСпутник_1-3" ||
                    row.Supplier == "Ренисcанс" ||
                    row.Supplier == "Нормавто (Teknorot)" ||
                    row.Supplier == "ЛиАрт")
                {
                    byte[] tempBytes = Encoding.Default.GetBytes(row.Название);
                    row.Название = Encoding.UTF8.GetString(tempBytes);
                }
            }

            DGTable.DataSource = MyList;

            LAbelCount.Text = "Итого: " + DGTable.RowCount;

            LabelMain.Text = "Итоговая таблица:";

            List<string> uniqueRows = DGTable.Rows.Cast<DataGridViewRow>()
                           .Where(x => x.Cells[2].Value != null)
                           .Select(x => x.Cells[2].Value.ToString())
                           .Distinct()
                           .ToList();

            ComboBrands.Items.Clear();
            foreach (var row in uniqueRows)
            {
                ComboBrands.Items.Add(row);
            }

            ComboBrands.Sorted = true;
        }

        private void BChooseBrand_Click(object sender, EventArgs e)
        {
            if (ComboBrands.SelectedItem == null)
            {
                MessageBox.Show("Не выбранд брэнд");
                return;
            }

            MyFilteredList = new List<f_REPORT_Mega_Base_Unrecognized__Result>();
            foreach (var item in MyList)
            {
                if (item.Производитель == ComboBrands.SelectedItem.ToString())
                {
                    MyFilteredList.Add(item);
                }
            }

            DGTable.DataSource = MyFilteredList;

            LAbelCount.Text = "Итого: " + DGTable.RowCount;

        }

        private void BSymbolsForm_Click(object sender, EventArgs e)
        {
            FormSymbols formSymbols = new FormSymbols(this);
            formSymbols.Show();
        }

        private void BTestik_Click(object sender, EventArgs e)
        {
            string timeNow = DateTime.Now.ToString().Replace(":", "-").Replace(".", "_");
            string fileName = @"\\server\out\Отдел Развития\Виктор\Unrec" + ComboBrands.SelectedItem + timeNow + ".xlsx";
            ExcelPackage eP = new ExcelPackage();
            ExcelWorkbook book = eP.Workbook;
            ExcelWorksheet sheet = book.Worksheets.Add("Лист1");

            // создать доп коллекцию с тирешными (или безтирешными) номерами
            // создать алгоритм для проверки: если есть 2+ безтирешных повторяющихся номера, то удалить строчку либо с пустым названием,
            // либо где безтирешный номер = тирешному
            for (int i = 1; i <= MyFilteredList.Count; i++)
            {
                sheet.Cells[i, 1].Value = MyFilteredList[i-1].Supplier.ToString();
                sheet.Cells[i, 2].Value = MyFilteredList[i - 1].Производитель.ToString();
                sheet.Cells[i, 4].Value = MyFilteredList[i - 1].Название.ToString();

            }



            byte[] excelBytes = eP.GetAsByteArray();
            File.WriteAllBytes(fileName, excelBytes);

            //var excel = new Excel.Application();
            //try
            //{
            //    excel = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application")
            //            as Excel.Application;
            //}
            //catch (Exception)
            //{
            //    excel = new Excel.Application();
            //    excel.Visible = true;
            //}
            //Workbook myBook = excel.Workbooks.Add();
            //Worksheet mySheet = myBook.Worksheets[1];
            //mySheet.Cells[1, 1].Value = MyFilteredList[1].Название;
        }
    }
}
