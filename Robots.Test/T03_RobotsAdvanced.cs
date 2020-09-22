using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robots.Test
{
    [TestClass]
    public class T03_RobotsAdvanced
    {
        [TestMethod()]
        public void Robots_Filter_EmptyFilter_ShouldReturnAll()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            Robot[] filteredRobots = robots.GetByFilter("");
            Assert.AreEqual(3, filteredRobots.Length, "Länge des Arrays stimmt nicht");
            Assert.AreEqual("FunCar", filteredRobots[0].Name, "Roboter an Position 0 wurde falsch zurückgegeben");
            Assert.AreEqual("Drone", filteredRobots[1].Name, "Roboter an Position 1 wurde falsch zurückgegeben");
            Assert.AreEqual("Mower", filteredRobots[2].Name, "Roboter an Position 2 wurde falsch zurückgegeben");
        }

        [TestMethod()]
        public void Robots_Filter_NotMatchingFilter_ShouldReturnNone()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            Robot[] filteredRobots = robots.GetByFilter("Terminator");
            Assert.AreEqual(0, filteredRobots.Length, "Länge des Arrays stimmt nicht");
        }

        [TestMethod()]
        public void Robots_Filter_UpperCase_ShouldReturnCorrectResult()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            Robot[] filteredRobots = robots.GetByFilter("MOWER");
            Assert.AreEqual(1, filteredRobots.Length, "Länge des Arrays stimmt nicht");
            Assert.AreEqual("Mower", filteredRobots[0].Name, "Name des gefilterten Roboters stimmt nicht");
        }

        [TestMethod()]
        public void Robots_Filter_SpecialCharactersAndNumber_ShouldReturnCorrectResult()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            Mower mower = new Mower("Mower1", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            Robot[] filteredRobots = robots.GetByFilter("_____1");
            Assert.AreEqual(2, filteredRobots.Length, "Länge des Arrays stimmt nicht");
            Assert.AreEqual("Drone1", filteredRobots[0].Name, "Name des gefilterten Roboters stimmt nicht");
            Assert.AreEqual("Mower1", filteredRobots[1].Name, "Name des gefilterten Roboters stimmt nicht");
        }

        [TestMethod()]
        public void Robots_Filter_ManySpecialCharacters_ShouldReturnCorrectResult()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            Mower mower2 = new Mower("Mower2", 8.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            ok = robots.AddRobot(mower2);
            Robot[] filteredRobots = robots.GetByFilter("M+)*$");
            Assert.AreEqual(2, filteredRobots.Length, "Länge des Arrays stimmt nicht");
            Assert.AreEqual("Mower2", filteredRobots[0].Name, "Name des gefilterten Roboters stimmt nicht");
            Assert.AreEqual("Mower", filteredRobots[1].Name, "Name des gefilterten Roboters stimmt nicht");
        }

        [TestMethod()]
        public void Robots_OperatorPlus_BothListsEmpty_ShouldBeEmptyUnion()
        {
            Robots robots1 = new Robots();
            Robots robots2 = new Robots();
            Robots union = robots1 + robots2;
            Assert.AreEqual(0, union.Count, "Anzahl Roboter sollte null sein.");
        }

        [TestMethod()]
        public void Robots_OperatorPlus_OneListEmpty_ShouldBeCorrectUnion()
        {
            Robots robots1 = new Robots();
            Robots robots2 = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            bool ok = robots1.AddRobot(mower);
            ok = robots1.AddRobot(dron);
            Robots union = robots1 + robots2;
            Assert.AreEqual(2, union.Count, "Anzahl Roboter nicht korrekt.");
            Assert.AreEqual("Drone", union.GetAt(0).Name, "Roboter an Position 1 wurde falsch zurückgegeben");
            Assert.AreEqual("Mower", union.GetAt(1).Name, "Roboter an Position 3 wurde falsch zurückgegeben");
        }

        [TestMethod()]
        public void Robots_OperatorPlus_FourRobots_ShouldBeCorrectUnion()
        {
            Robots robots1 = new Robots();
            Robots robots2 = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            Mower mower2 = new Mower("Mower2", 8.3, 1.2, 250);
            bool ok = robots1.AddRobot(mower);
            ok = robots1.AddRobot(dron);
            ok = robots2.AddRobot(funCar);
            ok = robots2.AddRobot(mower2);
            Robots union = robots1 + robots2;
            Assert.AreEqual(4, union.Count, "Anzahl Roboter nicht korrekt.");
            Assert.AreEqual("FunCar", union.GetAt(0).Name, "Roboter an Position 0 wurde falsch zurückgegeben");
            Assert.AreEqual("Drone", union.GetAt(1).Name, "Roboter an Position 1 wurde falsch zurückgegeben");
            Assert.AreEqual("Mower2", union.GetAt(2).Name, "Roboter an Position 2 wurde falsch zurückgegeben");
            Assert.AreEqual("Mower", union.GetAt(3).Name, "Roboter an Position 3 wurde falsch zurückgegeben");
        }

        [TestMethod()]
        public void Robots_OperatorPlus_DuplicateRobots_ShouldNotAddDuplicate()
        {
            Robots robots1 = new Robots();
            Robots robots2 = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            Mower mower2 = new Mower("Mower2", 8.3, 1.2, 250);
            Drone dron2 = new Drone("Drone", 10.5, 100.5);
            bool ok = robots1.AddRobot(mower);
            ok = robots1.AddRobot(dron);
            ok = robots1.AddRobot(funCar);
            ok = robots2.AddRobot(mower2);
            ok = robots2.AddRobot(dron2);
            Robots union = robots1 + robots2;
            Assert.AreEqual(4, union.Count, "Dron2 ist doppelt und wurde nicht übernommen");
            Assert.AreEqual("FunCar", union.GetAt(0).Name, "Roboter an Position 0 wurde falsch zurückgegeben");
            Assert.AreEqual("Drone", union.GetAt(1).Name, "Roboter an Position 1 wurde falsch zurückgegeben");
            Assert.AreEqual("Mower2", union.GetAt(2).Name, "Roboter an Position 2 wurde falsch zurückgegeben");
            Assert.AreEqual("Mower", union.GetAt(3).Name, "Roboter an Position 3 wurde falsch zurückgegeben");
        }
    }
}
