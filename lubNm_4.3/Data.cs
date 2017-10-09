using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace lubNm_4._3
{
    public static class Data
    {
        public static List<string> lang = new List<string>();
        public static NameValueCollection rulleIN = new NameValueCollection();
        public static NameValueCollection rulleOut = new NameValueCollection();
        public static string path = "",VN="", VT_OUT = "", VT_IN = "";
        public static System.Data.DataSet dataSet;
        public static System.Data.DataTable table = new System.Data.DataTable("Rulles");
        public static string startsimpbol = "";
        public static string[] A;
        public static string[] B;

        public static void CreateArrRulles()
        {
            string[] A =
            {

            };
            string[] B =
         {

            };


        }


        public static void parse()
        {
            StreamReader txtL = new StreamReader(path);
            lang.Clear();
            table.Dispose();
            while (!txtL.EndOfStream)
            {
                lang.Add(txtL.ReadLine());
            }

            
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "VN";
            column.AutoIncrement = false;
            column.Caption = "VN";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "IN";
            column.AutoIncrement = false;
            column.Caption = "IN";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "OUT";
            column.AutoIncrement = false;
            column.Caption = "OUT";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            dataSet = new DataSet();
            dataSet.Tables.Add(table);



            foreach (string str in lang)
            {
                if (str.StartsWith("_VN")) VN = str.Substring(str.IndexOf("=") + 1);
                if (str.StartsWith("_VT_IN")) VT_IN = str.Substring(str.IndexOf("=") + 1);
                if (str.StartsWith("_VT_OUT")) VT_OUT = str.Substring(str.IndexOf("=") + 1);
                if (str.StartsWith("_STARTsIMBOL")) startsimpbol = str.Substring(str.IndexOf("=") + 1);
                if (str.Length>1&&VN.Contains(str.Remove(1)))
                {
                    row = table.NewRow();
                    row["VN"] = str.Remove(1);
                    row["IN"] = str.Substring(str.IndexOf(">") + 1, str.IndexOf(",") - str.IndexOf(">") - 1);
                    row["OUT"] = str.Substring(str.IndexOf(",") + 1);
                    table.Rows.Add(row);

                    rulleIN.Add (str.Remove(1), str.Substring(str.IndexOf(">") + 1, str.IndexOf(",") - str.IndexOf(">")-1));
                    rulleOut.Add(str.Remove(1), str.Substring(str.IndexOf(",")+1));
                }
            }





        }
    }
}

