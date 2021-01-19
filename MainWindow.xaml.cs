using Ciphers;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace PeganovLaba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenDlg = new OpenFileDialog
            {
                Title = "Выберите текстовый файл исходных данных",
                Filter = "Текстовые файлы(*.txt)|*.txt",
                DefaultExt = "txt",
                CheckFileExists = true,
                InitialDirectory = @"PeganovLaba\SomeTests"
            };

            SaveDlg = new SaveFileDialog
            {
                Title = "Выберите текстовый файл исходных данных",
                Filter = "Текстовые файлы(*.txt)|*.txt",
                DefaultExt = "txt",
                CheckFileExists = true,
                InitialDirectory = @"PeganovLaba\SomeTests"
            };

            AtbashCiph = new AtbashCipher();
            CaesarCiph = new CaesarCipher();
            XORciph = new XORcipher();
        }

        private string Data { get; set; }               // Данные, полученные из файла
        private string NewData { get; set; }            // Данные, преобразованные шифрованием
        private OpenFileDialog OpenDlg { get; set; }    // Диалог для открытия файла
        private SaveFileDialog SaveDlg { get; set; }    // Диалог для сохранения файла
        private AtbashCipher AtbashCiph { get; set; }   // Экземпляр класса для ширования по Атбашу
        private CaesarCipher CaesarCiph { get; set; }   // ... по Цезарю
        private XORcipher XORciph { get; set; }         // ... с помощью XOR

        // Метод срабатывает при выборе Шифра Цезаря
        // Отключает ввод пароля для XOR
        private void CaesChoice_Click(object sender, RoutedEventArgs e)
        {
            CaesKeyLabel.IsEnabled = true;
            CaesKey.IsEnabled = true;
            XorKeyLabel.IsEnabled = false;
            XorKey.IsEnabled = false;
        }

        // ... при выборе Шифра XOR
        // Отключает ввод ключа для Шифра Цезаря
        private void XorChoice_Click(object sender, RoutedEventArgs e)
        {
            CaesKeyLabel.IsEnabled = false;
            CaesKey.IsEnabled = false;
            XorKeyLabel.IsEnabled = true;
            XorKey.IsEnabled = true;
        }

        // ... при выборе Шифра Атбаша
        // Отключает поля ввода для вышеупомянутых шифров
        private void AtbashChoice_Click(object sender, RoutedEventArgs e)
        {
            CaesKeyLabel.IsEnabled = false;
            CaesKey.IsEnabled = false;
            XorKeyLabel.IsEnabled = false;
            XorKey.IsEnabled = false;
        }

        // Метод открывает диалог для открытия файла и получения исходных данных
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";
            OpenDlg.ShowDialog();

            if (OpenDlg.FileName != "")
            {
                try
                {
                    using (StreamReader sr = new StreamReader(OpenDlg.FileName))
                    {
                        Data = sr.ReadToEnd();
                        InBox.Items.Clear();
                        InBox.Items.Add(Data);
                    }
                    NewData = "";
                    OutBox.Items.Clear();
                }
                catch (Exception)
                {
                    ErrorLabel.Content = "Ошибка при открытии файла!";
                }
            }
        }

        // Метод открывает диалог для открытия файла и сохранения в него преобразованных данных
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";
            SaveDlg.ShowDialog();

            if (SaveDlg.FileName != "")
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(SaveDlg.FileName))
                        sw.WriteLine(NewData);
                }
                catch (Exception)
                {
                    ErrorLabel.Content = "Ошибка при записи в файл!";
                }
            }

        }

        // Метод анализирует выбранные значения в программе и в зависимости от них
        // при помощи созданных экземпляров классов преобразовывает текст согласно их функциям и введенным значениям
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";

            if (Data == null) // Не был открыт файл исходных данных
                ErrorLabel.Content = "Введите исходные данные!";
            else
            {
                if ((bool)CaesChoice.IsChecked) // Выбран Шифр Цезаря
                {
                    if (CaesKey.Text == null || CaesKey.Text == "")
                        ErrorLabel.Content = "Введите пароль шифрования!";
                    else
                    {
                        try
                        {
                            NewData = (bool)EncryptChoice.IsChecked ? CaesarCiph.Encrypt(Data, int.Parse(CaesKey.Text)) :
                            CaesarCiph.Decrypt(Data, int.Parse(CaesKey.Text));
                        }
                        catch (Exception)
                        {
                            ErrorLabel.Content = "Неверный формат ввода ключа!";
                        }
                    }
                }
                else if ((bool)XorChoice.IsChecked)     // Выбран Шифр XOR
                {
                    if (XorKey.Text == null || XorKey.Text == "")
                        ErrorLabel.Content = "Введите пароль шифрования!";
                    else
                        NewData = (bool)EncryptChoice.IsChecked ? XORciph.Encrypt(Data, XorKey.Text) :
                            XORciph.Decrypt(Data, XorKey.Text);
                }
                else  // Выбран Шифр Атбаша
                    NewData = (bool)EncryptChoice.IsChecked ? AtbashCiph.Encrypt(Data) : AtbashCiph.Decrypt(Data);

                OutBox.Items.Clear();
                OutBox.Items.Add(NewData);
            }
        }
    }
}
