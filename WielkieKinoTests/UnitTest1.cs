using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Dane
{
    [TestClass()]
    public class MetodyPomocniczeTests
    {
        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            int rzad = 8;
            int miejsce = 10;
            bool result;
            result = MetodyPomocnicze.CzyMoznaKupicBilet(SkladDanych.Bilety, SkladDanych.Seanse[0], rzad, miejsce);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            DateTime data = new DateTime(2019, 1, 20, 16, 00, 00);
            bool result;
            result = MetodyPomocnicze.CzyMoznaDodacSeans(SkladDanych.Seanse, SkladDanych.Sale[0], SkladDanych.Filmy[1], data);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            bool result = false;
            if(MetodyPomocnicze.LiczbaWolnychMiejscWSali(SkladDanych.Bilety, SkladDanych.Seanse[0]) == 72)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            bool result = false;
            if (MetodyPomocnicze.CalkowitePrzychodyZBiletow(SkladDanych.Bilety) == 400.0)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }
    }
}