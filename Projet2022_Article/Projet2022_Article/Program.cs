using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Projet2022_Article
{
    static class Program
    {
        public static List<Article> collectionArticle= new List<Article>();
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
