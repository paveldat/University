using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Verifycation
    {
        public static string GetSHA512Hash(string input) // Хэширует входную строку и возвращает хеш в виде шестнадцатеричной строки из 128 символов
        {
            // Создаем новый экземпляр объекта MD5CryptoServiceProvider.
            SHA512CryptoServiceProvider SHA512Hasher = new SHA512CryptoServiceProvider();

            // Преобразуем входную строку в байтовый массив и вычисляем хеш.
            byte[] data = SHA512Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Создаем новый Stringbuilder для сбора байтов и создания строки.
            StringBuilder sBuilder = new StringBuilder();

            // Перебираем каждый байт хэшированных данных 
            // и форматируем каждый как шестнадцатеричную строку.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Возвращаем шестнадцатеричную строку.
            return sBuilder.ToString();
        }

        public static bool VerifySHA512Hash(string input, string hash) // Проверяет хэш (из базы данных) на соответствие строке (из поля ввода)
        {
            // Хэшируем ввод.
            string hashOfInput = GetSHA512Hash(input);

            // Создаем StringComparer для сравнения хэшей.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            // Сравниваем два хэша.
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true; // Хэши равны.
            }
            else
            {
                return false; // Не равны.
            }
        }
    }
}
