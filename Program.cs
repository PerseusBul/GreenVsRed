using System;

namespace GreenVsRed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                const int Zero = 0;
                var dimentions = Input.ParseGridDimentions();
                var gridInitial = Input.ParseGridContent(dimentions);
                int rounds = Zero;
                var targetCell = Input.ParseGridTargetAndRounds(ref rounds);

                var game = new Game(rounds, targetCell);

                var generationInitial = new Generation(Zero, gridInitial);
                game.AddGeneration(generationInitial);

                game.Play(generationInitial.Grid);
                game.DisplayScore();
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong! Ask the stuff around for help!");
            }
        }
    }
}
