using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace T03.Card
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cardCollection = new List<Card>();

            string[] cardInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cardInfo.Length; i++)
            {
                string[] splittedInfo = cardInfo[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Card card = CreateCard(splittedInfo[0], splittedInfo[1]);

                if (card != null)
                {
                    cardCollection.Add(card);                    
                }
            }

            Console.WriteLine(string.Join(" ", cardCollection));
        }

        private static Card CreateCard(string face, string suit)
        {
            Card card = null;
            try
            {
                card = new Card(face, suit);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return card;
        }

        public class Card
        {
            private List<string> cardFaces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            private Dictionary<string, string> cardSuits = new Dictionary<string, string>
            {
                {"S", "\u2660"},
                {"H", "\u2665"},
                {"D", "\u2666"},
                {"C", "\u2663"}
            };

            public Card(string face, string suit)
            {
                Face = face;
                Suit = suit;
            }

            private string face;
            public string Face
            {
                get { return face; }
                private set
                {
                    if (!cardFaces.Contains(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }

                    face = value;
                }
            }

            private string suit;
            public string Suit
            {
                get { return suit; }
                private set
                {
                    if (!cardSuits.ContainsKey(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }

                    suit = value;
                }
            }

            public override string ToString()
            {
                return $"[{face}{cardSuits[suit]}]";
            }
        }
    }
}
