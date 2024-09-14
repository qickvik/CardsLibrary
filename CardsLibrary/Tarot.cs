using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
    public class Tarot : Divination
    {
        #region Fields
        /// <summary>
        /// Разновидность карт Таро
        /// </summary>
        public string tittle;
        /// <summary>
        /// Количество пустых карт
        /// </summary>
        private int ecard;
        #endregion

        #region Properties
        public int Ecard
        {
            get { return ecard; }
            set
            {
                if (value >= 0 && value <= 2) ecard = value;
                else
                {
                    ecard = 0;
                    throw new InvalidPropertyException("Вы можете выбрать из: 0, 1, 2");
                }
            }
        }
        #endregion

        #region Constructors
        public Tarot() { }
        public Tarot(string name, string material, string digits, string periodoflife, string sphere, string design, string tittle, int ecard)
            : base(name, material, digits, periodoflife, sphere, design)
        {
            this.tittle = tittle;
            Ecard = ecard;
        }
        #endregion

        #region Methods
        public override void Usage()
        {
            Console.WriteLine($"{tittle} tarot cards are needed to consider the {Periodoflife} in the sphere of {Sphere}");
        }
        public override void PrintData()
        {
            base.PrintData();
            Console.WriteLine($"tittle: {tittle}");
            Console.WriteLine($"empty card: {Ecard}");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return String.Format($"tarot|{Name}|{Material}|{Digits}|{Periodoflife}|{Sphere}|{Design}|{tittle}|{Ecard}");
        }
        /// <summary>
        /// Расклад на одной карте
        /// </summary>
        public void LayoutOneCard()
        {
            string[] DeckTarotCards = File.ReadAllLines("tarot cards.txt");
            Random random = new Random();
            Console.WriteLine("A card has fallen to your question:");
            int rndplay = random.Next(0, DeckTarotCards.Length);
            Console.WriteLine("- " + DeckTarotCards[rndplay].ToString());
        }
        /// <summary>
        /// Расклад на трех картах
        /// </summary>
        public void LayoutThreeCards()
        {
            string[] DeckTarotCards = File.ReadAllLines("tarot cards.txt");
            Random random = new Random();
            Console.WriteLine("The cards fell out to your question:");
            for (int i = 0; i < 3; i++)
            {
                int rndplay = random.Next(0, DeckTarotCards.Length);
                Console.WriteLine("- " + DeckTarotCards[rndplay].ToString());
            }
        }
        #endregion
    }
}
