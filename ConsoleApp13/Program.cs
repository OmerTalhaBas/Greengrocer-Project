using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        List<string> meyveler = new List<string> { "Çilek", "Üzüm", "Kiraz", "Şeftali", "Armut" };
        List<string> sebzeler = new List<string> { "Pırasa", "Ispanak", "Patates", "Patlıcan" };

        Dictionary<string, int> alinanUrunler = new Dictionary<string, int>();

        Console.WriteLine("Hal'e Hoş Geldiniz!");
        Thread.Sleep(2000);
        bool devamet = true;

        while (devamet)
        {
            Console.WriteLine("Meyve mi Sebze mi? (Meyve/Sebze)");
            string secim = Console.ReadLine();

            if (secim == "Meyve")
            {
                Console.Clear();
                Listele(meyveler);
            }
            else if (secim == "Sebze")
            {
                Console.Clear();
                Listele(sebzeler);
            }
            else
            {
                Console.WriteLine("Geçersiz Seçim Yaptınız! Lütfen Doğru Seçim Yaptığınıza Emin Olun!");
                Thread.Sleep(2000);
                continue;
            }

            Console.Write("Seçtiğiniz Ürünü Giriniz : ");
            string urun = Console.ReadLine();
            Console.Clear();
            if (meyveler.Contains(urun) || sebzeler.Contains(urun))
            {
                Console.Write("Kaç Kilo Vereyim Abime ?\nKilo Giriniz : ");
                int kilo;
                bool kilo1 = int.TryParse(Console.ReadLine(), out kilo);
                if (kilo1 && kilo > 0)
                {
                    if (alinanUrunler.ContainsKey(urun))
                    {
                        alinanUrunler[urun] += kilo;
                    }
                    else
                    {
                        alinanUrunler[urun] = kilo;
                    }

                    Console.Write("Başka Bir Şey İster Misin Abim ? (Evet/Hayır)\n -->  ");
                    string devam = Console.ReadLine();
                    devamet = (devam.ToUpper() == "EVET");
                }
                else
                {
                    Console.WriteLine("Geçersiz Kilo Girdiniz! Lütfen Bize Borçlu Çıkmaya Çalışma Ya Da Çıkadabilirsin.");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("Geçersiz Ürün Girdiniz. Lütfen Mevcut Ürünlerden Giriniz!");
                Thread.Sleep(2000);
            }

            Console.Clear();
        }

        Console.WriteLine("Pazar'a Hoş Geldiniz!");
        Thread.Sleep(2000);
        foreach (var urun in alinanUrunler)
        {
            Console.WriteLine($"{urun.Key} - {urun.Value} kg");
        }

        bool satisDevam = true;
        Dictionary<string, int> satilanUrunler = new Dictionary<string, int>();

        while (satisDevam)
        {
            Console.Write("Satmak İstediğiniz Ürünü Yazınız : ");
            string satisUrun = Console.ReadLine();

            if (alinanUrunler.ContainsKey(satisUrun))
            {
                Console.Write("Kaç Kilo Satmak İstiyorsunuz ?\nKilo Giriniz : ");
                int satisKilo;
                bool satisGecerlilik = int.TryParse(Console.ReadLine(), out satisKilo);
                if (satisGecerlilik && satisKilo > 0)
                {
                    if (satisKilo <= alinanUrunler[satisUrun])
                    {
                        alinanUrunler[satisUrun] -= satisKilo;

                        if (satilanUrunler.ContainsKey(satisUrun))
                        {
                            satilanUrunler[satisUrun] += satisKilo;
                        }
                        else
                        {
                            satilanUrunler[satisUrun] = satisKilo;
                        }

                        Console.WriteLine($"{satisUrun} - {satisKilo} kg satıldı. Afiyet Olsun!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        if (alinanUrunler[satisUrun] == 0)
                        {
                            alinanUrunler.Remove(satisUrun);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Yeterli Stok Yok. Mevcut Stok : {alinanUrunler[satisUrun]} kg.");
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz Kilo Girdiniz. Lütfen Bize Borçlu Çıkmaya Çalışma Ya Da Çıkadabilirsin.");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("Bu Üründen Almadınız. Lütfen Geçerli Bir Ürün GİR!");
                Thread.Sleep(2000);
            }

            Console.Write("Başka Bir Satış Yapmak İster Misiniz? (Evet/Hayır)\n -->  ");
            string satisCevap = Console.ReadLine();
            satisDevam = (satisCevap.ToUpper() == "EVET");
            Console.Clear();
        }

        Console.WriteLine("İyi Satışlar Dilerim!");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("Satılan Ürünler:");
        foreach (var urun in satilanUrunler)
        {
            Console.WriteLine($"{urun.Key} - {urun.Value} kg");
        }
    }

    static void Listele(List<string> urunler)
    {
        Console.WriteLine("Mevcut Ürünler :");
        foreach (string urun in urunler)
        {
            Console.WriteLine(urun);
        }
    }
}
