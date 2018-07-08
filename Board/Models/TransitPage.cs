using System.Collections.Generic;
using Board;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Board
{
    public class TransitPage : BindableBase
    {
        private string _categoryID;

        public string CategoryID
        {
            get { return _categoryID; }
            set { SetProperty(ref _categoryID, value); }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set { SetProperty(ref _categoryName, value); }
        }
    }
}
