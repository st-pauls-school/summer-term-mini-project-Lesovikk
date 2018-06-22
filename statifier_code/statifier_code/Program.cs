using System;
using System.IO;
using System.Collections.Generic;

namespace statifier
{
    static class read
    {
        public static string typefile = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "typesStrength.csv");
        public static string typesIndex = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "typesIndex.csv");
    }

    static class fetch
    {
        struct Pokémon
        {
            public int natNum;
            public string name;
            public int type1Num;
            public int type2Num;
            public int ability1Num;
            public int ability2Num;
            public int ability3Num;
            //base stats
            public int HP;
            public int A;
            public  D;
            public int spA;
            public int spD;
            public int S;
        }

        static int[] fetchSize(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            int lineL = reader.ReadLine().Split(',').Length;
            int lines = 1;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                lines++;
            }
            reader.Close();
            return new int[] { lineL, lines };
        }

        static int[,] attack(string typefile)
        {
            StreamReader advantages = new StreamReader(typefile);
            string line;
            int[,] temp = new int[fetchSize(typefile)[1], fetchSize(typefile)[0]];
            for (int i = 0; i < fetchSize(typefile)[1]; i++)
            {
                line = advantages.ReadLine();
                for (int j = 0; j < fetchSize(typefile)[0]; j++)
                {
                    temp[i, j] = Convert.ToInt32(line.Substring(j,1));
                }
            }
            advantages.Close();
            return temp;
        }

        static Pokémon[] GetPokémon(string fileName)
        {
            StreamReader Plist = new StreamReader(fileName);
            Pokémon[] pokémons = new Pokémon[fetchSize(fileName)[1]];
            string[] line = new string[]{};
            for (int i = 0; i < fetchSize(fileName)[1]; i++)
            {
                line = Plist.ReadLine().Split(',');
                Pokémon pokémon = new Pokémon();
                pokémon.natNum = Convert.ToInt32(line[0]);
                pokémon.name = line[1];
                pokémon.type1Num = Convert.ToInt32(line[2]);
                pokémon.type2Num = Convert.ToInt32(line[3]);

            }

        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(read.typefile);
        }
    }
}

