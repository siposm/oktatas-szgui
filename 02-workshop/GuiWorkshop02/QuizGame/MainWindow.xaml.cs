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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Question> questions;
        public MainWindow()
        {
            InitializeComponent();
            questions = new List<Question>();
            questions.Add(new Question()
            {
                QuestionText = "Melyik megyében van Pécs?",
                Answers = new string[] { "Baranya", "Békés", "Bács-Kiskun", "Nógrád" }
            });
            questions.Add(new Question()
            {
                QuestionText = "Mi a legjobb kaja?",
                Answers = new string[] { "Hambi", "Pizza", "Fagyi", "Péksüti" }
            });
            questions.ForEach(x =>
            {
                Label l = new Label();
                l.Tag = x;
                l.Content = new Image()
                {
                    Name = "pic",
                    Source = new BitmapImage(new Uri("https://picsum.photos/70")),
                    Stretch = Stretch.None,
                    Width = 70,
                    Height = 70
                };
                l.HorizontalContentAlignment = HorizontalAlignment.Center;
                l.VerticalContentAlignment = VerticalAlignment.Center;
                l.Width = 130;
                l.Height = 130;
                l.Margin = new Thickness(20);
                l.Background = Brushes.LightBlue;
                wrap.Children.Add(l);
            });
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label label)
            {
                if (label.Tag is Question question)
                {
                    GameWindow gw = new GameWindow(question);
                    if (gw.ShowDialog() == true)
                    {
                        label.Background = Brushes.LightGreen;
                        label.IsEnabled = false;
                    }
                    else
                    {
                        label.Background = Brushes.LightPink;
                        label.IsEnabled = false;
                    }
                }
                
            }
        }
    }
}
