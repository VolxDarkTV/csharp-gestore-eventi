using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {
        private string titolo;
        private DateOnly data;
        private int capienzaMassima;

        public string Titolo 
        {
            get 
            {
                return this.titolo;
            }
            set
            {
                if (this.titolo != "" || this.titolo != null)
                    this.titolo = value;
                else
                    throw new ArgumentNullException("Il titolo non può essere vuoto!");
            } 
        }
        public DateOnly Data 
        {
            get 
            {
                return this.data;
            }
            set 
            {
                if(value >= DateOnly.FromDateTime(DateTime.Now))
                {
                    this.data = value;
                }
                else
                {
                    throw new Exception("La data dev'essere al presente o futura!");
                }
                
            } 
        }
        public int CapienzaMassima 
        {
            get
            {
                return this.capienzaMassima;
                
            } 
            set 
            {
                this.capienzaMassima = value;
            }
        }
        public int PostiPrenotati { get; set; }

        //Constructor
        public Evento(string titolo, DateOnly data, int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            CapienzaMassima = capienzaMassima;
            PostiPrenotati = 0;
        }

        //Methods
        public int PrenotaPosti(int postiPrenotati)
        {
            if(PostiPrenotati >= 0)
            {
                PostiPrenotati = PostiPrenotati + postiPrenotati;
                return PostiPrenotati;
            }
            else if (CapienzaMassima == 0)
            {
                throw new Exception("Non ci sono posti!");
            }
            else if(CapienzaMassima - PostiPrenotati < 0)
            {
                throw new Exception("I posti sono terminati!");
            }
            else if (Data < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception("La data è Passata...");
            }
            else 
            {
                throw new Exception("Qualcosa è andato storto!");
            }
        }

        public int DisdiciPosti(int disdiciPosti)
        {
            if(PostiPrenotati > 0)
            {
                int nPosti = CapienzaMassima - PostiPrenotati;

                CapienzaMassima = nPosti + disdiciPosti;

                PostiPrenotati = PostiPrenotati - disdiciPosti;

                return PostiPrenotati;
            }
            else if (PostiPrenotati <= 0)
            {
                throw new Exception("Non ci sono abbastanza posti da disdire!");
            }
            else if (Data < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception("La data è Passata...");
            }
            else
            {
                throw new Exception("Qualcosa è andato storto!");
            }
        }

        public static string DateFormatting(string dataInput)
        {
            DateOnly data = DateOnly.Parse(dataInput);
            return data.ToString("dd-MM-yyyy");
        }


    }
}
