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
	public partial class EditaContatoPage : ContentPage
	{
        private Contato viewModel;

		public EditaContatoPage ()
		{
			InitializeComponent ();
            viewModel = new Contato();
            BindingContext = viewModel;
		}

        public EditaContatoPage(Contato contato)
        {
            InitializeComponent();
            viewModel = contato;
            BindingContext = viewModel;
            SalvarButton.IsVisible = false;
            ExcluirButton.IsVisible = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Nome))
            {
                DisplayAlert("Erro", "Nome é obrigatório!", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(viewModel.Telefone1))
            {
                DisplayAlert("Erro", "Telefone1 é obrigatório!", "Ok");
                return;
            }

            App.Current.Contatos.Add(viewModel);
            Navigation.PopAsync();

        }

        private void ExcluirButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Contatos.Remove(viewModel);
            Navigation.PopAsync();
        }
    }
}