using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private string GetWeek(DateTime nowDt)
        {
            string ret = "";
            if (nowDt.DayOfWeek == DayOfWeek.Monday)
                ret = "월";
            else if (nowDt.DayOfWeek == DayOfWeek.Tuesday)
                ret = "화";
            else if (nowDt.DayOfWeek == DayOfWeek.Wednesday)
                ret = "수";
            else if (nowDt.DayOfWeek == DayOfWeek.Thursday)
                ret = "목";
            else if (nowDt.DayOfWeek == DayOfWeek.Friday)
                ret = "금";
            else if (nowDt.DayOfWeek == DayOfWeek.Saturday)
                ret = "토";
            else if (nowDt.DayOfWeek == DayOfWeek.Sunday)
                ret = "일";

            return ret;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
            //                                CultureInfo.InvariantCulture);
            DateTime nowDt = DateTime.Now;
            string timestamp = nowDt.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);

            label1.Text = GetWeek(nowDt) + "요일 " + timestamp;
        }

        // Copy this text into the Label using
        // the biggest font that will fit.
        private void SizeLabelFont(Label lbl)
        {
            // Only bother if there's text.
            string txt = lbl.Text;
            if (txt.Length > 0)
            {
                int best_size = 100;

                // See how much room we have, allowing a bit
                // for the Label's internal margin.
                int wid = lbl.DisplayRectangle.Width - 10;
                int hgt = lbl.DisplayRectangle.Height - 10;

                // Make a Graphics object to measure the text.
                using (Graphics gr = lbl.CreateGraphics())
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        using (Font test_font =
                            new Font(lbl.Font.FontFamily, i))
                        {
                            // See how much space the text would
                            // need, specifying a maximum width.
                            SizeF text_size =
                                gr.MeasureString(txt, test_font);
                            if ((text_size.Width > wid) ||
                                (text_size.Height > hgt))
                            {
                                best_size = i - 1;
                                break;
                            }
                        }
                    }
                }

                // Use that font size.
                lbl.Font = new Font(lbl.Font.FontFamily, best_size);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double width = Screen.PrimaryScreen.Bounds.Width;
            double height = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(0, 0);
            this.Width = (int)(width);
            this.Height = (int)(height * 0.2);

            SizeLabelFont(label1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
