using System;

namespace bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh thue thu nhap");
            Console.Write("Nhap luong: ");
            double luong = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap thuong: ");
            double thuong = Convert.ToDouble(Console.ReadLine());

            double thuNhap = luong + thuong;
            double thue = 0;

            if (thuNhap < 9000000)
            {
                thue = 0;
            }
            else if (thuNhap >= 9000000 && thuNhap <= 15000000)
            {
                thue = thuNhap * 0.1;
            }
            else if (thuNhap > 15000000 && thuNhap <= 30000000)
            {
                thue = thuNhap * 0.15;
            }
            else
            {
                thue = thuNhap * 0.2;
            }

            Console.WriteLine("Thue thu nhap cua ban la: " + thue);

            Console.ReadLine();
        }
    }
}
