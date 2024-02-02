using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BED5EsercizioSettimanale
{
    // inizializzazione classe e attributi
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set;}
        public string DataNascita { get; set;}
        public string CodiceFiscale { get; set;}
        public char Sesso { get; set;}
        public string ComuneResidenza { get; set;}
        public double RedditoAnnuale { get; set;}

        public bool Continue { get; set; }

        // metodo inserimento dati che si occupa di far inserire i dati necessari all'utente
        // tutti i campi da riempire eseguono il controllo sulla compilazione. Se un campo viene lasciato vuoto viene mostrato un messaggio di errore
        public void inserimentoDati()
        {
            Console.WriteLine("==========INSERIMENTO DATI AGENZIA DELLE ENTRATE==========");
            Console.WriteLine("\n Compila i vari campi e premi INVIO per confermare.");
            Console.WriteLine("\n Inserire nome");

            do
            {
                string nameChoice = Console.ReadLine();
                if (nameChoice == "")
                {
                    Console.WriteLine("Assicurati di aver inserito il nome e riprova.");
                }
                else
                {
                    Nome = nameChoice.ToUpper();
                    break;

                }
            } while (true);


            Console.WriteLine("\n Inserire cognome");

            do
            {
                string surnameChoice = Console.ReadLine();
                if (surnameChoice == "")
                {
                    Console.WriteLine("Assicurati di aver inserito il cognome e riprova.");
                }
                else
                {
                    Cognome = surnameChoice.ToUpper();
                    break;

                }
            } while (true);


            Console.WriteLine("\n Inserire data di nascita (gg/mm/aaaa)");

            do
            {
                string birthChoice = Console.ReadLine();
                if (birthChoice == "")
                {
                    Console.WriteLine("Assicurati di aver inserito la data di nascita e riprova.");
                }
                else
                {
                    DataNascita = birthChoice.ToUpper();
                    break;

                }
            } while (true);


            Console.WriteLine("\n Inserire codice fiscale");

            do
            {
                string CFChoice = Console.ReadLine();
                if (CFChoice == "")
                {
                    Console.WriteLine("Assicurati di aver inserito il codice fiscale e riprova.");
                }
                else
                {
                    CodiceFiscale = CFChoice.ToUpper();
                    break;

                }
            } while (true);

            // controllo diverso dagli altri. Si assicura che il tasto premuto sia m o f. In tutti gli altri casi viene mostrato un messaggio di errore.
            Console.WriteLine("\n Inserire Sesso (M o F)");
      
        do
        {
            string sexChoice = Console.ReadLine();

            if (sexChoice.ToUpper() == "M" || sexChoice.ToUpper() == "F")
            {
                Sesso = sexChoice.ToUpper()[0];
                break; 
            }
            else
            {
                Console.WriteLine("Input non valido. Inserisci solo M o F:");
            }

        } while (true);

            Console.WriteLine("\n Inserire comune residenza");

            do
            {
                string CRChoice = Console.ReadLine();
                if (CRChoice == "")
                {
                    Console.WriteLine("Assicurati di aver inserito il comune di residenza e riprova.");
                }
                else
                {
                    ComuneResidenza = CRChoice.ToUpper();
                    break;

                }
            } while (true);

            // altro controllo diverso dagli altri: se viene inserita qualsiasi cosa che non sia un numero maggiore di zero viene mostrato un messaggio di errore in console.
            Console.WriteLine("\n Inserire reddito annuale");

        do
        { 
            string inputReddito = Console.ReadLine();
                
            if (double.TryParse(inputReddito, out double numero) && numero >= 0)
            {
                        
                RedditoAnnuale = numero;
                    break;
            }
            else
            {

                Console.WriteLine("Input non valido. Inserisci solo numeri maggiori di 0.");
            }

        } while(true);
            calcoloAliquotaFiscale();
            
        }

        /*In questo metodo viene mostrato un riepilogo dei dati inseriti all'utente.
         Inoltre con una serie di if else vengono gestiti i vari calcoli per le aliquote da effettuare a seconda del reddito annuale inserito.*/
        public void calcoloAliquotaFiscale()
        {
            Console.Clear();
            Console.WriteLine("==========CALCOLO DELL'IMPOSTA DA VERSARE==========");
            Console.WriteLine($"\n Contribuente: \t{Nome} {Cognome}");
            Console.WriteLine($"\n Nato il: \t{DataNascita} ({Sesso})");
            Console.WriteLine($"\n Residente in: \t{ComuneResidenza}");
            Console.WriteLine($"\n Codice Fiscale: \t{CodiceFiscale}");
            Console.WriteLine($"\n Reddito Dichiarato: \t{RedditoAnnuale}");



            if (RedditoAnnuale <= 15000)
            {
                Console.WriteLine($"\n IMPOSTA DA VERSARE: \t{(RedditoAnnuale * 23) / 100}");
                Console.WriteLine("\n Premi INVIO per uscire dal programma.");
                Console.ReadLine();
            }
            else if (RedditoAnnuale >= 15001 && RedditoAnnuale <= 28000)
            {
                Console.WriteLine($"\n IMPOSTA DA VERSARE: \t{((RedditoAnnuale - 15000) * 27 / 100) + 3450}");
                Console.WriteLine("\n Premi INVIO per uscire dal programma.");
                Console.ReadLine();
            }           
            else if (RedditoAnnuale >= 28001 && RedditoAnnuale <= 55000)
            {
                Console.WriteLine($"\n IMPOSTA DA VERSARE: \t{((RedditoAnnuale - 28000) * 38 / 100) + 6960}");
                Console.WriteLine("\n Premi INVIO per uscire dal programma.");
                Console.ReadLine();
            }            
            else if (RedditoAnnuale >= 55001 && RedditoAnnuale <= 75000)
            {
                Console.WriteLine($"\n IMPOSTA DA VERSARE: \t{((RedditoAnnuale - 55000) * 41 / 100) + 17220}");
                Console.WriteLine("\n Premi INVIO per uscire dal programma.");
                Console.ReadLine();
            }            
            else if (RedditoAnnuale >= 75001)
            {
                Console.WriteLine($"\n IMPOSTA DA VERSARE: \t{((RedditoAnnuale - 75000) * 43 / 100) + 25420}");
                Console.WriteLine("\n Premi INVIO per uscire dal programma.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Si è verificato un errore nell'inserimento dei dati. Prego riprovare.");
                System.Threading.Thread.Sleep(6000);
                inserimentoDati();
                
            }
        }
    }
}
