namespace Ciphers
{
    // Шифр работает с использованием операции исключительной дизъюнкции:
    // по заданному паролю кодируется каждый символ текста.
    // Работает для любых алфавитов
    public class XORcipher
    {
        // Шифрование текста по заданному паролю
        public string Encrypt(string text, string password)
            => XORfunc(text, password);

        // Расшифровка текста с помощью указанного пароля
        public string Decrypt(string text, string password)
            => XORfunc(text, password);

        // Генерация ключа шифрования по заданному паролю
        private string GenerRepeatKey(string password, int len)
        {
            string str = password;
            while (str.Length < len)
                str += str;

            return str.Substring(0, len);
        }

        // Метод, осуществляющий шифрование / дешифрование текста по заданному паролю
        // Возвращает преобразованный текст
        private string XORfunc(string text, string password)
        {
            string Key = GenerRepeatKey(password, text.Length);
            string NewText = "";
            for (int i = 0; i < text.Length; i++)
                NewText += ((char)(text[i] ^ Key[i])).ToString();

            return NewText;
        }
    }
}
