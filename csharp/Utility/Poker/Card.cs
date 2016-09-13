using System;

namespace csharp.Utility.Poker
{
    public struct Card : IComparable<Card>
    {
        private static readonly int[] Values;
        public const int MaxValue = 14;
        private string _name;

        static Card()
        {
            Values = new int[127];
            for (int i = '2'; i <= '9'; i++)
                Values[i] = i - '2' + 2;
            Values['T'] = 10;
            Values['J'] = 11;
            Values['Q'] = 12;
            Values['K'] = 13;
            Values['A'] = 14;
        }

        public Card(string card)
        {
            Value = Values[card[0]];
            Suit = card[1];
            _name = card;
        }

        public override string ToString()
        {
            return _name;
        }

        public int Value { get; }
        public char Suit { get; }
        public int CompareTo(Card other)
        {
            if (Value < other.Value)
                return -1;
            if (Value > other.Value)
                return 1;
            return 0;
        }
    }
}
