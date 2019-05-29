using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拓扑生成
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //存放弧段信息的类
        public class Boundary
        {
            public string name;//弧名
            public string S, E, Pl, Pr;//起始点、左右多边形
            public Boundary(string str, string s0,string e0)
            {
                name = str;
                S = s0;E = e0;Pl = "";Pr = "";
            }
        }
        Boundary[] Side= new Boundary[6];
        string[,] Point = new string[4, 4];

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                Side[i] = new Boundary("", "", "");
            }//初始化所有弧段信息
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            string filename = o.FileName;
            StreamReader reader = null;
            reader = new StreamReader(filename);
            string line = reader.ReadLine();
            for (int i = 0; i < 6; line = reader.ReadLine())
            {
                line = new Regex("[\\s]+").Replace(line, " ");
                string[] str = line.Split(' ');
                Side[i] = new Boundary(str[0], str[1], str[2]);
                i++;
            }
            if (reader != null)
                reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //初始化所有点信息
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Point[i, j] = "";
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            string filename = o.FileName;
            StreamReader reader = null;
            reader = new StreamReader(filename);
            string line = reader.ReadLine();
            for (int i = 0; i < 4; line = reader.ReadLine())
            {
                line = new Regex("[\\s]+").Replace(line, " ");
                string[] str = line.Split(' ');
                for (int j = 0; j < 4; j++)
                {
                    Point[i, j] = str[j];
                }
                i++;
            }
            if (reader != null)
                reader.Close();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            string N0, Nc;
            for(int i=0,j=1;i<6;i++)
            {
                if(Side[i].Pl=="")
                {
                    richTextBox1.Text += "P" + j + " " + Side[i].name + " ";
                    Side[i].Pl = "P" + j;
                    N0 = Side[i].S;
                    Nc = Side[i].E;
                    string A = Side[i].name;
                    int B = 0;
                    while(N0!=Nc)
                    {
                        for(int m=0;m<4;m++)
                        {
                            if(Point[m,0]==Nc)
                            {
                                for(int n=1;n<4;n++)
                                {
                                    if(Point[m,n]==A)
                                    {
                                        if (n == 3)
                                            n = 0;
                                        B = Convert.ToInt16(Point[m, n + 1]);
                                        break;
                                    }
                                }
                            }
                        }
                        richTextBox1.Text += Side[B - 1].name + " ";
                        if(Nc==Side[B-1].S)
                        {
                            Side[B - 1].Pl = "P" + j;
                            Nc = Side[B - 1].E;
                            A = Side[B - 1].name;
                        }
                        else
                        {
                            Side[B - 1].Pr = "P" + j;
                            Nc = Side[B - 1].S;
                            A = Side[B - 1].name;
                        }
                        if (N0 == Nc)
                            break;
                    }
                    j++;
                    richTextBox1.Text += "\n";
                }
                if(Side[i].Pr=="")
                {
                    richTextBox1.Text += "P" + j + " " + Side[i].name + " ";
                    Side[i].Pl = "P" + j;
                    N0 = Side[i].E;
                    Nc = Side[i].S;
                    string A = Side[i].name;
                    int B = 0;
                    while (N0 != Nc)
                    {
                        for (int m = 0; m < 4; m++)
                        {
                            if (Point[m, 0] == Nc)
                            {
                                for (int n = 1; n < 4; n++)
                                {
                                    if (Point[m, n] == A)
                                    {
                                        if (n == 3)
                                            n = 0;
                                        B = Convert.ToInt16(Point[m, n + 1]);
                                        break;
                                    }
                                }
                            }
                        }
                        richTextBox1.Text += Side[B - 1].name + " ";
                        if (Nc == Side[B - 1].S)
                        {
                            Side[B - 1].Pl = "P" + j;
                            Nc = Side[B - 1].E;
                            A = Side[B - 1].name;
                        }
                        else
                        {
                            Side[B - 1].Pr = "P" + j;
                            Nc = Side[B - 1].S;
                            A = Side[B - 1].name;
                        }
                        if (N0 == Nc)
                            break;
                    }
                    j++;
                    richTextBox1.Text += "\n";
                }
            }
            for(int i=0;i<6;i++)
            {
                richTextBox2.Text += "弧段" + Side[i].name + " 左多边形为：" + Side[i].Pl + " 右多边形为：" + Side[i].Pr + "\n";
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
