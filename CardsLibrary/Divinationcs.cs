using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
    public class Divination : Cards
    {
        #region Fields
        /// <summary>
        /// Период жизни, которые рассматривается при гадании
        /// </summary>
        private string periodoflife;
        /// <summary>
        /// Сфера жизнедеятельности, на которую гадают
        /// </summary>
        private string sphere;
        /// <summary>
        /// Дизайн карт: классические или тематические
        /// </summary>
        private string design;
        #endregion

        #region Properties
        /// <summary>
        /// Период жизни, которые рассматривается при гадании
        /// </summary>
        public string Periodoflife
        {
            get { return periodoflife; }
            set
            {
                if (value == "present" || value == "past" || value == "future") periodoflife = value;
                else
                {
                    periodoflife = "unknown";
                    throw new InvalidPropertyException("Вы можете выбрать из: present, past, future");
                }
            }
        }
        /// <summary>
        /// Сфера жизнедеятельности, на которую гадают
        /// </summary>
        public string Sphere
        {
            get { return sphere; }
            set
            {
                if (value == "love" || value == "career" || value == "finance") sphere = value;
                else
                {
                    sphere = "unknown";
                    throw new InvalidPropertyException("Вы можете выбрать из: love, career, finance, psyhology");
                }
            }
        }
        /// <summary>
        /// Дизайн карт: классические или тематические
        /// </summary>
        public string Design
        {
            get { return design; }
            set
            {
                if (value == "classic" || value == "thematic") design = value;
                else
                {
                    design = "unknown";
                    throw new InvalidPropertyException("Вы можете выбрать из: classic, thematic");
                }
            }
        }
        #endregion

        #region Constructors
        public Divination() { }
        public Divination(string name, string material, string digits, string periodoflife, string sphere, string design)
            : base(name, material, digits)
        {
            Periodoflife = periodoflife;
            Sphere = sphere;
            Design = design;
        }
        #endregion

        #region Methods
        public override void Usage()
        {
            Console.WriteLine("these cards are used for divination");
        }
        public override void PrintData()
        {
            base.PrintData();
            Console.WriteLine($"period of life: {Periodoflife}");
            Console.WriteLine($"sphere: {Sphere}");
            Console.WriteLine($"design: {Design}");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return String.Format($"divination cards|{Name}|{Material}|{Digits}|{Periodoflife}|{Sphere}|{Design}");
        }
        #endregion
    }
}
