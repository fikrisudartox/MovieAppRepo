namespace Generic
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    class Program
    {
        static Dictionary<int, Dictionary<string, object>> movieData = new Dictionary<int, Dictionary<string, object>>();
        static Dictionary<int, List<string>> theaterData = new Dictionary<int, List<string>>();
        static int currentId = 1;

        static void Main()
        {
            // Tambah Inisial Data Movie
            AddMovie("Insidious 4", "Horror", 6.5f);
            AddMovie("The Hangover", "Comedy", 5.0f);
            AddMovie("007: Skyfall", "Action", 7.5f);
            AddMovie("Fantastic Beast", "Fantasy", 9.0f);
            AddMovie("Forbidden Door", "Horror", 4.0f);
            AddMovie("Harry Potter", "Fantasy", 8.0f);
            AddMovie("Avengers: EndGame", "Action", 9.5f);
            AddMovie("Home Alone", "Comedy", 5.0f);
            AddMovie("One Missed Call", "Horror", 3.5f);
            AddMovie("Die Hard", "Action", 7.0f);

            // Tambah Inisial Data Theater
            AddTheater(1, "CGV");
            AddTheater(2, "CINEPOLIS");
            AddTheater(3, "Cinema XXI");

            // Asosiasikan Inisial Movie Data ke Daftar Semua Theater
            AddMovieToTheater(1, 1);
            AddMovieToTheater(2, 2);
            AddMovieToTheater(3, 3);
            AddMovieToTheater(4, 2);
            AddMovieToTheater(5, 2);
            AddMovieToTheater(6, 1);
            AddMovieToTheater(7, 3);
            AddMovieToTheater(8, 3);
            AddMovieToTheater(9, 2);
            AddMovieToTheater(10, 1);


            DisplayMenu();
        }

        static void AddMovie(string title, string genre, float rating)
        {
            var movie = new Dictionary<string, object>
        {
            { "id", currentId },
            { "title", title },
            { "genre", genre },
            { "rating", rating }
        };

            movieData[currentId] = movie;
            currentId++;
        }

        static void AddTheater(int theaterId, string location)
        {
            if (!theaterData.ContainsKey(theaterId))
            {
                theaterData[theaterId] = new List<string>();
            }

            if (!theaterData[theaterId].Contains(location))
            {
                theaterData[theaterId].Add(location);
            }
        }

        static void AddMovieToTheater(int movieId, int theaterId)
        {
            if (!theaterData.ContainsKey(theaterId))
            {
                Console.WriteLine("Invalid theater ID.");
                return;
            }

            if (!movieData.ContainsKey(movieId))
            {
                Console.WriteLine("Invalid movie ID.");
                return;
            }

            if (!theaterData[theaterId].Contains(movieId.ToString()))
            {
                theaterData[theaterId].Add(movieId.ToString());
                //Console.WriteLine("Movie berhasil ditambahkan ke Theater.");
            }
            else
            {
                Console.WriteLine("Movie sudah ada di theater.");
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Daftar Movie");
            Console.WriteLine("2. Tambah Movie");
            Console.WriteLine("3. Daftar Theater");
            Console.WriteLine("4. Tambah Movie ke Theater");
            Console.WriteLine("5. Keluar");

            Console.Write("Masukkan Pilihan: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowMovieData();
                    break;
                case "2":
                    AddMovieData();
                    break;
                case "3":
                    ShowTheaterData();
                    break;
                case "4":
                    AddMovieToTheater();
                    break;
                case "5":
                    ExitProgram();
                    break;
                default:
                    Console.WriteLine("Pilihan Invalid...");
                    DisplayMenu();
                    break;
            }
        }

        static void ShowMovieData()
        {
            int tableWidth = 68;
            string title = "Daftar Movie";

            Console.WriteLine(new string('-', tableWidth));
            Console.WriteLine("{0}", new string(' ', (tableWidth - title.Length) / 2) + title + new string(' ', (tableWidth - title.Length + 1) / 2));
            Console.WriteLine(new string('-', tableWidth));
            Console.WriteLine(" {0,-5} | {1,-25} | {2,-15} | {3,-10} ", "ID", "Title", "Genre", "Rating");
            Console.WriteLine(new string('-', tableWidth));

            foreach (var movie in movieData)
            {
                Console.WriteLine(" {0,-5} | {1,-25} | {2,-15} | {3,-10} ", movie.Key, movie.Value["title"], movie.Value["genre"], movie.Value["rating"]);
            }

            Console.WriteLine(new string('-', tableWidth));
            Console.WriteLine();
            Console.Write("Masukkan ID Movie untuk Update Rating (atau 0 untuk kembali): ");
            int movieId = int.Parse(Console.ReadLine());

            if (movieId != 0 && movieData.ContainsKey(movieId))
            {
                Console.Write("Masukkan Rating yang Ingin Di Tambah: ");
                float ratingToAdd = float.Parse(Console.ReadLine());

                float currentRating = float.Parse(movieData[movieId]["rating"].ToString());
                float newRating = currentRating + ratingToAdd;

                // limit rating maksimum ke 10
                if (newRating > 10f)
                {
                    newRating = 10f;
                    Console.WriteLine("Rating movie sudah maksimum! (10)");
                }
                else if (newRating < 0f)
                {
                    newRating = 0f;
                }

                movieData[movieId]["rating"] = newRating.ToString();

                Console.WriteLine("Rating Movie Berhasil Di Update....");
            }
            else if (movieId != 0)
            {
                Console.WriteLine("Movie Tidak Di Temukan.");
            }

            Console.WriteLine();
            DisplayMenu();
        }

        static void AddMovieData()
        {
            Console.Write("Masukkan Title Movie: ");
            string title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine()); // buat userinput selalu Titlecase

            List<string> validGenres = new List<string> { "Comedy", "Horror", "Action", "Fantasy" }; // buat list untuk menunjukkan list genre

            string genre;
            do
            {
                Console.WriteLine("Genre List: Comedy, Horror, Action, Fantasy");
                Console.Write("Masukkan Genre Movie: ");
                genre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine()); // buat userinput selalu Titlecase

                if (!validGenres.Contains(genre)) // validasi genre
                {
                    Console.WriteLine("Genre tidak valid. Silahkan pilih dari list genre.");
                }
            } while (!validGenres.Contains(genre));

            Console.Write("Masukkan Rating Movie: ");
            float rating = float.Parse(Console.ReadLine());

            AddMovie(title, genre, rating);
            Console.WriteLine("Movie Berhasil Di Tambahkan...");

            DisplayMenu();
        }

        static void ShowTheaterData()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Daftar Semua Theater");
            Console.WriteLine("2. Filter Theater Berdasarkan Genre");
            Console.WriteLine("3. Kembali Ke Menu Utama");

            Console.Write("Masukkan Pilihan: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllTheaters();
                    break;
                case "2":
                    FilterTheatersByGenre();
                    break;
                case "3":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Pilihan Tidak Valid...");
                    ShowTheaterData();
                    break;
            }
        }

        static void ShowAllTheaters()
        {
            if (theaterData.Count == 0)
            {
                Console.WriteLine("Tidak ada data theater.");
            }
            else
            {
                Console.WriteLine("Daftar Semua Theater");
                Console.WriteLine("--------------------");

                foreach (var theater in theaterData)
                {
                    Console.WriteLine($"Theater ID: {theater.Key}");

                    if (theater.Value.Count == 0)
                    {
                        Console.WriteLine("Tidak ada lokasi yang ditambahkan.");
                    }
                    else
                    {
                        Console.WriteLine($"Lokasi: {theater.Value[0]}");
                        Console.WriteLine("Film:");
                        Console.WriteLine("-----");

                        for (int i = 1; i < theater.Value.Count; i++)
                        {
                            int movieId = int.Parse(theater.Value[i]);
                            string movieTitle = movieData[movieId]["title"].ToString();
                            Console.WriteLine($"- {movieTitle}");
                        }
                    }

                    Console.WriteLine();
                }
            }

            DisplayMenu();
        }

        static void FilterTheatersByGenre()
        {
            Console.Write("Masukkan Nama Genre: ");
            string genre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine()); // Buat user selalu Titlecase
            Console.WriteLine();

            var filteredTheaters = theaterData.Where(theater =>
                theater.Value.Skip(1)
                    .Any(movieId => string.Equals(movieData[int.Parse(movieId)]["genre"].ToString(), genre, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (filteredTheaters.Count == 0)
            {
                Console.WriteLine($"Tidak ada theater dengan genre ditemukan '{genre}'.");
                FilterTheatersByGenre();
            }
            else
            {
                foreach (var theater in filteredTheaters)
                {
                    Console.WriteLine($"Theater ID: {theater.Key}");
                    Console.WriteLine($"Lokasi: {theater.Value[0]}");

                    for (int i = 1; i < theater.Value.Count; i++)
                    {
                        int movieId = int.Parse(theater.Value[i]);
                        string movieGenre = movieData[movieId]["genre"].ToString();

                        if (string.Equals(movieGenre, genre, StringComparison.OrdinalIgnoreCase))
                        {
                            string movieTitle = movieData[movieId]["title"].ToString();
                            Console.WriteLine($"Movie: -{movieTitle}");
                        }
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            DisplayMenu();
        }

        static void AddMovieToTheater()
        {
            Console.Write("Masukkan ID Theater: ");
            int theaterId = int.Parse(Console.ReadLine());

            if (!theaterData.ContainsKey(theaterId))
            {
                Console.WriteLine("Invalid theater ID.");
                AddMovieToTheater();
                return;
            }

            Console.Write("Masukkan ID Movie: ");
            int movieId = int.Parse(Console.ReadLine());

            if (!movieData.ContainsKey(movieId))
            {
                Console.WriteLine("Invalid movie ID.");
                AddMovieToTheater();
                return;
            }

            if (!theaterData[theaterId].Contains(movieId.ToString()))
            {
                theaterData[theaterId].Add(movieId.ToString());
                Console.WriteLine("Movie berhasil ditambahkan ke Theater.");
            }
            else
            {
                Console.WriteLine("Movie sudah ada di theater.");
            }

            DisplayMenu();
        }

        static void ExitProgram()
        {
            Console.WriteLine("Apakah anda ingin keluar dari aplikasi? (yes/no)");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "yes")
            {
                Console.WriteLine("Menutup aplikasi...");
                Environment.Exit(0);
            }
            else if (choice.ToLower() == "no")
            {
                Console.WriteLine("Kembali ke menu utama..");
                Console.WriteLine();
                DisplayMenu();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid...");
                ExitProgram();
            }
        }
    }
}
