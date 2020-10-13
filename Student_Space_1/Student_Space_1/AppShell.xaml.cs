using System;
using System.Collections.Generic;
using Student_Space.ViewModels;
using Student_Space.Views;
using Xamarin.Forms;
using Student_Space_1.Views;

namespace Student_Space
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes {  get { return routes;  } }

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;

        }

        void RegisterRoutes()
        {
            routes.Add("CalendarMonth", typeof(CalendarMonth));
            routes.Add("links", typeof(Zoom));
            routes.Add("contacts", typeof(Unit_Contacts));
            routes.Add("grades", typeof(Grades));
            routes.Add("todolist", typeof(ToDo));

            //Routing to Enable Data Passing to the Settings Page
            Routing.RegisterRoute(nameof(ToDoSettings), typeof(ToDoSettings));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
