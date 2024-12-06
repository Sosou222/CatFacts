using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFacts
{
    public class CatFact
    {
        public string Fact { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return $"Fact:{Fact} \n Length:{Length}";
        }
    }
}
