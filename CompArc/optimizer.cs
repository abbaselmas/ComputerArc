using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompArc
{
    public class optimizer
    {
        /// variables
        public string kod = "";
        public bool hasnestedLoops = false;


        /// constructors
        public optimizer(string code)
        {
            kod = code;
            //trimmer();
            //trimmer2();
        }
        public optimizer()
        {}
        
        ///functions

        ///trim function remove all spaces (white tab enter)
        //public void trimmer()
        //{
        //    kod.Trim();
        //    while(kod.Contains(" "))
        //    {
        //        kod = kod.Replace(" ","");
        //    }
        //    while(kod.Contains("\n"))
        //    {
        //        kod = kod.Replace("\n","");
        //    }
        //    while(kod.Contains("\t"))
        //    {
        //        kod = kod.Replace("\t","");
        //    }
        //    kod.Trim();
        //}

        //public void trimmer2()
        //{
        //    kod = kod.Replace(";","; ");
        //    kod = kod.Replace("){", ")\n{");
        //    kod = kod.Replace("{", "\n{\n");
        //    kod = kod.Replace("}", "\n}\n");
        //    kod = kod.Replace("\n\n", "\n");
        //}

        public int loopcounter()
        {
            string temp1 = kod;
            short counter = 0;
            int temp2=0;
            int temp3=0;
            while (temp1.Contains("for") || temp1.Contains("while"))
            {
                if (temp1.Contains("for"))
                {
                    temp2=temp1.IndexOf("for");
                    counter++;
                    temp1=temp1.Remove(temp2, 3);
                    temp2 = 0;
                }
                else if (temp1.Contains("while"))
                {
                    temp3 = temp1.IndexOf("while");
                    counter++;
                    temp1=temp1.Remove(temp3, 5);
                    temp3 = 0;
                }
            }
            return counter;
        }

        public string loopFision()
        {
            string kod2 = kod;
            string yenikod = "";
            string[] satir = kod2.Split('\n');
            int bas = 0, son = satir.Length;
            if(hasnestedLoops)
            {
                return kod2;
            }
            else
            {
                for (int i = 0; i<satir.Length; i++ )
                {
                    if(satir[i].Contains("for"))
                    {
                        bas = i + 2;
                        break;
                    }
                }
                for (int i = 1; i < satir.Length; i++)
                {
                    if (satir[satir.Length - i].Contains("}"))
                    {
                        son = satir.Length - i;
                        break;
                    }
                }

                for (int t = 0; t < bas-2; t++)
                {
                    yenikod += satir[t]+"\n";
                }
                for (int i = 0; i<son-bas; i++ )
                {

                    for (int t = bas-2; t < bas; t++)
                    {
                        yenikod += satir[t]+ "\n";
                    }

                    yenikod += satir[bas+i];
                    yenikod += "\n}\n";
                }
            }
            return yenikod;
        }
        
      
    }
}
