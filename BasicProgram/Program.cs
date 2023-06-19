namespace BasicProgram;

public class Program
{
    public static void Main()
    {
        Menu();
    }

    static void Menu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("MENU GANJIL GENAP");
            Console.WriteLine("1. Cek Ganjil/Genap");
            Console.WriteLine("2. Print Ganjil/Genap (dengan limit)");
            Console.WriteLine("3. Exit");
            Console.Write("Pilihan: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Masukkan Bilangan yang ingin di cek : ");
                        int input;
                        if (int.TryParse(Console.ReadLine(), out input) && input > 0)
                        {
                            string result;
                            if (input % 2 == 0)
                            {
                                Console.WriteLine("Genap");
                            }
                            else
                            {
                                Console.WriteLine("Ganjil");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!!!");
                        }
                        break;
                    case 2:
                        Console.Write("Pilih (Ganjil/Genap): ");
                        string printChoice = Console.ReadLine();
                        if (printChoice.ToLower() == "even" || printChoice.ToLower() == "genap")
                        {
                            Console.Write("Masukkan limit: ");
                            int limit;
                            if (int.TryParse(Console.ReadLine(), out limit) && limit > 0)
                            {
                                Console.WriteLine("Print bilangan 1 - " + limit + " :");
                                PrintEvenOdd(limit, "Even");
                            }
                            else
                            {
                                Console.WriteLine("Input limit tidak valid!!!");
                            }
                        }
                        else if (printChoice.ToLower() == "odd" || printChoice.ToLower() == "ganjil")
                        {
                            Console.Write("Masukkan limit: ");
                            int limit;
                            if (int.TryParse(Console.ReadLine(), out limit) && limit > 0)
                            {
                                Console.WriteLine("Print bilangan 1 - " + limit + " :");
                                PrintEvenOdd(limit, "Odd");
                            }
                            else
                            {
                                Console.WriteLine("Input limit tidak valid!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input pilihan tidak valid!!!");
                        }
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Input pilihan tidak valid!!!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input pilihan tidak valid!!!");
            }

            Console.WriteLine();
        }
    }

    static void PrintEvenOdd(int limit, string choice)
    {

        for (int i = 1; i <= limit; i++)
        {
            if (EvenOddCheck(i) == choice)
            {
                Console.Write(i + " ");
            }
        }

        Console.WriteLine();
    }

    static string EvenOddCheck(int input)
    {
        if (input % 2 == 0)
        {
            return "Even";
        }
        else
        {
            return "Odd";
        }
    }
}
