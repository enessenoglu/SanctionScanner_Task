using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScanner_Task
{
    public class Program
    {
        //Selamlar öncelikle bu uygulamada sahibinden.com üzerinden ilanların title ve fiyat bilgilerini console ekranına yazdırdık.
        //lakin sahibinden.com birden fazla girişlerde bize sorun çıkardı ve şu hatayı verdi
        //Olağan dışı erişim tespit ettik...
       //Cihazınızdan ya da bağlı olduğunuz ağdan sitemize olağan dışı(otomatik) erişim yapılmaya çalışıldığını görüyoruz.Şu anda talebinizi gerçekleştiremiyoruz, kısa bir süre sonra tekrar deneyebilirsiniz.
       //Bu sebepten dolayı programı bitirmek zorunda kaldım
        static void Main(string[] args)
        {
            TitleAndPrice.TitleAndPrice.GetTitles();
        }
    }
}
