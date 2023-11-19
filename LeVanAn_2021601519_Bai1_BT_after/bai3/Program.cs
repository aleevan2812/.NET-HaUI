using System;

namespace bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap thang (1-12): ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nhap nam: ");
            int year = Convert.ToInt32(Console.ReadLine());

            int daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine("So ngay cua thang {0} nam {1} la: {2}", month, year, daysInMonth);

            Console.ReadLine();
        }
    }
}
