using System;

namespace TenTimesOne
{
    public class ChanceTester
    {
        Random rng = new Random();

        public bool Test1Time10()
        {            
            if(rng.Next(1,11) == 1)
            {
                return true;
            }

            return false;
        }

        public int Test10Times1()
        {
            int winCounter = 0;

            for(int i=0; i<10; i++)
            {
                if (rng.Next(1, 101) == 1)
                {
                    winCounter++;
                }
            }

            return winCounter;
        }
    }
}
