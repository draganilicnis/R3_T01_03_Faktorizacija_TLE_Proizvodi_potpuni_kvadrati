#include <bits/stdc++.h>
using namespace std;

// Eratostenovo sito — generiše listu prostih brojeva
vector<int> Prosti_brojevi_Lista_Napuni() 
{
    int N = 31623; //21623;
    vector<int> Prosti_brojevi_Lista;
    vector<bool> Eratostenovo_sito(N + 1, false);

    Prosti_brojevi_Lista.push_back(2);
    for (int i = 2; i <= N; i += 2) Eratostenovo_sito[i] = true;

    for (int p = 3; p <= N; p += 2) 
    {
        if (!Eratostenovo_sito[p]) 
        {
            Prosti_brojevi_Lista.push_back(p);
            long long p_na_kvadrat = 1LL * p * p;
            if (p_na_kvadrat <= N) 
            {
                for (int i = p * p; i <= N; i += p) Eratostenovo_sito[i] = true;
            }
        }
    }
    return Prosti_brojevi_Lista;
}

int main() 
{
    ios::sync_with_stdio(false);
    // cin.tie(nullptr);
    // Priprema liste prostih brojeva
    vector<int> Prosti_brojevi_Lista = Prosti_brojevi_Lista_Napuni();
    int id_max = (int)Prosti_brojevi_Lista.size();

    int n;
    cin >> n;
    vector<int> ulaz(n);
    for (int i = 0; i < n; i++) cin >> ulaz[i];

    set<int> a;  // Skup prostih cinilaca sa neparnim eksponentom

    for (int i = 0; i < n; i++) 
    {
        int B = ulaz[i];
        int id = 0;
        int d = Prosti_brojevi_Lista[id];

        while (id < id_max && d * d <= B) 
        {
            int p = 0;
            while (B % d == 0) 
            {
                B /= d;
                p++;
            }
            if (p % 2 == 1) 
            {
                if (a.count(d)) a.erase(d);
                else a.insert(d);
            }
            id++;
            if (id < id_max) d = Prosti_brojevi_Lista[id];
        }

        if (B > 1)
        {
            int Koren_od_B = (int)floor(sqrt((double)B));
            long Kvadrat_od_Korena = Koren_od_B * Koren_od_B;
            if (Kvadrat_od_Korena != B) 
            {
                if (a.count((int)B)) a.erase((int)B);
                else a.insert((int)B);
            }
        }
        cout << (a.empty() ? "da\n" : "ne\n");
    }
    return 0;
}