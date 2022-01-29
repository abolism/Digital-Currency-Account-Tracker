using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using System.IO;
namespace WebApplication1.Models

{
    public class Wallets
    {
        public string Name { get; set; } = "";
        public float Balance { get; set; } = 0;
        static public List<Wallets> allWallets = JsonSerializer.Deserialize<List<Wallets>>(File.ReadAllText(@"D:\WebApi\WebApplication1\jsonData.json"));
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