using System;

namespace TamGiac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap kich thuoc 3 canh cua tam giac:");
            Console.Write("Nhap canh a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap canh b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap canh c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            if (a > 0 && b > 0 && c > 0 && (a + b) > c && (a + c) > b && (b + c) > a)
            {
                double chuVi = a + b + c;
                double p = chuVi / 2;
                double dienTich = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                Console.WriteLine("Chu vi cua tam giac la: " + chuVi);
                Console.WriteLine("Dien tich cua tam giac la: " + dienTich);
            }
            else
            {
                Console.WriteLine("Khong phai tam giac hop le!");
            }

            Console.ReadLine();
        }
    }
}
