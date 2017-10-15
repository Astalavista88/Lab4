using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lubNm_4._3
{
    public class Rull
    {
        // static int n;
        public string[] VT;
        public string[] VN;
        string[] RULL;
        string[] OUT;

        public int[] position;
        public string startsimpbol = Data.startsimpbol;
        int count = 0;

        public bool check = true; //не содержит
        public List<string> result = new List<string>();
        public List<int> listRull = new List<int>();
        public List<string> buildResult = new List<string>();


        public void setVn(string[] Vn)
        {
            VT = new string[Vn.Count()];
            Vn.CopyTo(VT, 0);
        }

        public void ListRull(string[] R, string[] O)
        {
            RULL = new string[R.Count() * 2];

            for (int i = 0, j = 0; i < (R.Count() * 2) - 1; i++)
            {
                RULL[i] = R[j];
                i++;
                RULL[i] = O[j++];
            }
        }

        public List<string> parseIt(string str)
        {
            parse(str, "", "", "", 0, 0);
            par(); return result;

        }

        private void parse(string str, string s, string st, string strr, int c1, int tmps)
        {

            if (count < 1 && s.Length > 0)
            {
                // var find = list.Find(x => x == s);

                if (c1 > 1)
                {
                    var find = result.Find(x => x.Remove(x.IndexOf(" ")) == s);
                    // Console.WriteLine("#######" + find+ "#######" + s);
                    if (find != null)
                        result.RemoveRange(result.IndexOf(find), result.Count - result.IndexOf(find));
                }
                result.Add(s + " {" + st + " ==> " + strr + "} " + str + "# " + tmps.ToString());
            }
            // result.Add(s + " {" + st + " ==> " + strr + "} " + str + "# " + tmps.ToString());
            check = true;
            int c = 0;



            for (int j = 1; j <= RULL.Count() - 1; j += 2)
            {
                if (str == startsimpbol) count++;

                if (str.Contains(RULL[j]))
                {
                    int tmp1 = str.IndexOf(RULL[j]);
                    string tmpS = str.Remove(tmp1);
                    int tmp2 = 0;
                    string tmp = str.Remove(tmp1) + RULL[j - 1] + str.Substring(tmp1 + RULL[j].Length);
                        while (tmpS.Contains(RULL[j - 1]))

                    {
                        tmpS = tmpS.Substring(tmpS.IndexOf(RULL[j - 1])+1);
                        tmp2++;
                    }



                    c++;
                    parse(tmp, str, RULL[j], RULL[j - 1], c, tmp2);


                }

            }

        }

        private void par()
        {
            List<string> listR = result;
            listR.Reverse();
            position = new int[listR.Count()];
            int j = 0;
            foreach (string str in listR)
            {
                for (int i = 1; i < RULL.Count(); i += 2)
                {
                    string temp = str.Substring(str.IndexOf("{") + 1);
                    temp = temp.Remove(temp.IndexOf("}"));
                    if (RULL[i] == temp.Remove(temp.IndexOf(" ")) && RULL[i - 1] == temp.Substring(temp.LastIndexOf(" ") + 1))
                    {
                        listRull.Add(i - 1);
                        break;
                    }

                }
                position[j++] = Int32.Parse(str.Substring(str.LastIndexOf(" ")));
            }


        }

        public void build(List<int> listRull, string s, int[] position)
        {
            int j = 0;

            foreach (int i in listRull)
            {
                int X = 0;
                string temp = s;
                string temps = s;
                if (position[j] > 0)
                {
                    for (int k = 0; k < position[j]+1; k++)
                    {
                        X += temps.IndexOf(RULL[i]) + 1;
                        temps = temps.Substring(temps.IndexOf(RULL[i]) + 1);

                    }
                    X -= 1;
                }
                else X += temps.IndexOf(RULL[i]);

                j++;
                int temp1 = X;
                int temp2 = X + RULL[i].Length;
                string temp3 = RULL[i];
                string tempEnd = s.Substring(temp2);
                string tempStart = s.Remove(temp1);
                s = tempStart + RULL[i + 1] + tempEnd;
                buildResult.Add($"{temp} {{ {RULL[i]} ==> {RULL[i + 1]}}} {s}");
            }


        }


    }
}