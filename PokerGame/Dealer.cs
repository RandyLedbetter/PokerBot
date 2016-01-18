﻿using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Dealer
    {
        public Deck52Cards Deck;
        public Table Table;

        public Dealer(Table t, Deck52Cards deck)
        {
            Deck = deck;
            Table = t;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DealHands()
        {
            Deck.Shuffle();

            // Dealer... deals
            // TODO Button must be the last the receive cards
            // First Card
            for (int i = 0; i < Table.Seats.Count; i++)
            {
                if (Table.Seats[i] != null && !Table.Seats[i].IsEmpty)
                {
                    Table.Seats[i].Hand = new Hand();
                    Table.Seats[i].Hand.FirstCard = Deck.Deal();
                }
            }
            // Second Card
            for (int i = 0; i < Table.Seats.Count; i++)
            {
                if (Table.Seats[i] != null && !Table.Seats[i].IsEmpty)
                {
                    Table.Seats[i].Hand.SecondCard = Deck.Deal();
                }
            }
        }

        private void DealBoardCards(int numCards)
        {
            Deck.Burn();
            for (int i = 0; i < numCards; i++)
            {
                Table.Board.Add(Deck.Deal());
            }
        }

        public void DealFlop()
        {
            DealBoardCards(3);
        }

        public void DealTurn()
        {
            DealBoardCards(1);
        }

        public void DealRiver()
        {
            DealBoardCards(1);
        }
    }
}
