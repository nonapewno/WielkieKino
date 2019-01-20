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
            Assert.Fail();
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            Assert.Fail();
        }
    }
}