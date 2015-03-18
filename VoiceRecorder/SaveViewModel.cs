using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoiceRecorder.Core;
using NAudio.Wave;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using VoiceRecorder.Audio;
using VoiceRecorder.Properties;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging; 
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.IO;



namespace VoiceRecorder
{
    class SaveViewModel : ViewModelBase, IView
    {

        private VoiceRecorderState voiceRecorderState;
        private SampleAggregator sampleAggregator;
        private int leftPosition;
        private int rightPosition;
        private int totalWaveFormSamples;
        public static string hr;
        public static string hb;
        private IAudioPlayer audioPlayer;
        private RecorderViewModel rvm;
        private int samplesPerSecond;
        public const string ViewName = "SaveView";
        //SaveView svm = new SaveView();

        


        public SaveViewModel(IAudioPlayer audioPlayer)
        {
            
            this.SampleAggregator = new SampleAggregator();
            SampleAggregator.NotificationCount = 800; // gets set correctly later on
            this.audioPlayer = audioPlayer;
            this.SaveCommand = new RelayCommand(() => Save());
            this.SelectAllCommand = new RelayCommand(() => SelectAll());
            this.PlayCommand = new RelayCommand(() => Play());
            this.StopCommand = new RelayCommand(() => Stop());
            this.AutoTuneCommand = new RelayCommand(() => OnAutoTune());
            //Messenger.Default.Register<ShuttingDownMessage>(this, (message) => OnShuttingDown(message));
        }

        public SaveViewModel()
        {
            // TODO: Complete member initialization
        }

        public SaveViewModel(RecorderViewModel rvm)
        {
            // TODO: Complete member initialization
            this.rvm = rvm;
        }

