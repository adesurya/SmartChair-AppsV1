using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoiceRecorder.Audio;
using GalaSoft.MvvmLight;

namespace VoiceRecorder
{
    public class NoteViewModel : ViewModelBase
    {

        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    RaisePropertyChanged("Selected");
                }
            }
        }
        public string DisplayName { get; set; }
    }
}
