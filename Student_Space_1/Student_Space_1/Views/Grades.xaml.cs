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
    public partial class Grades : ContentPage
    {
        public Grades()
        {
            InitializeComponent();

            //Remove Orange Colour from List View When Item is Selected
            //Reference: https://forums.xamarin.com/discussion/173232/how-to-remove-the-background-color-orange-from-listview-items-selection
            AssessmentList.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                if (e.Item == null) return;
                if (sender is ListView lv) lv.SelectedItem = null;
            };
        }
    }
}