using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
    /// <summary>
    /// Игральная колода карт
    /// </summary>
    public class Play : Cards
    {
        #region Fields
        /// <summary>
        /// Количество карт в колоде
        /// </summary>
        private string count;
        /// <summary>
        /// Страна, в которой разработан дизайн колоды
        /// </summary>
        public string country;
        /// <summary>
        /// Являются ли карты коллекционными
        /// </summary>
        private string collectible;
        #endregion

        #region Properties
        /// <summary>
        /// Количество карт в колоде
        /// </summary>
        public string Count
        {
            get { return count; }
            set
            {
                if (value == "24" || value == "32" || value == "36" || value == "52" || value == "54") count = value;
                else
                {
                    count = "unknown";
                    throw new InvalidPropertyException("Вы можете выбрать из: 24, 32, 36, 52, 54");
                }
            }
        }
        /// <summary>
        /// Являются ли карты коллекционными
        /// </summary>
        public string Collectible
        {
            get { return collectible; }
            set
            {
                if (value == "yes" || value == "no") collectible = value;
                else
                {
                    collectible = "unknown";
                    throw new InvalidPropertyException("Вы можете выбрать из: yes, no");
                }
            }
        }
        #endregion

        #region Constructors
        public Play() { }
        public Play(string name, string material, string digits, string count, string country, string collectible)
            : base(name, material, digits)
        {
            Count = count;
            this.country = country;
            Collectible = collectible;
        }
        #endregion

        #region Methods
        public override void Usage()
        {
            Console.WriteLine("these cards are used for games");
        }
        public override void PrintData()
        {
            base.PrintData();
            Console.WriteLine($"count: {Count}");
            Console.WriteLine($"country: {country}");
            Console.WriteLine($"collectible: {Collectible}");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return String.Format($"playing cards|{Name}|{Material}|{Digits}|{Count}|{country}|{Collectible}");
        }
        #endregion
    }
}
