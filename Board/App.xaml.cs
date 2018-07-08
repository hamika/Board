using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Board.Views;
//using NavigationService.Views;
using Xamarin.Forms;

namespace Board
{
    // Xamarin.FormsはXamarin.Forms.Applicationクラスを継承して作成されるが、
    // PrismではPrism.Unity.PrismApplicationsが呼ばれてる
    public partial class App : PrismApplication
    {
        // Xamarin.FormsのAppクラスでは画面の生成までコンストラクタ内で行っているが、
        // PrismではIPlatformInitializerを引数にとり、親クラスにそれをそのまま受け渡してる
        // `派生クラスのコンストラクタ(引数) : base(基底クラスに渡したい引数)`
        // インスタンスの生成後フレームワーク(Prism)側からRegisterTypes, OnInitializedの順でメソッドが呼び出される
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        // アプリケーションの初期化と、初期画面への画面遷移
        protected override void OnInitialized()
        {
            InitializeComponent();
            // var parameters = new NavigationParameters();
            // parameters["title"] = "Hello from Xamarin.Forms";
            // NavigationService.NavigateAsync("MainPage", parameters);
            // ↑ こんな感じで書いてもいいけど、↓みたいな書き方のほうがメリット大きい
            // NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        // Prismでは画面遷移の際、遷移先の画面をDI(Dependency Injection) Containerから取得する
        // 新しい画面を作成した場合DI Containerへここから登録してあげる必要がある
        // アプリケーション内で利用するクラスをDI Containerに登録します
        // 基本的には画面数ぶん登録と思えばいい
        {   
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SecondPage>();
            Container.RegisterTypeForNavigation<ListingPage>();
            Container.RegisterTypeForNavigation<Category>();
            Container.RegisterTypeForNavigation<CategoryPage>();
            //Container.RegisterTypeForViewModelNavigation<RootPage, RootPageViewModel>(); // 起点ページ(第一階層)
            //Container.RegisterTypeForViewModelNavigation<SectionListPage, SectionListPageViewModel>(); // 第二階層
            //Container.RegisterTypeForViewModelNavigation<SectionPage, SectionPageViewModel>(); // 第三階層
        }

        // ...PageのViewModelの名称を ...PageViewModel ...ViewModelに変更する
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();   // <- 必須！忘れるとDIされなくなる
        //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
        //        viewType =>
        //        {
        //            var viewName = viewType.FullName;
        //            viewName = viewName.Replace(".Views.", ".ViewModels.");
        //            string viewModelName;
        //            if (viewName.EndsWith("Page"))
        //            {
        //                viewModelName = $"{viewName.Substring(0, viewName.LastIndexOf("Page", StringComparison.Ordinal))}ViewModel";
        //            }
        //            else
        //            {
        //                var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
        //                viewModelName = $"{viewName}{suffix}";
        //            }
        //            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        //            return Type.GetType(string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewModelName, viewAssemblyName));
        //        }
        //    );
        //}
    }
}

