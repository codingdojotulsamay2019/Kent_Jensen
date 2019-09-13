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
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            var mountVernon = Artists.Where(a => a.Hometown == "Mount Vernon").ToList<Artist>();
            var youngest = Artists.OrderBy(a => a.Age).ToList<Artist>();
            
            
            var willy = Artists.Where(a => a.RealName.Contains("William")).ToList<Artist>();
            
            List<Artist> oldAtlanta = Artists.Where(h => h.Hometown == "Atlanta").ToList();
            Artist[] orderedArtistArray = Artists
                    .OrderByDescending(a => a.Age)
                    .ToArray();

            List<Group> groupNames = Groups.Where(g => g.GroupName.Length < 8).ToList();
            Group[] orderedGroupArray = Groups.ToArray();





            Console.WriteLine(oldAtlanta[0].ArtistName + oldAtlanta[1].ArtistName + oldAtlanta[2].ArtistName);
            // Console.WriteLine(groupNames[i]);
            printGroups(groupNames);
            printWilly(willy);
        }
        public static void printGroups(List<Group> groupNames)
        {            
            int start = 0;
            int end = groupNames.Count;
            for(int i = start; i < end; i++)
            {
                Console.WriteLine(groupNames[i].GroupName);
            }
        }
        public static void printWilly(List<Artist> willy)
        {
            int start = 0;
            int end = willy.Count;
            for(int i = start; i < end; i++)
            {
                Console.WriteLine(willy[i].ArtistName);
            }

        }

    }
}
