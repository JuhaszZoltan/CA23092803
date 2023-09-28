using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA23092803
{
    class Program
    {
        static void Main()
        {
            var bank = new List<Karakter>();
            Beolvas(@"..\..\..\src\bank.txt", bank);

            Console.WriteLine($"5.f.: karakterek szama: {bank.Count}");

            char input;
            bool sikerult;
            do
            {
                Console.Write("6.f.: input: ");
                sikerult = char.TryParse(Console.ReadLine(), out input);
            } while (!sikerult || input < 65 || input > 90);

            Console.Write("7.f.: ");
            var megjelenitendo = bank.SingleOrDefault(k => k.Betu == input);
            if (megjelenitendo is not null) megjelenitendo.Megjelenit();
            else Console.WriteLine("nincs ilyen karakter a bankban");

            var kodolt = new List<Karakter>();
            Beolvas(@"..\..\..\src\dekodol.txt", kodolt);

            Console.WriteLine("9.f.: dekodolas:");
            foreach (var k in kodolt)
            {

                var karakter = bank.FirstOrDefault(bk => bk.Felismer(k));
                Console.Write(karakter is null ? "?" : karakter.Betu);

                //int index = 0;
                //while (index < bank.Count && !bank[index].Felismer(k)) index++;
                //if (index < bank.Count) Console.Write(bank[index].Betu);
                //else Console.Write("?");
            }
        }

        static void Beolvas(string filePath, List<Karakter> lista)
        {
            using var sr = new StreamReader(
                filePath,
                Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                char b = char.Parse(sr.ReadLine());
                var m = new bool[7, 4];
                for (int s = 0; s < m.GetLength(0); s++)
                {
                    string sor = sr.ReadLine();
                    for (int o = 0; o < m.GetLength(1); o++)
                    {
                        m[s, o] = sor[o] == '1';
                    }
                }
                lista.Add(new Karakter(b, m));
            }
        }
    }
}
