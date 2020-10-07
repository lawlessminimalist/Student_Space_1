using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Student_Space.ViewModels
{
    public class UnitInfoViewModel : BaseViewModel
    {
        
        
        
        
        List<Monkey> Monkeys;
        public class Monkey
        {

            public string Name { get; set; }
            public string Location { get; set; }
            public string Details { get; set; }
        }

    

    public UnitInfoViewModel()
        {

            Monkeys = new List<Monkey>() {
        new Monkey() {Name = "monkey1", Details = "details", Location = "brisbane" },
        new Monkey() {Name = "monkey2", Details = "details", Location = "brisbane" },
        new Monkey() {Name = "monkey3", Details = "details", Location = "brisbane" }

    };


            Title = "Unit Information";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));



    }


        public ICommand OpenWebCommand { get; }

        

    }
}