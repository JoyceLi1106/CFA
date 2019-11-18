using System;
using System.Collections.Generic;
using System.Text;

namespace CFAProject.Data
{
    public class Repository : IRepository
    {
        public int Add(string stream, int score, int group)
        {
            Stack<char> groups = new Stack<char>();
            
            for (int i = 0; i < stream.Length; i++)
            {
                if (stream[i] == '{')
                {
                    groups.Push('{');
                    group++;
                    continue;
                }
                else if (stream[i] == '}')
                {
                    score = score + group;
                    if (groups.Count == 0)
                    {
                        continue;
                    }
                    groups.Pop();
                    group--;
                    continue;
                }
                else if (stream[i] == '!')
                {
                    if (i <= stream.Length - 2)
                    {
                        return score;
                    }
                    i++;
                    continue;
                }
                else if (stream[i] == '<')
                {
                    i++;
                    i = Garbage(stream, i, stream.Length);
                }
                else
                {
                    continue;
                }
            }
            return score;
        }

        public int Garbage(string stream, int currentLen, int length)
        {
            while (stream[currentLen] != '>' && currentLen <= length - 1)
            {
                if (stream[currentLen] == '!')
                {
                    currentLen = currentLen + 2;
                    continue;
                }

                currentLen++;
            }

            if (stream[currentLen] == '>' && currentLen <= length - 1)
            {
                //current++;
                return currentLen;
            }
            if (currentLen > length - 1)
            {
                return -1;
            }

            return -2;
        }
    }
}
