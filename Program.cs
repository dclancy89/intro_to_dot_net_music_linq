using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist FromMtVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine($"The artists {FromMtVernon.ArtistName} from Mt Vernon is {FromMtVernon.Age} years old");
            //Who is the youngest artist in our collection of artists?
            Artist Youngest = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"The Youngest artist is {Youngest.ArtistName}");
            //Display all artists with 'William' somewhere in their real name
            List<Artist> Williams = Artists.Where(artist => artist.RealName.Contains("Williams")).ToList();
            foreach(var artist in Williams)
            {
                Console.WriteLine(artist.ArtistName + " - " + artist.RealName);
            }
            //Display the names of all groups less than 8 characters in length
            List<Group> groupByLength = Groups.Where(group => group.GroupName.Length < 8).ToList();
            Console.WriteLine("All groups with names less than 8 in length");
            foreach(var group in groupByLength)
            {
                Console.WriteLine(group.GroupName);
            }

            //Display the 3 oldest artist from Atlanta
            List<Artist> Oldest = Artists.Where(artist => artist.Hometown == "Atlanta")
                                  .OrderByDescending(artist => artist.Age)
                                  .Take(3)
                                  .ToList();

            Console.WriteLine("The three oldest artists from Atlanta are:");
            foreach(var artist in Oldest)
            {
                Console.WriteLine(artist.ArtistName + " - " + artist.Age);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
