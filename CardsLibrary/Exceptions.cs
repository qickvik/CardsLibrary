using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
    /// <summary>
    /// Ошибка, связанная с некорректными данными в файле
    /// </summary>
    public class ReadingForFileException : Exception
    {
        public ReadingForFileException() { }
        public ReadingForFileException(string message) : base(message)
        {
            Console.WriteLine("ReadingForFileException. Некорректное содержимое в файле");
        }
    }
    /// <summary>
    /// Ошибка, данные не были загружены
    /// </summary>
    public class NoDataUploadedException : Exception
    {
        public NoDataUploadedException() { }
        public NoDataUploadedException(string message) : base(message)
        {
            Console.WriteLine("NoDataUploadedException. Отсутствуют данные в файле");
        }
    }
    /// <summary>
    /// Ошибка, неверное свойство
    /// </summary>
    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException() { }
        public InvalidPropertyException(string message) : base(message)
        {
            Console.WriteLine("InvalidPropertyException. Попытка ввести некорректное свойство");
        }
    }
}
