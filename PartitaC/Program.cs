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
                Console.WriteLine("Il valore del " + (i + 1) + " giocatore e " + squadra[i]);
            }

            for (int i = 0; i < panchina.Length; i++)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Il valore del giocatore " + (i + 1) + " in panchina e " + panchina[i]);
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
        //funzione per la sostituzione dei giocatori
        static void Sostituzioni(int[] squadra, int[] panchina)
        {
            Console.WriteLine("Vuoi attuare una sostituzione?(s/n)");
            string risp = Console.ReadLine();
            if(risp == "s")
            {
                Console.WriteLine("Di quale squadra vuoi attuare la sostituzione?(A/B)");
                risp = Console.ReadLine();
                if(risp == "A")
                {
                    Console.WriteLine("scegli un giocatore della squadra A: ");
                    Stampa(squadra, panchina);
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Adesso scegli un panchinaro della squadra A: ");
                    int risposta = Convert.ToInt32(Console.ReadLine());
                    squadra[scelta] = panchina[risposta];
                    Console.WriteLine("Il titolare numero " + scelta + " e stato sostituito con il giocatore numero " + risposta + " della panchina");
                }
                else
                {
                    Console.WriteLine("scegli un giocatore della squadra B: ");
                    Stampa(squadra, panchina);
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Adesso scegli un panchinaro della squadra B: ");
                    int risposta = Convert.ToInt32(Console.ReadLine());
                    squadra[scelta] = panchina[risposta];
                    Console.WriteLine("Il titolare numero " + scelta + " e stato sostituito con il giocatore numero " + risposta);
                }
            }

        }
        static void Main(string[] args)
        {
            //creazione dei vettori delle 2 squadre
            int[] squadraA = new int[11];
            int[] squadraB = new int[11];
            int[] panchinaA = new int[5];
            int[] panchinaB = new int[5];
            int[] cartellinoGialloA = new int[11];
            int[] cartellinoGialloB = new int[11];
            int[] cartellinoRossoA = new int[11];
            int[] cartellinoRossoB = new int[11];
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
                    int rnd = random.Next(0,1);
                    int rand = random.Next(1, 11);
                    if (rnd == 0)
                    {
                        squadraA[rand] = squadraA[rand] - 5;
                        Console.WriteLine("Il giocatore " + rand + " della squadra A e stato ammonito con un cartellino giallo");
                        cartellinoGialloA[rand] += 1;
                        //richiesta all'utente per una sostituzione
                        Sostituzioni(squadraA, panchinaA);
                    }
                    else {
                        squadraB[rand] = squadraB[rand] - 5;
                        Console.WriteLine("Il giocatore " + rand + " della squadra B e stato ammonito con un cartellino giallo");
                        cartellinoGialloB[rand] += 1;
                        //richiesta all'utente per una sostituzione
                        Sostituzioni(squadraB, panchinaB);
                    }
                    if (cartellinoGialloA[rand] == 2)
                    {
                        //espulsione del giocatore dopo 2 gialli
                        Console.WriteLine("Il giocatore " + rand + " della squadra A ha subito 2 ammonizioni, e per ciò verrà espulso");
                        squadraA[rand] = 0;
                    }
                    else if (cartellinoGialloB[rand] == 2) {
                       
                        Console.WriteLine("Il giocatore " + rand + " della squadra B ha subito 2 ammonizioni, e per ciò verrà espulso");
                        squadraB[rand] = 0;
                    }
                }
                //cartellino rosso
                else if(probabilità <= 22)
                {   
                    int rnd = random.Next(0, 1);
                    int rand = random.Next(1, 11);
                    if(rand == 0)
                    {
                        squadraA[rand] = 0;
                        Console.WriteLine("Il giocatore " + rand + " della squadra A e stato espulso ed ora il suo valore e " + squadraA[rand]);
                        cartellinoRossoA[rand] += 1;

                    }
                    else
                    {
                        squadraB[rand] = 0;
                        Console.WriteLine("Il giocatore " + rand + " della squadra B e stato espulso ed ora il suo valore e " + squadraB[rand]);
                        cartellinoRossoB[rand] += 1;
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
                    if (gol <= probabilitàGolA)
                    {
                        //Gol segnato dalla squadra A
                        a++;

                        Console.WriteLine("Ha segnato la squadra A al minuto " + i + " e il punteggio e: " + a + " per la squadra A e " + b + " per la squadra B");
                        for (int z = 0; z < squadraA.Length; z++)
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
                    //cartellino giallo
                    if (probabilità <= 20)
                    {
                        int rnd = random.Next(0, 1);
                        int rand = random.Next(1, 11);
                        if (rnd == 0)
                        {
                            squadraA[rand] = squadraA[rand] - 5;
                            Console.WriteLine("Il giocatore " + rand + " della squadra A e stato ammonito con un cartellino giallo");
                            cartellinoGialloA[rand] += 1;
                            //richiesta all'utente per una sostituzione
                            Sostituzioni(squadraA, panchinaA);
                        }
                        else
                        {
                            squadraB[rand] = squadraB[rand] - 5;
                            Console.WriteLine("Il giocatore " + rand + " della squadra B e stato ammonito con un cartellino giallo");
                            cartellinoGialloB[rand] += 1;
                            //richiesta all'utente di una sostituzione
                            Sostituzioni(squadraB, panchinaB);
                        }
                        if (cartellinoGialloA[rand] == 2)
                        {
                            //espulsione del giocatore dopo 2 gialli
                            Console.WriteLine("Il giocatore " + rand + " della squadra A ha subito 2 ammonizioni, e per ciò verrà espulso");
                            squadraA[rand] = 0;
                        }
                        else if (cartellinoGialloB[rand] == 2)
                        {

                            Console.WriteLine("Il giocatore " + rand + " della squadra B ha subito 2 ammonizioni, e per ciò verrà espulso");
                            squadraB[rand] = 0;
                        }
                    }
                    // cartellino rosso
                    else if (probabilità <= 22)
                    {
                        int rnd = random.Next(0, 1);
                        int rand = random.Next(1, 11);
                        if (rand == 0)
                        {
                            squadraA[rand] = 0;
                            Console.WriteLine("Il giocatore " + rand + " della squadra A e stato espulso ed ora il suo valore e " + squadraA[rand]);
                            cartellinoRossoA[rand] += 1;

                        }
                        else
                        {
                            squadraB[rand] = 0;
                            Console.WriteLine("Il giocatore " + rand + " della squadra B e stato espulso ed ora il suo valore e " + squadraB[rand]);
                            cartellinoRossoB[rand] += 1;
                        }
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