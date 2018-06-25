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
            public int D;
            public int spA;
            public int spD;
            public int S;
        }

        struct Move
        {
            public int IndexNo;
            public string name;
            public int power;
            public double accuracy;
            public int effectIndex;
            public double effectProb;
            public double 
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

        static int[,] defend(string typefile)
        {
            StreamReader advantages = new StreamReader(typefile);
            string line;
            int[,] temp = new int[fetchSize(typefile)[1], fetchSize(typefile)[1]];
            for (int i = 0; i < fetchSize(typefile)[1]; i++)
            {
                line = advantages.ReadLine();
                for (int j = 0; j < fetchSize(typefile)[0]; j++)
                {
                    temp[j, i] = Convert.ToInt32(line.Substring(j, 1));
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
                pokémon.ability1Num = Convert.ToInt32(line[4]);
                pokémon.ability2Num = Convert.ToInt32(line[5]);
                pokémon.ability3Num = Convert.ToInt32(line[6]);

                pokémon.HP = Convert.ToInt32(line[7]);
                pokémon.A = Convert.ToInt32(line[8]);
                pokémon.D = Convert.ToInt32(line[9]);
                pokémon.spA = Convert.ToInt32(line[10]);
                pokémon.spD = Convert.ToInt32(line[11]);
                pokémon.S = Convert.ToInt32(line[12]);
                pokémons[i] = pokémon;
            }
            Plist.Close();
            return pokémons;
        }

        static double Damage(int level, Move move, Pokémon p1, Pokémon p2, int modifier)
        {
            double damage = (((((2*level/5)+2)*move.power*(p1.A/p2.D))/50)+2)*modifier;
            return damage;
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

