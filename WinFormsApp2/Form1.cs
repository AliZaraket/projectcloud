using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Position = new System.Drawing.Point(Cursor.Position.X + 10, Cursor.Position.Y);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}