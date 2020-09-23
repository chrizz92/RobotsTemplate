/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class:
 *--------------------------------------------------------------
 *              Name:
 *--------------------------------------------------------------
 * Description:
 *
 *--------------------------------------------------------------
*/

using System;
using System.Text;

namespace Robots
{
    public class DrivingRobot : Robot
    {
        public DrivingRobot(string name, double power, double maxSpeed) : base(name, power)
        {
            _maxSpeed = maxSpeed;
        }

        private double _maxSpeed;

        public double MaxSpeed
        {
            get { return _maxSpeed; }
        }

        //public void DrivingRobot_ToString_ShouldReturnCorrectOutput()
        //{
        //    DrivingRobot drivingRobot = new DrivingRobot("FunCar 17", 3.6, 17.88);
        //    string text = drivingRobot.ToString();
        //    Assert.AreEqual("Ich heiße FunCar 17, habe 3,60 W Leistung, bin ein Roboter auf Rädern und fahre maximal 17,88 km/H", drivingRobot.ToString());
        //}
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Ich heiße ");
            outputString.Append(Name);
            outputString.Append(", habe ");
            outputString.Append($"{Power:.00}");
            outputString.Append(" W Leistung, bin ein Roboter auf Rädern und fahre maximal ");
            outputString.Append($"{MaxSpeed:.00}");
            outputString.Append(" km/H");
            base.BuildString(this);
            return outputString.ToString();
        }
    }
}