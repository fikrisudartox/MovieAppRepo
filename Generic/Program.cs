//namespace Generic
//{
//    public class Program
//    {
//        /*static void Main()
//        {
//            Dictionary<string, string> myDictionary = new Dictionary<string, string>();

//            //nambahin entry dict
//            myDictionary.Add("Apel", "Apple");
//            myDictionary.Add("Pisang", "Banana");
//            myDictionary.Add("Ular", "Snake");
//            myDictionary.Add("Belimbing", "Jackfruit");
//            myDictionary.Add("Bermain", "Playing");
//            myDictionary.Add("Makan", "Eating");
//            myDictionary.Add("Pakaian", "Clothes");
//            myDictionary.Add("Lemari", "Cabinet");
//            myDictionary.Add("Sulap", "Magic");
//            myDictionary.Add("Komputer", "Computer");

//            Console.WriteLine("Inggris dari Pakaian: " + myDictionary["Pakaian"]);
//            Console.WriteLine("Inggris dari Pisang: " + myDictionary["Pisang"]);
//            Console.WriteLine();

//            //iterasi
//            foreach (KeyValuePair<string, string> entry in myDictionary)
//            {
//                Console.WriteLine(entry.Key + ": " + entry.Value);
//            }          
//        }*/

//        static void Main(string[] args)
//        {
//            //buat dict baru
//            Dictionary<int, Translate> myDictionary = new Dictionary<int, Translate>();

//            //buat objek
//            Translate translate1 = new Translate() { Id = "kata1", En = "word1" };
//            Translate translate2 = new Translate() { Id = "kata2", En = "word2" };
//            Translate translate3 = new Translate() { Id = "kata3", En = "word3" };
//            Translate translate4 = new Translate() { Id = "kata4", En = "word4" };
//            Translate translate5 = new Translate() { Id = "kata5", En = "word5" };
//            Translate translate6 = new Translate() { Id = "kata6", En = "word6" };
//            Translate translate7 = new Translate() { Id = "kata7", En = "word7" };
//            Translate translate8 = new Translate() { Id = "kata8", En = "word8" };
//            Translate translate9 = new Translate() { Id = "kata9", En = "word9" };
//            Translate translate10 = new Translate() { Id = "kata10", En = "word10" };

//            myDictionary.Add(1, translate1);
//            myDictionary.Add(2, translate2);
//            myDictionary.Add(3, translate3);
//            myDictionary.Add(4, translate4);
//            myDictionary.Add(5, translate5);
//            myDictionary.Add(6, translate6);
//            myDictionary.Add(7, translate7);
//            myDictionary.Add(8, translate8);
//            myDictionary.Add(9, translate9);
//            myDictionary.Add(10, translate10);

//            //Console.WriteLine(myDictionary[1].Id + " " + myDictionary[1].En);
//            //Console.WriteLine(myDictionary[2].Id + " " + myDictionary[2].En);
//            //Console.WriteLine(myDictionary[3].Id + " " + myDictionary[3].En);
//            //Console.WriteLine(myDictionary[4].Id + " " + myDictionary[4].En);
//            //Console.WriteLine(myDictionary[5].Id + " " + myDictionary[5].En);
//            //Console.WriteLine(myDictionary[6].Id + " " + myDictionary[6].En);
//            //Console.WriteLine(myDictionary[7].Id + " " + myDictionary[7].En);
//            //Console.WriteLine(myDictionary[8].Id + " " + myDictionary[8].En);
//            //Console.WriteLine(myDictionary[9].Id + " " + myDictionary[9].En);
//            //Console.WriteLine(myDictionary[10].Id + " " + myDictionary[10].En);

//            //iterasi
//            foreach (KeyValuePair<int, Translate> entry in myDictionary)
//            {
//                Console.WriteLine(entry.Key + ": " + entry.Value.Id + " " + entry.Value.En);
//            }
//        }
//    }

//    public class Translate
//    {
//        public string Id { get; set; }
//        public string En { get; set; }
//    }
//}