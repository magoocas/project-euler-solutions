using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace csharp.Utility.Poker
{
    public class Hand : IComparable<Hand>
    {
        private Func<IEnumerable<int>>[] _cardMatchers;
        
        public Hand(IEnumerable<Card> cards)
        {
            Cards = cards.ToList();
            Cards.Sort();
            Cards.Reverse();
            _cardMatchers = new Func<IEnumerable<int>>[]
            {
                RoyalFlush,
                StraightFlush,
                () => GetCardGroups(4,1), //Four of a kind
                FullHouse,
                Flush,
                Straight,
                () => GetCardGroups(3,1), //Three of a kind
                () => GetCardGroups(2,2), //Two Pair
                () => GetCardGroups(2,1), //One Pair
                () => Cards.Select(c=>c.Value) //High Card
            };

        }

        public List<Card> Cards { get; }
        
        private IEnumerable<int> GetCardGroups(int groupSize, int groupCount)
        {
            var cardGroups = Cards.GroupBy(c => c.Value).Where(g=>g.Count() == groupSize).ToList();
            if(cardGroups.Count!=groupCount)
                yield break;

            foreach (var cardGroup in cardGroups)
            {
                yield return cardGroup.Key;
            }
        }
        
        private IEnumerable<int> Straight()
        {
            for (int i = 1; i < Cards.Count; i++)
            {
                if(Cards[i-1].Value != Cards[i].Value+1)
                    yield break;
            }
            foreach (var card in Cards)
                yield return card.Value;
        }

        private IEnumerable<int> Flush()
        {
            for (int i = 1; i < Cards.Count; i++)
                if (Cards[0].Suit != Cards[i].Suit)
                    yield break;
            foreach (var card in Cards)
                yield return card.Value;
        }

        private IEnumerable<int> FullHouse()
        {
            var threeOfAKind = GetCardGroups(3,1).ToList();
            var onePair = GetCardGroups(2,1).ToList();
            if (threeOfAKind.Count <= 0 || onePair.Count <= 0) yield break;
            foreach (var c in threeOfAKind)
                yield return c;
            foreach (var c in onePair)
                yield return c;
        }
        
        private IEnumerable<int> StraightFlush()
        {
            var flush = Flush().ToList();
            var straight = Straight().ToList();

            if(flush.Count<5 || straight.Count<5)
                yield break;
            foreach (var card in Cards)
                yield return card.Value;
        }

        private IEnumerable<int> RoyalFlush()
        {
            if (Cards[0].Value != Card.MaxValue)
                yield break;
            foreach (var c in StraightFlush())
                yield return c;
        }

        public int CompareTo(Hand other)
        {
            for (int i = 0; i < _cardMatchers.Length; i++)
            {

                var cards = _cardMatchers[i]().ToList();
                var otherCards = other._cardMatchers[i]().ToList();
                if (cards.Count > otherCards.Count)
                    return 1;
                if (cards.Count < otherCards.Count)
                    return -1;

                if (cards.Count == 0)
                    continue;

                for (int j = 0; j < cards.Count; j++)
                {
                    if (cards[j] > otherCards[j])
                        return 1;
                    if (cards[j] < otherCards[j])
                        return -1;
                }

                var highCards = Cards.Where(c => !cards.Contains(c.Value)).ToList();
                var otherHighCards = other.Cards.Where(c => !otherCards.Contains(c.Value)).ToList();

                for (int j = 0; j < cards.Count; j++)
                {
                    if (highCards[j].Value > otherHighCards[j].Value)
                        return 1;
                    if (highCards[j].Value < otherHighCards[j].Value)
                        return -1;
                }

                throw new Exception("Unclear winner");
            }
            throw new Exception("Unclear winner");
        }
    }
}
