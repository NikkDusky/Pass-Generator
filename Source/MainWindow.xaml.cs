using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PSWDGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Generator generator = new Generator();


            string readnum = TextBox1.Text;           //Записываем количество паролей из формы в переменную
            if (String.IsNullOrEmpty(TextBox1.Text))  //Проверяем пустая строка или нет?
            {
                TextBox1.Clear();
                TextBox1.AppendText("");
                readnum = "-1";
            }

            int pnum = 0;
            try
            {
                pnum = Convert.ToInt32(readnum);      //Конвертируем количество паролей в int
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число, ты переполняешь мою память\n(〃∇〃 )");
                TextBox1.Clear();
            }


            string readlen = TextBox2.Text;           //Записываем длину паролей из формы в переменную
            if (String.IsNullOrEmpty(TextBox2.Text))  //Проверяем пустая строка или нет?
            {
                TextBox2.Clear();
                TextBox2.AppendText("");
                readlen = "-1";
            }

            int plength = 0;
            try
            {
                plength = Convert.ToInt32(readlen);   //Конвертируем длину паролей в int
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число, ты переполняешь мою память\n(〃∇〃 )");
                TextBox2.Clear();
            }

            //
            // Генерация паролей
            //
            richBoxText1.Clear(); //Очищаем box


            if (Convert.ToBoolean(checkbox1.IsChecked))                       //Проверка checkbox'a
            {
                for (int y = 0; y < pnum; y++)                                //Цикл работающий по количеству паролей
                {
                    richBoxText1.AppendText(y + 1 + ") ");                    //Добавляем нумерацию
                    string[] pswdsexit = generator.GenPasswd(pnum, plength);  //Вызываем генератор
                    string pswdsConverted = Convert.ToString(pswdsexit[y]);   //Конвертируем 1 пароль из массива в строчное
                    richBoxText1.AppendText(pswdsConverted);                  //Выводим 1 пароль
                    richBoxText1.Text += Environment.NewLine;                 //Переходим на новую строку
                }
            }
            else
            {
                for (int y = 0; y < pnum; y++)                                //Цикл работающий по количеству паролей
                {
                    string[] pswdsexit = generator.GenPasswd(pnum, plength);  //Вызываем генератор
                    string pswdsConverted = Convert.ToString(pswdsexit[y]);   //Конвертируем 1 пароль из массива в строчное
                    richBoxText1.AppendText(pswdsConverted);                  //Выводим 1 пароль
                    richBoxText1.Text += Environment.NewLine;                 //Переходим на новую строку
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            richBoxText1.Clear();                                             //Просто кнопка для очистки ¯\_(ツ)_/¯
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)         //Тут происходит проверка на ввод букв, если буквы, то ругаемся!
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("В данном поле разрешены только цифры (╯°□°）╯┻━┻");
                TextBox1.Clear();
            }
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)         //Аналогично на второй TextBox, тоже проверяем и ругаемся!
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TextBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("В данном поле разрешены только цифры (╯°□°）╯┻━┻");
                TextBox2.Clear();
            }
        }

        private void richBoxText1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void checkbox2_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
