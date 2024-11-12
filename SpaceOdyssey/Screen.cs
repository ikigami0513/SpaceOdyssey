using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceOdyssey
{
    internal class Screen
    {
        public char[][] Display;

        public Screen()
        {
            Display = GetEmptyScreen();
        }

        public static char[][] GetEmptyScreen()
        {
            char[][] display = new char[Settings.SCREEN_HEIGHT][];
            for (int i = 0; i < Settings.SCREEN_HEIGHT; i++)
            {
                display[i] = new char[Settings.SCREEN_WIDTH];
                for (int j = 0; j < display[i].Length; j++)
                {
                    display[i][j] = ' ';
                }
            }
            return display;
        }

        public void ResetScreen()
        {
            Console.Clear();
            Display = GetEmptyScreen();
            FillBorder();
        }

        public void FillBorder()
        {
            Display[0][0] = '┌';
            Display[0][Settings.SCREEN_WIDTH - 1] = '┐';
            Display[Settings.SCREEN_HEIGHT - 1][0] = '└';
            Display[Settings.SCREEN_HEIGHT - 1][Settings.SCREEN_WIDTH - 1] = '┘';

            for (int i = 1; i < Settings.SCREEN_WIDTH - 1; i++)
            {
                Display[0][i] = '-';
                Display[Settings.SCREEN_HEIGHT - 1][i] = '-';
            }

            for (int i = 1; i < Settings.SCREEN_HEIGHT - 1; i++)
            {
                Display[i][0] = '|';
                Display[i][Settings.SCREEN_WIDTH - 1] = '|';
            }
        }

        public void AddElements(char[][] elements, int start_x, int start_y)
        {
            for (int y = 0;  y < elements.Length; y++)
            {
                for (int x = 0; x < elements[y].Length; x++)
                {
                    Display[start_y + y][start_x + x] = elements[y][x];
                }
            }
        }

        public void AddElements(string ascii, int start_x, int start_y)
        {
            AddElements(Utils.StringToCharArray2D(ascii), start_x, start_y);
        }

        public void Show()
        {
            foreach (char[] row in Display)
            {
                String line = "";
                foreach(char element in row)
                {
                    line += element;
                }
                Console.WriteLine(line);
            }
        }
    }
}
