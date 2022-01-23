using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Wallets
    {
        public string Name { get; set; } = "";
        public float Balance { get; set; } = 0;
        static public List<Wallets> allWallets = new List<Wallets>();
        public List<Coins> coins = new List<Coins>();
        public DateTime lastUpdated;
        public Wallets(string name)
        {
            this.Name = name;
            //this.Balance = balance;
            lastUpdated = DateTime.Now;
            //allWallets.Add(this);
        }

        public void addToWallets ( Wallets w)
        {
            allWallets.Add(w);
        }
    }
}