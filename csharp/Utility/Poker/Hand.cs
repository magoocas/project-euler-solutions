using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Utility.Poker
{
    public class Hand : IComparable<Hand>
    {
        private Func<int>[] _handEvaluators;
        private string _name;
        
        public Hand(IEnumerable<Card> cards)
        {
            Cards = cards.ToList();
            _name = Cards.Aggregate("", (a, b) => $"{a} {b}".TrimStart());
            Cards.Sort();
            _handEvaluators = new Func<int>[]
            {
                HighCard,
                OnePair,
                TwoPair,
                ThreeOfAKind,
                Straight,
                Flush,
                FullHouse,
                FourOfAKind,
                RoyalFlush
            };

        }

        public List<Card> Cards { get; }
        
        public HandType HandType { get; }

        public int HandValue { get; }

        private int HighCard()
        {
            return Cards.Max(c=>c.Value);
        }

        public override string ToString()
        {
            return _name;
        }

        private IEnumerable<int> GetKindCounts(int kindCount)
        {
            var cardFrequency = new int[Card.MaxValue + 1];
            foreach (var card in Cards)
                cardFrequency[card.Value]++;
            for (int i = 2; i < cardFrequency.Length; i++)
            {
                if (cardFrequency[i] == kindCount)
                    yield return i;
            }
        }
        
        private int OnePair()
        {
            var pairs = GetKindCounts(2).ToArray();
            if (pairs.Length == 1)
                return pairs[0];
            return 0;
        }

        private int TwoPair()
        {
            var pairs = GetKindCounts(2).ToArray();
            if (pairs.Length == 2)
                return pairs.Sum();
            return 0;
        }

        private int ThreeOfAKind()
        {
            var value = GetKindCounts(3).ToArray();
            if(value.Length == 1)
                return value[0];
            return 0;
        }

        private int Straight()
        {
            var value = 0;
            for (int i = 0; i < Cards.Count-1; i++)
            {
                if (Cards[i].Value + 1 != Cards[i + 1].Value)
                    return 0;
            }
            return value;
        }

        private int Flush()
        {

            var suitCounts = Cards.GroupBy(c => c.Suit).Select(g => Tuple.Create(g.Key, g.Count()));
            if (suitCounts.Max(x => x.Item2) != 5)
                return 0;
            return  Cards.Sum(c=>c.Value);
        }

        private int FullHouse()
        {
            var threeOfAKind = ThreeOfAKind();
            var twoPair = TwoPair();
            if (threeOfAKind > 0 && twoPair > 00)
                return threeOfAKind + twoPair;
            return 0;
        }

        private int FourOfAKind()
        {
            var value = GetKindCounts(4).ToArray();
            if (value.Length == 1)
                return value[0];
            return 0;
        }

        private int StraightFlush()
        {
            var value = GetKindCounts(5).ToArray();
            if (value.Length == 1)
            {
                var straight = Straight();
                if (straight > 0)
                    return straight;
            }
            return 0;
        }

        private int RoyalFlush()
        {
            if (Cards[0].Value == 10)
            {
                var straightFlush = StraightFlush();
                if (straightFlush > 0)
                    return straightFlush;
            }
            return 0;
        }

        public int CompareTo(Hand other)
        {
            for (int i = _handEvaluators.Length - 1; i >= 0; i--)
            {
                var handType = (HandType) i;
                var value = _handEvaluators[i]();
                var otherValue = other._handEvaluators[i]();
                if (value > otherValue)
                    return 1;
                if (value < otherValue)
                    return -1;
            }
            throw new Exception("Unclear winner");
        }
    }
}
