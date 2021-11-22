using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Edpcom;

namespace PayRollManagementSystem
{
    class MenuGen
    {
       
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public ArrayList Index(string key)
        {
            ArrayList arr1 = new ArrayList();
            int a;
            int b;
            int c;
            string a1;
            string b1;
            string subkey, subkey1;
            a = Strings.InStr(key, "+", 0);
            if (a != 0)
            {
                a1 = key.Substring(0, a - 1);
                arr1.Add(match(a1));
                b1 = key.Substring(a + 1 - 1);
                b = Strings.InStr(b1, "+", 0);
                if (b != 0)
                {
                    subkey = b1.Substring(0, b - 1);
                    arr1.Add(match(subkey));
                    subkey = b1.Substring(b + 1 - 1);
                    c = Strings.InStr(subkey, "+", 0);
                    if (c != 0)
                    {
                        subkey1 = subkey.Substring(0, c - 1);
                        arr1.Add(match(subkey1));
                        subkey1 = subkey.Substring(c + 1 - 1);
                        arr1.Add(Strings.Asc(subkey1));
                    }
                    else
                    {
                        //Add S Dutta 20.07.13(Configur Hot Key)
                        arr1.Add(match(subkey));
                        if (arr1[2].ToString() == "0")
                            arr1[2] = (Strings.Asc(subkey));
                        //End 20.07.13

                        //arr1.Add(Strings.Asc(subkey));
                    }
                }
                else
                {
                    //Add S Dutta 20.07.13(Configur Hot Key)
                    arr1.Add(match(b1));
                    if (arr1[1].ToString() == "0")
                        arr1[1] = (Strings.Asc(b1));
                    //End 20.07.13

                //arr1.Add(Strings.Asc(b1));
                    
                }
            }
            else
            {
                arr1.Add(match(key));
            }
            return arr1;
        }
        public int match(string a1)
        {
            int i = 0;
            switch (a1)
            {
                case "Alt": i = 262144;
                    break;
                case "Ctrl": i = 131072;
                    break;
                case "Shift": i = 65536;
                    break;
                case "F1": i = 112;
                    break;
                case "F2": i = 113;
                    break;
                case "F3": i = 114;
                    break;
                case "F4": i = 115;
                    break;
                case "F5": i = 116;
                    break;
                case "F6": i = 117;
                    break;
                case "F7": i = 118;
                    break;
                case "F8": i = 119;
                    break;
                case "F9": i = 120;
                    break;
                case "F10": i = 121;
                    break;
                case "F11": i = 122;
                    break;
                case "F12": i = 123;
                    break;
            }
            return i;
        }
      
    }
}
