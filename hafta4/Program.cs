using System;
using System.Diagnostics;

class Program
{
    static (int, int, int, long, long) MaxSubarraySum(int[] sayilar, int complexity)
    {
        int maxToplam = int.MinValue;
        int baslangic = 0, bitis = 0;
        long adimSayisi = 0; // Adım sayacımız
        Stopwatch stopwatch = new Stopwatch(); // Zaman ölçmek için
        stopwatch.Start();

        if (complexity == 1) // O(n) - Kadane Algoritması
        {
            int geciciToplam = 0;
            int geciciBaslangic = 0;

            for (int i = 0; i < sayilar.Length; i++)
            {
                if (geciciToplam + sayilar[i] > sayilar[i])
                {
                    geciciToplam += sayilar[i];
                }
                else
                {
                    geciciToplam = sayilar[i];
                    geciciBaslangic = i;
                }

                if (geciciToplam > maxToplam)
                {
                    maxToplam = geciciToplam;
                    baslangic = geciciBaslangic;
                    bitis = i;
                }
                adimSayisi++;
            }
        }
        else if (complexity == 2) // O(n²) - Çift Döngü
        {
            for (int i = 0; i < sayilar.Length; i++)
            {
                int toplam = 0;
                for (int j = i; j < sayilar.Length; j++)
                {
                    toplam += sayilar[j];
                    if (toplam > maxToplam)
                    {
                        maxToplam = toplam;
                        baslangic = i;
                        bitis = j;
                    }
                    adimSayisi++;
                }
            }
        }
        else if (complexity == 3) // O(n³) - Üçlü Döngü
        {
            for (int i = 0; i < sayilar.Length; i++)
            {
                for (int j = i; j < sayilar.Length; j++)
                {
                    int toplam = 0;
                    for (int k = i; k <= j; k++)
                    {
                        toplam += sayilar[k];
                        adimSayisi++;
                    }
                    if (toplam > maxToplam)
                    {
                        maxToplam = toplam;
                        baslangic = i;
                        bitis = j;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Geçersiz karmaşıklık seviyesi! 1, 2 veya 3 seçin.");
            return (0, 0, 0, 0, 0);
        }

        stopwatch.Stop(); // Zaman ölçümünü durdur
        long gecenSureMs = stopwatch.ElapsedMilliseconds; // Milisaniye cinsinden geçen süre

        return (maxToplam, baslangic, bitis, adimSayisi, gecenSureMs);
    }

    static void Main()
    {
        int[] sayilar = { -2, 1, -3, 4, -1, 2, 1, -5, 4, 3, -1, 2, -6, 5, 1, -2, 3 };

        var (sonuc1, bas1, bit1, adim1, sure1) = MaxSubarraySum(sayilar, 1);
        Console.WriteLine($"O(n) - En Büyük Toplam: {sonuc1}, Başlangıç: {bas1}, Bitiş: {bit1}, Adım Sayısı: {adim1}, Süre: {sure1} ms");

        var (sonuc2, bas2, bit2, adim2, sure2) = MaxSubarraySum(sayilar, 2);
        Console.WriteLine($"O(n²) - En Büyük Toplam: {sonuc2}, Başlangıç: {bas2}, Bitiş: {bit2}, Adım Sayısı: {adim2}, Süre: {sure2} ms");

        var (sonuc3, bas3, bit3, adim3, sure3) = MaxSubarraySum(sayilar, 3);
        Console.WriteLine($"O(n³) - En Büyük Toplam: {sonuc3}, Başlangıç: {bas3}, Bitiş: {bit3}, Adım Sayısı: {adim3}, Süre: {sure3} ms");
    }
}
