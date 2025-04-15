using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8
{
    internal class BankTransferConfig
    {
        public BankTransfer bankTransfer;
        public string filePath = @"bank_transfer_config.json";

        public class BankTransfer
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }

            public BankTransfer(string lang, Transfer transfer, List<string> methods, Confirmation confirmation)
            {
                this.lang = lang;
                this.transfer = transfer;
                this.methods = methods;
                this.confirmation = confirmation;
            }
        }

        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }

            public Transfer(int thres, int low, int high) 
            { 
                this.threshold = thres;
                this.low_fee = low;
                this.high_fee = high;
            }
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }

            public Confirmation(string en, string id)
            {
                this.en = en;
                this.id = id;
            }
        }

        public BankTransferConfig()
        {
            try
            {
                readConfigFile();
            }
            catch
            {
                setDefault();
                writeConfigFile();
            }
        }

        private void setDefault()
        {
            bankTransfer = new BankTransfer(
                "en", 
                new Transfer(25000000, 6500, 15000), 
                new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                new Confirmation("yes", "ya")
            );
        }

        private BankTransfer readConfigFile()
        {
            string json = File.ReadAllText(filePath);
            bankTransfer = JsonSerializer.Deserialize<BankTransfer>(json);
            return bankTransfer;
        }

        private void writeConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(bankTransfer, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
