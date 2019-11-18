using System;
using System.Collections.Generic;
using System.Text;

namespace CFAProject.Services
{
    public class CFAService : ICFAService
    {
        public int AddScore(string stream, int score)
        {
            int level = 0;
            bool flagGarbage = false;
            for (int n = 0; n < stream.Length; n++)
            {
                char c = stream[n];
                if (c == '!')
                {
                    n++;
                }
                else if (c == '>')
                {
                    flagGarbage = false;
                }
                else if (c == '<')
                {
                    flagGarbage = true;
                }
                else if (!flagGarbage && c == '{')
                {
                    score += ++level;
                }
                else if (!flagGarbage && c == '}')
                {
                    level--;
                }
            }
            return score;
        }
    }
}
