using System;

namespace bai4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap mot so nguyen duong n (0 < n <= 100): ");
            int n = Convert.ToInt32(Console.ReadLine());

            int sum = 0;

            // Su dung vong lap while
            int i = 1;
            while (i <= n)
            {
                sum += i;
                i++;
            }
            Console.WriteLine("Tong S (while): " + sum);

            // Su dung vong lap do...while
            sum = 0;
            i = 1;
            do
            {
                sum += i;
                i++;
            } while (i <= n);
            Console.WriteLine("Tong S (do...while): " + sum);

            // Su dung vong lap for
            sum = 0;
            for (i = 1; i <= n; i++)
            {
                sum += i;
            }
            Console.WriteLine("Tong S (for): " + sum);

            Console.ReadLine();
        }
    }
}
