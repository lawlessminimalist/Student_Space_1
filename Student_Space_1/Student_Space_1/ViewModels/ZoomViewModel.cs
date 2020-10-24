using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

using System.Collections.Generic;
using System.Text;
using Student_Space_1.Models;
using System.Collections.ObjectModel;

namespace Student_Space.ViewModels
{
    public class ZoomViewModel : BaseViewModel
    {
        //Variables 
        public ObservableCollection<ZoomLink> ZoomLinks { get; set; } //Collection Stores List of Zoom Links and Details (Class Name, Link, ID)

        //Constructor
        public ZoomViewModel()
        {
            SetupData();
            //Title = "Zoom Links";
        }


        //Mock Data
        void SetupData()
        {
            ZoomLinks = new ObservableCollection<ZoomLink>()
            {
                new ZoomLink
            {
                ClassName = "CAB303 Tutorial",
                ZoomId = "Zoom ID: 1234 2534 2342",
                Link = "https://qut.zoom.us/0328457094385",

            },

                new ZoomLink
            {
                ClassName = "IFB295 Tutorial",
                ZoomId = "Zoom ID: 1234 9990 2342",
                Link = "https://qut.zoom.us/0328457094385",
            },

                new ZoomLink
            {
                ClassName = "IAB201 Tutorial",
                ZoomId = "Zoom ID: 7686 9990 2342",
                Link = "https://qut.zoom.us/0328457094385",
            },

            new ZoomLink
            {
                ClassName = "IAB330 Tutorial",
                ZoomId = "Zoom ID: 5648 2534 2342",
                Link = "https://qut.zoom.us/0328457094385",
            }
            };
        }
    }
}