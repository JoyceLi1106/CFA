using System;
using System.Collections.Generic;
using System.Text;

namespace CFAProject.Data
{
    public interface IRepository
    {
        int Garbage(string stream, int currentLen, int length);
        int Add(string stream, int score, int group);
    }
}
