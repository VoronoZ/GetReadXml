using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GetReadXml.Class
{
    internal class MyClass
    {
        public  void GetReadXml(Form form,string FileName)
        {
            try
            {

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(FileName);
                // получим корневой элемент

                XmlElement xRoot = xDoc.DocumentElement;
                if (xRoot != null)
                {
                    int Y_GroupBox = 10;
                    int Y_All = 20;

              

                    // обход всех узлов в корневом элементе
                    foreach (XmlElement xnode in xRoot.SelectNodes("parametrs"))
                    {
                        GroupBox groupBox = new GroupBox();
                        groupBox.Height = 90;
                        groupBox.Width = 260;
                       
                        ComboBox comboBox = new ComboBox();

                        groupBox.Location = new Point(10, Y_GroupBox);
                        groupBox.Text = xnode.GetAttribute("name");
                        form.Controls.Add(groupBox);

                        foreach (XmlElement node in xnode)
                        {
                            string TypeControl = node.Name;
                            Label label= new Label();  

                            switch (TypeControl)
                            {
                                #region Цифровой блок

                                case "number":
                                    NumericUpDown numeric = new NumericUpDown();
                                    label.Text = node.GetAttribute("label");
                                    label.Parent= groupBox;
                                    label.Location = new Point(10, Y_All);
                                    label.AutoSize= true;
                                    

                                    numeric.Maximum = 5000;
                                    numeric.Minimum = 100;
                                    numeric.Value = decimal.Parse(node.GetAttribute("value"));
                                    numeric.Parent = groupBox;
                                    numeric.Location = new Point(groupBox.Width - numeric.Width - 10, Y_All);
                                
                                    Y_All += 25;
                                    break;

                                #endregion

                                #region Выпадающий список

                                case "combobox":
                                    comboBox.Location = new Point(groupBox.Width - comboBox.Width - 10, Y_All);
                                    comboBox.Parent = groupBox;

                                    // Заполнение Combobox
                                  foreach(XmlElement xml in node)
                                    {
                                        comboBox.Items.Add(xml.GetAttribute("text"));
                                    }

                                    comboBox.SelectedIndex = 1;

                                    Y_All +=25;

                                    break;

                                #endregion

                            }
                        }
                        Y_All = 20;
                        Y_GroupBox = groupBox.Height + 10;
                    }
                }
            }
            catch (Exception e )
            {
                MessageBox.Show(e.Message,"Ошибка",MessageBoxButtons.OK);
            }
          
        }
    }
}
