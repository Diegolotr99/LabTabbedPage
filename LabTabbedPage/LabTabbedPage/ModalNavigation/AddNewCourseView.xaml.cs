using LabTabbedPage.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabTabbedPage.ModalNavigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewCourseView : ContentPage
	{
		public AddNewCourseView ()
		{
			InitializeComponent ();
            this.BindingContext = StudentViewModel.GetInstance();
		}
	}
}