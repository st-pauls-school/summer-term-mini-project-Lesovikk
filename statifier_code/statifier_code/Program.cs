using System;
using System.IO;
using System.Collections.Generic;

namespace statifier
{
    class read
    {
		public string typefile = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "typesStrength.csv");
        public string typesIndex = "typesIndex.csv";
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
        }

        int[] attack(string typefile)
        {
            int[] temp;
            StreamReader advantages = new StreamReader(typefile);
        }

        Pokémon[] GetPokémon(string fileName)
        {
			
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

