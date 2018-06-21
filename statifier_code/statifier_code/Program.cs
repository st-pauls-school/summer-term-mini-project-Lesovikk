using System;
using System.IO;
using System.Collections.Generic;

namespace statifier
{
    class read
    {
        public string typefile = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "typesStrength.csv");
        public string typesIndex = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "typesIndex.csv");

        int[] fetchSize(fileName)
        {
            StreamReader reader = new StreamReader
        }
    }

    class fetch
    {

        struct Pokémon
        {
            int natNum;
            string name;
            int type1Num;
            int type2Num;
            int abilityNum;
            //base stats
            int HP;
            int A;
            int D;
            int spA;
            int spD;
            int S;
        }

        int[,] attack(string typefile)
        {
            StreamReader advantages = new StreamReader(typefile);
            int lines = File.ReadAllLines(typefile).Length;
            int lineL = File.ReadLines(typefile).Length;
            string line;
            int[,] temp = new int[lines, lineL];
            for (int i = 0; i < lines; i++)
            {
                line = advantages.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    temp[i, j] = Convert.ToInt32(line.Substring(j,1));
                }
            }
            advantages.Close();
            return temp;
        }

        Pokémon[] GetPokémon(string fileName)
        {
            StreamReader pokemon = new StreamReader(fileName);
            int total = File.ReadAllLines(fileName).Length;
            int data = File.Read

        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            read read = new read();
            Console.WriteLine(read.typefile);
        }
    }
}

