
internal class Program
{
    private static void Main(string[] args) 
    {
        Console.WriteLine("Nhập vào số nguyên dương a:");
        int a = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Nhập vào số nguyên dương b:");
        int b = Int32.Parse(Console.ReadLine());

        //tinh tong
        Console.WriteLine($"Sum = {a+b}");

    }
}