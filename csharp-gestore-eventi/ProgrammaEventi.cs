using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ProgrammaEventi
    {

        public string Titolo { get; set; }
        public List<Evento> Eventi { get; set; }

        //Constructor
        public ProgrammaEventi(string titolo) 
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        //Methods
        public void AggiungiEvento(Evento nuovoEvento)
        {
            Eventi.Add(nuovoEvento);
        }

        public List<Evento> OttieniEventi(DateOnly date)
        {
            //List<Evento> eventsOnDate = new List<Evento>();
            foreach (Evento evento in Eventi)
            {
                if (evento.Data == date)
                {
                    Eventi.Add(evento);
                }
            }
            return Eventi;
        }

        public static string StampaEventi(List<Evento> listaEventi)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Evento evento in listaEventi)
            {
                sb.AppendLine($"Data: {evento.Data} Titolo: {evento.Titolo}");
            }
            return sb.ToString();
        }

        public int NumeroEventi()
        {
            return Eventi.Count;
        }

        public void SvuotaListaEventi(List<Evento> lista)
        {
            lista.Clear();
        }

        public string RappresentazioneProgramma()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome programma evento: {Titolo}");
            foreach (Evento evento in Eventi)
            {
                sb.AppendLine($"{evento.Data} - {evento.Titolo}");
            }
            return sb.ToString();
        }


    }
}
