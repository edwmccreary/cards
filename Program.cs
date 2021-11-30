using System;
using System.Collections.Generic;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Player mario = new Player("Mario");
            Deck deck = new Deck();
            mario.Draw(deck);
            mario.Draw(deck);
            mario.Draw(deck);
            mario.Draw(deck);
            mario.Draw(deck);
            mario.Discard(2);
        }
    }

    class Card
    {
        public string StringVal;
        public string Suit;
        public int Val;
        public Dictionary<int, string> card_name = new Dictionary<int, string>();

        public Card(int val, string suit){
            
            Suit = suit;
            Val = val;
            card_name.Add(1,"ace");
            card_name.Add(2,"two");
            card_name.Add(3,"three");
            card_name.Add(4,"four");
            card_name.Add(5,"five");
            card_name.Add(6,"six");
            card_name.Add(7,"seven");
            card_name.Add(8,"eight");
            card_name.Add(9,"nine");
            card_name.Add(10,"ten");
            card_name.Add(11,"jack");
            card_name.Add(12,"queen");
            card_name.Add(13,"king");
            card_name.Add(14,"ace");

            StringVal = card_name[val];
        }
    }

    class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck(){
            Reset();
            Shuffle();
        }

        public void Reset(){
            cards.Clear();
            for(int i = 1; i < 14; i++){
                for(int j = 1; j < 5; j++){
                    string current_suit = "";
                    switch(j){
                        case 1:
                            current_suit = "hearts";
                        break;
                        case 2:
                            current_suit = "diamonds";
                        break;
                        case 3:
                            current_suit = "spades";
                        break;
                        case 4:
                            current_suit = "clubs";
                        break;
                    }
                    cards.Add(new Card(i,current_suit));
                    //Console.WriteLine(cards[cards.Count-1].StringVal);
                }
                
            }
        }

        public void Shuffle(){
            Random rand = new Random();
            for(int i = 0; i < cards.Count; i++){
                Card temp = cards[i];
                int rand_index = rand.Next(52);
                cards[i] = cards[rand_index];
                cards[rand_index] = temp;
            }
        }

        public Card Deal(){
            Card temp = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return temp;
        }
    }

    class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();

        public Player(string _name){
            name = _name;
        }

        public Card Draw(Deck deck){
            hand.Add(deck.Deal());
            Card current_card = hand[hand.Count-1];
            Console.WriteLine($"{name} draws a {current_card.StringVal} of {current_card.Suit}");
            return current_card;
        }

        public Card Discard(int index){
            if(index < 0 || index >= hand.Count){
                return null;
            }
            Card temp = hand[index];
            hand.RemoveAt(index);
            Console.WriteLine($"{name} discards the {temp.StringVal} of {temp.Suit} from there hand.");
            return temp;
        }
    }

}
