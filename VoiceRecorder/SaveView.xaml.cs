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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

//using System.Windows.Input;
//using Microsoft.Win32;
using System.IO;
using VoiceRecorder.Audio;
using VoiceRecorder.Properties;



namespace VoiceRecorder
{
    /// <summary>
    /// Interaction logic for SaveView.xaml
    /// </summary>
    public partial class SaveView : UserControl
    {
        SaveViewModel svm = new SaveViewModel();
       
        public static string fn;
        public SaveView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            fn = username.Text.Trim();
            //SendUsername();
            //username
        }

        private void saveClick(object sender, RoutedEventArgs e)
        {
            
            if (username.Text.Trim() == "")
                MessageBox.Show("Missing First Name");
            else
            {
                //FileText();
                fn = username.Text.Trim();
                //svm.Save();
                //svm.SaveAs();
                //svm.SaveCommand;
            }

            
        }

        void SendUsername()
        {
            Messenger.Default.Send(new NavigateMessage(SaveViewModel.ViewName, fn));
            //new NavigateMessage(SaveViewModel.ViewName,fn);
        }

      
    }
}
