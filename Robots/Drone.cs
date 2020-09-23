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
    public class Drone : Robot
    {
        private double _maxHeight;

        public double MaxHeight
        {
            get { return _maxHeight; }
        }

        public Drone(string name, double power, double maxHeight) : base(name, power)
        {
            _maxHeight = maxHeight;
        }

        //Assert.AreEqual("Ich heiße Drone 1, habe 10,50 W Leistung, bin eine Drohne und fliege maximal 100,55 Meter hoch", dron.ToString());
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Ich heiße ");
            outputString.Append(Name);
            outputString.Append(", habe ");
            outputString.Append($"{Power:.00}");
            outputString.Append(" W Leistung, bin eine Drohne und fliege maximal ");
            outputString.Append($"{MaxHeight:.00}");
            outputString.Append(" Meter hoch");
            return outputString.ToString();
        }
    }
}