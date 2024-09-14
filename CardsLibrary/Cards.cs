namespace CardsLibrary
{
    public class DigitsComparer : IComparer<Cards>
    {
        int IComparer<Cards>.Compare(Cards? x, Cards? y)
        {
            if (x.Digits == y.Digits)
                return x.Name.CompareTo(y.Name);
            return x.Digits.CompareTo(y.Digits);
        }
    }
    /// <summary>
    /// Колода карт
    /// </summary>
    public abstract class Cards : IComparable<Cards>
    {
        #region Fields
        /// <summary>
        /// Наименование колоды карт
        /// </summary>
        private string name;
        /// <summary>
        /// Материал карт
        /// </summary>
        private string material;
        /// <summary>
        /// Дизайн цифр на картах
        /// </summary>
        private string digits;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (value != "") name = value;
                else
                {
                    name = "unknown";
                    throw new InvalidPropertyException("У колоды должно быть имя");
                }
            }
        }
        /// <summary>
        /// Материал карт
        /// </summary>
        public string Material
        {
            get { return material; }
            set
            {
                if (value == "paperboard" || value == "plastic") material = value;
                else
                {
                    material = "unknown";
                    throw new InvalidPropertyException("Вы можете выбрать из: paperboard, plastic");
                }
            }
        }
        /// <summary>
        /// Дизайн цифр на картах
        /// </summary>
        public string Digits
        {
            get { return digits; }
            set
            {
                if (value == "roman" || value == "arabic" || value == "without") digits = value;
                else
                {
                    digits = "unknown";
                    throw new InvalidPropertyException("Вы можете выбрать из: roman, arabic, without");
                }
            }
        }
        #endregion

        #region Constructors
        public Cards() { }
        public Cards(string name, string material, string digits)
        {
            Name = name;
            Material = material;
            Digits = digits;
        }
        public Cards(string name) : this(name, "unknown", "unknown") { }
        #endregion

        #region Methods
        /// <summary>
        /// Сравнение элементов по наименованию колод
        /// </summary>
        public int CompareTo(Cards other)
        {
            return Name.CompareTo(other.name);
        }
        /// <summary>
        /// Для чего используются карты
        /// </summary>
        public abstract void Usage();
        /// <summary>
        /// Вывод данных списком
        /// </summary>
        public virtual void PrintData()
        {
            Console.WriteLine("\nINFORMATION ABOUT CARDS");
            Console.WriteLine("name: {0}", Name);
            Console.WriteLine("material: {0}", Material);
            Console.WriteLine("digits: {0}", Digits);
        }
        /// <summary>
        /// Вывод данных в строку
        /// </summary>
        public override string ToString()
        {
            return String.Format($"cards|{Name}|{Material}|{Digits}");
        }
        public override bool Equals(object obj)
        {
            if (obj is Cards)
            {
                return material == ((Cards)obj).material;
            }
            else
                return false;
        }
        public static bool operator ==(Cards a, Cards b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Cards a, Cards b)
        {
            return !a.Equals(b);
        }
        #endregion

    }
}