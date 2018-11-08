using AgendaXamarinForms.Models;
using AgendaXamarinForms.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AgendaXamarinForms
{
    public partial class App : Application
    {
        public static new App Current => Application.Current as App;

        public List<Contato> Contatos { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContatosPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Contatos = BancoDeDados.Instance.GetContatos();
            if (Contatos.Count == 0)
            {
                Contatos.Add(new Contato
                {
                    Nome = "Comsolid",
                    Telefone1 = "3307-0800"
                });

                Contatos.Add(new Contato
                {
                    Nome = "Enzo",
                    Telefone1 = "0800-9666"
                });
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            BancoDeDados.Instance.SetContatos(Contatos);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
