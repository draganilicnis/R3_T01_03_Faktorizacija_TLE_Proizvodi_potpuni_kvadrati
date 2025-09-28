// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/proizvodi_potpuni_kvadrati
// https://petlja.org/sr-Latn-RS/kurs/17918/1/5319
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/rastavljanje_na_proste_cinioce
// https://petlja.org/sr-Latn-RS/biblioteka/r/problemi/Zbirka-stara/rastavljanje_na_proste_cinioce
// https://arena.petlja.org/sr-Latn-RS/competition/r1-t05-deljivost-prosti-tle-001-2024#tab_132321
// https://petlja.org/sr-Latn-RS/kurs/14606/23/2756
// https://github.com/draganilicnis/R1_T05_05_Deljivost_Prost_TLE_Rastavljanje_na_proste_cinioce/blob/main/R1_T05_05_Deljivost_Prost_TLE_Rastavljanje_na_proste_cinioce.cs
// https://onlinegdb.com/Xn72wK0Vb
// https://arena.petlja.org/sr-Latn-RS/competition/r3-t01-05-faktorizacija#tab_133483
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/01%20slozenost/00%20skupovi_i_mape
// https://sr.wikipedia.org/wiki/%D0%9F%D1%80%D0%BE%D1%81%D1%82_%D0%B1%D1%80%D0%BE%D1%98
// https://github.com/draganilicnis/R3_T01_03_Faktorizacija_TLE_Proizvodi_potpuni_kvadrati

using System;
using System.Collections.Generic;

