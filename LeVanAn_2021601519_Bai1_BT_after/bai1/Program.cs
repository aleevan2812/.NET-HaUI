using System;

namespace bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Giai phuong trinh bac 2: AX^2 + BX + C = 0");
            Console.Write("Nhap he so A: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap he so B: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap he so C: ");
            double c = Convert.ToDouble(Console.ReadLine());

            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                Console.WriteLine("Phuong trinh vo nghiem");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Phuong trinh co nghiem kep: x = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Phuong trinh co 2 nghiem phan biet:");
                Console.WriteLine("x1 = " + x1);
                Console.WriteLine("x2 = " + x2);
            }

            Console.ReadLine();
        }
    }
}
