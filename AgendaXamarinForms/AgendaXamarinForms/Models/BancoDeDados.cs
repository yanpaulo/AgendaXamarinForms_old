using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AgendaXamarinForms.Models
{
    public class BancoDeDados
    {
        public static BancoDeDados Instance { get; private set; } = new BancoDeDados();

        private SQLiteConnection connection;

        private BancoDeDados()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dados.db");
            connection = new SQLiteConnection(path);
            connection.CreateTable<Contato>();
        }

        public List<Contato> GetContatos() => 
            connection.Table<Contato>().ToList();


        public void SetContatos(List<Contato> contatos)
        {
            connection.DeleteAll<Contato>();
            connection.InsertAll(contatos);
        }


    }
}
