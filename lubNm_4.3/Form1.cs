using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lubNm_4._3
{
    public partial class Form1 : Form
    {
        DataTable DT;
        public static string[] alf = new string[3] { "S", "P", "A" };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            { DT.Close();
                Data.table.Rows.Clear();
                Data.table.Columns.Clear();
                Data.dataSet.Tables.Clear();
                Data.dataSet.Clear();
              
                // Data.column.Dispose();
                // Data.row.di
            }

            catch (System.NullReferenceException) { }
            finally { 
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.DefaultExt = "*.txt;";
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Data.rulleIN.Clear();
                Data.rulleOut.Clear();
                Data.path = ofd.FileName;
                Data.parse();
            foreach(string str in Data.rulleIN)
            {
                richTextBox1.Text += str +"=>"+ Data.rulleIN[str] + "\n";
            }
            richTextBox1.Text += "#########################\n";
            foreach (string str in Data.rulleOut)
            {
                richTextBox1.Text += str + "=>" + Data.rulleOut[str] + "\n";
            }
                DT = new DataTable();
               
                DT.Show();
                
            }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rull IN = new Rull();
            Rull OUT = new Rull();
            IN.setVn(alf);
            OUT.setVn(alf);
            IN.ListRull(DT.A, DT.B);
            OUT.ListRull(DT.A, DT.C);
            IN.parseIt(textBox1.Text);

            richTextBox1.Text = "Разбираем цепочку:\n\n";
            IN.result.Reverse();
            foreach (string str in IN.result)
            {
                richTextBox1.Text += str.Remove(str.IndexOf("#")) + '\n';
            }


            try
            {
                IN.build(IN.listRull, "S", IN.position);
                OUT.build(IN.listRull, "S", IN.position);

                richTextBox1.Text += "Строим входную цепочцу:\n\n";
                foreach (string str in IN.buildResult)
                {
                    richTextBox1.Text += str + '\n';
                }
                richTextBox1.Text += "Строим выходную цепочцу:\n\n";
                foreach (string str in OUT.buildResult)
                {
                    richTextBox1.Text += str + '\n';
                }

                richTextBox1.Text += Data.VT_IN;
                richTextBox1.Text += Data.VT_OUT;

            }
            catch (Exception) { richTextBox1.Text = "Не удалось разобрать цепочку";}
/*
            foreach (int str in IN.listRull)
            {
                richTextBox1.Text += str.ToString() + '\n';
            }*/

           
            /*  foreach(int i in IN.position)
                  richTextBox1.Text += i.ToString() + '\n';
             */
        }
    }
    
}
