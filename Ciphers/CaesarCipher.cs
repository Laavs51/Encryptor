namespace Ciphers
{
    // Шифр сдвигает буквы русского и английского алфавитов
    // на заданное значение key вперед при шифровании
    // и на -key при дешифровании
    public class CaesarCipher : Alphabets
    {
        // Шифрование текста по заданному ключу (сдвигу по алфавиту)
        public string Encrypt(string text, int key)
            => CaesFunc(text, key);

        // Дешифрование текста по заданному ключу (сдвигу по алфавиту)
        public string Decrypt(string text, int key)
            => CaesFunc(text, -key);

        // Метод для шифрования / дешифрования текста по заданному ключу
        private string CaesFunc(string text, int key)
        {
            string NewText = "";
            for (int i = 0; i < text.Length; i++)
            {
                char symb = text[i];
                if (RUalfabet.IndexOf(symb) != -1)  // Символ из русского алфавита
                    NewText += RUalfabet[(RUalfabetLen + RUalfabet.IndexOf(symb) + key) % RUalfabetLen];
                else if (RUalfabetUp.IndexOf(symb) != -1) // Заглавный символ из русского алфавита
                    NewText += RUalfabetUp[(RUalfabetLen + RUalfabetUp.IndexOf(symb) + key) % RUalfabetLen];
                else if (ENalfabet.IndexOf(symb) != -1)  // Символ из английского алфавита
                    NewText += ENalfabet[(ENalfabetLen + ENalfabet.IndexOf(symb) + key) % ENalfabetLen];
                else if (ENalfabetUp.IndexOf(symb) != -1)    // Заглавный символ из английского алфавита
                    NewText += ENalfabetUp[(ENalfabetLen + ENalfabetUp.IndexOf(symb) + key) % ENalfabetLen];
                else
                    NewText += symb.ToString(); // Символ не из обозначенных алфавитов
            }

            return NewText;
        }
    }
}
