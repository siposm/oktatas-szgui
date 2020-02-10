using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace objectViewer
{
    class ToDetectAttribute : Attribute { }

    #region MyClasses
    [ToDetect]
    class Bot
    {
        public int BotID { get; set; }
    }

    [ToDetect]
    class Dog : Bot
    {
        public int Name { get; set; }

        public void Bark() { }
    }

    [ToDetect]
    class Cat : Bot
    {
        public int Name { get; set; }
        public bool HasOwner { get; set; }

        public void Meow() { }
    }

    [ToDetect]
    class Character
    {
        public int BirthYear { get; set; }
        public int RelationNumber { get; set; }
        public string Name { get; set; }
    }

    [ToDetect]
    class Teacher : Character
    {
        public double MarkMyProfessorRatings { get; set; }
        public int StudentsNumber { get; set; }

        public void AddGradeToStudent(Student s) { }
    }
    #endregion

    [ToDetect]
    class Student : Character
    {
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public bool StudentGender { get; set; }
        public bool StudentHasAlgerie { get; set; }

        public void TakeCourse(int lessonNumber) { }
    }



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetCustomAttribute<ToDetectAttribute>() != null);
            foreach (var item in types)
                objectSelectorListBox.Items.Add(item.Name);

        }

        private void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            
            // clear prev. values
            propertiesListBox.Items.Clear();
            methodsListBox.Items.Clear();

            
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.ToString() == objectSelectorListBox.SelectedItem.ToString())
                .FirstOrDefault();

            // PROPERTIES add new values
            foreach (var item in types.GetProperties())
                propertiesListBox.Items.Add(item.Name);

            // METHODS add new values
            foreach (var item in types.GetMethods())
                if( ! (item.Name.StartsWith("get_") || item.Name.StartsWith("set_")) ) // additional filter if needed...
                    methodsListBox.Items.Add(item.Name);

        }
    }
}
