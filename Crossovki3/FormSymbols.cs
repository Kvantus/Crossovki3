﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crossovki3
{
    public partial class FormSymbols : Form
    {

        Form1 MainForm { get; set; }
        string point = "";
        string semicolon = "";
        string space = "";
        string dash = "";
        string underline = "";
        string slash = "";
        string backslash = "";
        string quotes = "";

        public FormSymbols(Form1 mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }


        private void ButtonOfSymbols_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            if (currentButton.BackColor == Color.LawnGreen)
                currentButton.BackColor = Color.Gray;
            else
                currentButton.BackColor = Color.LawnGreen;
        }

        private void BDelSymbols_Click(object sender, EventArgs e)
        {
            if (BPoint.BackColor == Color.LawnGreen)
                point = ".";
            if (BSemicolon.BackColor == Color.LawnGreen)
                semicolon = ",";
            if (BSpace.BackColor == Color.LawnGreen)
                space = " ";
            if (BDash.BackColor == Color.LawnGreen)
                dash = "-";
            if (BUnderLine.BackColor == Color.LawnGreen)
                underline = "_";
            if (BSlash.BackColor == Color.LawnGreen)
                slash = "/";
            if (BBackSlash.BackColor == Color.LawnGreen)
                backslash = "\\";
            if (BQuotes.BackColor == Color.LawnGreen)
                quotes = "\"";

            foreach (var row in MainForm.MyFilteredList)
            {
                string numberNice = row.NumberBad
                    .Replace(point, "")
                    .Replace(semicolon, "")
                    .Replace(space, "")
                    .Replace(dash, "")
                    .Replace(underline, "")
                    .Replace(slash, "")
                    .Replace(backslash, "")
                    .Replace(quotes, "");
                row.NumberNice = numberNice;
            }

            MainForm.DGVRefresh();

            SharedVariables.Point = point;
            SharedVariables.Semicolon = semicolon;
            SharedVariables.Space = space;
            SharedVariables.Dash = dash;
            SharedVariables.Underline = underline;
            SharedVariables.Slash = slash;
            SharedVariables.Backslash = backslash;
            SharedVariables.Quotes = quotes;

            // окрашивание повторяющихся - не нужно
            //List<string> coloredList = new List<string>();

            //for (int i = 0; i < MainForm.DGTable.RowCount; i++)
            //{
            //    coloredList.Add(MainForm.DGTable.Rows[i].Cells[3].Value.ToString());
            //}

            //foreach (var article in coloredList.Distinct())
            //{
            //    if (coloredList.Where(x => x == article).Count() > 1)
            //    {
            //        for (int i = 0; i < MainForm.DGTable.RowCount; i++)
            //        {
            //            if (MainForm.DGTable[3, i].Value.ToString() == article)
            //                MainForm.DGTable.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
            //        }
            //    }
            //}

            this.Close();

        }

    }
}
