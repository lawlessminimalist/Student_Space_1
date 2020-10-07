using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_Space_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Zoom : ContentPage
    {
        public Zoom()
        {
            InitializeComponent();

            //Get Rid of Orange Background when user selects ListView
            //Reference: https://forums.xamarin.com/discussion/173232/how-to-remove-the-background-color-orange-from-listview-items-selection
            ZoomLink.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                // don't do anything if we just de-selected the row.
                if (e.Item == null) return;

                if (sender is ListView lv) lv.SelectedItem = null;
            };
        }
    }
}