class R3_T01_03_Faktorizacija_TLE_Proizvodi_potpuni_kvadrati
{
    // public const int N_Mx_Prost_Cinilac = 21623; // 31623 = Math.Sqrt(10^9);       // Mx Prost = 31607 // Mx Potpun kvadrat je 31607 * 31607 = 999 002 449 = 999002449
                                                // Ustvari treci koren iz (10^9) sto je 10^3 = 1000, jer ako je prvi njamanji delilac 1009, onda je potpun kvadrat 10^6, 
                                                // a svaki veci broj od 10^6 bi imao najvise treci neparni delilac veci (ili jednak) 1009.
    static List<int> Prosti_brojevi_Lista_Napuni()
    {
        // Eratostenovo sito
        const int N = 21623;    // 31623 = Math.Sqrt(10^9);     // Mx Prost = 31607 // Mx Potpun kvadrat je 31607 * 31607 = 999 002 449 = 999002449
        List<int> Prosti_brojevi_Lista = new List<int>();       // Lista prostih brojeva do 1001, jer ako je 1001 najmanji delilac, onda 1001*1001*1001 > 10^9 
        bool[] Eratostenovo_sito = new bool[N + 1];             // Niz prostih brojeva (false = prost, true = slozen, nije prost), inicijalno su svi prosti = false

        Prosti_brojevi_Lista.Add(2); for (int i = 2; i <= N; i = i + 2) Eratostenovo_sito[i] = true;
        // Prosti_brojevi_Lista.Add(3); for (int i = 9; i <= N; i = i + 6) Eratostenovo_sito[i] = true;
        // Prosti_brojevi_Lista.Add(5); for (int i = 25; i <= N; i = i + 10) Eratostenovo_sito[i] = true;

        for (int p = 3; p <= N; p = p + 2)
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
        return Prosti_brojevi_Lista;    // Prosti_brojevi_Lista i Eratostenovo_sito[1000] su sada isti s tim sto Niz ima 1000 a Lista manje od 1000 elemenata, odnosno samo 168
    }
    static void Main()
    {
        List<int> Prosti_brojevi_Lista = new List<int>();       // Lista prostih brojeva u kojoj je 168 brojeva, najveci je 997 = Prosti_brojevi_Lista[167]
        Prosti_brojevi_Lista = Prosti_brojevi_Lista_Napuni();   // Ove dve linije koda su mogle da budu u jednoj, ali se tada program sporije izvrsava
        int id_max = Prosti_brojevi_Lista.Count;                // Najveci indeks u listi prostih brojeva, odnosno najveci prost broj u listi: Prosti_brojevi_Lista[167] = 997

        // for (int i = 0; i < Prosti_brojevi_Lista.Count; i++) Console.WriteLine(Prosti_brojevi_Lista[i]);

        // Resavanje zadatka
        int n = int.Parse(Console.ReadLine());          // 1 <=  n   <= 10^4
        string[] s = Console.ReadLine().Split();        // 1 <= a[i] <= 10^9
        SortedSet<int> a = new SortedSet<int>();        // Skup delioca

        // Resavanje zadatka (Glavna petlja)
        for (int i = 0; i < n; i++)
        {
            int B = int.Parse(s[i]);                    // B = a[i] Sledeci ucitan prirodan broj Ai koji bi trebalo da mnozimo sa proizvodom prethodnih i-1 brojeva
            int id = 0;                                 // Indeks prvog prostog broja u listi prostih brojeva
            int d = Prosti_brojevi_Lista[id];           // Trenutni delilac d (polazi se od najmanjeg, tj prvog): d = Prosti_brojevi_Lista[0] = 2 
            while (d * d <= B && id < id_max)
            {
                if (d * d > B) break;                   // Nije potrebno za while, ali jeste ukoliko umesto while koristimo foreach
                int p = 0;                              // Broj ponavljanja cinioca d
                while (B % d == 0) { B = B / d; p++; }  // Sve dok je broj B deljiv sa d => delimo ga sa d i inkrementiramo brojac delilaca p
                if (p % 2 > 0) { if (a.Contains(d)) a.Remove(d); else a.Add(d); }   // Samo ako je broj delilaca p neparan onda ako nije u skupu dodajemo ga, a ako jesto izbacujemo
                id++;                                   // Pripremamo se za sledecu iteraciju, odnosno sledeci prvi veci delilac, koji je prost broj
                if (id < id_max) 
                {
                    d = Prosti_brojevi_Lista[id];
                    // if (d == B && B > 1) { if (a.Contains(d)) a.Remove(d); else a.Add(d); B = 1; }
                }
            }
            if (B > 1)                                  // Ako je broj B jos uvek veci od 1 (a prvi najmanji d > Math.Sqrt(B)), onda proveravamo da li je B potpun kvadrat
            {
                int Koren_od_B = (int)Math.Floor(Math.Sqrt(B));         // Mx Prost = 31607 // Mx Potpun kvadrat je 31607 * 31607 = 999 002 449 = 999002449
                int Kvadrat_od_Korena_od_B = Koren_od_B * Koren_od_B;   // Mx Potpun kvadrat je 31607 * 31607 = 999 002 449 = 999002449
                if (Kvadrat_od_Korena_od_B != B)
                {
                    //if (B > N_Mx_Prost_Cinilac)         // if (B > 1009) Ako je broj B jos uvek veci od 1 (a prvi najmanji d >= 1001), onda proveravamo da li je B potpun kvadrat
                    //{                                   // jer su ostala najvise jos 2 cinioca (i to oba veca od 1001, ako su dva cinioca, jedan mora biti manji od 31607)
                    //    d = Koren_od_B;         
                    //    if (d % 2 > 0) d--; // prvi manji neparni
                    //    while (d >= N_Mx_Prost_Cinilac && B % d > 0) d = d - 2;
                    //    if (d >= N_Mx_Prost_Cinilac && B % d == 0)
                    //    {
                    //        B = B / d;
                    //        if (a.Contains(d)) a.Remove(d); else a.Add(d);
                    //    }
                    //}
                    if (a.Contains(B)) a.Remove(B); else a.Add(B);
                }
            }
            Console.WriteLine(a.Count > 0 ? "ne" : "da");
        }
    }
}

/*
Razmotriti sledeci test primer: 
Kada je broj B > 1000 i < 31607

Najmanji prosti brojevi veci od 1000 su: 1009, 1013 i 1019
Ako je:
N = 3
A[0] = 1009 * 1013 = 1 022 117 => a = [1009, 1013]
A[1] = 1009 * 1019 = 1 028 171 => a = [1013, 1019]
A[2] = 1013 * 1019 = 1 032 247 => a = []
A[0]*A[1]*A[2] = 1022117 * 1028171 * 1032247 = 1009 * 1013 * 1009 * 1019 * 1013 * 1019 = 1009 * 1013 * 1019 * 1009 * 1013 * 1019 = 1.041.537.223 * 1.041.537.223

ULAZ:
3
1022117 1028171 1032247

IZLAZ:
ne
ne
da

To bi bilo isto kao kada bi
N = 3
A[0] = 3 * 5 = 15 => a = [3, 5]
A[1] = 3 * 7 = 21 => a = [5, 7]
A[2] = 5 * 7 = 35 => a = []
A[0]*A[1]*A[2] = 15 * 21 * 35 = 3 * 5 * 3 * 7 * 5 * 7 = 3 * 5 * 7 * 3 * 5 * 7 = 105 * 105 = 11025

ULAZ:
3
15 21 35

IZLAZ:
ne
ne
da

*/
