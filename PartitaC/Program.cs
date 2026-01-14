namespace EsercizioCalcio
{
    internal class Program
    {

        //valorizzazione dei giocatori
        static void Valorizzare(int[] squadra, int[] panchinari)
        {
            Random random = new Random();

            for (int i = 0; i < squadra.Length; i++)
            {
                int punteggio = random.Next(30, 100);
                squadra[i] = punteggio;
            }
            for (int i = 0; i < panchinari.Length; i++)
            {
                int punteggio = random.Next(30, 70);
                panchinari[i] = punteggio;
            }

        }
        //stampa dei valori dei giocatori
        static void Stampa(int[] squadra, int[] panchina)
        {
            for (int i = 0; i < squadra.Length; i++)
            {
                Console.WriteLine("Il valore del " + i + " giocatore e " + squadra[i]);
            }

            for (int i = 0; i < panchina.Length; i++)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Il valore del giocatore " + i + " in panchina e " + panchina[i]);
            }
        }
        //funzione per la somma dei valori dei giocatori delle 2 squadre
        static int Somma(int[] squadra)
        {
            int somma = 0;
            for (int i = 0; i < squadra.Length; i++)
            {
                somma = squadra[i] + somma;

            }
            return somma;
        }
        static void Main(string[] args)
        {
            //creazione dei vettori delle 2 squadre
            int[] squadraA = new int[11];
            int[] squadraB = new int[11];
            int[] panchinaA = new int[5];
            int[] panchinaB = new int[5];
            int[] cartellinoGiallo = new int[11];
            int a = 0, b = 0, puntiGol = 2;
            //probabilità del gol
            Random random = new Random();
            Console.WriteLine("Squadra A ");
            //riempimento della squadra A e dei suoi panchinari
            Valorizzare(squadraA, panchinaA);
            //stampa dei valori della squadra A e dei panchinari
            Stampa(squadraA, panchinaA);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Squadra B");
            //riempimento del vettore della quadra B e dei panchinari
            Valorizzare(squadraB, panchinaB);
            //stampa dei valori della squadra B e dei panchinari
            Stampa(squadraB, panchinaB);
            Console.WriteLine("------------------------------------------------------");
            for (int i = 0; i < 90; i++)
            {
                Console.WriteLine("------------------------------------------------------");
                //minutaggio della partita
                Console.WriteLine("Siamo al minuto " + i);

                //random per la probabilità di gol
                int probabilità = random.Next(1, 100);
                if (probabilità <= 2)
                {
                    //somma dei valori della squadra A
                    float sommaA = Somma(squadraA);
                    //somma dei valori della squadra B
                    float sommaB = Somma(squadraB);
                    //calcolo della somma totale
                    float sommaTotale = sommaA + sommaB;
                    //calcolo probabilità gol della squadra A
                    float probabilitàGolA = (sommaA / sommaTotale) * 100;
                    //calcolo probabilità gol della squadra B
                    float probabilitàGolB = (sommaB / sommaTotale) * 100;
                    float gol = random.Next(1, 100);
                    if (gol<= probabilitàGolA)
                    {
                        //Gol segnato dalla squadra A
                        a++;

                        Console.WriteLine("Ha segnato la squadra A al minuto " + i + " e il punteggio e: " + a + " per la squadra A e " + b + " per la squadra B");
                        for(int z = 0; z < squadraA.Length; z++)
                        {
                            squadraA[z] = puntiGol + squadraA[z];
                          
                        }
                        Console.WriteLine("------------------------------------------------------");
                        
                    }
                    else
                    {
                        //Gol segnato dalla squadra B
                        b++;
                        Console.WriteLine("Ha segnato la squadra B al minuto " + i + " e il punteggio e: " + a + " per la squadra A e " + b + " per la squadra B");
                        for (int z = 0; z < squadraB.Length; z++)
                        {
                            squadraB[z] = puntiGol + squadraB[z];

                        }
                        Console.WriteLine("------------------------------------------------------");

                    }



                }
                //cartellino giallo
                if (probabilità <= 20)
                {
                    int rnd = random.Next(1, 2);
                    int rand = random.Next(0, 10);
                    if (rnd == 1)
                    {
                        squadraA[rand] = squadraA[rand] - 5;
                        Console.WriteLine("Il giocatore " + rand + " della squadra A e stato ammonito con un cartellino giallo");
                        cartellinoGiallo[rand] += 1;

                    }
                    else {
                        squadraB[rand] = squadraB[rand] - 5;
                        Console.WriteLine("Il giocatore " + rand + " della squadra A e stato ammonito con un cartellino giallo");
                        cartellinoGiallo[rand] += 1;
                    }
                }
            }
            int recupero = random.Next(91, 95);
            for (int i = 90; i < recupero; i++)
            {
                Console.WriteLine("------------------------------------------------------");
                //minutaggio della partita
                Console.WriteLine("Siamo al minuto " + i);
                //random per la probabilità di gol
                int probabilità = random.Next(1, 100);
                if (probabilità <= 2)
                {
                    //somma dei valori della squadra A
                    int sommaA = Somma(squadraA);
                    //somma dei valori della squadra B
                    int sommaB = Somma(squadraB);
                    //calcolo della somma totale
                    int sommaTotale = sommaA + sommaB;
                    //calcolo probabilità gol della squadra A
                    float probabilitàGolA = (sommaA / sommaTotale) * 100;
                    //calcolo probabilità gol della squadra B
                    float probabilitàGolB = (sommaB / sommaTotale) * 100;
                    if (probabilitàGolA > probabilitàGolB)
                    {
                        //Gol segnato dalla squadra A
                        a++;
                        Console.WriteLine("Ha segnato la squadra A al minuto " + i + " e il punteggio e: " + a + " per la squadra A e " + b + " per la squadra B");
                        Console.WriteLine("------------------------------------------------------");
                    }
                    else
                    {
                        //Gol segnato dalla squadra B
                        b++;
                        Console.WriteLine("Ha segnato la squadra B al minuto " + i + " e il punteggio e: " + a + " per la squadra A e " + b + " per la squadra B");
                        Console.WriteLine("------------------------------------------------------");
                    }



                }
            }
            if (a > b)
            {
                Console.WriteLine("La vittoria e stata presa dalla squadra A");
            }
            else if (a == b)
            {
                Console.WriteLine("Il risultato della partita e:" + a + " per la squadra A e " + b + " per la squadra B, percio la partita si conclude con un pareggio");
            }
            else
            {
                Console.WriteLine("La vittoria e stata presa dalla squadra B");
            }
        }
    }
}