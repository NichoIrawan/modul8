using modul8;

class main
{
    static BankTransferConfig config = new BankTransferConfig();
    static string input;
    static int nominalTransfer;
    static int fee;
    static string method;

    public static void Main(string[] args)
    {
        menuTransfer();
    }

    public static void menuTransfer()
    {
        if (config.bankTransfer.lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }

        input = Console.ReadLine();

        try
        {
            nominalTransfer = int.Parse(input);
                
            if (nominalTransfer <= config.bankTransfer.transfer.threshold)
            {
                fee = config.bankTransfer.transfer.low_fee;
            }
            else
            {
                fee = config.bankTransfer.transfer.high_fee;
            }
        }
        catch
        {
            Console.WriteLine("[Error]");
            menuTransfer();
        }
        if (config.bankTransfer.lang.Equals("en"))
        {
            Console.WriteLine($"Transfer fee = {fee} dan Total = {nominalTransfer + fee}");
            Console.WriteLine("Select transfer method: ");
        }
        else
        {
            Console.WriteLine($"Fee transfer = {fee} dan Total biaya = {nominalTransfer + fee}");
            Console.WriteLine("Pilih metode transfer: ");
        }

        for (int i = 0; i < config.bankTransfer.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1} {config.bankTransfer.methods.ElementAt(i)}");
        }
        input = Console.ReadLine();

        try
        {
            method = config.bankTransfer.methods.ElementAt(int.Parse(input));
        }
        catch
        {
            Console.WriteLine("[Error]");
            menuTransfer();
        }

        if (config.bankTransfer.lang.Equals("en"))
        {
            Console.WriteLine($"Please type {config.bankTransfer.confirmation.en} to confirm the transaction: ");
            input = Console.ReadLine();
            if (input == config.bankTransfer.confirmation.en)
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transfer is cancelled");
                menuTransfer();
            }
        }
        else
        {
            Console.WriteLine($"Ketik {config.bankTransfer.confirmation.id} untuk mengkonfirmasi transaksi: ");
            input = Console.ReadLine();
            if (input == config.bankTransfer.confirmation.id)
            {
                Console.WriteLine(" Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine(" Transfer dibatalkan");
                menuTransfer();
            }
        }

    }
}
