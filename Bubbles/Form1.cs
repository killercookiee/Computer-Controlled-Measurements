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

namespace Bubbles
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
        private int CountBubbles(string filePath)
        {
            double threshold = 1.7;
            int holdoff = 20;
            int count = 0;
            bool inBubble = false;
            int holdoffCounter = 0;

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2) continue;
                    if (holdoffCounter > 0) { holdoffCounter--; }
                    if (!double.TryParse(parts[1],
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double value)) continue;

                    if (value < threshold && !inBubble && holdoffCounter == 0)
                    {
                        count++;
                        inBubble = true;
                        holdoffCounter = holdoff;
                    }

                    else if (value >= threshold) { inBubble = false; }
                }
            }
            return count++;
        }
    }
}
