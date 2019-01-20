using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Logic
{
    /// <summary>
    /// Metody do napisania z wykorzystaniem LINQ (w składni zapytania, wyrażeń
    /// lambda lub mieszanej)
    /// </summary>
    public class DataProcessing
    {
        public static List<string> WybierzFilmyZGatunku(List<Film> filmy, string gatunek)
        {
            List<string> ListaFilmówZGatunku = (from Film f in filmy where f.Gatunek == gatunek select f.Tytul).ToList();
            // Właściwa odpowiedź: np. "Konan Destylator" dla "Fantasy"
            return ListaFilmówZGatunku;
        }

        /// <summary>
        /// Sumujemy wpływy bez względu na datę seansu
        /// </summary>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public static int PodajCalkowiteWplywyZBiletow(List<Bilet> bilety)
        {
            int wpływy = 0;
            wpływy = Convert.ToInt32(bilety.Sum(Bilet => Bilet.Cena));
            // Właściwa odpowiedź: 400
            return wpływy;
        }

        public static List<Film> WybierzFilmyPokazywaneDanegoDnia(List<Seans> seanse, DateTime data)
        {
             List<Film> FilmyDanegoDnia = (from Seans s in seanse
                                           where data.Day == s.Date.Day
                                           select s.Film).ToList();
            // Można dodać descending by usunąć duplikaty

            return FilmyDanegoDnia;
        }

        /// <summary>
        /// Zwraca gatunek, z którego jest najwięcej filmów. Jeśli jest kilka takich
        /// gatunków, to zwraca dowolny z nich.
        /// </summary>
        /// <param name="filmy"></param>
        /// <returns></returns>
        public static string NajpopularniejszyGatunek(List<Film> filmy)
        {
            string PopularnyGatunek;
            PopularnyGatunek = Convert.ToString(filmy.Max(Film => Film.Gatunek));
            // Właściwa odpowiedź: Obyczajowy
            return PopularnyGatunek;
        }

        public static List<Sala> ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(List<Sala> sale)
        {
            List<Sala> SortowanieSalPoLiczbieMiejsc = (from Sala s in sale
                                                       orderby s.LiczbaMiejscWRzedzie * s.LiczbaRzedow
                                                       select s).ToList();
            // Właściwa odpowiedź: Kameralna, Bałtyk, Wisła (lub w odwrotnej kolejności)
            return SortowanieSalPoLiczbieMiejsc;
        }

        public static Sala ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data)
        {
            List<Seans> seanseDlaDaty;
            seanseDlaDaty = (from Seans s in seanse
                             where s.Date.CompareTo(data)==0
                             select s).ToList();

            Sala sala = (from Seans s in seanseDlaDaty
                         group s by s.Sala into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 
            return sala;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public static Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {
            Film film = (from Bilet b in bilety
                         group b by b.Seans.Film into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            // Właściwa odpowiedź: "Konan Destylator"
            return film;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public static List<Film> PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {
            List<Film> FilmyPoDochodach = (from Bilet b in bilety
                         group b by b.Seans.Film into gr
                         orderby gr.Sum(x => x.Cena) descending
                         select gr.Key).ToList();

            return FilmyPoDochodach;
        }


    }
}
