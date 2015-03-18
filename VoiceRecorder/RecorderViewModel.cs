using System;
using System.Windows.Input;
using System.IO;
using VoiceRecorder.Audio;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
//using AudioRecorder.Audio;
using NAudio.Wave;
using NAudio.Mixer;

namespace VoiceRecorder
{
    class RecorderViewModel : ViewModelBase, IView
    {


        private RelayCommand beginRecordingCommand;
        private RelayCommand stopCommand;
        private IAudioRecorder recorder;
        public float lastPeak;
        public float countlastpeak=0;
        public double heartbeat =0;
        public double heartrate;
        public string minute;
        public string second;
        public string milisecond;
        private string waveFileName;
        public const string ViewName = "RecorderView";
        
        
        public RecorderViewModel(IAudioRecorder recorder)
        {
            this.recorder = recorder;
            this.recorder.Stopped += OnRecorderStopped;
            beginRecordingCommand = new RelayCommand(BeginRecording,
                () => recorder.RecordingState == RecordingState.Stopped ||
                      recorder.RecordingState == RecordingState.Monitoring);
            stopCommand = new RelayCommand(Stop,
                () => recorder.RecordingState == RecordingState.Recording);
            recorder.SampleAggregator.MaximumCalculated += OnRecorderMaximumCalculated;
            
        
        }

        public RecorderViewModel()
        {
            
            // TODO: Complete member initialization
        }

        void OnRecorderStopped(object sender, EventArgs e)
        {
            Messenger.Default.Send(new NavigateMessage(SaveViewModel.ViewName, 
                new VoiceRecorderState(waveFileName, null, this)));
        }
        
        public void OnRecorderMaximumCalculated(object sender, MaxSampleEventArgs e)
        {
        
            lastPeak = Math.Max(e.MaxSample, Math.Abs(e.MinSample));
            

            
            RaisePropertyChanged("CurrentInputLevel");
            //if (lastPeak >= 0.02)
            //{
            RaisePropertyChanged("MicrophoneLevel2");
                RaisePropertyChanged("HeartBeats");
                RaisePropertyChanged("HeartRate");
                RaisePropertyChanged("RecordedTime");
                RaisePropertyChanged("LastPeak");
            //}
        }

        public ICommand BeginRecordingCommand { get { return beginRecordingCommand; } }
        public ICommand StopCommand { get { return stopCommand; } }

        public void Activated(object state)
        {
            BeginMonitoring((int)state);
        }

        //int ipp=2;
        //int sss;
        //private object[] Seconds;
 
  
        private void BeginMonitoring(int recordingDevice)
        {
            recorder.BeginMonitoring(recordingDevice);
            RaisePropertyChanged("MicrophoneLevel");
            RaisePropertyChanged("MicrophoneLevel2");
        }

        private void BeginRecording()
        {
            waveFileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");

            recorder.BeginRecording(waveFileName);


            //RaisePropertyChanged("RecordedTime");
            RaisePropertyChanged("MicrophoneLevel");
            RaisePropertyChanged("MicrophoneLevel2");
            RaisePropertyChanged("ShowWaveForm");
            
        }

        private void Stop()
        {
            recorder.Stop();
        }


        public string LastPeak
        {

            get
            {
                
                return String.Format("{0} ", lastPeak.ToString());
            }

            //set
            //{
            //    heartbeat = value;
            //}   
        }


        public string HeartBeats
        {

            get
            {
                var current = recorder.RecordedTime;
                String.Format("{0:D2}:{1:D2}.{2:D2}", current.Minutes, current.Seconds, current.Milliseconds);
                if (current.Milliseconds < 1 && lastPeak >= 0.5)
                {
                    heartbeat = 0;

                }
                else
                {
                    heartbeat = 1 + heartbeat;
                }
                return String.Format("{0} ", heartbeat.ToString());
            }
       }

        public String RecordedTime
        {

            get
            {
                var current = recorder.RecordedTime;
                return String.Format("{0:D2}:{1:D2}.{2:D2}",
                    current.Minutes, current.Seconds, current.Milliseconds);

                

            }
        }
        
        public String HeartRate
        {

            get
            {
               // SaveViewModel svm = new SaveViewModel();

                var current = recorder.RecordedTime;
                String.Format("{0:D2}:{1:D2}.{2:D2}",current.Minutes, current.Seconds, current.Milliseconds);
                for (int x = 0; x <= 61; x = x + 2)
                {
                    if (current.Seconds == x)
                    {
                        heartrate = (int)heartbeat * (60/x);
                        
                        //svm.RecordedTime3 = heartbeat.ToString();
                    }                 
                }
                
                return String.Format("{0} bpm", heartrate.ToString());
            }            
        }

        
        public double MicrophoneLevel
        {
            get { return recorder.MicrophoneLevel; }
            set { recorder.MicrophoneLevel = 60; }
        }

        public double MicrophoneLevel2
        {
            get 
            {
                return  (int)recorder.MicrophoneLevel; 
            }
            set { recorder.MicrophoneLevel = 90; }
        }

        public bool ShowWaveForm
        {
            get
            {
                return recorder.RecordingState == RecordingState.Recording ||
                    recorder.RecordingState == RecordingState.RequestedStop;
            }
        }


        // multiply by 100 because the Progress bar's default maximum value is 100
        public float CurrentInputLevel { get { return lastPeak * 100; } }

        //RecorderView rv = new RecorderView();
        //private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        //{

        //    int output = Int32.Parse(rv.Number1.Text) + Int32.Parse(rv.Number2.Text);

        //    rv.Result.Text = output.ToString();

        //}

        public SampleAggregator SampleAggregator 
        {
            get
            {
                return recorder.SampleAggregator;
            }
        }

        public string Minutes { get; set; }

        public object Milliseconds { get; set; }
    }
}