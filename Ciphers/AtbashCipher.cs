using System.Linq;

namespace Ciphers
{
    // Шифр работает с символами русского и английского алфавитов
    // путем замены символа на "симметричный" элемент в алфавите
    public class AtbashCipher : Alphabets
    {
        // Шифрование текста
        public string Encrypt(string text)
            => AtbashFunc(text);

        // Дешифрование текста
        public string Decrypt(string text)
            => AtbashFunc(text);

        // Метод для шифрования / дешифрования текста
        private string AtbashFunc(string text)
        {
            string NewText = "";
            for (int i = 0; i < text.Length; i++)
            {
                char symb = text[i];
                if (RUalfabet.IndexOf(symb) != -1)  // Символ из русского алфавита
                    NewText += RUalfabet.Reverse().ElementAt(RUalfabet.IndexOf(symb)).ToString();
                else if (RUalfabetUp.IndexOf(symb) != -1) // Заглавный символ из русского алфавита
                    NewText += RUalfabetUp.Reverse().ElementAt(RUalfabetUp.IndexOf(symb)).ToString();
                else if (ENalfabet.IndexOf(symb) != -1) // Символ из английского алфавита
                    NewText += ENalfabet.Reverse().ElementAt(ENalfabet.IndexOf(symb)).ToString();
                else if (ENalfabetUp.IndexOf(symb) != -1) // Заглавный символ из английского алфавита
                    NewText += ENalfabetUp.Reverse().ElementAt(ENalfabetUp.IndexOf(symb)).ToString();
                else
                    NewText += symb.ToString(); // Символ не из обозначенных алфавитов
            }

            return NewText;
        }
    }
}
