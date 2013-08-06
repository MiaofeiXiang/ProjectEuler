using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
namespace Euler
{
   
    class Program
    {
        public static void GenerateCards(Card[] Player1Cards, Card[] Player2Cards, string[] CardsStr)
        {
            int Player1Count = 0;
            int Player2Count = 0;
            string Player1CardStr;
            string Player2CardStr;
            for (Player1Count = 0; Player1Count<= 4; Player1Count++)
            {
                Player1CardStr = CardsStr[Player1Count];
                Suit suit = Suit.C;
                Rank rank = Rank.Two;
                switch (Player1CardStr[0])
                {
                    case '2': rank = Rank.Two; break;
                    case '3': rank = Rank.Three; break;
                    case '4': rank = Rank.Four; break;
                    case '5': rank = Rank.Five; break;
                    case '6': rank = Rank.Six; break;
                    case '7': rank = Rank.Seven; break;
                    case '8': rank = Rank.Eight; break;
                    case '9': rank = Rank.Nine; break;
                    case 'T': rank = Rank.Ten; break;
                    case 'J': rank = Rank.J; break;
                    case 'Q': rank = Rank.Q; break;
                    case 'K': rank = Rank.K; break;
                    case 'A': rank = Rank.A; break;
                }
                switch (Player1CardStr[1])
                {
                    case 'H': suit = Suit.H; break;
                    case 'C': suit = Suit.C; break;
                    case 'S': suit = Suit.S; break;
                    case 'D': suit = Suit.D; break;
                }
                Player1Cards[Player1Count] = new Card(suit,rank);
            }

            for (Player2Count = 0; Player2Count <= 4; Player2Count++)
            {
                Player2CardStr = CardsStr[Player2Count+5];
                Suit suit = Suit.C;
                Rank rank = Rank.Two;
                switch (Player2CardStr[0])
                {
                    case '2': rank = Rank.Two; break;
                    case '3': rank = Rank.Three; break;
                    case '4': rank = Rank.Four; break;
                    case '5': rank = Rank.Five; break;
                    case '6': rank = Rank.Six; break;
                    case '7': rank = Rank.Seven; break;
                    case '8': rank = Rank.Eight; break;
                    case '9': rank = Rank.Nine; break;
                    case 'T': rank = Rank.Ten; break;
                    case 'J': rank = Rank.J; break;
                    case 'Q': rank = Rank.Q; break;
                    case 'K': rank = Rank.K; break;
                    case 'A': rank = Rank.A; break;
                }
                switch (Player2CardStr[1])
                {
                    case 'H': suit = Suit.H; break;
                    case 'C': suit = Suit.C; break;
                    case 'S': suit = Suit.S; break;
                    case 'D': suit = Suit.D; break;
                }
                Player2Cards[Player2Count] = new Card(suit, rank);
            }
        }
        
        static void Main(string[] args)
        {
            List<string> HandsList = new List<string>();
            Card[] Player1Cards = new Card[5];
            Card[] Player2Cards = new Card[5];
            int Player1WinnerSum = 0;
            try
            {
                FileInfo MyFile = new FileInfo("poker.txt");
                StreamReader sr = MyFile.OpenText();
                while (!sr.EndOfStream)
                {
                    string tempStr = sr.ReadLine();
                    string[] tempStrArray = tempStr.Split(new char[1] { ' ' });
                    GenerateCards(Player1Cards, Player2Cards, tempStrArray);
                    Hand Player1 = new Hand(Player1Cards);
                    Hand Player2 = new Hand(Player2Cards);
                    int Judge = Player1.CompareTo(Player2);
                    if (Judge > 0)
                    {
                        Console.WriteLine("The winner is Player1");
                        Player1WinnerSum++;
                    }
                    else if (Judge < 0)
                        Console.WriteLine("The winner is Player2");
                    else
                        Console.WriteLine("Tie hand.");
                }
                Console.WriteLine("The total win sum of Player1 is: {0}", Player1WinnerSum);
                Console.ReadKey();

            }

            catch (System.Exception e)
            {
                Console.WriteLine("throw exception: {0}", e.GetType());
                Console.WriteLine("{0}", e.Message);
                Console.ReadKey();
            }
            /*Card P11 = new Card(Suit.D,Rank.Four);
            Card P12 = new Card(Suit.S, Rank.Four);
            Card P13 = new Card(Suit.H, Rank.Three);
            Card P14 = new Card(Suit.D, Rank.Three);
            Card P15 = new Card(Suit.C, Rank.Six);

            Card P21 = new Card(Suit.D, Rank.Five);
            Card P22 = new Card(Suit.C, Rank.Five);
            Card P23 = new Card(Suit.D, Rank.Six);
            Card P24 = new Card(Suit.H, Rank.Six);
            Card P25 = new Card(Suit.S, Rank.Two);
            Card[] Player1Cards = {P11,P12,P13,P14,P15};
            Card[] Player2Cards = {P21,P22,P23,P24,P25};
            Hand Player1 = new Hand(Player1Cards);
            Hand Player2 = new Hand(Player2Cards);
            int Judge = Player1.CompareTo(Player2);
            if (Judge > 0)
                Console.WriteLine("The winner is Player1");
            else if (Judge < 0)
                Console.WriteLine("The winner is Player2");
            else
                Console.WriteLine("Tie hand.");
            Console.ReadKey();*/
        }

    }
}
