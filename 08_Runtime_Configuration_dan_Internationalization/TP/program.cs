using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace tpmodul8_2211104011
{
    class CovidConfig
    {
        private const string ConfigFile = "covid_config.json";
        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDemam { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public CovidConfig()
        {
            if (File.Exists(ConfigFile))
            {
                LoadConfig();
            }
            else
            {
                SaveConfig();
            }
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigFile))
                {
                    string json = File.ReadAllText(ConfigFile);
                    var config = JsonConvert.DeserializeObject<CovidConfig>(json);

                    if (config != null)
                    {
                        SatuanSuhu = config.SatuanSuhu;
                        BatasHariDemam = config.BatasHariDemam;
                        PesanDitolak = config.PesanDitolak;
                        PesanDiterima = config.PesanDiterima;
                    }
                }
                else
                {
                    SaveConfig();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat membaca konfigurasi: {ex.Message}");
            }
        }


        public void SaveConfig()
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(ConfigFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saat menyimpan konfigurasi: " + ex.Message);
            }
        }

        public void UbahSatuan()
        {
            SatuanSuhu = (SatuanSuhu == "celcius") ? "fahrenheit" : "celcius";
            SaveConfig();
        }
    }

    class Program
    {
        static void Main()
        {
            CovidConfig config = new CovidConfig();

            // Tambahkan opsi mengubah satuan suhu
            Console.WriteLine("Apakah Anda ingin mengubah satuan suhu? (y/n)");
            string pilihan = Console.ReadLine().ToLower();

            if (pilihan == "y")
            {
                config.UbahSatuan();
                Console.WriteLine($"Satuan suhu telah diubah ke {config.SatuanSuhu}.\n");
            }

            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int hariDemam = Convert.ToInt32(Console.ReadLine());

            // Debugging Info
            Console.WriteLine("\n--- Info ---");
            Console.WriteLine($"Satuan Suhu: {config.SatuanSuhu}");
            Console.WriteLine($"Input Suhu: {suhu}");
            Console.WriteLine($"Batas Hari Demam: {config.BatasHariDemam}");
            Console.WriteLine($"Input Hari Demam: {hariDemam}\n");

            bool suhuValid = (config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                              (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5);

            bool hariValid = hariDemam <= config.BatasHariDemam;

            Console.WriteLine("\nOUTPUT: " + (suhuValid && hariValid ? config.PesanDiterima : config.PesanDitolak));

          
            HapusKonfigurasi();
        }

        static void HapusKonfigurasi()
        {
            string configFile = "covid_config.json";
            if (File.Exists(configFile))
            {
                try
                {
                    File.Delete(configFile);
                    Console.WriteLine("\nKonfigurasi dihapus sebelum keluar.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nGagal menghapus konfigurasi: " + ex.Message);
                }
            }
        }
    }
}