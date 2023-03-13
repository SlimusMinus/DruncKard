using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace DruncKard
{
    public class Cards
    {
        List<Cards> cards = new List<Cards>();
        List<Cards> player1 = new List<Cards>();
        List<Cards> player2 = new List<Cards>();
        string[] Suits = { "\u2660", "\u2665", "\u2666", "\u2663" };
        public Cards() { }
        private int _rank;
        private string _suit;
        short moves = 10;
        public Cards(int rank, string suit)
        {
            _rank = rank;
            _suit = suit;
        }
        public override string ToString()
        {
            if (_suit == "\u2666" || _suit == "\u2665")
                ForegroundColor = ConsoleColor.Red;
            else
                ForegroundColor = ConsoleColor.Black;
            if (_rank == 11)
                return $"{"B"}{_suit}";
            else if (_rank == 12)
                return $"{"D"}{_suit}";
            else if (_rank == 13)
                return $"{"K"}{_suit}";
            else if (_rank == 14)
                return $"{"T"}{_suit}";
            else
                return $"{_rank}{_suit}";
        }

        public void draw()
        {
            for (int i = 0; i < 4; i++)
                for (int q = 6; q < 15; q++)
                    cards.Add(new Cards(q, Suits[i]) { });

            Random random = new Random();
            for (int i = cards.Count - 5; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }

            for (int i = 0; i < 18; i++)
            {
                player1.Add(cards[i]);
                cards.RemoveAt(i);
            }

            for (int i = 0; i < 18; i++)
                player2.Add(cards[i]);
            cards.Clear();
            WriteLine("\t\tCard 1 player");
            for (int i = 0; i< player1.Count; i++)
                Write(player1[i] + " ");
            WriteLine();
            WriteLine("\t\tCard 2 player");
            for (int i = 0; i< player1.Count; i++)
                Write(player2[i] + " ");
            WriteLine();
            WriteLine("\t\t\nLet's begin");
            ReadLine();
        }
        public void Gamexin()
        {
            
            for (int i = 0; i < moves; i++)
            {
                Clear();
                if (player1[i]._suit == "\u2666" || player1[i]._suit == "\u2665" )
                    ForegroundColor = ConsoleColor.Red;
                else if (player2[i]._suit == "\u2666" || player2[i]._suit == "\u2665")
                    ForegroundColor = ConsoleColor.Red;
                Write(player1[i] + " ");
                if (player1[i]._suit == "\u2660" || player1[i]._suit == "\u2663")
                    ForegroundColor = ConsoleColor.Black;
                if (player1[i]._suit == "\u2660" || player1[i]._suit == "\u2663")
                    ForegroundColor = ConsoleColor.Black;
                WriteLine(player2[i]);
                ForegroundColor = ConsoleColor.Black;
                if (player1[i]._rank < player2[i]._rank)
                {
                    WriteLine("Player 2 win");
                    player1.RemoveAt(i);
                    player2.Add(player1[i]);
                }
                else if (player1[i]._rank > player2[i]._rank)
                {
                    WriteLine("Player 1 win");
                    player2.RemoveAt(i);
                    player1.Add(player2[i]);
                }
                else if (player1[i]._rank == player2[i]._rank)
                {
                    WriteLine("Draw");
                    player1.Add(player1[i]);
                    player1.RemoveAt(i);
                    player2.Add(player2[i]);
                    player2.RemoveAt(i);
                }
                ReadLine();
            }
            Clear();
            WriteLine($"{"After"} {moves} {"moves"}");
            WriteLine($"{"Player 1 have"} {player1.Count} {"cards"}");
            foreach (var item in player1)
                Write(item + " ");
            WriteLine();
            ForegroundColor = ConsoleColor.Black;
            WriteLine($"{"Player 2 have"} {player2.Count} {"cards"}");
            foreach (var item in player2)
                Write(item + " ");
            WriteLine();
            ReadLine();
            Clear();
            ForegroundColor = ConsoleColor.Black;
            if (player1.Count > player2.Count) { WriteLine("Player 1 WIN!!!!"); }
            else if (player2.Count > player1.Count) { WriteLine("Player 2 WIN!!!!"); }
            else if (player2.Count == player1.Count) { WriteLine("Friendship WIN!!!!"); }
        }
    }
}
