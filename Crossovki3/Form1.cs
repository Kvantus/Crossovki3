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
using System.Data.SqlClient;

namespace Crossovki3
{
    public partial class Form1 : Form
    {
        Data_BaseEntities_Unrecognized content = new Data_BaseEntities_Unrecognized();
        public List<UnrecRows> MyList { get; set; }
        public List<UnrecRows> MyFilteredList { get; set; }
        public object DGVSourse { get { return DGTable.DataSource; } set { DGTable.DataSource = value; } }
        public string myDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public DirectoryInfo WorkingDirectory;

        public string MyUnrecFile { get; set; }
        public string MyTecDocFile { get; set; }
        public List<TecDocRows> MyTecDocTable { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public void DGVRefresh()
        {
            DGTable.Refresh();
        }

        private void BRefresh_Click(object sender, EventArgs e)
        {
            LabelMain.Text = "Подключение к базе...";
            System.Windows.Forms.Application.DoEvents();

            ConnectToDataBase(Environment.UserName);



            DGTable.DataSource = MyList; // закомментировать, для проверки чистого ADO.NET

            LAbelCount.Text = "Итого: " + DGTable.RowCount;

            LabelMain.Text = "Итоговая таблица:";

            List<string> uniqueRows = DGTable.Rows.Cast<DataGridViewRow>()
                           .Where(x => x.Cells[1].Value != null)
                           .Select(x => x.Cells[1].Value.ToString())
                           .Distinct()
                           .ToList();

            ComboBrands.Items.Clear();
            foreach (var row in uniqueRows)
            {
                ComboBrands.Items.Add(row);
            }

            ComboBrands.Sorted = true;
        }

        private void ConnectToDataBase(string user)
        {
            MyList = new List<UnrecRows>();
            //if (user.ToUpper() == "KAZAKOV_K1")
            //{
            //    SqlConnection KirillConnection = new SqlConnection();
            //    string connectionString = @"Data Source=master; DataBase=Data_Base; Integrated Security=True";
            //    KirillConnection.ConnectionString = connectionString;
            //    KirillConnection.Open();
            //    SqlCommand unrecCommand = new SqlCommand($"exec [dbo].[_REPORT_Mega_Base_Unrecognized_]", KirillConnection);
            //    SqlDataReader readerUnrec = unrecCommand.ExecuteReader();
            //    while (readerUnrec.Read())
            //    {
            //        string partName = readerUnrec["Название"].ToString();
            //        string sup = readerUnrec["Supplier"].ToString();

            //        partName = RecievePartName(partName, sup);

            //        MyList.Add(new UnrecRows
            //        {
            //            Supplier = readerUnrec["Supplier"].ToString(),
            //            Brand = readerUnrec["Производитель"].ToString(),
            //            NumberBad = readerUnrec["Номер_Производителя"].ToString(),
            //            PartName = partName,

            //        });
            //    }
            //}
            //else
            //{
            var myQuery = from items in content.f_REPORT_Mega_Base_Unrecognized_(null)
                          select items;
            var tempList = myQuery.ToList();

            foreach (var row in tempList)
            {
                string partName = row.Название;
                string sup = row.Supplier;

                partName = RecievePartName(partName, sup);
                MyList.Add(new UnrecRows
                {
                    Supplier = row.Supplier,
                    Brand = row.Производитель,
                    NumberBad = row.Номер_Производителя,
                    PartName = partName
                });
            }
            //}


        }

        private static string RecievePartName(string partName, string sup)
        {
            if (sup == "АвтоСпутник_1-2" ||
                sup == "АвтоСпутник_1-3" ||
                sup == "Ренисcанс" ||
                sup == "Нормавто (Teknorot)" ||
                sup == "ЛиАрт")
            {
                byte[] tempBytes = Encoding.Default.GetBytes(partName);
                partName = Encoding.UTF8.GetString(tempBytes);
            }

            return partName;
        }

        private void BChooseBrand_Click(object sender, EventArgs e)
        {
            if (ComboBrands.SelectedItem == null)
            {
                MessageBox.Show("Не выбранд брэнд");
                return;
            }

            MyFilteredList = new List<UnrecRows>();
            foreach (var item in MyList)
            {
                if (item.Brand == ComboBrands.SelectedItem.ToString())
                {
                    MyFilteredList.Add(item);
                }
            }

            DGTable.DataSource = MyFilteredList;
            DGTable.Refresh();

            LAbelCount.Text = "Итого: " + DGTable.RowCount;

        }

        private void BSymbolsForm_Click(object sender, EventArgs e)
        {
            FormSymbols formSymbols = new FormSymbols(this);
            formSymbols.Show();
        }

        private void BGoExcel_Click(object sender, EventArgs e)
        {
            string timeNow = DateTime.Now.ToString().Replace(":", "-").Replace(".", "_");
            WorkingDirectory = new DirectoryInfo($"{myDesktop}\\MegringCrosses");
            WorkingDirectory.Create();
            string fileName = WorkingDirectory + "\\" + ComboBrands.SelectedItem + " " + timeNow + ".xlsx";

            // присваиваем статической переменной имя созданного файла и отображаем его в LabelCurrentUnrec
            MyUnrecFile = fileName;
            LabelCurrentUnrec.Text = fileName;

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

            for (int i = 2; i <= MyFilteredList.Count; i++)
            {
                sheet.Cells[i, 1].Value = MyFilteredList[i - 2].Supplier;
                sheet.Cells[i, 2].Value = MyFilteredList[i - 2].Brand;
                sheet.Cells[i, 3].Value = MyFilteredList[i - 2].NumberNice;
                sheet.Cells[i, 4].Value = MyFilteredList[i - 2].NumberBad;
                sheet.Cells[i, 5].Value = MyFilteredList[i - 2].PartName;
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


            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Что-то пошло не так");
            }
        }


        private void BOpenFileTecDoc_Click(object sender, EventArgs e)
        {
            if (WorkingDirectory == null)
            {
                MessageBox.Show("Для начала необходимо создать файл Unrec!");
                return;
            }

            OpenFileUnrec.InitialDirectory = WorkingDirectory.FullName;

            if (OpenFileUnrec.ShowDialog() == DialogResult.OK)
            {
                MyTecDocFile = OpenFileUnrec.FileName;
                LabelCurrentTecDoc.Text = MyTecDocFile;
            }
        }





        // Создание таблицы из файла ТекДок
        public void CreateTecDocTable()
        {
            MyTecDocTable = new List<TecDocRows>();
            StreamReader readTecDoc = new StreamReader(MyTecDocFile);
            while (!readTecDoc.EndOfStream)
            {
                string[] line = readTecDoc.ReadLine().Split('\t');
                MyTecDocTable.Add(new TecDocRows
                {
                    Brand = line[0],
                    NumberBad = line[1],
                    NumberNice = MultiReplace(line[1], false),
                    OEMBrand = line[2],
                    OEMNumber = line[3],
                    OEMPartName = MultiReplace(line[4], true)
                });
            }
        }

        // Множественная замена ненужных символов. Если AllOfThem - то все подряд, если нет - заменяем выбранное на этапе FormSymbols
        public string MultiReplace(string start, bool allOfThem)
        {

            if (!allOfThem)
            {
                return start
                .Replace(SharedVariables.Point, "")
                .Replace(SharedVariables.Semicolon, "")
                .Replace(SharedVariables.Space, "")
                .Replace(SharedVariables.Dash, "")
                .Replace(SharedVariables.Underline, "")
                .Replace(SharedVariables.Slash, "")
                .Replace(SharedVariables.Backslash, "")
                .Replace(SharedVariables.Quotes, "");
            }
            else
            {
                return start
                .Replace(".", "")
                .Replace(",", "")
                .Replace(" ", "")
                .Replace("-", "")
                .Replace("_", "")
                .Replace("/", "")
                .Replace("\\", "")
                .Replace("\"", "");
            }
        }

        // Объединение Текдока и Анрека
        private void BMergeThem_Click(object sender, EventArgs e)
        {

            if (MyTecDocFile == null)
            {

                return;
            }
            CreateTecDocTable();
        }
    }
}
