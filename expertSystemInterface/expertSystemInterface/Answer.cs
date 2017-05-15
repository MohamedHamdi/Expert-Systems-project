using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expertSystemInterface
{
    class Answer
    {


      public string question { get; set; }
      public float ans1 { get; set; }
      public float ans2 { get; set; }
      public float ans3 { get; set; }
      public float ans4 { get; set; }
      public float ans1ht { get; set; }
      public float ans1lt { get; set; }
      public float ans2ht { get; set; }
      public float ans2lt { get; set; }
      public float ans3ht { get; set; }
      public float ans3lt { get; set; }
      public float ans4ht { get; set; }
      public float ans4lt { get; set; }

        public Answer(string q,float a1,float a2,float a3,float a4)
        {
            question = q;
            ans1 = a1;
            ans2 = a2;
            ans3 = a3;
            ans4 = a4;
        }

       
    }
}
