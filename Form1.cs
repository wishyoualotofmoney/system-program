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

        // Объявление переменной для хранения процесса
        Process ConsoleAppProcess = null;

        // Создание объектов событий для синхронизации потоков
        // EventStart - событие для запуска процесса
        EventWaitHandle EventStart = new EventWaitHandle(false, EventResetMode.AutoReset, "EventStart");

        // EventStop - событие для остановки процесса
        EventWaitHandle EventStop = new EventWaitHandle(false, EventResetMode.AutoReset, "EventStop");

        // EventOK - событие для сигнализации успешного выполнения операции
        EventWaitHandle EventOK = new EventWaitHandle(false, EventResetMode.AutoReset, "EventOK");

        // EventCloseDialogApp - событие для закрытия диалога/приложения 
        EventWaitHandle EventCloseDialogApp = new EventWaitHandle(false, EventResetMode.AutoReset, "EventCloseDialogApp");

        // Переменная для отслеживания количества созданных потоков
        int threadcount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void but_start_Click(object sender, EventArgs e)
        {
            // Проверяем, что процесс не запущен или уже завершен
            if (ConsoleAppProcess == null || ConsoleAppProcess.HasExited)
            {
                // Если процесс не запущен или уже завершен, то сбрасываем счетчик потоков и очищаем элементы в listBox
                threadcount = 0;
                listBox.Items.Clear();

                // Запускаем процесс
                ConsoleAppProcess = Process.Start("C:/projects/gazizov_lb_1_system/Debug/gazizov_lb_1.exe");

                // Добавляем сообщение о главном потоке в listBox
                listBox.Items.Add("Главный поток");

                // Обновляем текстовое поле счетчика потоков
                textBox.Text = threadcount.ToString();
            }
            else
            {
                // Если процесс уже запущен, то создаем новые потоки в количестве, указанном в numericUpDown
                for (int i = 0; i < numericUpDown.Value; i++)
                {
                    // Устанавливаем событие запуска нового потока
                    EventStart.Set();

                    // Ожидаем сигнала об успешном выполнении операции
                    EventOK.WaitOne();

                    // Увеличиваем счетчик потоков
                    threadcount++;

                    // Добавляем информацию о новом потоке в listBox
                    listBox.Items.Add("Поток " + threadcount.ToString());

                    // Обновляем текстовое поле счетчика потоков
                    textBox.Text = threadcount.ToString();
                }
            }
        }


        private void but_stop_Click(object sender, EventArgs e)
        {
            // Проверяем, что процесс запущен и не завершен
            if (!(ConsoleAppProcess == null || ConsoleAppProcess.HasExited))
            {
                // Если есть запущенные потоки
                if (threadcount != 0)
                {
                    // Отправляем сигнал остановки потока
                    EventStop.Set();

                    // Ожидаем сигнала об успешном завершении операции
                    EventOK.WaitOne();

                    // Уменьшаем счетчик потоков
                    threadcount--;

                    // Удаляем информацию о завершенном потоке из listBox
                    listBox.Items.Remove("Поток " + (threadcount + 1).ToString());

                    // Обновляем текстовое поле счетчика потоков
                    textBox.Text = threadcount.ToString();
                }
                else
                {
                    // Если нет запущенных потоков, то отправляем сигнал закрытия диалога приложения и закрываем приложение
                    EventCloseDialogApp.Set();
                    this.Close();
                }
            }
            else
            {
                // Если процесс не запущен или уже завершен, то отправляем сигнал закрытия диалога приложения и закрываем приложение
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
