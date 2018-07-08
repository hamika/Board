using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Board.Models;
using Xamarin.Forms;

namespace Board.ViewModels
{
    public class ListingPageViewModel : BindableBase
    {
        private List<Drink> _items;
        private string _selectedItem;

        public List<Drink> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public Command<Drink> ItemSelectedCommand { get; }

        public ListingPageViewModel()
        {
            //ListVIew上に表示させるデータ一覧
            _items = new List<Drink>
            {
                new Drink{DrinkName="太郎"},
                new Drink{DrinkName="次郎"},
                new Drink{DrinkName="三郎"},
                new Drink{DrinkName="四郎"},
                new Drink{DrinkName="五郎"},
                new Drink{DrinkName="六郎"},
                new Drink{DrinkName="七郎"},
                new Drink{DrinkName="八郎"},
                new Drink{DrinkName="九郎"},
                new Drink{DrinkName="十郎"},
            };

            //ListViewタップ時に実行されるコマンド
            ItemSelectedCommand = new Command<Drink>(
                x => SelectedItem = x.DrinkName,
                x => x != null);
        }


        //private List<string> _items;
        //public List<string> Items
        //{
        //    get { return _items; }
        //    set { SetProperty(ref _items, value); }
        //}

        //// 初期化処理
        //public ListingPageViewModel()
        //{
        //    _items = new List<string>
        //    {
        //        "太郎",
        //        "次郎",
        //        "三郎",
        //        "四郎",
        //        "五郎",
        //        "六郎",
        //        "七郎",
        //        "八郎",
        //        "九郎",
        //        "十郎"
        //    };
        //}
    }
}
