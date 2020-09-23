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
    public class Mower : DrivingRobot
    {
        private double _maxArea;

        public double MaxArea
        {
            get { return _maxArea; }
        }

        public Mower(string name, double power, double maxSpeed, double maxArea) : base(name, power, maxSpeed)
        {
            _maxArea = maxArea;
        }

        //Assert.AreEqual("Ich heiße Husquarna 350 und kann maximal 100,55 m² Rasen mit 1,7 km/H mähen", mower.ToString());
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Ich heiße ");
            outputString.Append(Name);
            outputString.Append(" und kann maximal ");
            outputString.Append($"{MaxArea:.00}");
            outputString.Append(" m² Rasen mit ");
            outputString.Append($"{MaxSpeed:.0}");
            outputString.Append(" km/H mähen");
            base.BuildString();
            return outputString.ToString();
        }
    }
}