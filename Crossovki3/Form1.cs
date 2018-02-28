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
        string timeNow = DateTime.Now.ToString().Replace(":", "-").Replace(".", "_");
        public object DGVSourse { get { return DGTable.DataSource; } set { DGTable.DataSource = value; } }
        public string myDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public DirectoryInfo WorkingDirectory;
        

        public string MyUnrecFile { get; set; }
        public string[] MyTecDocFiles { get; set; }
        public List<TecDocRows> MyTecDocTable { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public void DGVRefresh()
        {
            DGTable.Refresh();
        }

        // сединяемся с базой и обновляем таблицу DataGridView
        private void BRefresh_Click(object sender, EventArgs e)
        {
            LabelMain.Text = "Подключение к базе...";
            System.Windows.Forms.Application.DoEvents();


            try
            {
                ConnectToDataBase(Environment.UserName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Соединение не удалось");
                return;
            }



            DGTable.DataSource = MyList;

            LAbelCount.Text = "Итого: " + DGTable.RowCount;

            LabelMain.Text = "Итоговая таблица:";

            // добавляем в комбобокс уникальные значения брендов
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

        // соединяемся с базой и заполняем коллекцию MyList
        private void ConnectToDataBase(string user)
        {
            MyList = new List<UnrecRows>();
            #region Была проба ADO для одного из сотрудников, но в итоге обошлись без ADO
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
#endregion
            var myQuery = from items in content.f_REPORT_Mega_Base_Unrecognized_(null)
                          select items;
            var tempList = myQuery.ToList();

            foreach (var row in tempList)
            {

                string sup = row.Supplier;
                string partName = RecievePartName(row.Название, sup); // менаем кодировку, если поставщик входит в список неудобных

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

        // проверка названия поставщика, если совпадает с указанным списком - меняем кодировку
        private static string RecievePartName(string partName, string sup)
        {
            if (sup == "АвтоСпутник_1-2" ||
                sup == "АвтоСпутник_1-3" ||
                sup == "Ренисcанс" ||
                sup == "Нормавто (Teknorot)" ||
                sup == "ЛиАрт" ||
                sup == "Лидер Авто" ||
                sup == "Турбопорт_Reman" ||
                sup == "Турбопорт_Reman_BN" ||
                sup == "Турбопорт_New" ||
                sup == "Турбопорт_New_BN"
                )
            {
                byte[] tempBytes = Encoding.Default.GetBytes(partName);
                partName = Encoding.UTF8.GetString(tempBytes);
            }

            return partName;
        }

        // подтверждаем выбор бренда в комбобоксе
        private void BChooseBrand_Click(object sender, EventArgs e)
        {
            if (ComboBrands.SelectedItem == null)
            {
                MessageBox.Show("Не выбранд брэнд");
                return;
            }

            MyFilteredList = new List<UnrecRows>(); // получаем новуб коллекцию, с фильтром по бренду
            foreach (var item in MyList)
            {
                if (item.Brand == ComboBrands.SelectedItem.ToString())
                {
                    MyFilteredList.Add(item);
                }
            }

            DGTable.DataSource = MyFilteredList; // меняем источник DataGridView
            DGTable.Refresh();

            LAbelCount.Text = "Итого: " + DGTable.RowCount;

        }

        // вызываем форму с выбором удаляемых в артикуле символов
        private void BSymbolsForm_Click(object sender, EventArgs e)
        {
            FormSymbols formSymbols = new FormSymbols(this);
            formSymbols.Show();
        }

        // Записываем результат в xlsx файл и выводим его пользователю, чтоб он мог изменить его по своему усмотрению
        private void BGoExcel_Click(object sender, EventArgs e)
        {
            if (MyFilteredList == null)
            {
                MessageBox.Show("Необходимо отфильтровать таблицу по одному конкретному бренду");
                return;
            }

            WorkingDirectory = new DirectoryInfo($"{myDesktop}\\MegringCrosses");
            WorkingDirectory.Create();
            string fileName = WorkingDirectory + "\\" + ComboBrands.SelectedItem + " " + timeNow + ".xlsx";

            // присваиваем статической переменной имя созданного файла и отображаем его в LabelCurrentUnrec
            MyUnrecFile = fileName;
            LabelCurrentUnrec.Text = fileName;

            ExcelPackage eP;
            ExcelWorksheet sheet = GetSheet(out eP);


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

            for (int i = 2; i <= MyFilteredList.Count + 1; i++)
            {
                sheet.Cells[i, 1].Value = MyFilteredList[i - 2].Supplier;
                sheet.Cells[i, 2].Value = MyFilteredList[i - 2].Brand;
                sheet.Cells[i, 3].Value = MyFilteredList[i - 2].NumberNice;
                sheet.Cells[i, 4].Value = MyFilteredList[i - 2].NumberBad;
                sheet.Cells[i, 5].Value = MyFilteredList[i - 2].PartName;
            }

            sheet.Cells[1, 1, 1, 5].AutoFilter = true;
            //SaveExcel(eP, fileName);
            eP.SaveAs(new FileInfo(fileName));

            // открываем пользователю ексель файл, помечая повторяющиеся значение в колонке NumberNice
            OpenExcel(fileName, false);
        }

        // получаем доступ к листу и книге ексель.
        private static ExcelWorksheet GetSheet(out ExcelPackage eP)
        {
            eP = new ExcelPackage();
            ExcelWorkbook book = eP.Workbook;
            return book.Worksheets.Add("Лист1");
        }

        // открываем файл непосредственно в Екселе
        private static void OpenExcel(string fileName, bool uniq)
        {
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

                if (!uniq) // помечаем повторяющиеся значения в колонке с измененным артикулом
                {
                    Range myRange = mySheet.Range["C1"].EntireColumn;
                    myRange.FormatConditions.AddUniqueValues();
                    myRange.FormatConditions[myRange.FormatConditions.Count].SetFirstPriority();
                    myRange.FormatConditions[1].DupeUnique = XlDupeUnique.xlDuplicate;
                    myRange.FormatConditions[1].Font.Color = -16752384;
                    myRange.FormatConditions[1].Interior.Color = 13561798;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Что-то пошло не так");
            }
        }







        // Выбор файла TecDoc
        private void BOpenFileTecDoc_Click(object sender, EventArgs e)
        {
            
            if (WorkingDirectory == null)
            {
                MessageBox.Show("Для начала необходимо создать файл Unrec!");
                return;
            }

            OpenFileTecDoc.InitialDirectory = WorkingDirectory.FullName;

            if (OpenFileTecDoc.ShowDialog() == DialogResult.OK)
            {
                    MyTecDocFiles = OpenFileTecDoc.FileNames;
            }
        }


        // Множественная замена ненужных символов. Если AllOfThem - то все подряд, если нет - заменяем выбранное на этапе вызова FormSymbols
        public string MultiReplace(string start, bool allOfThem)
        {

            if (!allOfThem)
            {
                return start
                .Replace(Delimiters.Point, "")
                .Replace(Delimiters.Semicolon, "")
                .Replace(Delimiters.Space, "")
                .Replace(Delimiters.Dash, "")
                .Replace(Delimiters.Underline, "")
                .Replace(Delimiters.Slash, "")
                .Replace(Delimiters.Backslash, "")
                .Replace(Delimiters.Quotes, "");
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

            if (MyTecDocFiles == null || MyUnrecFile == null)
            {
                MessageBox.Show("Файл Текдока не выбран или файл Анрека не создан");
                return;
            }
            CreateTecDocTable(); // создаем таблицу текдока на основе выбранного пользователем файла txt
            CreateUnrecTable(); // создаем заново таблицу Анрек на основе измененного и сохраненного файла xlsx.

            List<ResultTable> resultTable = new List<ResultTable>(); // здесь будет результат слияния
            ExcelPackage eP;
            // заполняем шапку
            ExcelWorksheet sheet = GetSheet(out eP);
            sheet.Cells[1, 1].Value = "Supplier";
            sheet.Cells[1, 2].Value = "Brand";
            sheet.Cells[1, 3].Value = "UnrecNumberNice";
            sheet.Cells[1, 4].Value = "UnrecNumberBad";
            sheet.Cells[1, 5].Value = "TecDocNumberBad";
            sheet.Cells[1, 6].Value = "OEMBrand";
            sheet.Cells[1, 7].Value = "OEMNumber";
            sheet.Cells[1, 8].Value = "PartName";
            sheet.Cells[1, 9].Value = "OEMPartName";

            int counter = 2; // текущая строка в книге Ексель для заполнения
            foreach (var rowTD in MyTecDocTable)
            {
                foreach (var rowUR in MyFilteredList)
                {
                    if (rowUR.NumberNice == rowTD.NumberNice) // результат будет содержать только такие строки, в которых совпадают NumberNice (измененные артикулы)
                    {
                        resultTable.Add(new ResultTable
                        {
                            Supplier = rowUR.Supplier,
                            Brand = rowUR.Brand,
                            NumberNice = rowUR.NumberNice,
                            NumberBad = rowUR.NumberBad,
                            TDNumberBad = rowTD.NumberBad,
                            OEMBrand = rowTD.OEMBrand,
                            OEMNumber = rowTD.OEMNumber,
                            PartName = rowUR.PartName,
                            OEMPartName = rowTD.OEMPartName
                        });

                        sheet.Cells[counter, 1].Value = rowUR.Supplier;
                        sheet.Cells[counter, 2].Value = rowUR.Brand;
                        sheet.Cells[counter, 3].Value = rowUR.NumberNice;
                        sheet.Cells[counter, 4].Value = rowUR.NumberBad;
                        sheet.Cells[counter, 5].Value = rowTD.NumberBad;
                        sheet.Cells[counter, 6].Value = rowTD.OEMBrand;
                        sheet.Cells[counter, 7].Value = rowTD.OEMNumber;
                        sheet.Cells[counter, 8].Value = rowUR.PartName;
                        sheet.Cells[counter, 9].Value = rowTD.OEMPartName;
                        counter++;
                    }
                }
            }
            // наводим красоту
            sheet.Column(1).Width = 20;
            sheet.Column(2).Width = 15;
            sheet.Column(3).Width = 25;
            sheet.Column(4).Width = 25;
            sheet.Column(5).Width = 25;
            sheet.Column(6).Width = 15;
            sheet.Column(7).Width = 25;
            sheet.Column(8).Width = 55;
            sheet.Column(9).Width = 30;
            sheet.Cells[1, 1, 1, 9].AutoFilter = true;

            string fileName = WorkingDirectory + "\\" + ComboBrands.SelectedItem.ToString() + " Result " + timeNow + ".xlsx";
            //SaveExcel(eP, fileName);
            eP.SaveAs(new FileInfo(fileName));

            OpenExcel(fileName, true); // открываем результат пользователю
        }

        // сохраняем полученную таблицу в файле xlsx
        private static void SaveExcel(ExcelPackage eP, string fileName)
        {
            byte[] excelBytes = eP.GetAsByteArray();
            File.WriteAllBytes(fileName, excelBytes);
        }


        // Создание таблицы из файла ТекДок
        public void CreateTecDocTable()
        {
            
            char separator = '\t';
            MyTecDocTable = new List<TecDocRows>();


            for (int i = 0; i < MyTecDocFiles.Length; i++)
            {
                StreamReader readTecDoc = new StreamReader(MyTecDocFiles[i], Encoding.GetEncoding(1251));
                while (!readTecDoc.EndOfStream)
                {
                    string[] line = readTecDoc.ReadLine().Split(separator);

                    MyTecDocTable.Add(new TecDocRows
                    {
                        Brand = line[2],
                        NumberBad = line[3],
                        NumberNice = MultiReplace(line[3], false),
                        OEMBrand = line[0],
                        OEMNumber = MultiReplace(line[1], true),
                        OEMPartName = line[4]
                    });
                }
                readTecDoc.Close(); 
            }
        }

        // Получение таблицы из измененного сотрудниками файла Анрек
        public void CreateUnrecTable()
        {
            MyFilteredList = new List<UnrecRows>();

            FileInfo UnrecNewFile = new FileInfo(MyUnrecFile);
            ExcelPackage eP = new ExcelPackage(UnrecNewFile);
            ExcelWorkbook book = eP.Workbook;
            ExcelWorksheet sheet = book.Worksheets["Лист1"];
            

            int i = 2;
            while (sheet.Cells[i,1] != null && sheet.Cells[i,1].Value != null)
            {
                MyFilteredList.Add(new UnrecRows
                {
                    Supplier = sheet.Cells[i, 1].Value.ToString(),
                    Brand = sheet.Cells[i, 2].Value.ToString(),
                    NumberNice = sheet.Cells[i, 3].Value.ToString(),
                    NumberBad = sheet.Cells[i,4].Value.ToString(),
                    PartName = sheet.Cells[i,5].Value.ToString()
                });
                i++;
            }
        }
    }
}
