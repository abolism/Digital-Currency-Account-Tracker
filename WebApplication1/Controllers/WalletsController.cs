using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WalletsController : ApiController
    {
        // GET api/Wallets
        public List<Wallets> Get()
        {
            //Wallets[] output = Wallets.allWallets.ToArray();
            return Wallets.allWallets ;
        }

        //// GET api/Wallets/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/Wallets
        public string Post(Wallets walletName)
        {
            foreach (var item in Wallets.allWallets)
            {
                
                if(item.Name == walletName.Name)

                {
         
                    return "this name is already used ";
                }
                
            }

            Wallets.allWallets.Add(new Wallets(walletName.Name));
            return "Wallet added succesfully"; 
        }

        [Route("api/Wallets/{walletName}")]
        [HttpPut,HttpPost]
        public string Put(Wallets newWallet,string walletName)
        {
            bool checker = true;
            Wallets thisWallet= new Wallets("");
            foreach (var item in Wallets.allWallets) {
                if (item.Name == walletName)
                {
                    thisWallet = item;
                    thisWallet.lastUpdated = DateTime.Now;

                }
                if (item.Name == newWallet.Name)
                {
                    checker = false;
                }
            }
            if (thisWallet.Name == "" || checker==false)
            {
                return "name does not exist or new name already exists";
            }

            thisWallet.Name = newWallet.Name;
            return "wallet's name changed succesfully";
        }

        [Route("api/Wallets/{walletName}")]
        [HttpDelete]
        public string Delete(string walletName)
        {
            Wallets thisWallet = new Wallets("");
            foreach(var item in Wallets.allWallets)
            {
                if(item.Name == walletName)
                {
                    thisWallet = item;
                }
            }
            if (thisWallet.Name == "")
            {
                return "name does not exist";
            }
            foreach (var item in thisWallet.coins)
            {
                Coins.allCoins.Remove(item);
            }
            
            Wallets.allWallets.Remove(thisWallet);
            return "wallet deleted succesfully ";
        }
    }
}