using Student_Space.ViewModels;
using Student_Space_1.Models;
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
    public partial class CalendarWeek : ContentPage
    {
        public static string[] Months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public static string[] WeekDaysLabel = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        public DateTime DateNow { get; set; } = DateTime.Now;

        CalendarWeekViewModel cvm;

        public CalendarWeek()
        {
            InitializeComponent();
            cvm = new CalendarWeekViewModel(this);
            BindingContext = cvm;
            cvm.CurrentMonth = string.Format(Months[DateNow.Month - 1]);
            CalendarFrames();
            DaysofWeek_Buttons();
        }


        public void CalendarFrames()
        {
            Grid calendarframesgrid = new Grid
            {
                ColumnSpacing = 0,
                RowSpacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            calendarframes.Children.Add(calendarframesgrid);
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendarframesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Frame frame = new Frame
                    {
                        CornerRadius = 0,
                        BorderColor = Color.FromHex("#374B90"),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    };
                    Grid.SetRow(frame, row);
                    Grid.SetColumn(frame, col);
                    calendarframesgrid.Children.Add(frame);
                }
            }
        }

        public void DaysofWeek_Buttons()
        {




            Grid daysofweekgrid = new Grid
            {
                ColumnSpacing = 0,
                RowSpacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            daysofweek.Children.Add(daysofweekgrid);
            daysofweekgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            daysofweekgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            daysofweekgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            daysofweekgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            daysofweekgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            daysofweekgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            daysofweekgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            daysofweekgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (int col = 0; col < 7; col++)
            {

                Label label = new Label
                {
                    Text = 
                }

                Button button = new Button
                {
                    Text = WeekDaysLabel[col],
                    Padding = 0,
                    FontSize = 16,
                    BackgroundColor = Color.Transparent,
                    TextColor = Color.FromHex("#969FAA"),
                    BorderColor = Color.FromHex("#374B90"),
                    BorderWidth = 1,
                    HorizontalOptions = LayoutOptions.Center,
                };
                
                Grid.SetColumn(button, col);
                daysofweekgrid.Children.Add(button);

            }
        }

    }
}