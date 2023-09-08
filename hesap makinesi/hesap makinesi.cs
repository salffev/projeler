using System;

class HesapMakinesi
{
    static void Main()
    {
        double sayi1, sayi2, sonuc;
        char operatorSecim;

        Console.WriteLine("İlk sayıyı girin: ");
        sayi1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("İkinci sayıyı girin: ");
        sayi2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Yapmak istediğiniz işlemi seçin: ");
        Console.WriteLine("Toplama (+)");
        Console.WriteLine("Çıkarma (-)");
        Console.WriteLine("Çarpma (*)");
        Console.WriteLine("Bölme (/)");
        operatorSecim = Convert.ToChar(Console.ReadLine());

        switch (operatorSecim)
        {
            case '+':
                sonuc = sayi1 + sayi2;
                Console.WriteLine("Sonuç: " + sonuc);
                break;
            case '-':
                sonuc = sayi1 - sayi2;
                Console.WriteLine("Sonuç: " + sonuc);
                break;
            case '*':
                sonuc = sayi1 * sayi2;
                Console.WriteLine("Sonuç: " + sonuc);
                break;
            case '/':
                if (sayi2 != 0)
                {
                    sonuc = sayi1 / sayi2;
                    Console.WriteLine("Sonuç: " + sonuc);
                }
                else
                {
                    Console.WriteLine("Sıfıra bölme hatası!");
                }
                break;
            default:
                Console.WriteLine("Geçersiz işlem seçimi!");
                break;
        }

        Console.ReadLine();
    }
}
