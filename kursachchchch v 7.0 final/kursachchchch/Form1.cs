using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace kursachchchch
{
    public partial class Form1 : Form
    {
        int i = 0;
        int b = 0;
        int time;
        int tekyshai_time = 0;

        private generator generator;
        private OP OP;

        public Form1()
        {
            InitializeComponent();
            label1.TextChanged += tabl; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button1.Enabled = false;
            button5.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button4.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tekyshai_time < time)
            {
                generator.osnov_generator();
                OP.op_funct();
                update();
                tekyshai_time++;
            }
            else
            {
                update();
                timer1.Stop();
                button2.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = false;
                button3.Enabled = true;
                button6.Enabled = true;
            }
        }

        public void update()
        {
            Single tmp = 0;
            Single tmp2 = 1;
            Single tmp3 = 0;
            Single tmp4 = 1;

            if (!(generator.terminal.tipezav == 0))
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = generator.terminal.zav();
                dataGridView1.Rows[i].Cells[3].Value = NMD1.zavkas.Count();
                i++;
            }
            if(!(generator.terminal2.tipezav == 0))
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = generator.terminal2.zav();
                dataGridView1.Rows[i].Cells[3].Value = NMD1.zavkas.Count();
                i++;
            }
            if (!(generator.terminal3.tipezav == 0))
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = generator.terminal3.zav();
                dataGridView1.Rows[i].Cells[3].Value = NMD1.zavkas.Count();
                i++;
            }
            label1.Text = Convert.ToString(Processor.kol_vo_obrabotan_zav);
            label4.Text = Convert.ToString(NMD1.zavkas.Count());

            for(int c = 0; c < (dataGridView1.RowCount); c++)
            {
                if (!(dataGridView1.Rows[c].Cells[3].Value == null))
                {
                    tmp = tmp + Convert.ToSingle(dataGridView1.Rows[c].Cells[3].Value);
                    tmp2++;
                }
            }

            for (int p = 0; p < (dataGridView1.RowCount); p++)
            {
                if (!(dataGridView1.Rows[p].Cells[2].Value == null))
                {
                    tmp3 = tmp3 + Convert.ToSingle(dataGridView1.Rows[p].Cells[2].Value);
                    tmp4++;
                }
            }

            label8.Text = Convert.ToString(tmp / (tmp2-1));
            label9.Text = Convert.ToString(tmp3 / (tmp4-1));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button2.Enabled = true;
            button5.Enabled = true;
            button4.Enabled = false;
            button3.Enabled = true;
            button6.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            generator = new generator();
            OP = new OP();
            Processor.time();
            if (textBox1.Text == "")
                MessageBox.Show("ТЫ дибил!!!");
            else
            {
                time = Convert.ToInt32(textBox1.Text)*60;
                button3.Enabled = false;
                button1.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void tabl(object sender, EventArgs e)
        {
            dataGridView1.Rows[b].Cells[1].Value = "Готово";
            dataGridView1.Rows[b].Cells[2].Value = Convert.ToString(Processor.timer + OP.vrema_zapis + OP.vrema_NMD);
            b++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tekyshai_time = 0;
            Processor.kol_vo_obrabotan_zav = 0;
            label1.Text = "0";
            label4.Text = "0";
            label8.Text = "0";
            label9.Text = "0";
            i = 0;
            b = 0;
            dataGridView1.Rows.Clear();
            NMD1.zavkas.Clear();
        }
    }
}
