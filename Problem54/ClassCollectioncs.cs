using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public enum Suit
    {
        H,C,S,D
    };
    public enum Rank
    {
        Two=2,Three,Four,Five,Six,Seven,Eight,Nine,Ten,J,Q,K,A
    };
    public enum Rule
    {
        High,OneP,TwoP,ThrAkd,Strt,Flush, FullH,FourAkd,StrtFl,Royal
    };
    public class Card
    {
        public Card(Suit orgsuit, Rank orgrank) { suit = orgsuit; rank = orgrank; }

        public Card(Card Anothercard)
        {
            suit = Anothercard.suit;
            rank = Anothercard.rank;
        }

        private Suit suit;        
        private Rank rank;

        public Suit suitValue
        {
            get { return suit; }
        }

        public Rank rankValue
        {
            get { return rank; }
        }
    };

    public class Hand
    {
       public Hand(Card[] orgcards) { cards = orgcards; }

       public Hand(Hand Anotherhand)
       {
           cards = Anotherhand.cards;
       }

       private Card[] cards;

       public Card[] cardsValue
       {
           get { return cards; }
       }

       public int CompareTo(Hand hand2)//0: Equal to hand2; 1:Larger than hand2; -1: Smaller than hand2  
       {
           Shuffle shuffle1 = new Shuffle(cards);
           Shuffle shuffle2 = new Shuffle(hand2.cards);
           if (shuffle1.ruleValue > shuffle2.ruleValue)
               return 1;
           else if (shuffle1.ruleValue < shuffle2.ruleValue)
               return -1;
           else
           {
               for (int i = 4; i >= 0; i--)
               {
                   if (cards[i].rankValue > hand2.cards[i].rankValue)
                       return 1;
                   else if (cards[i].rankValue < hand2.cards[i].rankValue)
                       return -1;
               }
               return 0;
           }
       }

      
    };

    public class Shuffle
    {
        public Shuffle(Card[] orgCards) { shufCards = orgCards; rule = shuffleCards(); }
        private Card[] shufCards;
        private Rule rule;
        public Rule ruleValue
        {
            get{ return rule; }
        }
        private Rule shuffleCards()
        {
            if (isRoyalFlush())
                return Rule.Royal;
            if (isStraightFlush())
                return Rule.StrtFl;
            if (isFourAkind())
                return Rule.FourAkd;
            if (isFullHouse())
                return Rule.FullH;
            if (isFlush())
                return Rule.Flush;
            if (isStraight())
                return Rule.Strt;
            if (isThreeAkind())
                return Rule.ThrAkd;
            if (isTwoPairs())
                return Rule.TwoP;
            if (isOnePair())
                return Rule.OneP;

            return Rule.High;
        }
        private bool isRoyalFlush()
        {
            Rank[] RoyalCards = { Rank.Ten, Rank.J, Rank.Q, Rank.K, Rank.A };
            Array.Sort(shufCards, (a, b) => a.rankValue.CompareTo(b.rankValue));
            for (int i = 0; i <= 3; i++)
            {
                if (shufCards[i].suitValue != shufCards[i + 1].suitValue)
                    return false;
            }
            for (int i = 0; i <= 4; i++)
            {
                if (shufCards[i].rankValue != RoyalCards[i])
                    return false;
            }
            return true;
        }

        private bool isStraightFlush()
        {
            for (int i = 0; i <= 3; i++)
            {
                if (shufCards[i].suitValue != shufCards[i + 1].suitValue)
                    return false;
            }
            for (int i = 0; i <= 3; i++)
            {
                if ((int)shufCards[i].rankValue + 1 != (int)shufCards[i + 1].rankValue)
                    return false;
            }

            return true;
        }

        private bool isFourAkind()
        {
            Card temp;
            if (shufCards[0] == shufCards[1] && shufCards[0] == shufCards[2] && shufCards[0] == shufCards[3])
            {
                temp = new Card(shufCards[0]);
                shufCards[0] = new Card(shufCards[4]);
                shufCards[4] = new Card(shufCards[3]);
                shufCards[3] = new Card(shufCards[2]);
                shufCards[2] = new Card(shufCards[1]);
                shufCards[1] = temp;
                return true;
            }
            else if (shufCards[1] == shufCards[2] && shufCards[1] == shufCards[3] && shufCards[1] == shufCards[4])
            {
                return true;
            }
            else
                return false;
            
        }

        private bool isFullHouse()
        {
            if (isThreeAkind())
            {
                if (shufCards[0].rankValue == shufCards[1].rankValue)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private bool isFlush()
        {
            for (int i = 0; i <= 3; i++)
            {
                if (shufCards[i].suitValue != shufCards[i + 1].suitValue)
                    return false;
            }
            return true;
        }

        private bool isStraight()
        {
            for (int i = 0; i <= 3; i++)
            {
                if ((int)shufCards[i].rankValue + 1 != (int)shufCards[i + 1].rankValue)
                    return false;
            }

            return true;

        }

        private bool isThreeAkind()
        {
            Card First;
            Card Second;
            Card Third;
            if (shufCards[0].rankValue == shufCards[1].rankValue && shufCards[0].rankValue == shufCards[2].rankValue)
            {
                First = new Card(shufCards[0]);
                Second = new Card(shufCards[1]);
                Third = new Card(shufCards[2]);
                shufCards[0] = new Card(shufCards[3]);
                shufCards[1] = new Card(shufCards[4]);
                shufCards[2] = First;
                shufCards[3] = Second;
                shufCards[4] = Third;               
                return true;
            }
            else if (shufCards[1].rankValue == shufCards[2].rankValue && shufCards[1].rankValue == shufCards[3].rankValue)
            {
                First = new Card(shufCards[1]);
                Second = new Card(shufCards[2]);
                Third = new Card(shufCards[3]);
                shufCards[1] = new Card(shufCards[4]);
                shufCards[2] = First;
                shufCards[3] = Second;
                shufCards[4] = Third;
                return true;
            }
            else if (shufCards[2].rankValue == shufCards[3].rankValue && shufCards[2].rankValue == shufCards[4].rankValue)
            {
                return true;
            }
            else
                return false;
            
        }

        private bool isTwoPairs()
        {
            Card temp;
            if (shufCards[0].rankValue == shufCards[1].rankValue)
            {
                if (shufCards[2].rankValue == shufCards[3].rankValue)
                {
                    temp = new Card(shufCards[0]);
                    shufCards[0] = new Card(shufCards[4]);
                    shufCards[4] = new Card(shufCards[3]);
                    shufCards[3] = new Card(shufCards[2]);
                    shufCards[2] = new Card(shufCards[1]);
                    shufCards[1] = temp;

                    return true;
                }
                else if (shufCards[3].rankValue == shufCards[4].rankValue)
                {
                    temp = new Card(shufCards[0]);
                    shufCards[0] = new Card(shufCards[2]);
                    shufCards[2] = new Card(shufCards[1]);
                    shufCards[1] = temp;
                    return true;
                }
                return false;
            }
            else
            {
                if (shufCards[1].rankValue == shufCards[2].rankValue && shufCards[3].rankValue == shufCards[4].rankValue)
                    return true;
                else
                    return false;
            }
        }

        private bool isOnePair()
        {
            Card First;
            Card Second;
            for (int i = 0; i <= 3; i++)
            {
                if (shufCards[i].rankValue == shufCards[i + 1].rankValue)
                {
                    First = new Card(shufCards[i]);
                    Second = new Card(shufCards[i+1]);
                    for (int j = i + 2; j <= 4; j++)
                    {
                        shufCards[j-2] = new Card(shufCards[j]);
                    }
                    shufCards[3] = First;
                    shufCards[4] = Second;
                    return true;
                }
            }
            return false;
        }

    };
}
