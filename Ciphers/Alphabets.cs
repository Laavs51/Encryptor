namespace Ciphers
{
    // Класс содержит некоторые константные величины для наследования шифрам,
    // нуждающимся в их наличии
    public abstract class Alphabets
    {
        public const string RUalfabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public const string RUalfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public const string ENalfabet = "abcdefghijklmnopqrstuvwxyz";
        public const string ENalfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const int RUalfabetLen = 33;
        public const int ENalfabetLen = 26;
    }
}
