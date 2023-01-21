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


namespace MusicApp
{
    
    public partial class Form1 : Form
    {
        int[] fores;
        int p = 0, n = 0;
        public string[] names;
        public string[] paths;
        string[] artist;
        string[] etos;
        string[] eidos;
        string[] glossa;

        public Form1()
        {
            InitializeComponent();

        }
        //vazei tragoudia
        private void button1_Click(object sender, EventArgs e)
        {
            int a1 = p, a2 = n,k=0;
            int c1 = p, c2 = n;
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = true;


            if (o.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in o.FileNames)
                {
                    c1++;
                }
                paths = new string[c1];
                fores = new int[c1];
                eidos = new string[c1];
                etos = new string[c1];
                artist = new string[c1];
                glossa = new string[c1];

                foreach (string s in o.FileNames)
                {
                    paths[p] = s;
                    eidos[p] = "";
                    etos[p] = "";
                    artist[p] = "";
                    glossa[p] = "";
                    fores[p] = 0;
               
                    p++;
                    

                }
                foreach(string s in richTextBox1.Lines)
                {
                    paths[k] = s;
                    k++;
                  
                }
                k = 0;

                foreach (string s in richTextBox3.Lines)
                {
                    fores[k] = int.Parse(s);
                    k++;
                  
                }
                k = 0;
                foreach (string s in richTextBox4.Lines)
                {
                    eidos[k] = s;
                   
                    k++;

                }

                k = 0;

                foreach (string s in richTextBox5.Lines)
                {
                    etos[k] = s;
                 
                    k++;

                }

                k = 0;


                foreach (string s in richTextBox6.Lines)
                {
                    artist[k] = s;
                    k++;

                }

                k = 0;

                foreach (string s in richTextBox7.Lines)
                {
                    glossa[k] = s;
                    k++;

                }

                k = 0;


                foreach (string s in o.SafeFileNames)
                {
                    c2++;
                }
                names = new string[c2];

                foreach (string s in richTextBox2.Lines)
                {
                    names[k] = s;
                    k++;
                  
                }


                foreach (string s in o.SafeFileNames)
                {
                    names[n] = s;
                    listBox1.Items.Add(names[n]);
                    n++;
                }


                for (int i = a1; i < paths.Length; i++)
                {
                    string neopath = Environment.NewLine + paths[i];
                    richTextBox1.Text += Environment.NewLine + paths[i];
                    File.AppendAllText("paths.txt", neopath, Encoding.UTF8);

                    string frs= Environment.NewLine + fores[i].ToString();
                    richTextBox3.Text += Environment.NewLine + fores[i].ToString();
                    File.AppendAllText("top5.txt", frs, Encoding.UTF8);

                    string type = Environment.NewLine + eidos[i].ToString();
                    richTextBox4.Text += Environment.NewLine + eidos[i].ToString();
                    File.AppendAllText("eidos.txt", frs, Encoding.UTF8);

                    string year = Environment.NewLine + etos[i].ToString();
                    richTextBox5.Text += Environment.NewLine + etos[i].ToString();
                    File.AppendAllText("etos.txt", frs, Encoding.UTF8);

                    string kalit = Environment.NewLine + artist[i].ToString();
                    richTextBox6.Text += Environment.NewLine + artist[i].ToString();
                    File.AppendAllText("kalitexnis.txt", frs, Encoding.UTF8);

                    string lang = Environment.NewLine + glossa[i].ToString();
                    richTextBox7.Text += Environment.NewLine + glossa[i].ToString();
                    File.AppendAllText("glossa.txt", frs, Encoding.UTF8);

                }


                for (int i = a2; i < names.Length; i++)
                {

                    string neoname = Environment.NewLine + names[i];
                    richTextBox2.Text += Environment.NewLine + names[i];
                    File.AppendAllText("names.txt", neoname, Encoding.UTF8);
                }

               

            }

        }



        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int count = names.Length;
            listBox1.SelectedItem = listBox1.Items[random.Next(0, count)];
            axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
            axWindowsMediaPlayer1.Ctlcontrols.play();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        /*private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
          {

              if(listBox1.SelectedItem == listBox1.Items[0])
              {
                  button8.Enabled = false;
              }
              else
              {
                  button8.Enabled = true;
              }

              if (listBox1.SelectedItem == listBox1.Items[names.Length - 1])
              {
                  button7.Enabled = false;
              }
              else
              {
                  button7.Enabled = true;
              }
          }
          */
        private void button4_Click(object sender, EventArgs e)
        {
            

            axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
            fores[listBox1.SelectedIndex]++;
            
            richTextBox3.Text = fores[0].ToString();
            for(int i=1; i < fores.Length; i++)
            {
                richTextBox3.Text += Environment.NewLine + fores[i].ToString();
            }
            File.WriteAllText("top5.txt", richTextBox3.Text, Encoding.UTF8);
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button7_Click(object sender, EventArgs e)
        {


            if (listBox1.SelectedItem != listBox1.Items[names.Length - 1])
            {
                for (int i = 0; i < names.Length - 1; i++)
                {

                    if (listBox1.SelectedItem == listBox1.Items[i])
                    {



                        listBox1.SelectedItem = listBox1.Items[i + 1];
                        axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
                        fores[listBox1.SelectedIndex]++;
                        richTextBox3.Text = fores[0].ToString();
                        for (int j = 1; j < fores.Length; j++)
                        {
                            richTextBox3.Text += Environment.NewLine + fores[j].ToString();
                        }
                        File.WriteAllText("top5.txt", richTextBox3.Text, Encoding.UTF8);
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                        break;
                    }
                }
            }
            else
            {

            }

        }



        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == listBox1.Items[0])
            {
                return;
            }
            else
            {
                button8.Enabled = true;
                for (int i = 1; i < names.Length; i++)
                {

                    if (listBox1.SelectedItem == listBox1.Items[i])
                    {



                        listBox1.SelectedItem = listBox1.Items[i - 1];
                        axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
                        fores[listBox1.SelectedIndex]++;
                        richTextBox3.Text = fores[0].ToString();
                        for (int j = 1; j < fores.Length; j++)
                        {
                            richTextBox3.Text += Environment.NewLine + fores[j].ToString();
                        }
                        File.WriteAllText("top5.txt", richTextBox3.Text, Encoding.UTF8);

                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }



                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            int k = 0, l = 0;

            richTextBox1.LoadFile("paths.txt", RichTextBoxStreamType.PlainText);
            richTextBox2.LoadFile("names.txt", RichTextBoxStreamType.PlainText);
            richTextBox3.LoadFile("top5.txt", RichTextBoxStreamType.PlainText);
            richTextBox4.LoadFile("eidos.txt", RichTextBoxStreamType.PlainText);
            richTextBox5.LoadFile("etos.txt", RichTextBoxStreamType.PlainText);
            richTextBox6.LoadFile("kalitexnis.txt", RichTextBoxStreamType.PlainText);
            richTextBox7.LoadFile("glossa.txt", RichTextBoxStreamType.PlainText);

        

            foreach (string s in richTextBox1.Lines)
            {

                p++;
            }
            paths = new string[p];
            foreach (string s in richTextBox1.Lines)
            {

                paths[k] = s;
                k++;

            }
            foreach (string s in richTextBox2.Lines)
            {
                n++;
            }
            names = new string[n];
            fores = new int[n];
            eidos = new string[p];
            etos = new string[p];
            artist = new string[p];
            glossa = new string[p];

            foreach(string s in richTextBox3.Lines)
            {
                fores[l] = int.Parse(s);
                l++;
            }
            l = 0;


            foreach (string s in richTextBox4.Lines)
            {
                eidos[l]=s;
                l++;
            }
            l = 0;

            foreach (string s in richTextBox5.Lines)
            {
                etos[l] = s;
                l++;
            }
            l = 0;


            foreach (string s in richTextBox6.Lines)
            {
                artist[l] = s;
                l++;
            }
            l = 0;

            foreach (string s in richTextBox7.Lines)
            {
                glossa[l] = s;
                l++;
            }
            l = 0;

            foreach (string s in richTextBox2.Lines)
            {
                names[l] = s;
                listBox1.Items.Add(names[l]);
                l++;
            }
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox1.FindString(textBox1.Text);
        }

        private void favoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] names2 = new string[n];
            int[] fores2 = new int[p];

