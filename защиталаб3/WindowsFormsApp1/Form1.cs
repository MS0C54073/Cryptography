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
using System.Numerics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        string s = " абвгдеёжзийклмнопрстуфхцчшщъыьэюя";


     
        public Form1()
        {
            InitializeComponent();
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
        public int div(int x, int y)//правильное целочисленное деление x на y
        {
            if (x >= 0)
                return x / y;

            else return (x / y) - 1;

        }

        public int mod(int x, int y)//правильный остаток от деления x на y
        {


            // MessageBox.Show((x >= 0 && y > 0).ToString());

            if (x >= 0)
                return x % y;

            else return (x % y + y);


        }

        public string encrypt(string m, double key, int pos)//m-сообщение,s-алфавит
        {
           
            
            if (m.Length == 0)
                return "" ;


            int t = 0;

            List<int> keys = new List<int>();

            BigInteger s=0;
            
            string k=key.ToString();

             string []k1 = k.Split(',');


            int y = k.IndexOf(',');

            if (y == -1)
                y = k.Length;

         //   MessageBox.Show(k.ToString());


            
          //  MessageBox.Show(y.ToString());
            int c=0;
            int i = 0;
            if (y % 2 == 1)
            {
                c = Convert.ToInt32(k[0] - 48);
               // MessageBox.Show(c.ToString());

                i = 1;
            }



            else
            {
                c = Convert.ToInt32(k[0] - 48) * 10 + Convert.ToInt32(k[1] - 48);
               // MessageBox.Show(c.ToString());
                i = 2;
            }


            int x =(int) Math.Floor(Math.Pow(c, 0.5));

            s += x;
            BigInteger c1 = 0;

            BigInteger g1 = 0;


            keys.Add(x);

           

            c1 = c - x * x;

            bool h = false;
           

          //  BigInteger

            if(y!=k.Length && k[i]==',')
            {
                i++;
                h = true;
            }

            t++;
            while (t <= 6*m.Length + 1000)
            {
              //  MessageBox.Show(t.ToString());
                c1 *= 100;


           //     MessageBox.Show(i.ToString());
           if(i+1<k.Length)

                c1 += Convert.ToInt32(k[i] - 48) * 10 + Convert.ToInt32(k[i + 1] - 48);

           else if(i+1==k.Length)
                    c1 += Convert.ToInt32(k[i] - 48) * 10;


                // MessageBox.Show(c1.ToString());

                g1 = s * 20;
                bool z = false;
                int j = 9;
             
        
                do

                {
                    g1 += j;

                    if (g1 * j <= c1)

                    {
                        c1 -= g1*j;
                    //    MessageBox.Show(g1.ToString());
                        z = true;

                      //  if(h==false)
                        s = s * 10 + j;

                        if(t>=pos)
                        keys.Add(j);
                      //  else


                    }
                    else
                    {
                        z = false;
                        g1 -= j;
                        j--;
                    }


                }
                while (z == false);

                i+=2;
                if (y != k.Length&& h == false && k[i] == ',')
                {
                    h = true;
                    i++;
                }
                t++;
                
            }
            string m1 = "";

           
            int f = 0;
            for (int l = 0; l < m.Length; l++)
            {
              //  MessageBox.Show(keys[f].ToString());
            //    MessageBox.Show(keys[f+1].ToString());
              //  MessageBox.Show(keys[f+2].ToString());
             //   MessageBox.Show(keys[f+3].ToString());
             //   MessageBox.Show(keys[f+4].ToString());
             //   MessageBox.Show(keys[f+5].ToString());
                // MessageBox.Show(((int)m[f]).ToString());
                //  MessageBox.Show(((int)keys[f]).ToString());
                //  MessageBox.Show(((char)m[f] ^ keys[f]).ToString());
                char d = (char)(m[l] ^ (keys[f] * 100000 + keys[f + 1] * 10000 + keys[f + 2] * 1000 + keys[f + 3] * 100 + keys[f + 4] * 10 + keys[f + 5]));
                m1 += d;

                f += 6;
                //  MessageBox.Show((y1).ToString());

            }


            return m1;
           
        }


        public string decrypt(string m, double key, int pos)//m-сообщение
        {

            if (m.Length == 0)
                return "";


            int t = 0;

            List<int> keys = new List<int>();

            BigInteger s = 0;

            string k = key.ToString();

            string[] k1 = k.Split(',');


            int y = k.IndexOf(',');

            if (y == -1)
                y = k.Length;

            //   MessageBox.Show(k.ToString());



            //  MessageBox.Show(y.ToString());
            int c = 0;
            int i = 0;
            if (y % 2 == 1)
            {
                c = Convert.ToInt32(k[0] - 48);
                // MessageBox.Show(c.ToString());

                i = 1;
            }



            else
            {
                c = Convert.ToInt32(k[0] - 48) * 10 + Convert.ToInt32(k[1] - 48);
                // MessageBox.Show(c.ToString());
                i = 2;
            }


            int x = (int)Math.Floor(Math.Pow(c, 0.5));

            s += x;
            BigInteger c1 = 0;

            BigInteger g1 = 0;


            keys.Add(x);



            c1 = c - x * x;

            bool h = false;


            //  BigInteger

            if (y != k.Length && k[i] == ',')
            {
                i++;
                h = true;
            }

            t++;
            while (t <= 6 * m.Length + 1000)
            {
                //  MessageBox.Show(t.ToString());
                c1 *= 100;


                //     MessageBox.Show(i.ToString());
                if (i + 1 < k.Length)

                    c1 += Convert.ToInt32(k[i] - 48) * 10 + Convert.ToInt32(k[i + 1] - 48);

                else if (i + 1 == k.Length)
                    c1 += Convert.ToInt32(k[i] - 48) * 10;


                // MessageBox.Show(c1.ToString());

                g1 = s * 20;
                bool z = false;
                int j = 9;


                do

                {
                    g1 += j;

                    if (g1 * j <= c1)

                    {
                        c1 -= g1 * j;
                        //    MessageBox.Show(g1.ToString());
                        z = true;

                        //  if(h==false)
                        s = s * 10 + j;
                        if (t >= pos)
                            keys.Add(j);
                        //  else


                    }
                    else
                    {
                        z = false;
                        g1 -= j;
                        j--;
                    }


                }
                while (z == false);

                i += 2;
                if (y != k.Length && h == false && k[i] == ',')
                {
                    h = true;
                    i++;
                }
                t++;

            }
            string m1 = "";

            int f = 0;
            for (int l = 0; l < m.Length; l++)
            {
                // MessageBox.Show(((int)m[f]).ToString());
                //  MessageBox.Show(((int)keys[f]).ToString());
                //  MessageBox.Show(((char)m[f] ^ keys[f]).ToString());
                char d = (char)(m[l] ^ (keys[f] * 100000 + keys[f + 1] * 10000 + keys[f + 2] * 1000 + keys[f + 3] * 100 + keys[f + 4] * 10 + keys[f + 5]));
                m1 += d;

                f += 6;
                //  MessageBox.Show((y1).ToString());

            }




            return m1;


        }


        public string perebor(string m)//m-сообщение,s-алфавит
        {
           
            //   int n = 0;


            string h = "";


            for (int i = 0; i < s.Length; i++)
              
                {
                    
                        h += "Ключ: a = " + i + "\r\n" + "Сообщение: ";
                        h += decrypt(m, i,0);
                        h += "\r\n";
                    

                }
            return h;

        }
        private void button2_Click(object sender, EventArgs e)
        {


            string x = textBox1.Text;

            double key;
            int pos;

           
            string m = textBox2.Text;

            if (!Double.TryParse(x, out key))
            {
                MessageBox.Show("ключ должен быть действительным числом");
                return;

            }


            string x1 = textBox9.Text;

            if (!Int32.TryParse(x1, out pos))
            {
                MessageBox.Show("позиция должен быть целым числом");
                return;

            }

            //    MessageBox.Show(m);
            // m = m.ToLower();

            // m1

            string m1 = encrypt(m, key, pos);

            textBox3.Text = m1;

          //  int y = '0';

         



        }

        private void button5_Click(object sender, EventArgs e)
        {
            string x = textBox4.Text;

            double a;
            int pos;

            if (!Double.TryParse(x, out a))
            {
                MessageBox.Show("ключ должен быть действительным числом");
                return;

            }

            string x1 = textBox10.Text;

            if (!Int32.TryParse(x1, out pos))
            {
                MessageBox.Show("позиция должен быть целым числом");
                return;

            }


            string m = "";

            // MessageBox.Show(m);
            if (m != "")
                textBox3.Text = m;
            else m = textBox5.Text;

            string m1 = decrypt(m, a, pos);

            textBox6.Text = m1;
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
         //   string m = "";
        //    if (m != "")
             //   textBox9.Text = m;

           // textBox10.Text = perebor(textBox9.Text);
            //     Save(textBox10.Text);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                MessageBox.Show("Слишком много ключей. Извините.");
                return;
            }
          // string m = textBox7.Text;
          //  textBox8.Text = perebor(m);
           // if (m != "")
                //textBox9.Text = m;

          //  textBox10.Text = frequency.analyze(textBox9.Text);
            //  Save(textBox10.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Save(textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = Open();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
          //  textBox9.Text = Open();
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
           // Save(textBox10.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Save(textBox6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox7.Text = Open();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Save(textBox8.Text);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Save(textBox8.Text);
        }
    }
}
