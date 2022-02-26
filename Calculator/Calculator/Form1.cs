using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string a, b, c, mark;

        #region Number

        private void button0_Click(object sender, EventArgs e)
        {
            if (textBoxshow.Text.Contains("="))
            {
                a = "";
                b = "0";
                mark = "";
            }
            else if (b.StartsWith("0") || b.StartsWith("-0"))
            {
                if (b.Contains("."))
                {
                    b += "0";
                }
            }
            else
            {
                b += "0";
            }
            textBoxshow.Text = a + mark + b;


        }
        private void NumClick(string num)
        {
            if (textBoxshow.Text.Contains("="))
            {
                a = "";
                b = num;
                mark = "";
            }
            else if (b == "0")
            {
                b = num;
            }
            else if (b == "-0")
            {
                b = "-" + num;
            }
            else
            {
                b += num;
            }
            textBoxshow.Text = a + mark + b;
        }
        private void button1_Click(object sender, EventArgs e) => NumClick("1");
        private void button2_Click(object sender, EventArgs e) => NumClick("2");
        private void button3_Click(object sender, EventArgs e) => NumClick("3");
        private void button4_Click(object sender, EventArgs e) => NumClick("4");
        private void button5_Click(object sender, EventArgs e) => NumClick("5");
        private void button6_Click(object sender, EventArgs e) => NumClick("6");
        private void button7_Click(object sender, EventArgs e) => NumClick("7");
        private void button8_Click(object sender, EventArgs e) => NumClick("8");
        private void button9_Click(object sender, EventArgs e) => NumClick("9");

        private void buttondot_Click(object sender, EventArgs e)
        {
            if (textBoxshow.Text.Contains("="))
            {
                a = "";
                b = "0.";
                mark = "";
            }
            else if (b == "")
            {
                b = "0.";
            }
            else if (b == "-")
            {
                b = "-0.";
            }
            else if (!b.Contains("."))
            {
                b += ".";
            }
            textBoxshow.Text = a + mark + b;
        }

        #endregion

        #region Cal

        private void MarkClick(string m)
        {
            if (a == "" && b == "")
            {
                b = "0";
            }
            if (textBoxshow.Text.Contains("="))
            {
                a = c;
                mark = m;
                b = "";
            }
            else if (a != "" && b == "")
            {
                mark = m;
            }
            else if (a == "")
            {
                a = Del0(b);
                b = "";
                mark = m;
            }
            textBoxshow.Text = a + mark + b;
        }
        private void buttonjia_Click(object sender, EventArgs e) => MarkClick("+");
        private void buttonjian_Click(object sender, EventArgs e) => MarkClick("-");
        private void buttoncheng_Click(object sender, EventArgs e) => MarkClick("×");
        private void buttonchu_Click(object sender, EventArgs e) => MarkClick("÷");
        private void buttonzhc_Click(object sender, EventArgs e) => MarkClick("\\");

        #endregion
        private string Del0(string b)
        {
            return b.Contains(".") ? b.TrimEnd('0').TrimEnd('.') : b;
        }

        private void buttonfu_Click(object sender, EventArgs e)
        {
            if (textBoxshow.Text.Contains("="))
            {
                a = "";
                b = "-0";
                mark = "";
            }
            else if (b.StartsWith("-"))
            {
                b = b.Substring(1);
            }
            else
            {
                b = "-" + b;
            }
            textBoxshow.Text = a + mark + b;
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            if (textBoxshow.Text.Contains("="))
            {
                textBoxshow.Text = a + mark + b;
            }
            else if (b.Length > 1)
            {
                b = b.Substring(0, b.Length - 1);
            }
            else if (b.Length == 1)
            {
                if (a == "" && mark == "")
                {
                    b = "0";
                }
                else
                {
                    b = "";
                }
            }
            else if (a != "" && mark != "" && b == "")
            {
                b = a;
                mark = "";
                a = "";
            }
            textBoxshow.Text = a + mark + b;
        }

        private void textBoxshow_TextChanged(object sender, EventArgs e)
        {
            textBoxshow.SelectionStart = textBoxshow.Text.Length;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            a = "";
            b = "0";
            mark = "";
            c = "0";
            textBoxshow.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a = "";
            b = "0";
            mark = "";
            c = "0";
        }

        private void buttondy_Click(object sender, EventArgs e)
        {
            if (textBoxshow.Text.Contains("=") || a == "" || b == "" || mark == "" || b == "-")
            {
                return;
            }
            b = Del0(b);
            double na, nb, nc;
            int yu = 0;
            na = Convert.ToDouble(a);
            nb = Convert.ToDouble(b);
            if (mark == "÷" && nb == 0)
            {
                MessageBox.Show("除数不能为0！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mark == "\\" && (int)nb == 0)
            {
                MessageBox.Show("除数不能为0！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (mark)
            {
                case "-":
                    nc = na - nb;
                    break;
                case "×":
                    nc = na * nb;
                    break;
                case "÷":
                    nc = na / nb;
                    break;
                case "\\":
                    nc = (int)na / (int)nb;
                    yu = (int)na % (int)nb;
                    break;
                default:
                    nc = na + nb;
                    break;

            }
            string mkb = b.StartsWith("-") ? "(" + b + ")" : b;
            if (mark == "\\")
            {
                c = ((int)nc).ToString();
                textBoxshow.Text = a + mark + mkb + "=" + c + "余" + yu.ToString();
            }
            else
            {
                c = nc.ToString();
                textBoxshow.Text = a + mark + mkb + "=" + c;
            }
            textBoxhis.AppendText(textBoxshow.Text + "\r\n");
        }
    }
}