            for(int i=0; i < names2.Length; i++)
            {
                names2[i] = names[i];
                fores2[i] = fores[i];
            }

            for (int i = 0; i < fores2.Length; i++)
            {
                for (int j= fores2.Length - 1; j > i; j--)
                {
                    if (fores2[j - 1] < fores2[j])
                    {
                        int temp = fores2[j - 1];
                        fores2[j - 1] = fores2[j];
                        fores2[j] = temp;
                        String temp1 = names2[j - 1];
                        names2[j - 1] = names2[j];
                        names2[j] = temp1;

                    }
                }
            }

            MessageBox.Show(names2[0] + "\n" + names2[1] + "\n" + names2[2] + "\n" + names2[3] + "\n" + names2[4] + "\n");

        }

        private void enimerosi_Click(object sender, EventArgs e)
        {
            eidos[listBox1.SelectedIndex]=textBox2.Text;
            etos[listBox1.SelectedIndex] = textBox3.Text;
            artist[listBox1.SelectedIndex] = textBox4.Text;
            glossa[listBox1.SelectedIndex] = textBox5.Text;
            richTextBox4.Text = eidos[0];
            richTextBox5.Text = etos[0];
            richTextBox6.Text = artist[0];
            richTextBox7.Text = glossa[0];
            for (int i = 1; i < eidos.Length; i++)
            {
                richTextBox4.Text += Environment.NewLine + eidos[i].ToString();
                richTextBox5.Text += Environment.NewLine + etos[i].ToString();
                richTextBox6.Text += Environment.NewLine + artist[i].ToString();
                richTextBox7.Text += Environment.NewLine + glossa[i].ToString();
            }
            File.WriteAllText("eidos.txt", richTextBox4.Text, Encoding.UTF8);
            File.WriteAllText("etos.txt", richTextBox5.Text, Encoding.UTF8);
            File.WriteAllText("kalitexnis.txt", richTextBox6.Text, Encoding.UTF8);
            File.WriteAllText("glossa.txt", richTextBox7.Text, Encoding.UTF8);

            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exodos exod = new exodos();
            exod.exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minima m = new minima();
            m.message();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string temp1, temp2,temp4,temp5,temp6,temp7;
            int temp3;
            int k = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.SelectedItem == listBox1.Items[i])

                {


                    for (int j = i + 1; j < names.Length; j++)
                    {
                        temp1 = names[j];
                        names[j] = names[j - 1];
                        names[j - 1] = temp1;

                        temp2 = paths[j];
                        paths[j] = paths[j - 1];
                        paths[j - 1] = temp2;

                        temp3 = fores[j];
                        fores[j] = fores[j - 1];
                        fores[j - 1] = temp3;

                        temp4 = eidos[j];
                        eidos[j] = eidos[j - 1];
                        eidos[j - 1] = temp4;

                        temp5 = etos[j];
                        etos[j] = etos[j - 1];
                        etos[j - 1] = temp5;

                        temp6 = artist[j];
                        artist[j] = artist[j - 1];
                        artist[j - 1] = temp6;

                        temp7 = glossa[j];
                        glossa[j] = glossa[j - 1];
                        glossa[j - 1] = temp7;

                    }
                }
                k++;
            }
            textBox2.Text = k.ToString();
            paths[k - 1] = "";
            names[k - 1] = "";
            fores[k - 1] = 0;
            eidos[k - 1] = "";
            etos[k - 1] = "";
            artist[k - 1] = "";
            glossa[k - 1] = "";

            richTextBox1.Text = paths[0];
            richTextBox2.Text = names[0];
            richTextBox3.Text = fores[0].ToString();
            richTextBox4.Text = eidos[0];
            richTextBox5.Text = etos[0];
            richTextBox6.Text = artist[0];
            richTextBox7.Text = glossa[0];
            for (int i = 1; i < paths.Length-1 ; i++)
            {
                richTextBox1.Text += Environment.NewLine + paths[i];
                richTextBox2.Text += Environment.NewLine + names[i];
                richTextBox3.Text += Environment.NewLine + fores[i].ToString();
                richTextBox4.Text += Environment.NewLine + eidos[i];
                richTextBox5.Text += Environment.NewLine + etos[i];
                richTextBox6.Text += Environment.NewLine + artist[i];
                richTextBox7.Text += Environment.NewLine + glossa[i];

            }

        
            File.WriteAllText("paths.txt", richTextBox1.Text, Encoding.UTF8);
              File.WriteAllText("names.txt", richTextBox2.Text, Encoding.UTF8);
            File.WriteAllText("top5.txt", richTextBox3.Text, Encoding.UTF8);
            File.WriteAllText("eidos.txt", richTextBox4.Text, Encoding.UTF8);
            File.WriteAllText("etos.txt", richTextBox5.Text, Encoding.UTF8);
            File.WriteAllText("kalitexnis.txt", richTextBox6.Text, Encoding.UTF8);
            File.WriteAllText("glossa.txt", richTextBox7.Text, Encoding.UTF8);


            for (int i = 0; i < listBox1.Items.Count; i++)
              {
                  listBox1.Items.Clear();
              }
              foreach(string s in richTextBox2.Lines)
              {
                  listBox1.Items.Add(s);
              }
            p--;
            n--;
           
            
            k = 0;
            paths = new string[p];
            names = new string[n];
            fores = new int[p];
            eidos = new string[p];
            etos = new string[p];
            artist = new string[p];
            glossa = new string[p];


            foreach (string s in richTextBox1.Lines)
            {
                paths[k] = s;
                k++;
            }
            k = 0;
            foreach(string s in richTextBox2.Lines)
            {
                names[k] = s;
                k++;
            }

            k = 0;
            foreach (string s in richTextBox3.Lines)
            {
                fores[k] = int.Parse(s);
                k++;
            }
            k = 0;

            foreach (string s in richTextBox4.Lines)
            {
                eidos[k] = s;
                k++;
            }
            k = 0;

            foreach (string s in richTextBox5.Lines)
            {
                etos[k] = s;
                k++;
            }
            k = 0;
            foreach (string s in richTextBox6.Lines)
            {
                artist[k] = s;
                k++;
            }
            k = 0;

            foreach (string s in richTextBox7.Lines)
            {
                glossa[k] = s;
                k++;
            }
          

        }
        }

    class exodos
    {
        public void exit()
        {
            Application.Exit();
        }

    }

    class minima
    {
        public void message()
        {
            MessageBox.Show("Symplirose ta textbox kai pata check gia na enimerothoyn oi plirofories tou tragoudiou pou exeis epilexi");
        }
    }

    }


