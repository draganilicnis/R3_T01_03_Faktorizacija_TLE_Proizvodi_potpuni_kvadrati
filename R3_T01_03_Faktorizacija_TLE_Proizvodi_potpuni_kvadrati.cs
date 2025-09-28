// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/proizvodi_potpuni_kvadrati
// https://petlja.org/sr-Latn-RS/kurs/17918/1/5319
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/rastavljanje_na_proste_cinioce
// https://petlja.org/sr-Latn-RS/biblioteka/r/problemi/Zbirka-stara/rastavljanje_na_proste_cinioce
// https://arena.petlja.org/sr-Latn-RS/competition/r1-t05-deljivost-prosti-tle-001-2024#tab_132321
// https://petlja.org/sr-Latn-RS/kurs/14606/23/2756
// https://github.com/draganilicnis/R1_T05_05_Deljivost_Prost_TLE_Rastavljanje_na_proste_cinioce/blob/main/R1_T05_05_Deljivost_Prost_TLE_Rastavljanje_na_proste_cinioce.cs
// https://onlinegdb.com/Xn72wK0Vb
// https://arena.petlja.org/sr-Latn-RS/competition/r3-t01-05-faktorizacija#tab_133483


using System;
using System.Collections.Generic;
class R3_T01_03_Faktorizacija_TLE_Proizvodi_potpuni_kvadrati
{
    static List<int> Prosti_brojevi_Lista_Napuni()
    {
        // Eratostenovo sito
        const int N = 1001;     // 31623 = Math.Sqrt(10^9);       // Mx Prost = 31607 // Mx Potpun kvadrat je 31607 * 31607 = 999 002 449 = 999002449
                                // Ustvari treci koren iz (10^9) sto je 10^3 = 1000, jer ako je prvi njamanji delilac 1007, onda je potpun kvadrat 10^6, 
                                // a svaki veci broj od 10^6 bi imao najvise treci neparni delilac veci od 1007.
        List<int> Prosti_brojevi_Lista = new List<int>();       //Lista prostih brojeva do 31623 = Math.Sqrt(10^9)
        bool[] Eratostenovo_sito = new bool[N + 1];

        Prosti_brojevi_Lista.Add(2); for (int i = 2; i <= N; i = i + 2) Eratostenovo_sito[i] = true;
        Prosti_brojevi_Lista.Add(3); for (int i = 9; i <= N; i = i + 6) Eratostenovo_sito[i] = true;

        for (int p = 5; p <= N; p = p + 2)
        {
            if (!Eratostenovo_sito[p])
            {
                Prosti_brojevi_Lista.Add(p);
                int p_na_kvadrat = p * p;
                if (p_na_kvadrat <= N)
                {
                    for (int i = p_na_kvadrat; i <= N; i = i + p) Eratostenovo_sito[i] = true;
                }
            }
        }
        return Prosti_brojevi_Lista;
    }
    static void Main()
    {
        List<int> Prosti_brojevi_Lista = new List<int>();      //Lista prostih brojeva do Math.Sqrt(10^9)
        Prosti_brojevi_Lista = Prosti_brojevi_Lista_Napuni();

        // for (int i = 0; i < Prosti_brojevi_Lista.Count; i++) Console.WriteLine(Prosti_brojevi_Lista[i]);

        // Resavanje zadatka (glavna petlja)
        int n = int.Parse(Console.ReadLine());          // 1 <=  n   <= 10^4
        string[] s = Console.ReadLine().Split();        // 1 <= a[i] <= 10^9

        SortedSet<int> a = new SortedSet<int>();

        for (int i = 0; i < n; i++)
        {
            int B = int.Parse(s[i]);                    // B = a[i]

            int id = 0;
            int id_max = Prosti_brojevi_Lista.Count;
            int d = Prosti_brojevi_Lista[id];

            while (d * d <= B && id < id_max)
            {
                if (d * d > B) break;
                int p = 0;                              // Broj ponavljanja cinioca d
                while (B % d == 0)
                {
                    B = B / d;
                    p++;
                }
                if (p % 2 > 0) { if (a.Contains(d)) a.Remove(d); else a.Add(d); }
                id++;
                if (id < id_max) d = Prosti_brojevi_Lista[id];
            }
            if (B > 1)
            {
                int Koren_od_B = (int)Math.Floor(Math.Sqrt(B));         // Mx Prost = 31607 // Mx Potpun kvadrat je 31607 * 31607 = 999 002 449 = 999002449
                int Kvadrat_od_Korena_od_B = Koren_od_B * Koren_od_B;   // Mx Potpun kvadrat je 31607 * 31607 = 999 002 449 = 999002449
                if (Kvadrat_od_Korena_od_B != B)
                {
                    if (a.Contains(B)) a.Remove(B); else a.Add(B);
                }
            }
            Console.WriteLine(a.Count > 0 ? "ne" : "da");
        }
    }
}
