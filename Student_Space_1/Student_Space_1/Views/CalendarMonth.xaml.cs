using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Student_Space.ViewModels;
using System.Windows.Input;
using System.Collections.Specialized;
using System;

namespace Student_Space_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarMonth : ContentPage
    {
        public static string[] WeekDaysLabel = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        public static string[] Months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public DateTime DateNow { get; set; } = DateTime.Now;

        CalendarViewModel cvm;

        public CalendarMonth()
        {
            InitializeComponent();
            cvm = new CalendarViewModel(this);
            BindingContext = cvm;
            DaysofWeek_Buttons();
            CalendarDates_Buttons();

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
                    Command = cvm.GoToCurrentWeek,
                };
                Grid.SetColumn(button, col);
                daysofweekgrid.Children.Add(button);
                
            }
        }

        public void CalendarDates_Buttons()
        {

            

            Grid calendardatesgrid = new Grid
            {
                ColumnSpacing = 0,
                RowSpacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            calendardates.Children.Add(calendardatesgrid);
            calendardatesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            calendardatesgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


          
            int currentday = DateNow.Day;
            int currentmonth = DateNow.Month;
            int previousmonth = currentmonth - 1;
            if(currentmonth == 1)
            {
                previousmonth = 12;
            }
            int nextmonth = currentmonth + 1;
            if (currentmonth == 12)
            {
                nextmonth = 1;
            }
            int currentyear = DateNow.Year;
            bool isLeapYear = DateTime.IsLeapYear(currentyear);
            int daysinmonth_current = DateTime.DaysInMonth(currentyear, currentmonth);
            int daysinmonth_previous = DateTime.DaysInMonth(currentyear, previousmonth);
            int daysinmonth_next = DateTime.DaysInMonth(currentyear, nextmonth);
            DateTime firstdayofmonth = new DateTime(currentyear, currentmonth, 1);
            int firstdayofweek = (int)firstdayofmonth.DayOfWeek;


            int counter =  daysinmonth_previous - firstdayofweek + 1;

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if((row == 0 && col < firstdayofweek) || (row == 5 && counter >= 1))
                    {
                        Button button = new Button
                        {
                            Text = counter.ToString(),
                            Padding = 0,
                            FontSize = 16,
                            BackgroundColor = Color.LightGray,
                            CornerRadius = 0,
                            TextColor = Color.Gray,
                            BorderColor = Color.FromHex("#374B90"),
                            BorderWidth = 1,
                            HorizontalOptions = LayoutOptions.Center,
                        };
                        Grid.SetRow(button, row);
                        Grid.SetColumn(button, col);
                        calendardatesgrid.Children.Add(button);
                    }
                    else if(counter == currentday && currentmonth == DateNow.Month)
                    {
                        Button button = new Button
                        {
                            Text = counter.ToString(),
                            Padding = 0,
                            FontSize = 16,
                            CornerRadius = 0,
                            BackgroundColor = Color.LightBlue,
                            TextColor = Color.FromHex("#0f0f0f"),
                            BorderColor = Color.FromHex("#374B90"),
                            BorderWidth = 1,
                            HorizontalOptions = LayoutOptions.Center,
                        };
                        Grid.SetRow(button, row);
                        Grid.SetColumn(button, col);
                        calendardatesgrid.Children.Add(button);
                    }
                    else
                    {

                        Button button = new Button
                        {
                            Text = counter.ToString(),
                            Padding = 0,
                            FontSize = 16,
                            CornerRadius = 0,
                            BackgroundColor = Color.Transparent,
                            TextColor = Color.FromHex("#0f0f0f"),
                            BorderColor = Color.FromHex("#374B90"),
                            BorderWidth = 1,
                            HorizontalOptions = LayoutOptions.Center,
                        };
                        Grid.SetRow(button, row);
                        Grid.SetColumn(button, col);
                        calendardatesgrid.Children.Add(button);
                    }


                    if(row == 0)
                    {
                        if (daysinmonth_previous == 30)
                        {
                            if (counter == 30) { counter = 0; }
                        }
                        else if (daysinmonth_previous == 28)
                        {
                            if (counter == 28) { counter = 0; }
                        }
                        else if (daysinmonth_previous == 29)
                        {
                            if (counter == 29) { counter = 0; }
                        }
                        else if (daysinmonth_previous == 31)
                        {
                            if (counter == 31) { counter = 0; }
                        }
                    }
                    else
                    {
                        if (daysinmonth_current == 30)
                        {
                            if (counter == 30) { counter = 0; }
                        }
                        else if (daysinmonth_current == 28)
                        {
                            if (counter == 28) { counter = 0; }
                        }
                        else if (daysinmonth_current == 29)
                        {
                            if (counter == 29) { counter = 0; }
                        }
                        else if (daysinmonth_current == 31)
                        {
                            if (counter == 31) { counter = 0; }
                        }
                    }

                    counter++;
                }
            }
        }
    }
}