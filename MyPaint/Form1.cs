using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }
        bool canPaint = false;
        Graphics g;
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            canPaint = true;
            if (drawSquare)
            {
                SolidBrush s = new SolidBrush(toolStripButton1.ForeColor);

                g.FillRectangle(s, e.X, e.Y, Convert.ToInt32(toolStripTextBox2.Text), Convert.ToInt32(toolStripTextBox2.Text));
                canPaint = false;
                drawSquare = false;
            }
            else if (drawRect)
            {
                SolidBrush s = new SolidBrush(toolStripButton1.ForeColor);

                g.FillRectangle(s, e.X, e.Y, Convert.ToInt32(toolStripTextBox2.Text) * 2, Convert.ToInt32(toolStripTextBox2.Text));
                canPaint = false;
                drawRect = false;
            }
            else if (drawCircle)
            {
                SolidBrush s = new SolidBrush(toolStripButton1.ForeColor);
                g.FillEllipse(s, e.X, e.Y, Convert.ToInt32(toolStripTextBox2.Text), Convert.ToInt32(toolStripTextBox2.Text));

                canPaint = false;
                drawCircle = false;
            }
            else if (drawEllipse)
            {
                SolidBrush s = new SolidBrush(toolStripButton1.ForeColor);
                g.FillEllipse(s, e.X, e.Y, Convert.ToInt32(toolStripTextBox2.Text) * 5, Convert.ToInt32(toolStripTextBox2.Text));

                canPaint = false;
                drawEllipse = false;
            }
            else if (circ)
            {
                Pen p = new Pen(toolStripButton1.ForeColor, Convert.ToInt32(toolStripTextBox2.Text));
                g.DrawEllipse(p, e.X, e.Y, Convert.ToInt32(toolStripTextBox2.Text) * 5, Convert.ToInt32(toolStripTextBox2.Text));
                canPaint = false;
                circ = false;
            }
            else if (sqr)
            {
                Pen p = new Pen(toolStripButton1.ForeColor, Convert.ToInt32(toolStripTextBox2.Text));
                g.DrawRectangle(p, e.X, e.Y, Convert.ToInt32(toolStripTextBox2.Text), Convert.ToInt32(toolStripTextBox2.Text));
                sqr = false;
                canPaint = false;
                
            }
            else if (rect)
            {
                Pen p = new Pen(toolStripButton1.ForeColor, Convert.ToInt32(toolStripTextBox2.Text));
                g.DrawRectangle(p, e.X, e.Y, Convert.ToInt32(toolStripTextBox2.Text)*2, Convert.ToInt32(toolStripTextBox2.Text));
                rect = false;
                canPaint = false;
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canPaint = false;
            prevX = null;
            prevY = null;

        }
        int? prevX = null;
        int? prevY = null;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (canPaint)
            {
                if (rubber)
                {
                    Pen p = new Pen(Color.White, float.Parse(toolStripTextBox3.Text));
                    g.DrawLine(p, new Point(prevX ?? e.X, prevY ?? e.Y), new Point(e.X, e.Y));
                    prevX = e.X;
                    prevY = e.Y;
                }
                else
                {
                    Pen p = new Pen(toolStripButton1.ForeColor, float.Parse(toolStripTextBox1.Text));
                    g.DrawLine(p, new Point(prevX ?? e.X, prevY ?? e.Y), new Point(e.X, e.Y));
                    prevX = e.X;
                    prevY = e.Y;
                }

            }
        }
        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toolStripButton1.ForeColor = cd.Color;
            }
        }
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            g.Clear(panel1.BackColor);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
               
                panel1.BackColor = cd.Color;
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }
        bool drawSquare = false;
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawSquare = true;
        }
        bool drawRect = false;
        private void rectangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawRect = true;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] imagePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach(string path in imagePath)
            {
                g.DrawImage(Image.FromFile(path), new Point(0, 0));
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            
           // panel1.Refresh();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != " ")
            {
              //  Bitmap b = new Bitmap();

            } 

        }
        bool drawCircle = false;
        
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawCircle = true;
        }

        private void myPaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyPaint Application. ^_^ \n\nVersion 0.1 Beta.\n\nThe Paint that Meets my Expectation.\nHoping against hope that my efforts will outweigh the bugs in the program.\n\nHowever, all rights reserved!!!", "About MyPaint. @nm");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }
        bool rubber = false;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            rubber = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            rubber = false;
        }
        bool drawEllipse = false;
        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawEllipse = true;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog p = new PrintDialog();
            p.ShowDialog();
        }
        bool rect = false;
        bool sqr = false;
        bool circ=false;
        private void squareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sqr = true;
        }
       
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rect = true;
        }
       
        private void circleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            circ = true;
        }
    }


}
