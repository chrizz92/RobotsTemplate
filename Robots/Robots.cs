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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt den Roboter an der Position zurück.
        /// Ist die Position ungültig, wird null zurückgegeben
        /// </summary>
        /// <param name="position"></param>
        /// <returns>Roboter an der Position oder null, falls Position nicht existiert</returns>
        public Robot GetAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ermittelt die Gesamtsumme der Leistung aller Roboter in der Liste
        /// </summary>
        /// <returns>Gesamtsummer der Leistung</returns>
        public double GetSumOfPower()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Summe der mähbaren Fläche aller Mähroboter
        /// </summary>
        /// <returns>Mähbare Gesamtfläche</returns>
        public double GetSumOfArea()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Die beiden Roboterschwärme werden zusammengelegt
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Robots operator +(Robots a, Robots b)
        {
            throw new NotImplementedException();
        }
    }
}