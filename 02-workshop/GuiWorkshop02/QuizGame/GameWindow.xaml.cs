using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuizGame
{
    public partial class GameWindow : Window
    {
        static Random r = new Random();
        string correctAnswer;
        Question question;
        int seconds = 60;
        public GameWindow(Question question)
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();

            this.question = question;
            correctAnswer = question.Answers[0];
            lbl_time.Content = seconds;

            string[] answersCopy = new string[4];
            for (int i = 0; i < question.Answers.Length; i++)
            {
                answersCopy[i] = question.Answers[i];
            }

            //keverés
            for (int i = 0; i < 100; i++)
            {
                int a = r.Next(0, 4);
                int b = r.Next(0, 4);
                string tmp = answersCopy[a];
                answersCopy[a] = answersCopy[b];
                answersCopy[b] = tmp;
            }

            btn1.Content = answersCopy[0];
            btn2.Content = answersCopy[1];
            btn3.Content = answersCopy[2];
            btn4.Content = answersCopy[3];

            lbl_question.Content = question.QuestionText;

        }

        private void Dt_Tick(object? sender, EventArgs e)
        {
            seconds--;
            this.Dispatcher.Invoke(() =>
            {
                lbl_time.Content = seconds;
            });
            if (seconds == 0)
            {
                this.DialogResult = false;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label label)
            {
                if (label.Content.ToString() == correctAnswer)
                {
                    question.Correct = true;
                    this.DialogResult = true;
                }
                else
                {
                    question.Correct = false;
                    this.DialogResult = false;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(question.Correct is null) // no answer has been selected yet
            {                
                var result = MessageBox.Show("Biztosan bezárod?", "Erősítsd meg", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }            
        }
    }
}
