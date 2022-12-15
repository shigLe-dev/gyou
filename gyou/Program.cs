﻿using System.Text;

namespace gyou
{
    internal class Program
    {
        int width;
        int height;

        ConsoleKeyInfo key;
        Text text;

        Program()
        {
            text = new Text("aiueo\nafawfaw");
            Init();

            while (true)
            {
                SetWindowSize();
                RefleshScreen();
                ProcessKeyPress();
            }
        }

        void Init()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        void SetWindowSize()
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;
        }

        void RefleshScreen()
        {
            Console.SetCursorPosition(0, 0);
            StringBuilder builder = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char c = text.GetChar(x, y);
                    c = Text.IsNewLineChar(c) ? ' ' : c;
                    builder.Append(c);
                }
            }
            Console.Write(builder.ToString());
        }

        void ProcessKeyPress()
        {
            key = Console.ReadKey(true);
        }

        static void Main(string[] args) { Program program = new Program(); }
    }
}
