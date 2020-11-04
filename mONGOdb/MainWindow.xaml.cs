using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mONGOdb
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IMongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("example");
            IMongoCollection<Postagem> colNews = database.GetCollection<Postagem>("news");


            //criar
            Postagem doc = new Postagem();
            doc.Title = "Titulo";
            doc.Body = "Texto";
            doc.Criado = DateTime.Now;
            doc.Active = true;
            colNews.InsertOne(doc);


            //editar
            Expression<Func<Postagem, bool>> filter =
                x => x.Id.Equals(ObjectId.Parse("594b093325841c1b6cac28ea"));

            Postagem news = colNews.Find(filter).FirstOrDefault();
            if (news != null)
            {
                news.Value = 200d;
                ReplaceOneResult result = colNews.ReplaceOne(filter, news);
            }

            //pesquisar
            filter = x => x.Title.Contains("s");
            IList<Postagem> items = colNews.Find(filter).ToList();

            //apagar
            filter = x => x.Id.Equals(ObjectId.Parse("594b093325841c1b6cac28ea"));
            DeleteResult delresult = colNews.DeleteOne(filter);
        }
    }
}
