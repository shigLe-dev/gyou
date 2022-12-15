using System.Text;

namespace gyou
{
    internal class Program
    {
        int width;
        int height;
        char c;

        Program()
        {
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
            Console.Clear();
            StringBuilder builder = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    builder.Append(c);
                }
            }
            Console.Write(builder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        void ProcessKeyPress()
        {
            c = Console.ReadKey(false).KeyChar;
        }

        static void Main(string[] args) { Program program = new Program(); }
    }
}