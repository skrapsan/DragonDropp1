using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragonDropp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setter skjermstørrelsen til 800x200
            Size s = new System.Drawing.Size(800, 200);
            this.ClientSize = s;

            listBox1.Items.Add("0001 Lasse Berntzen");
            listBox1.Items.Add("0002 Hans Hansen");
            listBox1.Items.Add("0003 Per Nilsen");
            listBox1.Items.Add("0004 Aage Andersen");

            // skal generere 3x4 rom
            int i, j;
            for (i = 1; i <= 14; i++)
            {
                for (j = 1; j <= 4; j++)
                {
                    Panel a = new Panel();
                    a.Location = new Point(i * 200, j * 50);
                    a.Width = 180;
                    a.Height = 40;
                    a.Name = "Rom " + (((i * 4) - 3) + (j - 1));
                    a.BackColor = Color.Yellow;
                    a.AllowDrop = true;
                    
                    // Setter opp hendelseshåndterere for DragOver og DragDrop
                    a.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
                    a.DragOver += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
                    a.Visible = true;
                    
                    // Legger til en label inne i panelet
                    Label l = new Label();
                    l.Location = new Point(10, 10);
                    l.Width = 180;
                    l.Text = a.Name;
                    a.Controls.Add(l);
                    
                    // Legger panelet til form
                    this.Controls.Add(a);

                }
            }
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                DragDropEffects dropEffect = listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Move);
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.All);
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            // item vil inneholde navnet som dras fra nedtrekkslisten
            Object item = (object)e.Data.GetData(typeof(System.String));
            //Typekonverter for å få tak i egenskapene til Control
            Control c = (Control)sender;
            c.Controls[0].Text = item.ToString();
            c.BackColor = Color.Red;
        }
    }
}
