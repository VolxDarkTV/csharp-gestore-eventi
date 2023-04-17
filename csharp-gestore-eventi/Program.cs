namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool error = false;

            while (!error)
            {
                try
                {
                    //Titolo
                    Console.Write("Inserisci il Nome dell'evento: ");
                    string titolo = Console.ReadLine();

                    //Data
                    Console.Write("Inserisci la Data dell'evento (dd/mm/yyyy): ");

                    string dateInput = Console.ReadLine();
                    DateOnly data = DateOnly.Parse(dateInput);
                    string dateString = data.ToString("dd-MM-yyyy");

                    //Capienza massima
                    Console.Write("Inserisci la Capienza Massima: ");
                    int capienza = Convert.ToInt32(Console.ReadLine());

                 

                    Evento evento = new Evento(titolo, data, capienza);
                    Console.WriteLine(evento.CapienzaMassima);

                    //PostiPrenotati
                    Console.WriteLine("Quanti posti desideri prenotare?");
                    int postiPrenotatiInput = evento.PrenotaPosti(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine(evento.PostiPrenotati);

                    //S/N
                    Console.WriteLine("Vuoi disdire dei posti (s/n)?");
                    string risposta = Console.ReadLine();
                    if(risposta.ToLower() == "s")
                    {
                        Console.Write("Quanti posti vuoi disdire: ");
                        evento.DisdiciPosti(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"Posti prenotati: {evento.PostiPrenotati}");
                    }
                    else
                    {
                        Console.WriteLine($"Posti prenotati: {evento.PostiPrenotati}");
                    }


                    Console.WriteLine($"Posti Rimanenti: {evento.CapienzaMassima}");



                    List<Evento> programmaList = new List<Evento>();

                    Console.Write($"Titolo Programma: ");
                    string titoloProgramma = Console.ReadLine();
                    Console.Write($"Quanti Eventi vuoi inserire?");
                    int eventiProgramma = Convert.ToInt32(Console.ReadLine());

                    ProgrammaEventi programmaEventi = new ProgrammaEventi(titoloProgramma);

                    for (int i = 0; i < eventiProgramma; i++)
                    {
                        programmaEventi.AggiungiEvento(programmaEventi);
                    }
    
                    //error = true;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                }catch(InvalidOperationException e)
                {
                    Console.WriteLine(e);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }



        }
    }
}