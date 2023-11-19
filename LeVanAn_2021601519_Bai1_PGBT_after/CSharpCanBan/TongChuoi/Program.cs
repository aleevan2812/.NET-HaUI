using System;

namespace TongChuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen duong n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int sum1 = 0;
            double sum2 = 0;

            for (int i = 1; i <= n; i++)
            {
                sum1 += i;
                sum2 += 1.0 / i;
            }

            Console.WriteLine("Tong S1 = " + sum1);
            Console.WriteLine("Tong S2 = " + sum2);

            Console.ReadLine();
        }
    }
}
