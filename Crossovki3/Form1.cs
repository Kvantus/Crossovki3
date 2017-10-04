using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            Application.DoEvents();
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

            //DGTable.Rows[1].Cells[3].Style.BackColor = Color.GreenYellow;

        }

        private void BSymbolsForm_Click(object sender, EventArgs e)
        {
            FormSymbols formSymbols = new FormSymbols(this);
            formSymbols.Show();
        }
    }
}
