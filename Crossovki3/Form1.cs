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
        public List<UnrecRows> MyUnrecTable { get; set; }
        public List<TecDocRows> MyTecDocTable { get; set; }
        public object DGVSourse { get { return DGTable.DataSource; } set { DGTable.DataSource = value; } }

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
            string fileName = @"\\server\out\Отдел Развития\Виктор\" + ComboBrands.SelectedItem + " " + timeNow + ".xlsx";
            ExcelPackage eP = new ExcelPackage();
            ExcelWorkbook book = eP.Workbook;
            ExcelWorksheet sheet = book.Worksheets.Add("Лист1");

            // todo создать доп коллекцию с тирешными (или безтирешными) номерами
            // todo создать алгоритм для проверки: если есть 2+ безтирешных повторяющихся номера, то удалить строчку либо с пустым названием,
            // todo либо где безтирешный номер = тирешному

            sheet.Column(1).Width = 26;
            sheet.Column(2).Width = 19;
            sheet.Column(3).Width = 29;
            sheet.Column(4).Width = 29;
            sheet.Column(5).Width = 110;

            sheet.Cells[1, 1].Value = "Supplier";
            sheet.Cells[1, 2].Value = "Brand";
            sheet.Cells[1, 3].Value = "NumberNice";
            sheet.Cells[1, 4].Value = "NumberBad";
            sheet.Cells[1, 5].Value = "PartName";

            for (int i = 2; i <= MyUnrecTable.Count; i++)
            {
                sheet.Cells[i, 1].Value = MyUnrecTable[i-1].Supplier;
                sheet.Cells[i, 2].Value = MyUnrecTable[i - 1].Brand;
                sheet.Cells[i, 3].Value = MyUnrecTable[i - 1].NumberNice;
                sheet.Cells[i, 4].Value = MyUnrecTable[i - 1].NumberBad;
                sheet.Cells[i, 5].Value = MyUnrecTable[i - 1].PartName;

            }
            

            byte[] excelBytes = eP.GetAsByteArray();
            File.WriteAllBytes(fileName, excelBytes);

            var excel = new Excel.Application();
            try
            {
                excel = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application")
                        as Excel.Application;
            }
            catch (Exception)
            {
                excel = new Excel.Application();
                excel.Visible = true;
            }
            Workbook myBook = excel.Workbooks.Open(fileName);
            Worksheet mySheet = myBook.Worksheets[1];
            Range myRange = mySheet.Range["C1"].EntireColumn;
            myRange.FormatConditions.AddUniqueValues();
            myRange.FormatConditions[myRange.FormatConditions.Count].SetFirstPriority();
            myRange.FormatConditions[1].DupeUnique = XlDupeUnique.xlDuplicate;
            myRange.FormatConditions[1].Font.Color = -16752384;
            myRange.FormatConditions[1].Interior.Color = 13561798;
            mySheet.Columns["A:E"].AutoFilter();
        }
    }
}
