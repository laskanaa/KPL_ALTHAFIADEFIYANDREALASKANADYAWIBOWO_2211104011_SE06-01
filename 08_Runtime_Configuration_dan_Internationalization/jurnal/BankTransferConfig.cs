using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_2211104011
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }

        private const string configFile = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(configFile))
            {
                string json = File.ReadAllText(configFile);

                // Deserialize ke struct/temp object, bukan class ini langsung
                var loadedConfig = JsonSerializer.Deserialize<BankTransferConfigDTO>(json);

                lang = loadedConfig.lang;
                transfer = loadedConfig.transfer;
                methods = loadedConfig.methods;
                confirmation = loadedConfig.confirmation;
            }
            else
            {
                // Default config
                lang = "en";
                transfer = new Transfer
                {
                    threshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000
                };
                methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
                confirmation = new Confirmation { en = "yes", id = "ya" };

                SaveDefaultConfig();
            }
        }

        private void SaveDefaultConfig()
        {
            var dto = new BankTransferConfigDTO
            {
                lang = this.lang,
                transfer = this.transfer,
                methods = this.methods,
                confirmation = this.confirmation
            };

            string json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFile, json);
        }

        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }

        // DTO class untuk parsing JSON agar tidak stack overflow
        private class BankTransferConfigDTO
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }
        }
    }
}