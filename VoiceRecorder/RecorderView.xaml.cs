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
using System.Threading;
using System.Windows.Threading;
using System.IO.Ports;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace VoiceRecorder
{
    /// <summary>
    /// Interaction logic for RecorderView.xaml
    /// </summary>
    public partial class RecorderView : UserControl
    {

        SerialPort _serialPort;
        private delegate void UpdateTextYo(string data);
        public RecorderView()
        {
            InitializeComponent();
            _serialPort = new SerialPort("COM11", 9600);

        }
        

        
        
      

                }
       }

        
 