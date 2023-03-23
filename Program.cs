using GetReadXml.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetReadXml
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
           Form form = new Form1();
           string FileName = @"D:\\Приложения Visual Basic\\GetReadXml\\Parametrs.xml";

           MyClass myClass = new MyClass();
           myClass.GetReadXml(form, FileName);

           form.ShowDialog();
          
        }
    }
}
