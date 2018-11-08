using AgendaXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaXamarinForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatosPage : ContentPage
	{
		public ContatosPage ()
		{
			InitializeComponent ();
		}

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            ContatosListView.ItemsSource = null;
            ContatosListView.ItemsSource = App.Current.Contatos;
        }

        private void ContatosListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new EditaContatoPage(e.Item as Contato));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditaContatoPage());
        }
    }
}