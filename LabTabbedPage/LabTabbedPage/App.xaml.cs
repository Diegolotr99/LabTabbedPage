using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using LabTabbedPage.View;
using DLToolkit.Forms.Controls;
using Xamarin.Forms.PlatformConfiguration;

namespace LabTabbedPage
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            FlowListView.Init();

            //NavigationPage navPage = new NavigationPage(new MainTabNavigation());
            //navPage.BarBackgroundColor=Color.Black;
            //navPage.Title = "Courses-Student Control";
            //MainPage = navPage;
            //CoursesView cv = new CoursesView();
            
            NavigationPage np = new NavigationPage(new CoursesView());
            np.BarTextColor = Color.White;
            
            np.BarBackgroundColor = Color.RoyalBlue;
            
            MainPage = np;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
