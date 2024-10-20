using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace NFL
{
    internal class Match
    {
        public RomaiSorszam Ssz;
        public string Dátum;
        public string Győztes;
        public string Eredmény;
        public string Vesztes;
        public string Helyszín;
        public string VárosÁllam;
        public int Nézőszám;
    }
    internal class Program
    {
        //3.feladat
        static List<Match> ParseData(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<Match> matches = new List<Match>();

            sr.ReadLine(); //skipping the first line lol

            while (!sr.EndOfStream)
            {
                string[] tokens = sr.ReadLine().Split(';');

                Match match = new Match() 
                { 
                    Ssz = new RomaiSorszam(tokens[0]),
                    Dátum = tokens[1],
                    Győztes = tokens[2],
                    Eredmény = tokens[3],
                    Vesztes = tokens[4],
                    Helyszín = tokens[5],
                    VárosÁllam = tokens[6],
                    Nézőszám = int.Parse(tokens[7]),
                };

                matches.Add(match);
            }

            return matches;
        }
        static double AvgPointDiff(List<Match> matches) 
        {
            int pointDiffSum = 0;
            foreach (Match match in matches) 
            {
                string[] tokens = match.Eredmény.Split('-');
                pointDiffSum += Math.Abs(int.Parse(tokens[0]) - int.Parse(tokens[1])); //math.abs is for when the first number < second number 
            }

            return pointDiffSum / matches.Count;
        }
        static void Main(string[] args)
        {
            var data = ParseData("nfl.txt");

            //4.feladat
            Console.WriteLine(data.Count());
            
            //5.feladat
            Console.WriteLine(AvgPointDiff(data));

            Console.ReadKey();
        }
    }
}
