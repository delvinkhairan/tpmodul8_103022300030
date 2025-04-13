using System;
using System.IO;
using Newtonsoft.Json;

public class CovidConfig
{
    public string SatuanSuhu { get; set; }
    public int BatasHariDeman { get; set; }
    public string PesanDitolak { get; set; }
    public string PesanDiterima { get; set; }

    public CovidConfig()
    {
        // Nilai default kalo file config belum ada
        SatuanSuhu = "celcius";
        BatasHariDeman = 14;
        PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        // Load config dari file (jika ada)
        LoadConfig();
    }

    private void LoadConfig()
    {
        if (File.Exists("covid_config.json"))
        {
            string json = File.ReadAllText("covid_config.json");
            dynamic config = JsonConvert.DeserializeObject(json);

            SatuanSuhu = config.satuan_suhu ?? SatuanSuhu;
            BatasHariDeman = config.batas_hari_deman ?? BatasHariDeman;
            PesanDitolak = config.pesan_ditolak ?? PesanDitolak;
            PesanDiterima = config.pesan_diterima ?? PesanDiterima;
        }
    }

    public void UbahSatuan()
    {
        SatuanSuhu = (SatuanSuhu == "celcius") ? "fahrenheit" : "celcius";
        Console.WriteLine($"Satuan suhu diganti ke: {SatuanSuhu}");
    }
}