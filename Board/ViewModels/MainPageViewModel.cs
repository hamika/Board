using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Board.ViewModels
{
    // INavigationAware: 必ずViewModelで実装する必要はないが、
    // 画面遷移で引数を渡したい、もしくは受け取りたい場合などに実装する
    // INavigationAwareにはOnNavigatedToとOnNavigatedFromの2つのメソッドが定義されている
    // 
    // BindableBase: Prismが提供するINotifyPropertyCangedを実装した
    // ViewModelなどの標準基底クラス
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // コンストラクタ //
        // Prismでは画面遷移を行う際にINavigationServiceを利用する
        // INavigationServiceはコンテナからViewModelにインジェクションして利用する
        // 今回はMainPageからの画面遷移なので、MainPageViewModelでINavigationServiceを受け取る
        private readonly INavigationService _navigationService;
        public ICommand NavigateSecondCommand { get; } // ボタンに対応するCommandを作成
        public ICommand NavigateListingCommand { get; } // ボタンに対応するCommandを作成
        public ICommand NavigategCategoryCommand { get; } // ボタンに対応するCommandを作成
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // コマンドの処理として画面遷移を実装する
            NavigateSecondCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("SecondPage");
            });

            NavigateListingCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("ListingPage");
            });

            NavigategCategoryCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("CategoryPage");
            });
        }

        // 画面遷移する前にOnNavigatedFromが呼び出される
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        // 画面遷移してきた際にOnNavigatedToが呼び出される
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}

