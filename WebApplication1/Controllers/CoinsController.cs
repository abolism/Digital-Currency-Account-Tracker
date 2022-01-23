using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CoinsController : ApiController
    {
        // GET api/<controller>
        [Route("api/Coins/{walletName}")]
        [HttpGet]

        public Wallets Get(string walletName)
        {
            Wallets thisWallet = new Wallets("");
            foreach(var item in Wallets.allWallets)
            {
                if (item.Name == walletName)
                    thisWallet = item;
            }
            if(thisWallet.Name == "")
            {
                return thisWallet;
            }
            return thisWallet;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route("api/{walletName}/Coins")]
        [HttpPost]
        public string Post(string walletName,Coins coin)

        {
            Wallets thisWallet = new Wallets("");

            bool checker = true;
            foreach(var item in Wallets.allWallets)
            {
                if(item.Name == walletName)
                {
                    thisWallet = item;
                }
            }
            if (thisWallet.Name == "")
            {
                return "wallet does not exist";
            }
            foreach(var item in thisWallet.coins)
            {
                if (item.Name == coin.Name || item.Symbol == coin.Symbol)
                {
                    checker = false;
                }
            }
            foreach(var item in Coins.allCoins)
            {
                if(item.Name == coin.Name || item.Symbol == coin.Symbol)
                {
                    checker = false;
                }
            }
            if (checker)
            {
                Coins.allCoins.Add(coin);
                thisWallet.coins.Add(coin);
                thisWallet.Balance += coin.Amount * coin.Rate;
                thisWallet.lastUpdated = DateTime.Now;
                return "coin added succesfully";

            }
            return "name or symbol already exists";
            
        }

        // PUT api/<controller>/5
        [Route("api/Coins/{walletName}/{symbol}")]
        [HttpPut]
        public string Put(string walletName,string symbol,Coins coin) 
        {
            Wallets thisWallet = new Wallets("");
            Coins thisCoin = new Coins("");
            foreach(var item in Wallets.allWallets)
            {
                if (item.Name == walletName)
                {
                    thisWallet = item;
                }
            }
            foreach(var item in thisWallet.coins)
            {
                if(item.Symbol == symbol)
                {
                    thisCoin = item;
                }
            }
            if(thisCoin.Name == "" || thisWallet.Name == "")
            {
                return "wallet or coin not found";
            }
            thisWallet.coins.Remove(thisCoin);
            thisWallet.coins.Add(coin);
            thisWallet.Balance -= thisCoin.Amount * thisCoin.Rate;
            thisWallet.Balance += coin.Amount * coin.Rate;
            thisWallet.lastUpdated = DateTime.Now;
            return "coin updated succesfully";
        }


        // DELETE api/<controller>/5
        [Route("api/Coins/{walletName}/{symbol}")]
        [HttpPut]

        public string Delete(string walletName,string symbol)
        {
            Wallets thisWallet = new Wallets("");
            Coins thisCoin = new Coins("");
            foreach (var item in Wallets.allWallets) { 
                if(item.Name == walletName)
                {
                    thisWallet = item;
                }
            }
            foreach (var item in thisWallet.coins)
            {
                if(item.Symbol == symbol)
                {
                    thisCoin = item;
                }

            }
            if(thisCoin.Name == "" || thisWallet.Name == "")
            {
                return "wallet or coin not found";
            }
            thisWallet.coins.Remove(thisCoin);
            thisWallet.Balance -= thisCoin.Amount * thisCoin.Rate;
            thisWallet.lastUpdated = DateTime.Now;
            return "coin deleted succesfully ";
        }
    }
}