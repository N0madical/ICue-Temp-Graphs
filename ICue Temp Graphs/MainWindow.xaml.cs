using System;
using System.IO;
using System.Text;
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
using System.Diagnostics;

namespace ICue_Temp_Graphs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            File.Delete(@"C:\Users\video\Desktop\Icue Temp Logs\corsair_cue_20211121_23_06_48 - Copy.csv");
            File.Copy(@"C:\Users\video\Desktop\Icue Temp Logs\corsair_cue_20211121_23_06_48.csv", @"C:\Users\video\Desktop\Icue Temp Logs\corsair_cue_20211121_23_06_48 - Copy.csv");

            InitializeComponent();
            Debug.WriteLine("Hello2");

            // We can access ListViewPeople here because that's the Name of our list
            // using the x:Name property in the designer.
            ListViewPeople.ItemsSource = ReadCSV(@"C:\Users\video\Desktop\Icue Temp Logs\corsair_cue_20211121_23_06_48 - Copy.csv");
            

        }

        public IEnumerable<Person> ReadCSV(string filepath)
        {
            // We change file extension here to make sure it's a .csv file.
            // TODO: Error checking.
            //string[] lines = 
            //string[] lines = ReadAllLines(filepath, System.Text.Encoding encoding);
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(filepath, ".csv"));
            

            // lines.Select allows me to project each line as a Person. 
            // This will give me an IEnumerable<Person> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                // We return a person with the data in order.
                return new Person(data[0], data[1], data[2], data[3], data[4]);
            });

        }

        public class Person
        {
            public string filepath = @"C:\Users\video\Desktop\Icue Temp Logs\corsair_cue_20211121_23_06_48 - Copy.csv";

            public string filepath2 = @"C:\Users\video\Desktop\Icue Temp Logs\corsair_cue_20211121_23_06_48.csv";
            public string TimeStamp { get; set; }
            public string Temp1 { get; set; }
            public string Temp2 { get; set; }
            public string Temp3 { get; set; }
            public string Temp4 { get; set; }
            public static void Delete(string filepath) { }
            public static void Copy(string filepath2, string filepath) { }

            public Person(string Timestamp, string Value1, string Value2, string Value3, string Value4)
            {
                TimeStamp = Timestamp;
                Temp1 = Value1;
                Temp2 = Value2;
                Temp3 = Value3;
                Temp4 = Value4;
            }

        }
    }

}