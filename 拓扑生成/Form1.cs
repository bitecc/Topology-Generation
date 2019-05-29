using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i=0;i<6;i++)
            {
                Side[i] = new Boundary("", "", "");
            }//初始化所有弧段信息
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            string filename = o.FileName;
            StreamReader reader = null;
            reader = new StreamReader(filename);


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
