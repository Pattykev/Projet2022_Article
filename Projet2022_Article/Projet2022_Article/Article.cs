using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet2022_Article
{
    class Article
    {
        public string Code { get; set; }
        public string Désignation { get; set; }
        public string Catégorie { get; set; }
        public double Prix { get; set; }
        public double Prix_Solde { get; set; }

        public Article(string p, string p_2, string p_3, double p_4, double p_5)
        {
            // TODO: Complete member initialization
            Code = p;
            Désignation = p_2;
            Catégorie = p_3;
            Prix = p_4;
            Prix_Solde = p_5;
        }
        
    
    }
}
