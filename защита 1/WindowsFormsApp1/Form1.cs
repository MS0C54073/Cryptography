using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        string s = " абвгдеёжзийклмнопрстуфхцчшщъыьэюя";


        static class frequency
        {
            static string a = " абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            static double[] a1 = { 0.175, 0.062, 0.014, 0.038, 0.013, 0.025, 0.072, 0.072, 0.01, 0.007, 0.016, 0.062, 0.01, 0.028, 0.035, 0.026, 0.053, 0.09, 0.023, 0.040, 0.045, 0.053, 0.021, 0.002, 0.009, 0.004, 0.012, 0.006, 0.003, 0.014, 0.014, 0.003, 0.006, 0.018 };

            public static string analyze(string h)
            {
                string a1 = "";
                //MessageBox.Show(h);
                string h1 = h;

                char d = '6';

                for(int i=0;i<a.Length;i++)

                {
                   
                    
                    d = a[i];
                   
                    int c = 0;

                    for (int j = 0; j < h.Length; j++)
                    {
                        if (h[j] == d)
                            c++;
                      
                        if (h[j] == ' ')
                        {
                          //  MessageBox.Show(h.Length.ToString());
                           // MessageBox.Show(f.ToString());
                        }

                    }
                    
                    double f = (double)c / h.Length;

                  
                    
                    int g = 0;
                    double r = 9999;
                    for (int k = 0; k < a1.Length; k++)
                        {


                        /*  if (k == 1)
                          {
                              MessageBox.Show(f.ToString());
                              MessageBox.Show(a1[k].ToString());
                              MessageBox.Show((f - a1[k]).ToString());
                          }*/
                        double w = Math.Abs((f - a1[k]));
                        if (w <= r)
                        {
                         
                            r = w;
                          //  MessageBox.Show(r.ToString());
                            g = k;
                        }


                       
                        
                    }
                    a1 += a[g];
                    // if (d == 'ж')
                    // MessageBox.Show(f.ToString());

                    for (int v = 0; v < h1.Length; v++)
                    {
                        if (h1[v] == d)
                        {
                            //if (d == 'ж')
                            //  MessageBox.Show(a[g].ToString());

                            h1 = h1.Replace(d, a[g]);
                        }
                    }

                }

             /*   for (int v = 0; v < a1.Length; v++)
                {
                        MessageBox.Show(a1[v].ToString());

                     
                }*/
                //  MessageBox.Show(d.ToString());
               
                return h1;
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        public int NOD(int a1, int b1)// НОД
        {
            int a = Math.Abs(a1);
            int b = Math.Abs(b1);

            if (a == 1 || b == 1)
                return 1;

            if (a == 0)
                return b;
            if (b == 0)
                return a;
            int r = 0;


            if (a == b)
                return a;

            if (a < b)
            {
                int c = a;
                //MessageBox.Show("%%".ToString());
                // MessageBox.Show(mod(a, b).ToString());
                a = b;
                b = c;
            }

            int i = 0;
            r = b;
            while ((mod(a,b))!=0&& mod(b, a) != 0)
            {
                if (i%2==0)
                {
                    //MessageBox.Show("%%".ToString());
                   // MessageBox.Show(mod(a, b).ToString());
                    r = mod(a, b);
                    a = mod(a, b);
                }

                else
                {
                 //   MessageBox.Show("%4".ToString());
                   // MessageBox.Show(mod(b, a).ToString());
                    r = mod(b, a);
                    b = mod(b, a);
                }
                i++;

            }
            return r;
        }


        public int[] EXTNOD(int a1, int b1)// коэффициенты линейного представления
        {
            int a = Math.Abs(a1);
            int b = Math.Abs(b1);
            int q = 0;

            int[] l = new int[2];
         /*   int u1 = 0;
            int u2 = 1;
            int u3 = b;

            int v1 = 1;
            int v2 = 0;
            int v3 = a;*/

            if (a == 1 || b == 1)
            {
                l[0] = 1;
                l[1] = 1;
                return l;
            }

            if (a == 0)
            {
                l[0] = 1;
                l[1] = 1;
                return l;

            }
            if (b == 0)
            {
                l[1] = 1;
                l[0] = 1;
                return l;
            }
            int r = 0;


            if (a == b)
            {
                l[1] = 1;
                l[1] = 0;
                return l;
               
            }

            if (a < b)
            {
                int c = a;
                //MessageBox.Show("%%".ToString());
                // MessageBox.Show(mod(a, b).ToString());
                a = b;
                b = c;
            }



            int[]l1 = new int[2];

            int i = 0;

            l[0] = 0;
            l[1] = 1;
            while ((mod(a, b)) != 0 && mod(b, a) != 0)
            {


                if (i == 0)

                {
                    l[0] = 1;
                    l[1] = -div(a, b);


                }
               
                if (i == 1)

                {
                    l1[0] = l[0];
                    l1[1] = l[1];
                    l[0] = -div(b, a);
                    l[1] = 1-l[1]*div(b, a);


                }

                if (i % 2 == 0)
                {
                    q = div(a, b);
                    //MessageBox.Show("%%".ToString());
                    // MessageBox.Show(mod(a, b).ToString());
                    r = mod(a, b);
                    a = mod(a, b);

                   

                }

                else
                {
                    q = div(b, a);
                    //   MessageBox.Show("%4".ToString());
                    // MessageBox.Show(mod(b, a).ToString());
                    r = mod(b, a);
                    b = mod(b, a);
                }

                if (i >= 2)
                {
                    int x0 = l[0];
                    int x1 = l[1];
                    l[0] = l1[0] - q * l[0];
                    l[1] = l1[1] - q * l[1];
                    l1[0] = x0;
                    l1[1] = x1;
                }

                i++;

            }
            return l;
        }
        public void Save(string m)
        {

          //  MessageBox.Show(m);
            SaveFileDialog f = new SaveFileDialog();
            f.ShowDialog();
            if (f.FileName != "")
            {
                StreamWriter f1 = new StreamWriter(f.FileName,false);
                f1.Write(m);
                f1.Close();
            }
          //  h.S
        }
        public string Open()
        {
            string s = "";
            //  MessageBox.Show(m);
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            if (f.FileName != "")
            {
                StreamReader f1 = new StreamReader(f.FileName, false);
 
                s=f1.ReadToEnd();
                f1.Close();
            }
            return s;
        }
        public int div(int x, int y)//правильное целочисленное деление x на y
        {
            if (x >= 0)
                return x / y;

            else return (x / y)-1;

        }

        public int mod(int x, int y)//правильный остаток от деления x на y
        {


           // MessageBox.Show((x >= 0 && y > 0).ToString());

            if (x>=0)
                return x % y;

            else return (x % y + y);


        }

        public string encrypt(string m,int a,int b)//m-сообщение,s-алфавит
        {
            int n = -1;
            string m1 = "";
            for(int i=0;i<m.Length;i++)
            {
              //  MessageBox.Show(m[i]);
                for (int j = 0; j < s.Length; j++)
                {
                    if (m[i] == s[j])
                    {

                       
                        n = j;
                        break;
                    }

                  

                    

                  
                    // m1 += m[(a*i+b)%];

                }

                if (n == -1)
                    m1 += m[i];

                   else m1 += s[(a * n + b) % s.Length];
                n = -1;
                // m1 += m[(a*i+b)%];

            }
           
          //  MessageBox.Show(m1);

            return m1;
        }


        public string decrypt(string m1, int a, int b)//m-сообщение
        {
          
            int n = -1;
            int reva = 0;
            string m = "";

            reva = EXTNOD(a,s.Length)[1];

            if (reva < 0)
                reva += s.Length;
            for (int i = 0; i < m1.Length; i++)
            {

                for (int j = 0; j < s.Length; j++)
                {
                    if (m1[i] == s[j])
                    {
                        n = j;
                        break;
                    }
                }


                if (n == -1)
                    m += m1[i];
                   
               else m += s[reva * (n + s.Length - b) % s.Length];
              
                n = -1;
            }
            return m;

            
        }


        public string perebor(string m)//m-сообщение,s-алфавит
        {
           
         //   int n = 0;
          

            string h = "";
            
          
            for(int i = 1;i < s.Length;i++)
                for (int j = 0; j < s.Length; j++)
                {if (NOD(i, s.Length) == 1)
                    {
                        h += "Ключ: a = " + i + " , b = " + j + "\r\n" + "Сообщение: ";
                        h += decrypt(m, i, j);
                        h += "\r\n";
                    }
                   
                }
            return h;
      
        }
        private void button1_Click(object sender, EventArgs e)
        {


            string x = textBox1.Text;

            int a;
            int b;
            if (!Int32.TryParse(x, out a))
            {
                MessageBox.Show("a должно быть целым числом");
                return;

            }   
       
            if (a<=0)
            {
                MessageBox.Show("a должно быть положительным");
                return;

            }

            if (a >= s.Length)
            {
                MessageBox.Show("a должно меньше длины алфавита");
                return;

            }

            x = textBox2.Text;

            if (!Int32.TryParse(x, out b))
            {
                MessageBox.Show("b должно быть целым числом");
                return;

            }

            if (b < 0)
            {
                MessageBox.Show("b должно быть неотрицательным");
                return;

            }


            if (b >= s.Length)
            {
                MessageBox.Show("b должно меньше длины алфавита");
                return;

            }


            //  MessageBox.Show((b-s.Length).ToString());



            if (NOD(a, s.Length) != 1)

            {
                MessageBox.Show("a должно быть взаимно просто с длиной алфавита");
                return;
            }


            string m = textBox3.Text;

            //    MessageBox.Show(m);
            m = m.ToLower();

            string m1 = encrypt(m, a, b);

            textBox4.Text = m1;

            


            Save(m1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = textBox5.Text;

            int a;
            int b;
            if (!Int32.TryParse(x, out a))
            {
                MessageBox.Show("a должно быть целым числом");
                return;

            }

            if (a <= 0)
            {
                MessageBox.Show("a должно быть положительным");
                return;

            }

            if (a >= s.Length)
            {
                MessageBox.Show("a должно меньше длины алфавита");
                return;

            }

            x = textBox6.Text;

            if (!Int32.TryParse(x, out b))
            {
                MessageBox.Show("b должно быть целым числом");
                return;

            }

            if (b < 0)
            {
                MessageBox.Show("b должно быть неотрицательным");
                return;

            }


            if (b >= s.Length)
            {
                MessageBox.Show("b должно меньше длины алфавита");
                return;

            }


            //  MessageBox.Show((b-s.Length).ToString());



            if (NOD(a, s.Length) != 1)

            {
                MessageBox.Show("a должно быть взаимно просто с длиной алфавита");
                return;
            }


            string m = Open();

            // MessageBox.Show(m);
            if (m != "")
                textBox7.Text = m;
            else m = textBox7.Text;

            string m1 = decrypt(m, a, b);

            textBox8.Text = m1;
         //   MessageBox.Show(m1);
            //  int a = Convert.ToInt32(textBox1.Text);
            //  int b = Convert.ToInt32(textBox2.Text);



            //    if (a==0)

            //   MessageBox.Show(EXTNOD(161, 28)[0].ToString());
            //   MessageBox.Show(EXTNOD(161, 28)[1].ToString());
            //  MessageBox.Show(div(-20,30).ToString());
            //   MessageBox.Show(s.Length.ToString());
            // encrypt("yyy", "uuu", 0, 0);


            Save(m1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string m = Open();
            if (m != "")
                textBox9.Text = m;

            textBox10.Text = perebor(textBox9.Text);
            Save(textBox10.Text);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            string m = Open();
            if (m != "")
                textBox9.Text = m;

            textBox10.Text = frequency.analyze(textBox9.Text);
            Save(textBox10.Text);
        }
    }
}
