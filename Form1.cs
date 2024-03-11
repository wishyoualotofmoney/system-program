using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gazizov_lb_1_system
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        EventWaitHandle EventStart = new EventWaitHandle(false, EventResetMode.AutoReset, "GazizovEventStart");
        EventWaitHandle EventStop = new EventWaitHandle(false, EventResetMode.AutoReset, "GazizovEventStop");
        EventWaitHandle EventQuit = new EventWaitHandle(false, EventResetMode.AutoReset, "GazizovEventQuit");
        EventWaitHandle EventConfirm = new EventWaitHandle(false, EventResetMode.AutoReset, "GazizovEventConfirm");
        Process ChildProcess = null;

        // Проверка на наличие процесса
        private Boolean ConsoleIsOpen()
        {
            if (ChildProcess == null || ChildProcess.HasExited)
            {
                listBox.Items.Clear();
                NoMainThread();
                return false;
            }
            return true;
        }

        private void but_start_Click(object sender, EventArgs e)
        {
            //int addNum = Int32.Parse(TextBox1.Text);
            int addNum = Convert.ToInt32(Math.Round(numericUpDown.Value, 0));
            for (int i = 0; i < addNum; ++i)
            {
                if (ConsoleIsOpen())
                {
                    EventStart.Set();
                    EventConfirm.WaitOne();

                    listBox.Items.Add("Поток " + (listBox.Items.Count - 1).ToString());
                }
                else
                {
                    ChildProcess = Process.Start("C:\\projects\\gazizov_lb_1_system\\Debug\\gazizov_lb_1.exe");

                    listBox.Items.Clear();
                    listBox.Items.Add("Все потоки");
                    listBox.Items.Add("Главный поток");
                    break;
                }
            }
        }


        private void but_stop_Click(object sender, EventArgs e)
        {
            if (!ConsoleIsOpen())
                return;

            EventStop.Set();
            EventConfirm.WaitOne();

            listBox.Items.RemoveAt(listBox.Items.Count - 1);
            if (listBox.Items.Count == 1)
                NoMainThread();
        }

        private void NoMainThread()
        {
            listBox.Items.Clear();
            listBox.Items.Add("Нет запущенных потоков");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            NoMainThread();
            numericUpDown.Value = 1;
            //TextBox1.SelectedText = "1";
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            if (!ConsoleIsOpen())
                return;

            EventQuit.Set();
            EventConfirm.WaitOne();
        }
       /* private void NumThreadKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }*/

    }
}
