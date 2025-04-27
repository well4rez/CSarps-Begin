using System;
using System.Collections.Generic;
using System.Data.Common;
using static PrikladMoy3.FileDataSource;


namespace PrikladMoy3
{
    /// <summary>
    /// Основной класс записи
    /// </summary>


    /// <summary>
    /// Класс записи сотрудника
    /// </summary>
    /// <summary>
    /// Интерфейс для реализации хранилища записей
    /// </summary>


    /// <summary>
    /// Хранение записей в оперативной памяти
    /// </summary>


    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
