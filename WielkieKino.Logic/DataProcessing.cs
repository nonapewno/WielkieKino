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
            int comparison;
            List<Seans> ListaSeansów = (from Seans s in seanse where (comparison = s.Date.CompareTo(data))==0 select s).ToList();
            List<Film> FilmyDanegoDnia = (from Film f in ListaSeansów select f).ToList();

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
            //int comparison;
            //Sala sala = (Sala => { comparison = Sala.Date.CompareTo(data); return Sala; });
            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 
            return null;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {

            // Właściwa odpowiedź: "Konan Destylator"
            return null;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {

            return null;
        }


    }
}
