using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Person
    {
        public List<Card> CardsInHand { get; }

        public Person(List<Card> cardsInHand)
        {
            CardsInHand = cardsInHand;
        }

        protected Person()
        {
            CardsInHand = new List<Card>();
        }

        public void PrintHandCard()
        {
            foreach (var cardString in CardsInHand.Select(card => card.FormatCardString()))
            {
                Console.WriteLine(cardString);
            }
        }

        public bool DetermineBust()
        {
            return Sum() > 21;
        }
        
        public bool DetermineBlackjack()
        {
            return Sum() == 21;
        }
        
        public int DetermineAce()
        {
            while (Sum()<=10)
            {
                return 11;
            }
            return 1;
        }
        

        public int Sum()
        {
            var sum = 0;
            foreach (var card in CardsInHand)
            {
                if (card.CardFace == CardFace.Jack || card.CardFace == CardFace.Queen || card.CardFace == CardFace.King)
                {
                    sum += 10;
                }
                else
                {
                    var i = Convert.ToInt32(card.CardFace);
                    sum += i;
                }
            }
            
            return sum;
        }

        public void DrawCard(Card newCard)
        {
            CardsInHand.Add(newCard);
        }
    }
}