using System;

namespace XepLoaiHS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ho ten hoc sinh: ");
            string hoTen = Console.ReadLine();

            Console.Write("Nhap diem thi cuoi ky: ");
            double diem = Convert.ToDouble(Console.ReadLine());

            string xepLoai = "";

            if (diem >= 8)
            {
                xepLoai = "Gioi";
            }
            else if (diem >= 6.5 && diem < 8)
            {
                xepLoai = "Kha";
            }
            else if (diem >= 5 && diem < 6.5)
            {
                xepLoai = "Trung binh";
            }
            else
            {
                xepLoai = "Yeu";
            }

            Console.WriteLine("Ho ten hoc sinh: " + hoTen.ToUpper());
            Console.WriteLine("Ket qua xep loai: " + xepLoai);

            Console.ReadLine();
        }
    }
}
