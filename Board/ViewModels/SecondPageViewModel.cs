using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Board
{
    public class SecondPageViewModel : BindableBase
    //, IAppearingAware, IDisappearingAware
    {
        //public void OnAppearing()
        //{
        //}
        //public void OnDisappearing()
        //{
        //}

        // 
        private readonly INavigationService _navigationService;
        public ICommand GoBackCommand { get; } // 戻るボタン
        public SecondPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBackCommand = new DelegateCommand(() =>
            {
                _navigationService.GoBackAsync();
            });
        }

        // IsProcessingが真の場合3秒待つ
        public async Task<bool> CanNavigateAsync(NavigationParameters parameters)
        {
            IsProcessing = true;
            await ProcessHeavy();
            IsProcessing = false;
            return true;
        }

        private bool _isProcessing;
        public bool IsProcessing
        {
            get { return _isProcessing; }
            set { SetProperty(ref _isProcessing, value); }
        }

        private Task ProcessHeavy()
        {
            return Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
}
