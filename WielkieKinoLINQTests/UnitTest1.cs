using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Logic;
using WielkieKino.Dane;
using System.Collections.Generic;

namespace WielkieKinoLINQTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WybierzFilmyZGatunkuTest()
        {
            bool result = false;
            string gatunek = "Fantasy";
            if (DataProcessing.WybierzFilmyZGatunku(SkladDanych.Filmy, gatunek).Count == 1)
            {
                result = true;
            }
            Assert.IsTrue(result);
            result = false;
            List<string> FilmyZGatunku = DataProcessing.WybierzFilmyZGatunku(SkladDanych.Filmy, gatunek);
            if (FilmyZGatunku[0] == "Konan Destylator")
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PodajCalkowiteWplywyZBiletowTest()
        {
            bool result = false;
            if (DataProcessing.PodajCalkowiteWplywyZBiletow(SkladDanych.Bilety) == 400.00)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WybierzFilmyPokazywaneDanegoDniaTest()
        {
            bool result = false;
            DateTime data = new DateTime(2019, 1, 20, 16, 00, 00);
            if (DataProcessing.WybierzFilmyPokazywaneDanegoDnia(SkladDanych.Seanse, data).Count == 6)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NajpopularniejszyGatunekTest()
        {
            bool result = false;
            if(DataProcessing.NajpopularniejszyGatunek(SkladDanych.Filmy) == "Obyczajowy")
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ZwrocSalePosortowanePoCalkowitejLiczbieMiejscTest()
        {
            bool result = false;
            if(DataProcessing.ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(SkladDanych.Sale)[0].Nazwa == "Kameralna")
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ZwrocSaleGdzieJestNajwiecejSeansowTest()
        {
            bool result = false;
            //DataProcessing.ZwrocSaleGdzieJestNajwiecejSeansow
            Assert.IsTrue(result);
        }
    }
}
