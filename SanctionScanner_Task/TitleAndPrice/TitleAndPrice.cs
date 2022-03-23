using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScanner_Task.TitleAndPrice
{
    public static class TitleAndPrice
    {
        public static void GetTitles()
        {
            //Listelerimiz
            List<string> LinkList = new List<string>();
            List<string> TitleList = new List<string>();
            List<string> PriceList = new List<string>();
            HtmlDocument doc=new HtmlDocument();
            //Sitemizin linki
            string mainUrl = "https://www.sahibinden.com/";
            //Siteye giriş adımları
            using (var client = new WebClient() {Encoding=Encoding.UTF8 })
            {
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.82 Safari/537.36";
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var response=client.DownloadString(mainUrl);
                doc.LoadHtml(response);
            }
            //Sitemizden istediğimiz bilgileri aldık
            var links = doc.DocumentNode.SelectNodes("//ul[@class='vitrin-list clearfix']//li//a");
          
            //Bilgilerimiz içinden title ve linkleri aldık
            foreach (var item in links)
            {
               
                if (item.Attributes["href"].Value.Contains("/ilan"))
                {
                    TitleList.Add(item.Attributes["title"].Value);
                    LinkList.Add("https://www.sahibinden.com" + item.Attributes["href"].Value);
                }
               
                

            }
            //Linkler üzerinden ilanların sayfalarına ulaştık
            HtmlDocument docForPrice = new HtmlDocument();
            for (int i = 0; i < LinkList.Count; i++)
            {
                string mainUrlForPrice = LinkList[i];
                using (var client = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.82 Safari/537.36";
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var response = client.DownloadString(mainUrlForPrice);
                    docForPrice.LoadHtml(response);
                }
                //İlanımızın price bilgisini aldık burada b,r sorunla karşılaştım h3'ün içerisinde inputlar var onlar haricinde fiyat bilgisi var innerhtml ve innerText hepsini içiriyor firstChild denedim
                var price = docForPrice.DocumentNode.SelectSingleNode("//div[@class='classifiedInfo ']//h3").FirstChild.InnerText;

               
            }
            for (int i = 0; i < PriceList.Count; i++)
            {
                //Consola yazdırma işlemimiz
                Console.WriteLine("Title : " + TitleList[i] + "Price : "+PriceList[i]);
                Console.ReadKey();
            }

           
        }
    }
}
