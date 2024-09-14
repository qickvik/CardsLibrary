using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace CardsLibrary
{
    public class Base : IEnumerable<Cards>, IPrintSort
    {
        SortedSet<Cards> decks;
        public Base() { decks = new SortedSet<Cards>(); }
        public Base(IEnumerable<Cards> st)
        { decks = new SortedSet<Cards>(st); }
        public IEnumerator<Cards> GetEnumerator()
        { return decks.GetEnumerator(); }
        /// <summary>
        /// Вывод всех данных
        /// </summary>
        public void PrintBaseList()
        {
            Console.WriteLine("BASE LIST:");
            foreach (var deck in decks)
            {
                Console.WriteLine(deck.ToString());
            }
        }
        IEnumerator IEnumerable.GetEnumerator() { return decks.GetEnumerator(); }
        /// <summary>
        /// Добавление элемента
        /// </summary>
        public void AddDeck(Cards deck)
        { decks.Add(deck); }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        public void RemoveDeck(Cards deck)
        { decks.Remove(deck); }
        /// <summary>
        /// Наличие элемента
        /// </summary>
        public bool ContainsDeck(Cards deck)
        { return decks.Contains(deck); }
        /// <summary>
        /// Удаление всех элементов
        /// </summary>
        public void ClearBase()
        { decks.Clear(); }
        public void ReverseBase()
        { decks.Reverse(); }
        public void SortedDigits()
        {
            Cards[] massiv = decks.ToArray();
            Array.Sort(massiv);
            decks = new SortedSet<Cards>(massiv, new DigitsComparer());
        }
        public void SortedName() //переделать
        {
            Cards[] massiv = decks.ToArray();
            Array.Sort(massiv);
            decks = new SortedSet<Cards>(massiv);
        }
        public void LoadFromFile(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                bool isnymeric = int.TryParse(sr.ReadLine(), out int n);
                if (isnymeric)
                {
                    Base decks = new Base();
                    for (int i = 0; i < n; i++)
                    {
                        string[] str = sr.ReadLine().Split(new char[] { '|' });
                        if (str[0] == "playing cards")
                            decks.AddDeck(new Play(str[1], str[2], str[3], str[4], str[5], str[6]));

                        if (str[0] == "divination cards")
                            decks.AddDeck(new Divination(str[1], str[2], str[3], str[4], str[5], str[6]));

                        if (str[0] == "tarot")
                            decks.AddDeck(new Tarot(str[1], str[2], str[3], str[4], str[5], str[6], str[7], int.Parse(str[8])));
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string[] Print()
        {
            string[] result = new string[decks.Count];
            int index = 0;
            foreach (var deck in decks)
            {
                result[index++] = deck.ToString();
            }
            return result;
        }
        public void SortByString() //Сортирует по цифрам
        {
            if (decks.Count > 0)
            {
                Cards[] massiv = decks.ToArray();
                Array.Sort(massiv);
                decks = new SortedSet<Cards>(massiv, new DigitsComparer());
            }
            else
            {
                throw new InvalidOperationException("The container is empty");
            }
        }
        public void SortByInt()
        {
            if (decks.Count > 0)
            {
                throw new InvalidOperationException("This list does not support sorting by numeric field");
            }
            else
            {
                throw new InvalidOperationException("The container is empty");
            }
        }
    }
}
