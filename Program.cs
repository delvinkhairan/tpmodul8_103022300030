// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        // Input suhu
        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        // Input hari demam
        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDeman = Convert.ToInt32(Console.ReadLine());

        // Validasi
        bool suhuValid = (config.SatuanSuhu == "celcius")
            ? (suhu >= 36.5 && suhu <= 37.5)
            : (suhu >= 97.7 && suhu <= 99.5);
        bool hariValid = hariDeman < config.BatasHariDeman;

        // Output pesan
        Console.WriteLine(hariValid && suhuValid ? config.PesanDiterima : config.PesanDitolak);

        // Bonus: Ubah satuan
        Console.WriteLine("\nTekan 'U' untuk ubah satuan suhu...");
        if (Console.ReadKey().Key == ConsoleKey.U)
        {
            config.UbahSatuan();
        }
    }
}
