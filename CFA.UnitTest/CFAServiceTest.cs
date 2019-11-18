using CFAProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFAProject.API.Controllers;
using Moq;
using System.Collections.Generic;

namespace CFA.UnitTest
{
    [TestClass]
    public class CFAServiceTest
    {
        private ICFAService _service;
        private List<string> _list;

        [TestInitialize]
        public void Initialize()
        {
            _service = new CFAService();
            _list = new List<string>
            {
               "{}",
            "{{{}}}",
            "{{},{}}",
            "{{{},{},{{}}}}",
            "{<a>,<a>,<a>,<a>}",
            "{{<ab>},{<ab>},{<ab>},{<ab>}}",
            "{{<!!>},{<!!>},{<!!>},{<!!>}}",
            "{{<a!>},{<a!>},{<a!>},{<ab>}}"
            };
        }

        [TestMethod]
        public void CheckInputFromFakeData1()
        {
           for ( int i = 0; i < _list.Count; i++)
            {
                int returnScore = _service.AddScore(_list[i],0);
                switch(i)
                {
                    case 0:
                        Assert.AreEqual(1, returnScore);
                        break;
                    case 1:
                        Assert.AreEqual(6, returnScore);
                        break;
                    case 2:
                        Assert.AreEqual(5, returnScore);
                        break;
                    case 3:
                        Assert.AreEqual(16, returnScore);
                        break;
                    case 4:
                        Assert.AreEqual(1, returnScore);
                        break;
                    case 5:
                        Assert.AreEqual(9,returnScore);
                        break;
                    case 6:
                        Assert.AreEqual(9, returnScore);
                        break;
                    case 7:
                        Assert.AreEqual(3, returnScore);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
