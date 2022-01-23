using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Coins
    {
        public string Name { get; set; } = "";
        public string Symbol { get; set; } = "";
        public float Rate { get; set; } = 0;
        public float Amount { get; set; } = 0;
        static public List<Coins> allCoins = new List<Coins>();
        DateTime lastUpdated;
        public Coins(string name)
        {
            this.Name = name;
            //this.Amount = amount;
            lastUpdated = DateTime.Now;
            //allCoins.Add(this);
        }
        

    }
}