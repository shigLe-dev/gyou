using System.Text;

namespace gyou
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int c = 0;
            while (true)
            {
                DateTime start = DateTime.Now;

                int width = Console.WindowWidth;
                int height = Console.WindowHeight;

                while (true) if ((DateTime.Now - start).TotalSeconds >= (1 / 10d)) break;

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        builder.Append((char)((c % 25) + 'a'));
                    }
                }

                Console.Clear();
                Console.Write($"\u001b[0;0f\u001b[j{builder}");
                c++;
            }
        }
    }
}