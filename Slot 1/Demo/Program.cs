// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Nhập số thứ nhất:");
        string inputA = Console.ReadLine();

        Console.WriteLine("Nhập số thứ hai:");
        string inputB = Console.ReadLine();

        // Chuyển đổi chuỗi thành số nguyên
        if (int.TryParse(inputA, out int a) && int.TryParse(inputB, out int b))
        {
            int ucln = TimUCLN(a, b);
            int bcnn = TimBCNN(a, b);

            Console.WriteLine($"Ước số chung lớn nhất của {a} và {b} là: {ucln}");
            Console.WriteLine($"Bội số chung nhỏ nhất của {a} và {b} là: {bcnn}");
        }
        else
        {
            Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập lại các số nguyên.");
        }
    }

    // Hàm tìm Ước số chung lớn nhất (UCLN) sử dụng thuật toán Euclid
    static int TimUCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Hàm tìm Bội số chung nhỏ nhất (BCNN)
    static int TimBCNN(int a, int b)
    {
        return (a * b) / TimUCLN(a, b);
    }
}
