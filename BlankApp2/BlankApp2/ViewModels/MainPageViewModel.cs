using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankApp2.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;

        public int NumA {get;set;}
        public int NumB { get; set; }
        public String QuestionLabel { get; set; }
        public int? AnswerEntry { get; set; }
        public String AnswerLabel { get; set; }
        public String AnswerColor { get; set; }
        public DelegateCommand RefreshButton { get; set; }
        public DelegateCommand SubmitButton { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            RefreshQuestion();
            RefreshButton = new DelegateCommand(RefreshQuestion);
            SubmitButton = new DelegateCommand(SubmitAnswer);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void RefreshQuestion()
        {
            Random random = new Random();
            NumA = random.Next(0, 10);
            NumB = random.Next(0, 10);
            QuestionLabel = NumA.ToString() + "+" + NumB.ToString() + "=？";
            AnswerLabel = "";
            AnswerColor = "";
            AnswerEntry = null;
        }

        public void SubmitAnswer()
        {
            if (AnswerEntry == NumA + NumB)
            {
                AnswerLabel = "你的答案是正確的";
                AnswerColor = "Green";
            }
            else
            {
                AnswerLabel = "你的答案是錯誤的";
                AnswerColor = "OrangeRed";
            }
        }
    }
}
