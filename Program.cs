using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV
{
    internal class Program
    {  
            struct SinhVien
        {
            public string HoTen;
            public double Diem;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int n = 0;
            while (n <= 0)
            {
                Console.Write("Nhập số lượng sinh viên n (n > 0): ");
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Số lượng không hợp lệ. Vui lòng nhập lại số nguyên lớn hơn 0!");
                }
            }

            SinhVien[] danhSach = new SinhVien[n];
            double tongDiem = 0;
            int soLuongDat = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin sinh viên thứ {i + 1}");
                Console.Write("Họ tên: ");
                danhSach[i].HoTen = Console.ReadLine();

                Console.Write("Điểm: ");
                while (!double.TryParse(Console.ReadLine(), out danhSach[i].Diem) || danhSach[i].Diem < 0 || danhSach[i].Diem > 10)
                {
                    Console.Write("Điểm số không hợp lệ (0 - 10). Vui lòng nhập lại: ");
                }
                tongDiem += danhSach[i].Diem;
                if (danhSach[i].Diem >= 5.0)
                {
                    soLuongDat++;
                }
            }

            double diemTrungBinh = tongDiem / n;
            double diemMax = danhSach[0].Diem;
            for (int i = 1; i < n; i++)
            {
                if (danhSach[i].Diem > diemMax)
                {
                    diemMax = danhSach[i].Diem;
                }
            }

            Console.WriteLine("DANH SÁCH SINH VIÊN");
            Console.WriteLine($"{"STT",-5} | {"Họ và tên",-25} | {"Điểm số",-7}");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1,-5} | {danhSach[i].HoTen,-25} | {danhSach[i].Diem,-7:F2}");
            }
            Console.WriteLine($"\n> Điểm trung bình của lớp: {diemTrungBinh:F2}");
            Console.Write($"> Sinh viên có điểm cao nhất ({diemMax} điểm): ");
            bool firstMax = true;
            for (int i = 0; i < n; i++)
            {
                if (danhSach[i].Diem == diemMax)
                {
                    if (!firstMax) Console.Write(", ");
                    Console.Write(danhSach[i].HoTen);
                    firstMax = false;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"> Số lượng sinh viên đạt (>= 5.0): {soLuongDat}");
            Console.ReadLine();
        }
    }
}
