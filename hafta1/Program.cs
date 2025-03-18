using System;
using System.Diagnostics;

namespace ComplexityEstimator
{
    internal class Program
    {
        static void Main()
        {
            for (int size = 2; size <= 50; size++) // Matris boyutunu artırarak deneme yap
            {
                int[,,] matrix = GenerateMatrix(size);

                // Brute-force için süre ölçümü
                Stopwatch stopwatchBrute = Stopwatch.StartNew();
                int stepsBrute = FindLargestSubCubeSumBrute(matrix);
                stopwatchBrute.Stop();

                // Optimize için süre ölçümü
                Stopwatch stopwatchOptimized = Stopwatch.StartNew();
                int stepsOptimized = FindLargestSubCubeSumOptimized(matrix);
                stopwatchOptimized.Stop();

                Console.WriteLine($"n={size} için adım sayıları ve süreler:");
                Console.WriteLine($"Brute-force: {stepsBrute} adım, Süre: {stopwatchBrute.Elapsed.TotalMilliseconds} ms");
                Console.WriteLine($"Optimize: {stepsOptimized} adım, Süre: {stopwatchOptimized.Elapsed.TotalMilliseconds} ms");
                Console.WriteLine();
            }
        }

        static int[,,] GenerateMatrix(int n)
        {
            Random rand = new Random();
            int[,,] matrix = new int[n, n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        matrix[i, j, k] = rand.Next(-10, 10); // Rastgele değerler ata

            return matrix;
        }

        // BRUTE-FORCE ÇÖZÜMÜ O(N^6) (DAHA YAVAŞ)
        public static int FindLargestSubCubeSumBrute(int[,,] mat)
        {
            int n = mat.GetLength(0);
            int stepCounter = 0;
            int maxSum = int.MinValue;

            for (int x1 = 0; x1 < n; x1++)
            {
                for (int y1 = 0; y1 < n; y1++)
                {
                    for (int z1 = 0; z1 < n; z1++)
                    {
                        stepCounter++;
                        for (int x2 = x1; x2 < n; x2++)
                        {
                            for (int y2 = y1; y2 < n; y2++)
                            {
                                for (int z2 = z1; z2 < n; z2++)
                                {
                                    stepCounter++;
                                    int sum = 0;

                                    for (int i = x1; i <= x2; i++)
                                    {
                                        for (int j = y1; j <= y2; j++)
                                        {
                                            for (int k = z1; k <= z2; k++)
                                            {
                                                sum += mat[i, j, k];
                                                stepCounter++;
                                            }
                                        }
                                    }

                                    maxSum = Math.Max(maxSum, sum);
                                }
                            }
                        }
                    }
                }
            }

            return stepCounter;
        }

        // OPTİMİZE O(N^3) ÇÖZÜMÜ (DAHA HIZLI)
        public static int FindLargestSubCubeSumOptimized(int[,,] mat)
        {
            int n = mat.GetLength(0);
            int stepCounter = 0;
            int maxSum = int.MinValue;

            for (int x1 = 0; x1 < n; x1++)
            {
                for (int y1 = 0; y1 < n; y1++)
                {
                    for (int z1 = 0; z1 < n; z1++)
                    {
                        stepCounter++;
                        int sum = 0;

                        for (int x2 = x1; x2 < n; x2++)
                        {
                            for (int y2 = y1; y2 < n; y2++)
                            {
                                for (int z2 = z1; z2 < n; z2++)
                                {
                                    sum += mat[x2, y2, z2]; // Toplamı tekrar hesaplamıyoruz
                                    stepCounter++;
                                    maxSum = Math.Max(maxSum, sum);
                                }
                            }
                        }
                    }
                }
            }

            return stepCounter;
        }
    }
}
