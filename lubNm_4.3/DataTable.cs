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
            Thread myThread = new Thread(func);
            this.Width = dataGridView1.ColumnCount * 70 + 8;
            this.Height = dataGridView1.RowCount * 25 + 67;
            this.Width = maxl() + 20;
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
            this.Height = dataGridView1.RowCount * dataGridView1.ColumnHeadersHeight + dataGridView1.ColumnHeadersHeight *5;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            this.Width = maxl()+20;
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
          

            for (i=0; i< dataGridView1.Rows.Count - 1;i++)
            {
                C[i] = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                B[i] = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                A[i] = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
            }
        }

    }
    }

