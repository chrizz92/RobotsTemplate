using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Robots.Test
{
    [TestClass]
    public class T01_Robot
    {
        [TestMethod()]
        public void DrivingRobot_Instantiate_CorrectParameters_PropertiesShouldBeCorrect()
        {
            DrivingRobot drivingRobot = new DrivingRobot("FunCar 17", 3.6, 17.88);
            Assert.AreEqual("FunCar 17", drivingRobot.Name);
            Assert.AreEqual(3.6, drivingRobot.Power, 0.001);
            Assert.AreEqual(17.88, drivingRobot.MaxSpeed, 0.001);
        }

        [TestMethod()]
        public void DrivingRobot_Instantiate_IncorrectPower_PropertiesShouldBeCorrect()
        {
            DrivingRobot drivingRobot = new DrivingRobot("FunCar 17", -1, 17.88);
            Assert.AreEqual("FunCar 17", drivingRobot.Name);
            Assert.AreEqual(0, drivingRobot.Power, 0.001);
            Assert.AreEqual(17.88, drivingRobot.MaxSpeed, 0.001);
        }

        [TestMethod()]
        public void DrivingRobot_Instantiate_ShouldInheritRobot()
        {
            DrivingRobot drivingRobot = new DrivingRobot("FunCar 17", 3.6, 17.88);
            Assert.IsInstanceOfType(drivingRobot, typeof(Robot), "DrivingRobot erbt nicht von Robot");
        }

        [TestMethod()]
        public void DrivingRobot_ToString_ShouldReturnCorrectOutput()
        {
            DrivingRobot drivingRobot = new DrivingRobot("FunCar 17", 3.6, 17.88);
            string text = drivingRobot.ToString();
            Assert.AreEqual("Ich heiﬂe FunCar 17, habe 3,60 W Leistung, bin ein Roboter auf R‰dern und fahre maximal 17,88 km/H", drivingRobot.ToString());
        }

        [TestMethod()]
        public void Drone_Instantiate_CorrectParameters_PropertiesShouldBeCorrect()
        {
            Drone dron = new Drone("Drone 1", 10.5, 100.55);
            Assert.AreEqual("Drone 1", dron.Name);
            Assert.AreEqual(10.5, dron.Power, 0.001);
            Assert.AreEqual(100.55, dron.MaxHeight, 0.001);
        }

        [TestMethod()]
        public void Drone_Instantiate_IncorrectPower_PropertiesShouldBeCorrect()
        {
            Drone dron = new Drone("Drone 1", -99, 100.55);
            Assert.AreEqual("Drone 1", dron.Name);
            Assert.AreEqual(0, dron.Power, 0.001);
            Assert.AreEqual(100.55, dron.MaxHeight, 0.001);
        }

        [TestMethod()]
        public void Drone_Instantiate_ShouldInheritRobot()
        {
            Drone dron = new Drone("Drone 1", 10.5, 100.55);
            Assert.IsInstanceOfType(dron, typeof(Robot), "Drone erbt nicht von Robot");
        }

        [TestMethod()]
        public void Drone_ToString_ShouldReturnCorrectOutput()
        {
            Drone dron = new Drone("Drone 1", 10.5, 100.55);
            string text = dron.ToString();
            Assert.AreEqual("Ich heiﬂe Drone 1, habe 10,50 W Leistung, bin eine Drohne und fliege maximal 100,55 Meter hoch", dron.ToString());
        }

        [TestMethod()]
        public void Mower_Instantiate_CorrectParameters_PropertiesShouldBeCorrect()
        {
            Mower mower = new Mower("Husquarna 350", 10.5, 1.7, 100.55);
            Assert.AreEqual("Husquarna 350", mower.Name);
            Assert.AreEqual(10.5, mower.Power, 0.001);
            Assert.AreEqual(1.7, mower.MaxSpeed, 0.001);
            Assert.AreEqual(100.55, mower.MaxArea, 0.001);
        }

        [TestMethod()]
        public void Mower_Instantiate_IncorrectPower_PropertiesShouldBeCorrect()
        {
            Mower mower = new Mower("Husquarna 350", -34, 1.7, 100.55);
            Assert.AreEqual("Husquarna 350", mower.Name);
            Assert.AreEqual(0, mower.Power, 0.001);
            Assert.AreEqual(1.7, mower.MaxSpeed, 0.001);
            Assert.AreEqual(100.55, mower.MaxArea, 0.001);
        }

        [TestMethod()]
        public void Mower_Instantiate_ShouldInheritRobot()
        {
            Mower mower = new Mower("Husquarna 350", 10.5, 1.7, 100.55);
            Assert.IsInstanceOfType(mower, typeof(Robot), "Drone erbt nicht von Robot");
        }

        [TestMethod()]
        public void Mower_Instantiate_ShouldInheritDrivingRobot()
        {
            Mower mower = new Mower("Husquarna 350", 10.5, 1.7, 100.55);
            Assert.IsInstanceOfType(mower, typeof(DrivingRobot), "Drone erbt nicht von DrivingRobot");
        }

        [TestMethod()]
        public void Mower_ToString_ShouldReturnCorrectOutput()
        {
            Mower mower = new Mower("Husquarna 350", 10.5, 1.7, 100.55);
            string text = mower.ToString();
            Assert.AreEqual("Ich heiﬂe Husquarna 350 und kann maximal 100,55 m≤ Rasen mit 1,7 km/H m‰hen", mower.ToString());
        }
    }
}