        private void OnAutoTune()
        {
            audioPlayer.Dispose(); // needed to relinquish the file as it may get deleted
            Messenger.Default.Send(new NavigateMessage("AutoTuneView", this.voiceRecorderState));
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand SelectAllCommand { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand StopCommand { get; private set; }
        public ICommand AutoTuneCommand { get; private set; }



        public string RecordedTime3
        {
            get
           {
                if (this.rvm == null)
                {
                    this.rvm = new RecorderViewModel();
                }

               hr = rvm.heartrate.ToString();
                return String.Format("{0} bpm",hr);
            }
               
            set
            {
                hr = value;
                RaisePropertyChanged("RecordedTime3");
            }
        }
        
        public string heartbeats
        {
            get
            {
                if (this.rvm == null)
                {
                    this.rvm = new RecorderViewModel();
                }

                hr = rvm.heartbeat.ToString();
                return hb;
            }
            set
            {
                hb = value;
                RaisePropertyChanged("heartbeats");
            }
        }

        

        public void Activated(object state)
        {
            this.voiceRecorderState = (VoiceRecorderState)state;
            this.rvm = this.voiceRecorderState.recorderViewModel;
            RecordedTime3 = rvm.heartbeat.ToString();
            heartbeats = rvm.heartbeat.ToString();
            
            RenderFile();
        }
        //public static String GetTimestamp(DateTime value)
        //{
        //    return value.ToString("yyyy-MM-dd HH:mm:ss");
        //}
        string fileName = @"E:\RecordHeartRate.txt";
 

        private void FileText()
        {
           try
            {
                // Check if file already exists. If yes, delete it. 
                if (File.Exists(fileName))
                {
                File.Delete(fileName);
                 }
                using (FileStream fs = File.Create(fileName)) ; 
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }  
            
            try
            {
                DateTime dtCurrTime = DateTime.Today;
                //string d = dtCurrTime.ToString();

                StreamWriter sw = new StreamWriter(@"E:\RecordHeartRate.txt", true);


                string userid = SaveView.fn;
                string serialNumber = "ES";
                string jenisPengukuran = "";
                string jumlahheartbeat = SaveViewModel.hb;
                string value = "";
                //TimeSpan ts = DateTime.Now - new DateTime(2015, 1, 1);
                dtCurrTime = DateTime.Now;
                value = rvm.heartrate.ToString();
                jenisPengukuran = "HR";
                sw.WriteLine(userid + "#" + serialNumber + "#"+ jenisPengukuran + "#" + value + "#" + dtCurrTime);
                //sw.WriteLine(userid + "#" + serialNumber + "#"+ jenisPengukuran + "#" + value);
                sw.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("Terjadi kesalahan\n" + error.ToString());
            }
        }

        public void Save()
        {


            if (SaveView.fn == "" || SaveView.fn == null)
            {
                MessageBox.Show("Missing username");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "WAV file (.wav)|*.wav|MP3 file (.mp3)|.mp3";
                saveFileDialog.DefaultExt = ".wav";
                FileText();
                bool? result = saveFileDialog.ShowDialog();

                if (result.HasValue && result.Value)
                {
                    SaveAs(saveFileDialog.FileName);

                    //db : local
                    HeartRate student = new HeartRate();
                    student.Username = SaveView.fn;
                    student.HeartRates = rvm.heartrate;
                    student.Date = DateTime.Now;
                    Admin.AddStudent(student);

                    MessageBox.Show("Data is saved");
                    //string file = @"E:\RecordHeartRate.txt";
                    SqlConnection con = new SqlConnection(@"User id=hostingRecord;Password=123456;Server=ITSME\SQLEXPRESS;Database=hostingRecord");
                    SqlCommand cmdinsert = new SqlCommand();
                    cmdinsert.CommandText = @"BULK INSERT SmartChair FROM 'E:\RecordHeartRate.txt' WITH (FIELDTERMINATOR = '#', ROWTERMINATOR = '\n' );";
                    cmdinsert.CommandTimeout = 0;
                    cmdinsert.CommandType = System.Data.CommandType.Text;
                    cmdinsert.Connection = con;
                    try
                    {
                        con.Open();
                        cmdinsert.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        //Label.Text = ex.Message.ToString();
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                    string destinationFile = @"E:\RecordHeartRate.txt";
                    try
                    {
                        File.Delete(destinationFile);
                    }
                    catch (IOException iox)
                    {
                        Console.WriteLine(iox.Message);
                    }
                    //System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    //if (Directory.Exists(Path.GetDirectoryName(file)))
                    //{
                    //    File.Delete(file);
                    //}
                }
            }
        }
                
            
                
                      
        

        private TimeSpan PositionToTimeSpan(int position)
        {
            int samples = SampleAggregator.NotificationCount * position;
            return TimeSpan.FromSeconds((double)samples / samplesPerSecond);
        }

        public void SaveAs(string fileName)
        {
            AudioSaver saver = new AudioSaver(voiceRecorderState.ActiveFile);
            saver.TrimFromStart = PositionToTimeSpan(LeftPosition);
            saver.TrimFromEnd = PositionToTimeSpan(TotalWaveFormSamples - RightPosition);
            
            if (fileName.ToLower().EndsWith(".wav"))
            {
                saver.SaveFileFormat = SaveFileFormat.Wav;
                saver.SaveAudio(fileName);
            }
            else if (fileName.ToLower().EndsWith(".mp3"))
            {
                string lameExePath = LocateLame();
                if (lameExePath != null)
                {
                    saver.SaveFileFormat = SaveFileFormat.Mp3;
                    saver.LameExePath = lameExePath;
                    saver.SaveAudio(fileName);
                }
            }
            else
            {
                MessageBox.Show("Please select a supported output format");
            }
        }

        public int LeftPosition
        {
            get
            {
                return leftPosition;
            }
            set
            {
                if (leftPosition != value)
                {
                    leftPosition = value;
                    RaisePropertyChanged("LeftPosition");
                }
            }
        }

        public int RightPosition
        {
            get
            {
                return rightPosition;
            }
            set
            {
                if (rightPosition != value)
                {
                    rightPosition = value;
                    RaisePropertyChanged("RightPosition");
                }
            }
        }

        public string LocateLame()
        {
            string lameExePath = Settings.Default.LameExePath;

            if (String.IsNullOrEmpty(lameExePath) || !File.Exists(lameExePath))
            {
                if (MessageBox.Show("To save as MP3 requires LAME.exe, please locate",
                    "Save as MP3",
                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.FileName = "lame.exe";
                    bool? result = ofd.ShowDialog();
                    if (result != null && result.HasValue)
                    {
                        if (File.Exists(ofd.FileName) && ofd.FileName.ToLower().EndsWith("lame.exe"))
                        {
                            Settings.Default.LameExePath = ofd.FileName;
                            Settings.Default.Save();
                            return ofd.FileName;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            return lameExePath;
        }

        private void RenderFile()
        {
            SampleAggregator.RaiseRestart();
            using (WaveFileReader reader = new WaveFileReader(this.voiceRecorderState.ActiveFile))
            {
                this.samplesPerSecond = reader.WaveFormat.SampleRate;
                SampleAggregator.NotificationCount = reader.WaveFormat.SampleRate / 10;

                byte[] buffer = new byte[1024];
                WaveBuffer waveBuffer = new WaveBuffer(buffer);
                waveBuffer.ByteBufferCount = buffer.Length;
                int bytesRead;
                do
                {
                    bytesRead = reader.Read(waveBuffer, 0, buffer.Length);
                    int samples = bytesRead / 2;
                    for (int sample = 0; sample < samples; sample++)
                    {
                        if (bytesRead > 0)
                        {
                            sampleAggregator.Add(waveBuffer.ShortBuffer[sample] / 32768f);
                        }
                    }
                } while (bytesRead > 0);
                int totalSamples = (int)reader.Length / 2;
                TotalWaveFormSamples = totalSamples / sampleAggregator.NotificationCount;
                SelectAll();
            }
            audioPlayer.LoadFile(this.voiceRecorderState.ActiveFile);
        }

        private void Play()
        {
            audioPlayer.StartPosition = PositionToTimeSpan(LeftPosition);
            audioPlayer.EndPosition = PositionToTimeSpan(RightPosition);
            audioPlayer.Play();
        }

        private void Stop()
        {
            audioPlayer.Stop();
        }

        private void SelectAll()
        {
            LeftPosition = 0;
            RightPosition = TotalWaveFormSamples;
        }

        public SampleAggregator SampleAggregator
        {
            get
            {
                return sampleAggregator;
            }
            set
            {
                if (sampleAggregator != value)
                {
                    sampleAggregator = value;
                    RaisePropertyChanged("SampleAggregator");
                }
            }
        }

        public int TotalWaveFormSamples
        {
            get
            {
                return totalWaveFormSamples;
            }
            set
            {
                if (totalWaveFormSamples != value)
                {
                    totalWaveFormSamples = value;
                    RaisePropertyChanged("TotalWaveFormSamples");
                }
            }
        }
    }
}
