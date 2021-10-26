using System;

namespace Sticks.Core
{
    public  interface ICanGenerateNumbers
    {
        int Next(int min, int max);
    }

    public class NumbersGenerator : ICanGenerateNumbers
    {
        private readonly Random _generator = new Random();
        public int Next(int min, int max)
        {
            return _generator.Next(min, max);
        }
    }
    public class Game
    {
        public const int MaxToTake = 3;
        public const int MinToTake = 1;

        public int NumberOfSticks { get; }
        public Player Turn { get;  }

        public EventHandler<Player> GameOver;
        public EventHandler<Move> MachineMoved;

        ICanGenerateNumbers _generator;
        private ICanGenerateNumbers generator;

        public Game(int numberOfSticks, Player turn):this(numberOfSticks, turn, new NumbersGenerator())
        {
        }

        public Game(int numberOfSticks, Player turn, ICanGenerateNumbers generator)
        {
            if (generator == null) throw new ArgumentNullException(nameof(generator));
           
            if (numberOfSticks < 10)
                throw new ArgumentException($"Number of sticks has to be >= 10. You passed:{numberOfSticks}");

            _generator = generator;
            NumberOfSticks = numberOfSticks;
            Turn = turn;
        }

        public Game(Player turn, int numberOfSticks, ICanGenerateNumbers generator, EventHandler<Move> onMachineMoved,EventHandler<Player> onGameOver)
        {
            NumberOfSticks = numberOfSticks;
            Turn = turn;
            _generator = generator;
            MachineMoved = onMachineMoved;
            GameOver = onGameOver;
        }

        private Player Revert(Player player)
        {
            return player == Player.Machine ? Player.Human : Player.Machine;
        }

        public Game HumanMakesMove(int sticksTaken)
        {
            if (Turn == Player.Machine)
                throw new InvalidOperationException("It's turn of machine to make a move!");

            if (sticksTaken < MinToTake || sticksTaken > MaxToTake)
                throw new ArgumentException($"You should take from one to three sticks. You took: {sticksTaken}");

            if (sticksTaken > NumberOfSticks)
                throw new ArgumentException($"You took too many sticks.");

            return MakeMove(sticksTaken);
        }

        public Game MachineMakesMove()
        {
            if (Turn == Player.Human) throw new InvalidOperationException("It's turn of human to make a move!");
            int sticksTaken = MachineTakes();

            MachineMoved?.Invoke(this, new Move(sticksTaken, Remains(sticksTaken)));

            return MakeMove(sticksTaken);
        }

        private int MachineTakes()
        {
            int maxValue = NumberOfSticks >= MaxToTake ? MaxToTake : NumberOfSticks;

            return _generator.Next(MinToTake, maxValue);
        }

        private Game MakeMove(int sticksTaken)
        {
            int remains = Remains(sticksTaken);
            if (IsGameOver(remains))
                GameOver?.Invoke(this, Revert(Turn));

            return new Game(Revert(Turn), remains, _generator, MachineMoved, GameOver);
        }

        private int Remains(int sticksTaken)
        {
            return NumberOfSticks - sticksTaken;
        }

        public bool IsGameOver()
        {
            return IsGameOver(NumberOfSticks);
        }
        private bool IsGameOver(int numberOfSticks)
        {
            return numberOfSticks <= 0;
        }
    }

    public class Move
    {
        public int Taken { get;}
        public int Remains { get; }

        public Move(int taken, int remains)
        {
            Taken = taken;
            Remains = remains;
        }
    }
}