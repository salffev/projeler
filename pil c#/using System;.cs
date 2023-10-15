using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Random random = new Random();
        double batteryLevel = 100.0; // Başlangıçta tam dolu bir pil
        double chargingRate = 0.1;   // Şarj hızı (örneğin, her mili saniyede artış miktarı)
        double dischargingRate = 0.05; // Deşarj hızı (örneğin, her mili saniyede azalma miktarı)

        while (true)
        {
            // Pil seviyesini güncelleme (rastgele veri üretimi)
            batteryLevel += random.NextDouble() * (chargingRate - dischargingRate) - dischargingRate;

            // Pil seviyesini 0 ile 100 arasında sınırlama
            batteryLevel = Math.Max(0, Math.Min(100, batteryLevel));

            // Pil seviyesini yazdırma
            Console.WriteLine($"Pil Doluluğu: {batteryLevel}%");

            // Bekleme süresi (örneğin, her mili saniye)
            Thread.Sleep(1);
        }
    }
}
