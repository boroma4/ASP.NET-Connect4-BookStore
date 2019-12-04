using System;
using Domain;

namespace GameEngine
{
    public static class GameAI
    {
        public static int MakeMove(GameSettings settings)
        {
            var botX = 0;
            Random random = new Random(); 

            do
            {
                botX = random.Next(1, settings.BoardWidth); 
                
            } while (settings.YCoordinate[botX-1] < 1);

            return botX;
        }
    }
}