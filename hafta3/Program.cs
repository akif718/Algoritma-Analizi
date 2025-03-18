using System;
using System.Diagnostics;

namespace PowFunction
{
    internal class Program
    {
        static int callCountLinear = 0;  // Lineer fonksiyon çağrı sayacı
        static int callCountRecursive = 0;  // Rekürsif fonksiyon çağrı sayacı

        static void Main()
        {
            // PowFunctionLinear'ı test etme
            Console.WriteLine("PowFunctionLinear'ı test etme:");
            callCountLinear = 0;
            Stopwatch stopwatch = new Stopwatch();  // Zaman ölçümünü başlatmak için Stopwatch nesnesi oluştur
            stopwatch.Start();  // Zaman ölçümüne başla
            int resultLinear = PowFunctionLinear(2, 16);
            stopwatch.Stop();  // Zaman ölçümünü durdur
            Console.WriteLine($"PowFunctionLinear'ın sonucu: {resultLinear}");
            Console.WriteLine($"PowFunctionLinear'da yapılan fonksiyon çağrıları: {callCountLinear}");
            Console.WriteLine($"PowFunctionLinear'ın çalışma süresi: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"PowFunctionLinear karmaşıklığı: O(n) = {callCountLinear}");

            Console.WriteLine();  // Testler arasında ayrım yapmak için boşluk ekleyelim

            // PowFunctionRecursive'ı test etme
            Console.WriteLine("PowFunctionRecursive'ı test etme:");
            callCountRecursive = 0;  // Sayaç sıfırlanıyor
            stopwatch.Restart();  // Zaman ölçümünü yeniden başlat
            int resultRecursive = PowFunctionRecursive(2, 16);
            stopwatch.Stop();  // Zaman ölçümünü durdur
            Console.WriteLine($"PowFunctionRecursive'ın sonucu: {resultRecursive}");
            Console.WriteLine($"PowFunctionRecursive'da yapılan fonksiyon çağrıları: {callCountRecursive}");
            Console.WriteLine($"PowFunctionRecursive'ın çalışma süresi: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"PowFunctionRecursive karmaşıklığı: O(log n) = {callCountRecursive}");
        }

        // Lineer üs hesaplama fonksiyonu
        static int PowFunctionLinear(int x, int y)
        {
            int result = 1;

            for (int i = 0; i < y; i++)
            {
                callCountLinear++;
                result *= x;
            }

            return result;
        }

        // Rekürsif üs hesaplama fonksiyonu
        static int PowFunctionRecursive(int x, int y)
        {
            callCountRecursive++;  // Her fonksiyon çağrısında sayaç artıyor
            int m;
            if (y == 0)
                return 1;

            if (y % 2 == 1)
                return x * PowFunctionRecursive(x, y - 1);

            m = PowFunctionRecursive(x, y / 2);
            return m * m;
        }
    }
}