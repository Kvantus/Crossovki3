using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Crossovki3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (DateTime.Now > new DateTime(2018, 4, 6))
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
