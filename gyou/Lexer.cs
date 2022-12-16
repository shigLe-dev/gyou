namespace gyou
{
    public class Lexer
    {
        public readonly string code;
        public int currentPosition { get; private set; }
        public char currentChar { get; private set; }
        public char nextChar { get; private set; }

        public Lexer(string code)
        {
            this.code = code;
            ReadChar();
        }

        public Character NextCharacter()
        {
            Character c;

            switch (currentChar)
            {
                case '\n':
                    c = new Character('\n'.ToString(), CharacterType.NEWLINE);
                    break;
                case '\r':
                    if (nextChar == '\n')
                    {
                        c = new Character("\r\n".ToString(), CharacterType.NEWLINE);
                        ReadChar();
                        break;
                    }

                    c = new Character('\r'.ToString(), CharacterType.NEWLINE);
                    break;
                case (char)0:
                    c = new Character(currentChar.ToString(), CharacterType.EOF);
                    break;
                default:
                    c = new Character(currentChar.ToString(), CharacterType.NORMAL);
                    break;
            }

            ReadChar();
            return c;
        }

        private void ReadChar()
        {
            if (currentPosition >= code.Length) currentChar = (char)0;
            else currentChar = code[currentPosition];

            if (currentPosition + 1 >= code.Length) nextChar = (char)0;
            else nextChar = code[currentPosition + 1];

            currentPosition++;
        }
    }
}
