using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_1._2
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "1.2 Three sorting types and one comparator";
        
        static void Main(string[] args)
        {
            Console.WriteLine(programDescription);
            Console.WriteLine(author);

            
            List<IPlayer> players = new List<IPlayer>()
            {
                new Player(29, "Ivan", "Ivanenko", PlayerRank.Captain),
                new Player(19, "Peter", "Petrenko", PlayerRank.Private),
                new Player(59, "Ivan", "Ivanov", PlayerRank.General),
                new Player(52, "Ivan", "Snezko", PlayerRank.Lieutenant),
                new Player(34, "Alex", "Zeshko", PlayerRank.Colonel),
                new Player(29, "Ivan", "Ivanenko", PlayerRank.Captain),
                new Player(19, "Peter", "Petrenko", PlayerRank.Private),
                new Player(34, "Vasiliy", "Sokol", PlayerRank.Major),
                new Player(31, "Alex", "Alexeenko", PlayerRank.Major)
            };

            players = players.Distinct(new PlayersEqualityComparer()).ToList();

            Console.WriteLine("\n\nList of players sorted by last name and first name without duplicates");
            players.Sort(new PlayersByNameComparer());
            players.ForEach(Console.WriteLine);
            
            Console.WriteLine("\n\nList of players sorted by age without duplicates");
            players.Sort(new PlayersByAgeComparer());
            players.ForEach(Console.WriteLine);
            
            Console.WriteLine("\n\nList of players sorted by rank without duplicates");
            players.Sort(new PlayersByRankComparer());
            players.ForEach(Console.WriteLine);
        }
    }
}