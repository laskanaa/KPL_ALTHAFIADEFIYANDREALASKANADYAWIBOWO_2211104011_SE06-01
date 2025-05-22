using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8_2211104011
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          BANK TRANSFER SERVICE         ");
            Console.WriteLine("========================================");

            // Load config
            BankTransferConfig config = new BankTransferConfig();

            // Menampilkan pilihan bahasa
            Console.WriteLine("\nSelect Language:");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Bahasa Indonesia");
            Console.Write("Enter your choice [Press Enter to use default: " + (config.lang == "id" ? "Bahasa Indonesia" : "English") + "]: ");

            string langChoice = Console.ReadLine().Trim();
            if (langChoice == "1")
            {
                config.lang = "en";
            }
            else if (langChoice == "2")
            {
                config.lang = "id";
            }
            // Else: use default from JSON config

            Console.WriteLine();

            // Input nominal transfer
            if (config.lang == "en")
                Console.Write("Please insert the amount of money to transfer: ");
            else
                Console.Write("Masukkan jumlah uang yang akan di-transfer: ");

            int amount;
            while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                if (config.lang == "en")
                    Console.Write("Invalid input. Please enter a positive number: ");
                else
                    Console.Write("Input tidak valid. Masukkan angka yang benar: ");
            }

            // Hitung biaya
            int fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
            int total = amount + fee;

            Console.WriteLine();
            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee  : " + fee);
                Console.WriteLine("Total amount  : " + total);
            }
            else
            {
                Console.WriteLine("Biaya transfer: " + fee);
                Console.WriteLine("Total biaya   : " + total);
            }

            // Pilih metode transfer
            Console.WriteLine();
            if (config.lang == "en")
                Console.WriteLine("Select transfer method:");
            else
                Console.WriteLine("Pilih metode transfer:");

            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }

            int methodIndex = 0;
            while (true)
            {
                Console.Write(config.lang == "en" ? "Enter your choice (1-" + config.methods.Count + "): " : "Masukkan pilihan Anda (1-" + config.methods.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out methodIndex) && methodIndex >= 1 && methodIndex <= config.methods.Count)
                {
                    break;
                }

                if (config.lang == "en")
                    Console.WriteLine("Invalid choice. Please try again.");
                else
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
            }

            // Konfirmasi
            Console.WriteLine();
            string confirmKeyword = config.lang == "en" ? config.confirmation.en : config.confirmation.id;
            string confirmMessage = config.lang == "en"
                ? $"Please type \"{confirmKeyword}\" to confirm the transaction: "
                : $"Ketik \"{confirmKeyword}\" untuk mengkonfirmasi transaksi: ";
            Console.Write(confirmMessage);
            string confirmationInput = Console.ReadLine().Trim();

            bool isConfirmed = confirmationInput.Equals(confirmKeyword, StringComparison.OrdinalIgnoreCase);

            Console.WriteLine();
            if (isConfirmed)
            {
                Console.WriteLine(config.lang == "en" ? "The transfer is completed." : "Proses transfer berhasil.");
            }
            else
            {
                Console.WriteLine(config.lang == "en" ? "Transfer is cancelled." : "Transfer dibatalkan.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}