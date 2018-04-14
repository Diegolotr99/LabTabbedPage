using LabTabbedPage.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabTabbedPage.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainTabNavigation : TabbedPage
	{
		public MainTabNavigation ()
		{
			InitializeComponent ();
            BindingContext = StudentViewModel.GetInstance();

            
        }
	}
}