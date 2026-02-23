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

namespace Fibonacci
{
    public partial class Form1 : Form
    {
        int F0 = 1;
        int F1 = 1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fibtextbox.Text = "Write the number of numbers to show";
            button1.Text = "Save";
            button2.Text = "Moodle task";
        }

        private int getFibonachi(int n)
        {
            int current = F1;
            int previous = F0;
            if (n < 1) { return F0; }
            else if (n == 1) { return F1; }
            else
            {
                for (int index = 1; index < n; index++)
                {
                    int next = current + previous;
                    previous = current;
                    current = next;
                }
                return current;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Fibtextbox.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Enter a positive integer.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = "fibonacci.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                        {
                            writer.WriteLine($"Fibonacci Sequence - first {count} numbers: ");
                            long[] fib = new long[count];
                            for (int i = 0; i < count; i++)
                            {
                                fib[i] = getFibonachi(i);
                                writer.WriteLine($"F{i} = {fib[i]}");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Error writing file");
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Difference between 20th and 17th = {getFibonachi(20) - getFibonachi(17)}");
        }
    }
}
