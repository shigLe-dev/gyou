using System.Diagnostics;
using System.Text;

namespace gyou
{
    internal class Program
    {
        int width;
        int height;
        int textXPosition;
        int textYPosition;
        ConsoleKeyInfo key;
        Text text;

        Program()
        {
            text = new Text(@"using System.Text;

namespace gyou
{
    internal class Programああああ
    {🤣ああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        int width;
        int height;
        int textXPosition;
        int textYPosition;
        ConsoleKeyInfo key;
        Text text;

        Program()
        {
            text = new Text();
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
                    char c = text.GetChar(x + textXPosition, y + textYPosition);
                    c = Text.IsNewLineChar(c) ? ' ' : c;
                    builder.Append(c);
                }
            }
            Console.Write(builder.ToString());
        }

        void ProcessKeyPress()
        {
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    textXPosition++;
                    break;
                case ConsoleKey.LeftArrow:
                    textXPosition--;
                    textXPosition = textXPosition < 0 ? 0 : textXPosition;
                    break;
                case ConsoleKey.UpArrow:
                    textYPosition--;
                    textYPosition = textYPosition < 0 ? 0 : textYPosition;
                    break;
                case ConsoleKey.DownArrow:
                    textYPosition++;
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args) { Program program = new Program(); }
    }
}
");
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
            Console.OutputEncoding = Encoding.UTF8;
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
                    Character c = text.GetCharacter(x + textXPosition, y + textYPosition);
                    x += c.width - 1;
                    if (x >= width)
                    {
                        builder.Append(' ');
                        continue;
                    }
                    builder.Append(c.ToString());
                }
            }
            Console.Write(builder.ToString());
        }

        void ProcessKeyPress()
        {
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    textXPosition++;
                    break;
                case ConsoleKey.LeftArrow:
                    textXPosition--;
                    textXPosition = textXPosition < 0 ? 0 : textXPosition;
                    break;
                case ConsoleKey.UpArrow:
                    textYPosition--;
                    textYPosition = textYPosition < 0 ? 0 : textYPosition;
                    break;
                case ConsoleKey.DownArrow:
                    textYPosition++;
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args) { Program program = new Program(); }
    }
}
