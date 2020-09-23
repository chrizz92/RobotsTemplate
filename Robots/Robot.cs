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

namespace Robots
{
    public abstract class Robot
    {
        private string _name;
        private double _power;

        public Robot(string name, double power)
        {
            _name = name;
            Power = power;
        }

        public double Power
        {
            get
            {
                return _power;
            }
            private set
            {
                if (value < 0.0)
                {
                    _power = 0.0;
                }
                else
                {
                    _power = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Berechnet die Prüfsumme über den Namen.
        /// Dabei werden alle Buchstaben (a-z, A-Z) mit der Differenz zu a oder A berechnet (a=0, b=1, c=2, ...A=0, B=1,...)
        /// Etwaig vorkommende Ziffern werden mit der Differenz zu 0 berechnet.
        /// Andere Zeichen werden ignoriert.
        /// Die sich ergebenden Zahlen werden aufsummiert und als Prüfsumme zurückgegeben.
        /// </summary>
        /// <returns></returns>
        public int CheckSum
        {
            get
            {
                int _checkSum = 0;
                foreach (char character in _name)
                {
                    if (character >= '0' && character <= '9')
                    {
                        _checkSum += Convert.ToInt32(character - '0');
                    }
                    else if (character >= 'a' && character <= 'z')
                    {
                        _checkSum += Convert.ToInt32(character - 'a');
                    }
                    else if (character >= 'A' && character <= 'Z')
                    {
                        _checkSum += Convert.ToInt32(character - 'A');
                    }
                }
                return _checkSum;
            }
        }

        public string BuildString(Robot robot)
        {
            return "x";
        }
    }
}