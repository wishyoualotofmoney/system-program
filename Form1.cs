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

        // ���������� ���������� ��� �������� ��������
        Process ConsoleAppProcess = null;

        // �������� �������� ������� ��� ������������� �������
        // EventStart - ������� ��� ������� ��������
        EventWaitHandle EventStart = new EventWaitHandle(false, EventResetMode.AutoReset, "EventStart");

        // EventStop - ������� ��� ��������� ��������
        EventWaitHandle EventStop = new EventWaitHandle(false, EventResetMode.AutoReset, "EventStop");

        // EventOK - ������� ��� ������������ ��������� ���������� ��������
        EventWaitHandle EventOK = new EventWaitHandle(false, EventResetMode.AutoReset, "EventOK");

        // EventCloseDialogApp - ������� ��� �������� �������/���������� 
        EventWaitHandle EventCloseDialogApp = new EventWaitHandle(false, EventResetMode.AutoReset, "EventCloseDialogApp");

        // ���������� ��� ������������ ���������� ��������� �������
        int threadcount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void but_start_Click(object sender, EventArgs e)
        {
            // ���������, ��� ������� �� ������� ��� ��� ��������
            if (ConsoleAppProcess == null || ConsoleAppProcess.HasExited)
            {
                // ���� ������� �� ������� ��� ��� ��������, �� ���������� ������� ������� � ������� �������� � listBox
                threadcount = 0;
                listBox.Items.Clear();

                // ��������� �������
                ConsoleAppProcess = Process.Start("C:/projects/gazizov_lb_1_system/Debug/gazizov_lb_1.exe");

                // ��������� ��������� � ������� ������ � listBox
                listBox.Items.Add("������� �����");

                // ��������� ��������� ���� �������� �������
                textBox.Text = threadcount.ToString();
            }
            else
            {
                // ���� ������� ��� �������, �� ������� ����� ������ � ����������, ��������� � numericUpDown
                for (int i = 0; i < numericUpDown.Value; i++)
                {
                    // ������������� ������� ������� ������ ������
                    EventStart.Set();

                    // ������� ������� �� �������� ���������� ��������
                    EventOK.WaitOne();

                    // ����������� ������� �������
                    threadcount++;

                    // ��������� ���������� � ����� ������ � listBox
                    listBox.Items.Add("����� " + threadcount.ToString());

                    // ��������� ��������� ���� �������� �������
                    textBox.Text = threadcount.ToString();
                }
            }
        }


        private void but_stop_Click(object sender, EventArgs e)
        {
            // ���������, ��� ������� ������� � �� ��������
            if (!(ConsoleAppProcess == null || ConsoleAppProcess.HasExited))
            {
                // ���� ���� ���������� ������
                if (threadcount != 0)
                {
                    // ���������� ������ ��������� ������
                    EventStop.Set();

                    // ������� ������� �� �������� ���������� ��������
                    EventOK.WaitOne();

                    // ��������� ������� �������
                    threadcount--;

                    // ������� ���������� � ����������� ������ �� listBox
                    listBox.Items.Remove("����� " + (threadcount + 1).ToString());

                    // ��������� ��������� ���� �������� �������
                    textBox.Text = threadcount.ToString();
                }
                else
                {
                    // ���� ��� ���������� �������, �� ���������� ������ �������� ������� ���������� � ��������� ����������
                    EventCloseDialogApp.Set();
                    this.Close();
                }
            }
            else
            {
                // ���� ������� �� ������� ��� ��� ��������, �� ���������� ������ �������� ������� ���������� � ��������� ����������
                EventCloseDialogApp.Set();
                this.Close();
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventCloseDialogApp.Set();
            return;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
