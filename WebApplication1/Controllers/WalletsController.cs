using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Text.Json;
using System.IO;
using System.Reflection;
//using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class WalletsController : ApiController

    {
        string fileName;
        public static string jsonSerialWalletsList;
        string ProgramPath = @"D:\WebApi\WebApplication1\";

        //string programPathToBe = @$"{ProgramPath}\\";
        // GET api/Wallets
        public List<Wallets> Get()
        {
            //Wallets[] output = Wallets.allWallets.ToArray();
            //Wallets.makeList();
            //try
            //{
            //    return Wallets.allWallets;

            //}
            //catch (Exception e) { 
            //    Console.WriteLine(e.Message);
            //    return null;
            //}
            return Records.allWallets;
        }

        // GET api/Wallets/{id:int}
        [Route("api/wallets/getJson/{userID:int}")]
        [HttpGet]
        public string Get(int userID)
        {
            //try
            //{
            //    fileName = $"{ProgramPath}.json";
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //File.WriteAllText(ProgramPath, WalletsController.jsonSerialWalletsList);
            try
            {
                jsonSerialWalletsList = JsonSerializer.Serialize(Records.allWallets);
                fileName = $"{ProgramPath}jsonData.json";
                File.WriteAllText(fileName, jsonSerialWalletsList);
                //var fileMode = FileMode.CreateNew;
                
                //FileStream fs = new FileStream(fileName, fileMode);
                //StreamWriter sw = new StreamWriter(fs);
                //sw.WriteLine(jsonSerialWalletsList);
                //sw.Close();
                //fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jsonSerialWalletsList;
            //return "value";
            //return "value";
        }

        //POST api/Wallets
        public string Post(Wallets walletName)
        {
            //Wallets.makeList();
            //if((File.ReadAllText(@"D:\WebApi\WebApplication1\jsonData.json")).Contains(List<Wallets>))
            //{

            if (Records.allWallets != null && Records.allWallets.Any())
            {

                foreach (var item in Records.allWallets)
                {

                    if (item.Name == walletName.Name)

                    {

                        return "this name is already used ";
                    }

                }

            }            //}

            Records.allWallets.Add(new Wallets(walletName.Name));
            //jsonSerialWalletsList = JsonSerializer.Serialize(Wallets.allWallets);
            return "Wallet added succesfully";
        }

        [Route("api/Wallets/{walletName}")]
        [HttpPut, HttpPost]
        public string Put(Wallets newWallet, string walletName)
        {
            bool checker = true;
            Wallets thisWallet = new Wallets("");
            foreach (var item in Records.allWallets)
            {
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
            if (thisWallet.Name == "" || checker == false)
            {
                return "name does not exist or new name already exists";
            }

            thisWallet.Name = newWallet.Name;
            //jsonSerialWalletsList = JsonSerializer.Serialize(Wallets.allWallets);
            return "wallet's name changed succesfully";
        }

        [Route("api/Wallets/{walletName}")]
        [HttpDelete]
        public string Delete(string walletName)
        {
            Wallets thisWallet = new Wallets("");
            foreach (var item in Records.allWallets)
            {
                if (item.Name == walletName)
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

            Records.allWallets.Remove(thisWallet);
            //jsonSerialWalletsList = JsonSerializer.Serialize(Wallets.allWallets);
            return "wallet deleted succesfully ";
        }
    }
}