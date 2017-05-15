using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expertSystemInterface
{
    class Rule
    {
       public float ans1 { get; set; }
       public float ans2 { get; set; }
       public float ans3 { get; set; }
       public float ans4 { get; set; }
       public float CS { get; set; }
       public float IT { get; set; }
       public float IS { get; set; }

        public Rule(float ans1,float ans2,float ans3,float ans4)
        {
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
            this.ans4 = ans4;
        }
    }
}
