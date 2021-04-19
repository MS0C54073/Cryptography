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
            while ((mod(a, b)) != 0 && mod(b, a) != 0)
            {
                if (i % 2 == 0)
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



            int[] l1 = new int[2];

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
                    l[1] = 1 - l[1] * div(b, a);


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
                StreamWriter f1 = new StreamWriter(f.FileName, false);
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

                s = f1.ReadToEnd();
                f1.Close();
            }    
            return s;
        }

        // string s = " абвгдеёжзийклмнопрстуфхцчшщъыьэюя";



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

        public string encrypt(string m, int a, int b)//m-сообщение,s-алфавит
        {

            
            List<int> k = new List<int>(m.Length);

           // for (int i = 0; i < m.Length; i++)
            //    m1 += (char)1;
          
            for(int i=0;i<m.Length;i++)
            {
                //  MessageBox.Show(m[i]);
                // m1.Remove(i);
                //  MessageBox.Show(i.ToString());
                // MessageBox.Show(((a * i + b) % m.Length).ToString());
                k.Add((a * i + b) % m.Length);
              //  m1=m1.Insert((a * i + b) % m.Length,m[i].ToString());
                // m1 += m[(a*i+b)%];

            }
            
            char[] p = m.ToCharArray();

            for (int i = 0; i < m.Length; i++)
            {
                // MessageBox.Show(m1.Length.ToString());
              //  MessageBox.Show(m1[k[i]].ToString());

                // MessageBox.Show(m1[k[i]].ToString());
                // MessageBox.Show(m1[i].ToString());
            
               p[k[i]]=m[i];
               // MessageBox.Show(m1);
            }

            string m1 = new string(p);
            return m1;
        }


        public string decrypt(string m1, int a, int b)//m-сообщение,s-алфавит
        {
          
            int reva = 0;
           
            List<int> k = new List<int>(m1.Length);

            reva = EXTNOD(a, m1.Length)[1];

            if (reva < 0)
                //  reva += s.Length;
                reva = mod(reva, m1.Length);

            for (int i = 0; i < m1.Length; i++)
            {

                k.Add(reva * (i + m1.Length - b) % m1.Length);
               //  MessageBox.Show((b).ToString());
                // m1 += m[(a*i+b)%];
              
            }
            //  MessageBox.Show(reva.ToString());
          //  foreach (int g in k)
            //    MessageBox.Show(g.ToString());

            char[] p = m1.ToCharArray();

            for (int i = 0; i < m1.Length; i++)
            {
                // MessageBox.Show(m1.Length.ToString());
                //  MessageBox.Show(m1[k[i]].ToString());

                // MessageBox.Show(m1[k[i]].ToString());
                // MessageBox.Show(m1[i].ToString());

                p[k[i]] = m1[i];
                // MessageBox.Show(m1);
            }

            string m = new string(p);

            return m;
        }


        public string perebor(string m)//m-сообщение
        {

            //   int n = 0;


            string h = "";


            for (int i = 1; i < m.Length; i++)
                for (int j = 0; j < m.Length; j++)
                {
                    if (NOD(i, m.Length) == 1)
                    {
                        h += "Ключ: a = " + i + " , b = " + j + "\r\n" + "Сообщение: ";
                        h += decrypt(m, i, j);
                        h += "\r\n";
                    }

                }
            return h;

        }
        public void analyze(string m1)//m-сообщение,s-алфавит
        {

            
        //    int revam = 0;
            string m = "";
            for (int i = 0; i < m.Length; i++)
            {

                // m1 += m[(a*i+b)%];

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            string x = textBox1.Text;

            int a;
            int b;
            string m = textBox3.Text;
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


            if (b >= m.Length)
            {
                MessageBox.Show("b должно меньше длины сообщения");
                return;

            }


            //  MessageBox.Show((b-s.Length).ToString());



            if (NOD(a, m.Length) != 1)

            {
                MessageBox.Show("a должно быть взаимно просто с длиной алфавита");
                return;
            }




            textBox9.Text = m.Length.ToString();


            string m1 = encrypt(m, a, b);

            //  int a = Convert.ToInt32(textBox1.Text);
            //  int b = Convert.ToInt32(textBox2.Text);

            textBox7.Text = m1;

            //    if (a==0)

            //   MessageBox.Show(NOD(20, -30).ToString());
            //  MessageBox.Show(div(-20,30).ToString());
            //   MessageBox.Show(s.Length.ToString());
            // encrypt("yyy", "uuu", 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = Open();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Save(textBox7.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = Open();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Save(textBox8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox12.Text = Open();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Save(textBox14.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = textBox6.Text;

            int a;
            int b;
            string m = textBox5.Text;
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

            if (a >= m.Length)
            {
                MessageBox.Show("a должно меньше длины сообщения");
                return;

            }

            x = textBox4.Text;

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


            if (b >= m.Length)
            {
                MessageBox.Show("b должно меньше длины алфавита");
                return;

            }


            //  MessageBox.Show((b-s.Length).ToString());



            if (NOD(a, m.Length) != 1)

            {
                MessageBox.Show("a должно быть взаимно просто с длиной алфавита");
                return;
            }



            textBox10.Text = m.Length.ToString();

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


            //   Save(m1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox14.Text = perebor(textBox12.Text);
        }
    }
}
