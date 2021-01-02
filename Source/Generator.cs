using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSWDGenerator
{
    class Generator
    {
        public string[] GenPasswd(int pswdnum, int pswdlen)
        {

            Random rand = new Random();
            char[] chpass = new char[]
            {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', //Это массив с нашим словарём из каких букв, чисел, знаков будет составлен пароль.
            'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '+', '-', '/', '*', '!', '&', '$', '#', '?', '=', '@', '<', '>'
            };

            string onepswd = "";
            string[] pswds = new string[pswdnum];

            for (int x = 0; x < pswdnum; x++) //Цикл для количества паролей
            {

                for (int y = 0; y < pswdlen; y++) //Цикл для генерации длины пароля
                {
                    char goingA = chpass[rand.Next(74)];
                    string goingB = Convert.ToString(goingA);
                    onepswd = onepswd + goingB;
                }
                pswds[x] = onepswd;
                onepswd = "";
            }
            return pswds;
        }
    }
}
