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

        public string encrypt(string m, int key)//m-сообщение,s-алфавит
        {
            int n = -1;
            string m1 = "";
            int g = -98;
            for (int i = 0; i < m.Length; i++)
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

                else
                    if (i == 0)
                {
                    m1 += s[(n + key) % s.Length];
                    g = (n + key) % s.Length;
                }
                else

                {
                    m1 += s[(n + g + key) % s.Length];

                    g = (n + g + key) % s.Length;

                    n = -1;

                }
                // m1 += m[(a*i+b)%];

            }

            //  MessageBox.Show(m1);

            return m1;
        }


        public string decrypt(string m1, int a)//m-сообщение
        {

               int n = -1;
            string m = "";
            int g = -98;
              
               for (int i = 0; i < m1.Length; i++)
               {

                   for (int j = 0; j < s.Length; j++)
                   {
                       if (m1[i] == s[j])
                       {
                           n = j;
                           break;
                       }
                       // MessageBox.Show((reva * (n + s.Length - b) % s.Length).ToString());

                       // m1 += m[(a*i+b)%];

                   }


                   if (n == -1)
                       m += m1[i];

                else
                    if (i == 0)
                {
                     m += s[mod((n + s.Length - a) , s.Length)];
                    g = n;
                }
                else

                {
                

                    m += s[mod((n + s.Length - a - g) , s.Length)];


                    g = n;
   

                }
                //   else m += s[(n + s.Length - a) % s.Length];
                   // MessageBox.Show(reva.ToString());
                   // m1 += m[(a*i+b)%];
                   n = -1;
               }
               //  MessageBox.Show(reva.ToString());

               return m;
          

        }


        public string perebor(string m)//m-сообщение,s-алфавит
        {
           
            //   int n = 0;


            string h = "";


            for (int i = 0; i < s.Length; i++)
              
                {
                    
                        h += "Ключ: a = " + i + "\r\n" + "Сообщение: ";
                        h += decrypt(m, i);
                        h += "\r\n";
                    

                }
            return h;

        }
        private void button2_Click(object sender, EventArgs e)
        {


            string x = textBox1.Text;

            int key;

            string m = textBox2.Text;

            if (!Int32.TryParse(x, out key))
            {
                MessageBox.Show("ключ должен быть целым числом");
                return;

            }

            if (key < 0)
            {
                MessageBox.Show("ключ должен быть неотрицательным");
                return;

            }

          
            if (key > s.Length)
            {
                MessageBox.Show("ключ должен быть меньше длины алфавита");
               // return;

            }

          

            //    MessageBox.Show(m);
            m = m.ToLower();

            string m1 = encrypt(m, key);

            textBox3.Text = m1;


            //  int a = Convert.ToInt32(textBox1.Text);
            //  int b = Convert.ToInt32(textBox2.Text);



            //    if (a==0)

            //  MessageBox.Show(EXTNOD(161, 28)[0].ToString());
            // MessageBox.Show(EXTNOD(161, 28)[1].ToString());
            //  MessageBox.Show(div(-20,30).ToString());
            //   MessageBox.Show(m1);
            // encrypt("yyy", "uuu", 0, 0);



        }

        private void button5_Click(object sender, EventArgs e)
        {
            string x = textBox4.Text;

            int a;
          //  int b;
            if (!Int32.TryParse(x, out a))
            {
                MessageBox.Show("a должно быть целым числом");
                return;

            }

      /*      if (a <= 0)
            {
                MessageBox.Show("a должно быть положительным");
                return;

            }

           
           // x = textBox6.Text;

            if (!Int32.TryParse(x, out b))
            {
                MessageBox.Show("b должно быть целым числом");
                return;
      
            }*/

         


            //  MessageBox.Show((b-s.Length).ToString());




            string m = "";

            // MessageBox.Show(m);
            if (m != "")
                textBox3.Text = m;
            else m = textBox5.Text;

            string m1 = decrypt(m, a);

            textBox6.Text = m1;
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

           string m = textBox7.Text;
            textBox8.Text = perebor(m);
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
