using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace lubNm_4._3
{
    public partial class DataTable : Form
    {
        public static int count=0;
        public  string [] A;
        
        public  string[] B;
        public string[] C;
        public DataTable()

        {
            InitializeComponent();
            buildTable();
           // Thread myThread = new Thread(func);
            //this.Width = dataGridView1.ColumnCount * 70 + 8;
           // this.Height = dataGridView1.RowCount * 25 + 67;
           // this.Width = maxl() + 20;
            Thread.Sleep(100); ;
        }

        void buildTable()
        {
            /* dataGridView1.Columns.Add("VN", "VN");
             dataGridView1.Columns.Add("IN", "IN");
             dataGridView1.Columns.Add("OUT", "OUT");

             foreach (string str in Data.rulleIN)
             {
                 foreach (char ch in Data.rulleIN[str])
                 {
                     if (ch == ',') count++;
                     dataGridView1.Rows.Add(str, Data.rulleIN[str]);
                 }
                 count++;
             }

            

                 dataGridView1.Rows.Add(count);*/

            textBox1.Text = Data.VN;
            textBox2.Text = Data.VT_IN;
            textBox3.Text = Data.VT_OUT;
            textBox4.Text = Data.startsimpbol;
            dataGridView1.DataSource = Data.table;
            
            
        }
        private int maxl()
        { int maxl = 0;
           
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                maxl += dataGridView1.Columns[j].Width;
                }
            return maxl;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // this.Width = dataGridView1.ColumnCount * dataGridView1.ColumnHeaders + 8;
            //this.Width = dataGridView1.RowHeadersWidth
           // this.Height = dataGridView1.RowCount * dataGridView1.ColumnHeadersHeight + dataGridView1.ColumnHeadersHeight *5;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {/*  int a = e.ColumnIndex;
            int b = e.RowIndex;
            if (a==0) (dataGridView1.Columns[a].[e])
           // e.ColumnIndex.
          //  this.Width = maxl()+20;*/
        }
        void func()
        {
            this.Width = maxl() + 20;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A = new string[dataGridView1.Rows.Count - 1];
            B = new string[dataGridView1.Rows.Count - 1];
            C = new string[dataGridView1.Rows.Count - 1];
            int i = 0;
                Data.VN= textBox1.Text ;
                Data.VT_IN = textBox2.Text ;
                Data.VT_OUT= textBox3.Text;
                Data.startsimpbol= textBox4.Text;

            for (i=0; i< dataGridView1.Rows.Count - 1;i++)
            {
                C[i] = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                B[i] = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                A[i] = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (dataGridView1.CurrentCell.ColumnIndex == 0 && !textBox1.Text.Contains(ch)&&!(ch == 8 || ch == 127))
            {
                e.Handled = true;
                richTextBox1.Text = "В левой части правила могут находиться только символы принадлежащие нетерминальному алфавиту";
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 1 && !textBox2.Text.Contains(ch) && !textBox1.Text.Contains(ch) && !(ch == 8 || ch == 127))
            {
                e.Handled = true;
                richTextBox1.Text = "В правой части правила могут находиться только символы принадлежащие нетерминальному или входному терминальному алфавиту";
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 2 && !textBox3.Text.Contains(ch) && !textBox1.Text.Contains(ch) && !(ch == 8 || ch == 127))
            {
                e.Handled = true;
                richTextBox1.Text = "В правой части правила могут находиться только символы принадлежащие нетерминальному или выходному терминальному алфавиту";
            }


            //  if (dataGridView1.col)
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch == 8 || ch == 127)) { }
            else if (textBox1.Text.Contains(ch))
            {
                e.Handled = true;
                richTextBox1.Text = "Символы нетерминального алфавита не должны повторяться";
                
            }

            else if(((ch > 0 && ch < 65) || (ch > 91))&&(ch !=0|| ch != 127))
            {
                
                e.Handled = true;
                richTextBox1.Text = "Для нетерминального алфавита используются только Заглавные латинские Буквы";
            }


            else
            {
                e.Handled = true;
                if (textBox1.Text.Length>0&& textBox1.Text.Substring(textBox1.Text.Length-1) != ",")
                {
                    textBox1.Text += "," + ch;
                }
                else textBox1.Text += ch;
                richTextBox1.Text = "";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch == 8 || ch == 127)) { }
            else if (textBox2.Text.Contains(ch))
            {
                e.Handled = true;
                richTextBox1.Text = "Символы алфавита не должны повторяться";

            }

            else if ((ch >= 65 && ch <= 91) && (ch != 0 || ch != 127))
            {

                e.Handled = true;
                richTextBox1.Text = "Заглавные латинские буквы используются только для нетерминального алфавита";
            }


            else
            {
                e.Handled = true;
                if (textBox2.Text.Length > 0 && textBox2.Text.Substring(textBox2.Text.Length - 1) != ",")
                {
                    textBox2.Text += "," + ch;
                }
                else textBox2.Text += ch;
                richTextBox1.Text = "";
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch == 8 || ch == 127)) { }
            else if (textBox3.Text.Contains(ch))
            {
                e.Handled = true;
                richTextBox1.Text = "Символы алфавита не должны повторяться";

            }

            else if ((ch >= 65 && ch <= 91) && (ch != 0 || ch != 127))
            {

                e.Handled = true;
                richTextBox1.Text = "Заглавные латинские буквы используются только для нетерминального алфавита";
            }


            else
            {
                e.Handled = true;
                if (textBox3.Text.Length > 0 && textBox3.Text.Substring(textBox3.Text.Length - 1) != ",")
                {
                    textBox3.Text += "," + ch;
                }
                else textBox3.Text += ch;
                richTextBox1.Text = "";
            }
        }


        private void checkRull()
        {

            int i = A.Count<string>();
            int In = 0;
            int Out = 0;
            bool Chek = true;
            for (int j =0; j < i ; j++)
            {
                for (int K = 0; K <= B[j].Length-1 ; K++)
                {
                    char ch = B[j][K];
                    if (Data.VN.Contains(ch)) In++;
                   
                }
                for (int K = 0; K <= C[j].Length-1; K++)
                {
                    char ch = C[j][K];
                    if (Data.VN.Contains(ch)) Out++;
                }
                if (In != Out) { Chek = false; break; }
                
            }
            richTextBox1.Text = In.ToString();
            richTextBox1.Text += Out.ToString();
            if (Chek == false)
            {
                Data.Good = false;
                this.Show();
                richTextBox1.Text += "Количество нетерминальных символов во входящем и исходящем алфавитах отличаюся, проверьте корректность введенных правил";
            }
            else { Data.Good = true; }

        }


        private void DataTable_Leave(object sender, EventArgs e)
        {
            A = new string[dataGridView1.Rows.Count - 1];
            B = new string[dataGridView1.Rows.Count - 1];
            C = new string[dataGridView1.Rows.Count - 1];
            int i = 0;
            Data.VN = textBox1.Text;
            Data.VT_IN = textBox2.Text;
            Data.VT_OUT = textBox3.Text;
            Data.startsimpbol = textBox4.Text;

            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                C[i] = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                B[i] = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                A[i] = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
            }
        }

        private void DataTable_Deactivate(object sender, EventArgs e)
        {


            dataGridView1.EndEdit();


            A = new string[dataGridView1.Rows.Count - 1];
            B = new string[dataGridView1.Rows.Count - 1];
            C = new string[dataGridView1.Rows.Count - 1];
            int i = 0;
            Data.VN = textBox1.Text;
            Data.VT_IN = textBox2.Text;
            Data.VT_OUT = textBox3.Text;
            Data.startsimpbol = textBox4.Text;

            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                C[i] = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                B[i] = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                A[i] = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
            }
            checkRull();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl textBoxEditingControl = e.Control as DataGridViewTextBoxEditingControl;
            if (textBoxEditingControl != null)
            {
                textBoxEditingControl.KeyPress -= dataGridView1_KeyPress;
               // textBoxEditingControl.KeyPress -= textBoxEditingControl_KeyPress_digits;
              //  if (((DataGridView)sender).CurrentCell.ColumnIndex == 0)
                    textBoxEditingControl.KeyPress += dataGridView1_KeyPress;
             //   else
               //     textBoxEditingControl.KeyPress += textBoxEditingControl_KeyPress_digits;
            }
        }
    }
    }

