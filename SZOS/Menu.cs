using System;
using System.Linq;

namespace SZOS
{
    class Menu
    {
        private string[] _elementsMenu = new string[0];
        private string[] _elementsMethods = new string[0];


        private int LongestString { get; set; }

        public void Configure(string[] elementsMenu)
        {
            if (_elementsMenu != null && elementsMenu.Length > 0)
            {
                this._elementsMenu = elementsMenu;
            }

            LongestString = elementsMenu.Max(w => w.Length);
        }

        /// <summary>
        /// Wyświetla Menu
        /// </summary>
        /// <returns>Zwraca numer wybranego zadania licząc od 0. Jeśli wciśnięty ESC zwraca -1.</returns>
        public int Open()
        {
            int choice = 0;
            ConsoleKeyInfo button;

            Console.CursorVisible = false;

            do
            {
                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < _elementsMenu.Length; i++)
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(_elementsMenu[i].PadRight(LongestString));
                }

                button = Console.ReadKey(intercept: true);

                if (button.Key == ConsoleKey.DownArrow && choice < _elementsMenu.Length - 1)
                {
                    choice++;
                }
                else if (button.Key == ConsoleKey.UpArrow && choice > 0)
                {
                    choice--;
                }

                if (button.Key == ConsoleKey.Escape)
                {
                    choice -= 1;
                }

            } while (button.Key != ConsoleKey.Enter && button.Key != ConsoleKey.Escape);

            Console.CursorVisible = true;
            Console.ResetColor();
            return choice;
        }

        public void MethodsWriteLineElementColor(string[] elementsMethod)
        {
            if (_elementsMethods != null && elementsMethod.Length > 0)
            {
                this._elementsMethods = elementsMethod;
            }

            LongestString = elementsMethod.Max(l => l.Length);

            for (int i = 0; i < _elementsMethods.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(_elementsMethods[i].PadRight(LongestString));
            }
        }
    }
}
