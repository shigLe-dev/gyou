using Kodnix.Character.Extensions;

namespace gyou
{
    public struct Character
    {
        public readonly string rawSource;
        public readonly CharacterType characterType;
        public readonly int width = 1;

        public Character(string rawSource, CharacterType characterType)
        {
            this.rawSource = rawSource;
            this.characterType = characterType;

            switch (characterType)
            {
                case CharacterType.NORMAL:
                    width = rawSource.GetEastAsianWidthLength();
                    break;
            }
        }

        public override string ToString()
        {
            switch (characterType)
            {
                case CharacterType.NORMAL:
                    return rawSource;
                case CharacterType.NEWLINE:
                    return " ";
                case CharacterType.EOF:
                    return " ";
                default:
                    return " ";
            }
        }
    }
}
