using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VoiceRecorder
{
    /// <summary>
    /// Interaction logic for RekamJejak.xaml
    /// </summary>
    public partial class RekamJejak : Window
    {
        public RekamJejak()
        {
            InitializeComponent();
            //Window_Loadeds();
        }

        //private void Window_Loadeds()
        //{
        //    DataClasses1DataContext con = new DataClasses1DataContext();
        //    List<HeartBeatRecorded> students = (from s in con.HeartBeatRecordeds
        //                              select s).ToList();
        //    StudentGrid.ItemsSource = students;

        //}
    }
}
