﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.App
{
    public class Program
    {
        /// <summary>
        /// Na podstawie danych seansu i sprzedanych biletów należy wyświetlić "podgląd"
        /// sali w ten sposób, że: każdy rząd to jedna linia tekstu, znaków w linii
        /// ma być tyle ile miejsc w rzędzie, miejsca zajęte są inaczej oznaczone niż
        /// miejsca wolne.
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        private static void WyswietlPodgladSali(List<Bilet> sprzedaneBilety, Seans seans)
        {
            seans = Dane.SkladDanych.Seanse[0];
            sprzedaneBilety = Dane.SkladDanych.Bilety;
            int jest = 0;
            List<Bilet> sprzedaneBiletySeansu = (from Bilet b in sprzedaneBilety where b.Seans == seans
                                                 select b).ToList();

            for (int i = 0; i <= seans.Sala.LiczbaRzedow;i++)
            {
                for(int j = 0;j <= seans.Sala.LiczbaMiejscWRzedzie;j++)
                {
                    jest = 0;
                    foreach (Bilet bilet in sprzedaneBiletySeansu)
                    {
                        if (bilet.Miejsce == j && bilet.Rzad == i)
                        {
                            Console.Write("X ");
                            jest = 1;
                        }
                    }
                    if(jest == 0)
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Wyświetlony powinien być tytuł filmu, godzina rozpoczęcia, czas trwania
        /// i nazwa sali.
        /// </summary>
        /// <param name="seanse"></param>
        /// <param name="data"></param>
        private static void WyswietlFilmyOGodzinie(List<Seans> seanse, DateTime data)
        {
            seanse = Dane.SkladDanych.Seanse;
            int comparison;

            foreach (Seans seans in seanse)
            {
                
                // Compare today to last year
                if ((comparison = seans.Date.CompareTo(data)) == 0)
                {
                    Console.WriteLine(seans.Film.Tytul + " " + seans.Date.Hour + " " + seans.Film.CzasTrwania + " " + seans.Sala.Nazwa);
                }
    
            }
            //Wskazówka: Do obliczenia czy parametr data "wpada" w film można wykorzystać
            //metodę AddMinutes wykonanej na czasie rozpoczęcia seansu.
        }

        public static void Main(string[] args)
        {
            WyswietlPodgladSali(Dane.SkladDanych.Bilety, Dane.SkladDanych.Seanse[0]);
            /* Przykładowo:
            ----------
            ----------
            ----------
            ----------
            ----ooo---
            ----ooo---
            -----oo---
            ----------
            */
            DateTime data = new DateTime(2019, 1, 20, 14, 00, 00);
            WyswietlFilmyOGodzinie(Dane.SkladDanych.Seanse, data);
            Console.ReadKey();
        }
    }
}
