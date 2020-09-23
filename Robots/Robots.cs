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
using System.Collections.Generic;

namespace Robots
{
    public class Robots
    {
        private List<Robot> _listOfRobots;

        public Robots()
        {
            _listOfRobots = new List<Robot>();
        }

        /// <summary>
        /// Ermittelt die Anzahl an Robotern in der Liste
        /// </summary>
        public int Count
        {
            get
            {
                return _listOfRobots.Count;
            }
        }

        /// <summary>
        /// Fügt den Roboter zur Liste sortiert nach der Leistung hinzu (höchste Leistung zuerst).
        /// Existiert bereits ein Roboter mit dem Namen, wird er nicht eingefügt und false
        /// zurückgegeben
        /// </summary>
        /// <param name="insertRobot"></param>
        /// <returns>Wurde der Roboter eingefügt?</returns>
        public bool AddRobot(Robot robot)
        {
            int index = 0;
            if (Count == 0)
            {
                _listOfRobots.Add(robot);
                return true;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (_listOfRobots[i].Name.Equals(robot.Name))
                    {
                        return false;
                    }
                    if (_listOfRobots[i].Power < robot.Power)
                    {
                        break;
                    }
                    index = i + 1;
                }
                _listOfRobots.Insert(index, robot);
                return true;
            }
        }

        /// <summary>
        /// Gibt den Roboter an der Position zurück.
        /// Ist die Position ungültig, wird null zurückgegeben
        /// </summary>
        /// <param name="position"></param>
        /// <returns>Roboter an der Position oder null, falls Position nicht existiert</returns>
        public Robot GetAt(int index)
        {
            if (index >= Count || index < 0)
            {
                return null;
            }
            else
            {
                return _listOfRobots[index];
            }
        }

        /// <summary>
        /// Ermittelt die Gesamtsumme der Leistung aller Roboter in der Liste
        /// </summary>
        /// <returns>Gesamtsummer der Leistung</returns>
        public double GetSumOfPower()
        {
            double sumOfPower = 0.0;
            foreach (Robot robot in _listOfRobots)
            {
                sumOfPower += robot.Power;
            }
            return sumOfPower;
        }

        /// <summary>
        /// Summe der mähbaren Fläche aller Mähroboter
        /// </summary>
        /// <returns>Mähbare Gesamtfläche</returns>
        public double GetSumOfArea()
        {
            double sumOfArea = 0.0;
            foreach (Robot robot in _listOfRobots)
            {
                if (robot is Mower)
                {
                    sumOfArea += (robot as Mower).MaxArea;
                }
            }
            return sumOfArea;
        }

        /// <summary>
        /// Gibt alle Roboter der Liste als Array zurück,
        /// die dem Filterkriterium entsprechen.
        /// Groß-/Klein-Schreibung ist egal, Sonderzeichen werden ignoriert.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Ergebnis als Array</returns>
        public Robot[] GetByFilter(string filter)
        {
            if (filter.Equals(""))
            {
                return _listOfRobots.ToArray();
            }
            else
            {
                Robots filteredRobots = new Robots();
                foreach (Robot robot in _listOfRobots)
                {
                    if (robot.Name.StartsWith(filter[0]))
                    {
                        filteredRobots.AddRobot(robot);
                    }
                    else
                    {
                        for (int i = 1; i < filter.Length; i++)
                        {
                            if (filter[i] >= '0' && filter[i] <= '9')
                            {
                                if (robot.Name.Contains(filter[i]))
                                {
                                    filteredRobots.AddRobot(robot);
                                }
                            }
                        }
                    }
                }
                return filteredRobots._listOfRobots.ToArray();
            }
        }

        /// <summary>
        /// Die Liste der Roboter wird als Text zurückgegeben.
        /// Die erste Zeile enthält Anzahl und Gesamtleistung.
        /// Die zweite Zeile enthält die zu mähende Gesamtfläche, wenn ein Mähroboter in der Liste ist.
        /// Die folgenden Zeilen enthalten die Infos der einzelnen Roboter.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            //expected.AppendLine("Die Liste enthält 3 Roboter mit einer Gesamtleistung von 50,3 Watt");
            //expected.AppendLine("Die maximal zu mähende Rasenfläche beträgt 250 m²");
            //expected.AppendLine("Ich heiße FunCar, habe 33,50 W Leistung, bin ein Roboter auf Rädern und fahre maximal 55,50 km/H");
            //expected.AppendLine("Ich heiße Drone, habe 10,50 W Leistung, bin eine Drohne und fliege maximal 100,50 Meter hoch");
            //expected.AppendLine("Ich heiße Mower und kann maximal 250,00 m² Rasen mit 1,2 km/H mähen");
            stringBuilder.AppendLine($"Die Liste enthält {Count} Roboter mit einer Gesamtleistung von {GetSumOfPower()} Watt");
            double sumOfArea = GetSumOfArea();
            if (sumOfArea > 0.0)
            {
                stringBuilder.AppendLine($"Die maximal zu mähende Rasenfläche beträgt {sumOfArea} m²");
            }
            foreach (Robot robot in _listOfRobots)
            {
                if (robot is DrivingRobot)
                {
                    stringBuilder.AppendLine((robot as DrivingRobot).ToString());
                }
                else if (robot is Mower)
                {
                    stringBuilder.AppendLine((robot as Mower).ToString());
                }
                else if (robot is Drone)
                {
                    stringBuilder.AppendLine((robot as Drone).ToString());
                }
                else
                {
                    stringBuilder.AppendLine(robot.ToString());
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Die beiden Roboterschwärme werden zusammengelegt
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Robots operator +(Robots a, Robots b)
        {
            Robots robots = new Robots();
            for (int i = 0; i < b.Count; i++)
            {
                robots.AddRobot(b.GetAt(i));
            }
            for (int j = 0; j < a.Count; j++)
            {
                robots.AddRobot(a.GetAt(j));
            }
            return robots;
        }
    }
}