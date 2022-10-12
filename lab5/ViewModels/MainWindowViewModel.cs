using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Reactive;
using ReactiveUI;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public const int maxCharAmount = 5000;
        public string? PathOpen
        {
            get { return null; }
            set
            {
                if (value is not null && File.Exists(value))
                {
                    using (StreamReader sr = File.OpenText(value))
                    {
                        TextIn = sr.ReadToEnd();
                    }
                }
            }
        }
        public string? PathSave
        {
            get { return null; }
            set
            {
                if (value is not null)
                    using (StreamWriter sw = File.CreateText(value))
                    {
                        sw.Write(TextOut);
                    }
            }
        }

        string textIn = "";
        public string TextIn
        {
            get
            {
                return textIn;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref textIn, value);
                TextOut = "";
                foreach (Match match in Regex.Matches(value, RegexString, RegexOptions.IgnoreCase))
                {
                    TextOut += $"{match.Value}\n";
                }
            }
        }

        string textOut = "";
        public string TextOut
        {
            get
            {
                return textOut;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref textOut, value);
            }
        }

        string regexString = "";
        public string RegexString
        {
            get
            {
                return regexString;
            }
            set
            {
                regexString = value;
                TextOut = "";
                foreach (Match match in Regex.Matches(TextIn, value, RegexOptions.IgnoreCase))
                {
                    TextOut += $"{match.Value}\n";
                }
            }
        }
        string regexStringNew = "";
        public string RegexStringNew
        {
            get
            {
                return regexStringNew;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref regexStringNew, value);
            }
        }
    }
}
