//using System;
//using System.Collections.Generic;

//class Program
//{
//    static Dictionary<string, string> dictionary = new Dictionary<string, string>();

//    static void Main()
//    {
//        bool running = true;

//        while (running)
//        {
//            Console.WriteLine("Menu:");
//            Console.WriteLine("1. Tampilkan Kamus");
//            Console.WriteLine("2. Tambah Data Kata");
//            Console.WriteLine("3. Keluar Aplikasi");
//            Console.WriteLine();

//            Console.Write("Enter your choice (1-3): ");
//            string choice = Console.ReadLine();

//            switch (choice)
//            {
//                case "1":
//                    ShowDictionary();
//                    break;
//                case "2":
//                    AddKeyValuePair();
//                    break;
//                case "3":
//                    running = !CloseApp();
//                    break;
//                default:
//                    Console.WriteLine("Pilihan Invalid. Coba lagi");
//                    break;
//            }

//            Console.WriteLine();
//        }
//    }

//    static void ShowDictionary()
//    {
//        if (dictionary.Count == 0)
//        {
//            Console.WriteLine("Kamus masih kosong.");
//        }
//        else
//        {
//            Console.WriteLine("Dictionary Contents:");
//            foreach (var pair in dictionary)
//            {
//                Console.WriteLine($"KataID: {pair.Key} -- KataEng: {pair.Value}");
//            }
//        }
//    }

//    static void AddKeyValuePair()
//    {
//        Console.Write("Masukkan Kata ID: ");
//        string key = Console.ReadLine();

//        Console.Write("Masukkan Kata Eng: ");
//        string value = Console.ReadLine();

//        dictionary[key] = value;

//        Console.WriteLine("Kamus Berhasil Di Tambahkan.");
//    }
//    static bool CloseApp()
//    {
//        Console.WriteLine("Apakah Ingin Keluar Aplikasi? (Yes/No)");
//        string answer = Console.ReadLine();
//        return answer.Equals("Yes", StringComparison.OrdinalIgnoreCase);
//    }
//}
