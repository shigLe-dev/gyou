using Ansi;
using System.Text;

namespace gyou;

delegate bool KeyEvent();

internal class Program
{
    int width;
    int height;
    int textXPosition;
    int textYPosition;
    int cursorXPosition;
    int cursorYPosition;
    List<KeyEvent> keyEvents;
    ConsoleKeyInfo key;
    Text text;
    Mode mode;

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
        keyEvents = RegisterKeyEvents();
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
        mode = Mode.Normal;
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
                bool isCursor = (x + textXPosition) == cursorXPosition && (y + textYPosition) == cursorYPosition;
                Character c = text.GetCharacter(x + textXPosition, y + textYPosition);
                x += c.width - 1;
                if (x >= width)
                {
                    if (isCursor)
                    {
                        builder.SetBackgroundColor(new AnsiColor(255, 255, 255));
                        builder.SetForegroundColor(new AnsiColor(0, 0, 0));
                        builder.Append(' ');
                        builder.SetBackgroundColor(new AnsiColor(0, 0, 0));
                        builder.SetForegroundColor(new AnsiColor(255, 255, 255));
                    }
                    else
                    {
                        builder.Append(' ');
                    }
                    continue;
                }
                if (isCursor)
                {
                    builder.SetBackgroundColor(new AnsiColor(255, 255, 255));
                    builder.SetForegroundColor(new AnsiColor(0, 0, 0));
                    builder.Append(c.ToString());
                    builder.SetBackgroundColor(new AnsiColor(0, 0, 0));
                    builder.SetForegroundColor(new AnsiColor(255, 255, 255));
                }
                else
                {
                    builder.Append(c.ToString());
                }
            }
        }
        Console.Write(builder.ToString());
    }

    void ProcessKeyPress()
    {
        key = Console.ReadKey(true);

        foreach (var keyEvent in keyEvents)
        {
            // trueの場合は受け流さない
            if (keyEvent.Invoke()) break;
        }
    }

    List<KeyEvent> RegisterKeyEvents()
    {
        return new List<KeyEvent>
        {
            MoveCursor,
            KeyInput
        };
    }

    #region KeyEvents
    bool KeyInput()
    {
        if (mode != Mode.Insert) return false;

        // TODO: 文字入力

        return true;
    }

    bool MoveCursor()
    {
        if (mode != Mode.Insert) return false;

        switch (key.Key)
        {
            case ConsoleKey.RightArrow:
                cursorXPosition++;
                return true;
            case ConsoleKey.LeftArrow:
                cursorXPosition--;
                return true;
            case ConsoleKey.UpArrow:
                cursorYPosition--;
                return true;
            case ConsoleKey.DownArrow:
                cursorYPosition++;
                return true;
            default:
                return false;
        }
    }
    #endregion

    static void Main(string[] args) { Program program = new Program(); }
}
