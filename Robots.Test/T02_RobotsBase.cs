using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robots.Test
{
    [TestClass]
    public class T02_RobotsBase
    {
        [TestMethod()]
        public void Robots_Add_OneRobot_ShouldBeAdded()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            bool ok = robots.AddRobot(dron);
            Assert.IsTrue(ok);
            Robot robot = robots.GetAt(0);
            Assert.AreEqual("Drone", robot.Name, "Roboter an Position 0 wurde falsch zurückgegeben");
        }

        [TestMethod()]
        public void Robots_GetAt_TooHighIndex_ShouldReturnNull()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250.22);
            bool ok = robots.AddRobot(dron);
            ok = robots.AddRobot(mower);
            Robot robot = robots.GetAt(2);
            Assert.IsNull(robot, "Roboter an zu hohem Index sollte null sein.");
        }

        [TestMethod()]
        public void Robots_GetAt_NegativeIndex_ShouldReturnNull()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250.22);
            bool ok = robots.AddRobot(dron);
            ok = robots.AddRobot(mower);
            Robot robot = robots.GetAt(-1);
            Assert.IsNull(robot, "Roboter an negativem Index sollte null sein.");
        }

        [TestMethod()]
        public void Robots_Add_TwoRobotsInCorrectOrder_ShouldBeCorrectOrder()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            bool ok = robots.AddRobot(dron);
            ok = robots.AddRobot(mower);
            Assert.IsTrue(ok);
            Robot robot = robots.GetAt(0);
            Assert.AreEqual("Drone", robot.Name, "Roboter an Position 0 wurde falsch zurückgegeben");
            robot = robots.GetAt(1);
            Assert.AreEqual("Mower", robot.Name, "Roboter an Position 1 wurde falsch zurückgegeben");
        }

        [TestMethod()]
        public void Robots_Add_TwoRobotsInWrongOrder_ShouldBeCorrectOrder()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            Assert.IsTrue(ok);
            Robot robot = robots.GetAt(0);
            Assert.AreEqual("Drone", robot.Name, "Roboter an Position 0 wurde falsch zurückgegeben");
            robot = robots.GetAt(1);
            Assert.AreEqual("Mower", robot.Name, "Roboter an Position 1 wurde falsch zurückgegeben");
        }

        [TestMethod()]
        public void Robots_Add_ThreeRobotsInWrongOrder_ShouldBeCorrectOrder()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            Assert.IsTrue(ok);
            Robot robot = robots.GetAt(0);
            Assert.AreEqual("FunCar", robot.Name, "Roboter an Position 0 wurde falsch zurückgegeben");
            robot = robots.GetAt(1);
            Assert.AreEqual("Drone", robot.Name, "Roboter an Position 1 wurde falsch zurückgegeben");
            robot = robots.GetAt(2);
            Assert.AreEqual("Mower", robot.Name, "Roboter an Position 2 wurde falsch zurückgegeben");
        }

        [TestMethod()]
        public void Robots_Add_WithSameName_ShouldNotAddDuplicate()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            Mower mower2 = new Mower("Mower", 4.3, 1.7, 200);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            ok = robots.AddRobot(mower2);
            Assert.IsFalse(ok, "Der Name Mower existiert bereits");
        }

        [TestMethod()]
        public void Robots_GetSumOfPower_NoRobots_ShouldReturnZeroPower()
        {
            Robots robots = new Robots();
            double sumOfPower = robots.GetSumOfPower();
            Assert.AreEqual(0, sumOfPower, 0.001, "Summe der Leistung stimmt nicht");
        }

        [TestMethod()]
        public void Robots_GetSumOfPower_OneRobot_ShouldReturnCorrectPower()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            bool ok = robots.AddRobot(dron);
            double sumOfPower = robots.GetSumOfPower();
            Assert.AreEqual(10.5, sumOfPower, 0.001, "Summe der Leistung stimmt nicht");
        }

        [TestMethod()]
        public void Robots_GetSumOfPower_FourRobots_ShouldReturnCorrectPower()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.5, 1.2, 250);
            Mower mower2 = new Mower("Mower2", 8.3, 1.2, 255.5);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            ok = robots.AddRobot(mower2);
            double sumOfPower = robots.GetSumOfPower();
            Assert.AreEqual(58.8, sumOfPower, 0.001, "Summe der Leistung stimmt nicht");
        }

        [TestMethod()]
        public void Robots_GetSumOfArea_NoRobots_ShouldReturnEmptyArea()
        {
            Robots robots = new Robots();
            double sumOfArea = robots.GetSumOfArea();
            Assert.AreEqual(0, sumOfArea, 0.001, "Summe der mähbaren Fläche stimmt nicht");
        }

        [TestMethod()]
        public void Robots_GetSumOfArea_FourRobots_ShouldReturnCorrectArea()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250.22);
            Mower mower2 = new Mower("Mower2", 8.3, 1.2, 255.5);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            ok = robots.AddRobot(mower2);
            double sumOfArea = robots.GetSumOfArea();
            Assert.AreEqual(505.72, sumOfArea, 0.001, "Summe der mähbaren Fläche stimmt nicht");
        }

        [TestMethod()]
        public void Robots_GetSumOfArea_NoMowers_ShouldReturnEmptyArea()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone1", 10.5, 100.5);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            double sumOfArea = robots.GetSumOfArea();
            Assert.AreEqual(0, sumOfArea, 0.001, "Summe der mähbaren Fläche stimmt nicht");
        }

        [TestMethod()]
        public void Robots_ToString_NoRobot_ShouldReturnCorrectOutput()
        {
            Robots robots = new Robots();
            string text = robots.ToString();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Die Liste enthält 0 Roboter mit einer Gesamtleistung von 0 Watt");
            Assert.AreEqual(expected.ToString(), text, "ToString() liefert falsches Ergebnis");
        }

        [TestMethod()]
        public void Robots_ToString_OneRobot_ShouldReturnCorrectOutput()
        {
            Robots robots = new Robots();
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(funCar);
            string text = robots.ToString();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Die Liste enthält 1 Roboter mit einer Gesamtleistung von 33,5 Watt");
            expected.AppendLine("Ich heiße FunCar, habe 33,50 W Leistung, bin ein Roboter auf Rädern und fahre maximal 55,50 km/H");
            Assert.AreEqual(expected.ToString(), text, "ToString() liefert falsches Ergebnis");
        }

        [TestMethod()]
        public void Robots_ToString_ThreeRobots_ShouldReturnCorrectOutput()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            Mower mower = new Mower("Mower", 6.3, 1.2, 250);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(mower);
            ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            string text = robots.ToString();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Die Liste enthält 3 Roboter mit einer Gesamtleistung von 50,3 Watt");
            expected.AppendLine("Die maximal zu mähende Rasenfläche beträgt 250 m²");
            expected.AppendLine("Ich heiße FunCar, habe 33,50 W Leistung, bin ein Roboter auf Rädern und fahre maximal 55,50 km/H");
            expected.AppendLine("Ich heiße Drone, habe 10,50 W Leistung, bin eine Drohne und fliege maximal 100,50 Meter hoch");
            expected.AppendLine("Ich heiße Mower und kann maximal 250,00 m² Rasen mit 1,2 km/H mähen");
            Assert.AreEqual(expected.ToString(), text, "ToString() liefert falsches Ergebnis");
        }

        [TestMethod()]
        public void Robots_ToString_NoMower_ShouldNotReturnMowingLine()
        {
            Robots robots = new Robots();
            Drone dron = new Drone("Drone", 10.5, 100.5);
            DrivingRobot funCar = new DrivingRobot("FunCar", 33.5, 55.5);
            bool ok = robots.AddRobot(dron);
            ok = robots.AddRobot(funCar);
            string text = robots.ToString();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Die Liste enthält 2 Roboter mit einer Gesamtleistung von 44 Watt");
            expected.AppendLine("Ich heiße FunCar, habe 33,50 W Leistung, bin ein Roboter auf Rädern und fahre maximal 55,50 km/H");
            expected.AppendLine("Ich heiße Drone, habe 10,50 W Leistung, bin eine Drohne und fliege maximal 100,50 Meter hoch");
            Assert.AreEqual(expected.ToString(), text, "ToString() liefert falsches Ergebnis");
        }
    }
}
