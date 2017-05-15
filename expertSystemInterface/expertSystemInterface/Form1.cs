using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expertSystemInterface
{
    public partial class Form1 : Form
    {
      
        //Rules
        List<Rule> Rules = new List<Rule>();
        List<InferencedRule> infRules = new List<InferencedRule>();

        public int counter0 = 0;
        public int counter1 = 0;
        public int counter2 = 0;
        public int counter3 = 0;
        public int countCs = 0;
        public int countIt = 0;
        public int countIs = 0;

        public bool value = false;
        public bool value1 = false;
        public bool value2 = false;
        public bool value3 = false;

        public float Value;
        public float Value1;
        public float Value2;
        public float Value3;
        public float CsValue;
        public float IsValue;
        public float ItValue;

        Answer first;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            first = new Answer(label2.Text,(float)trackBar1.Value,(float)trackBar2.Value,(float)trackBar3.Value,(float)trackBar4.Value);
            first = membershipFunction(first);

            int counter = 0;

            while (counter<16)
            {
                GenerateRules();
                counter++;
            }

            chooseDepartmentForEachRule(Rules);

            fillDataGridView(dataGridView1);

            inference(first,Rules);

            fillDataGridView0(dataGridView2);

           

        }

        private Answer membershipFunction(Answer ans)
        {
            ans.ans1ht = ans.ans1 / 10;
            ans.ans1lt = 1 - (ans.ans1 / 10);

            ans.ans2ht = ans.ans2 / 10;
            ans.ans2lt = 1 - (ans.ans2 / 10);

            ans.ans3ht = ans.ans3 / 10;
            ans.ans3lt = 1 - (ans.ans3 / 10);

            ans.ans4ht = ans.ans4 / 10;
            ans.ans4lt = 1 - (ans.ans4 / 10);

            return ans;
        }

        private void GenerateRules()
        {
           

            if (value == false) Value = 0;
            else Value = 1;
            if (value1 == false) Value1 = 0;
            else Value1 = 1;
            if (value2 == false) Value2 = 0;
            else Value2 = 1;
            if (value3 == false) Value3 = 0;
            else Value3 = 1;

            if(counter0==0)
            {
                counter0++;
                value = !value;
            }
            else
            {
                counter0=0;
                value = !value;
            }

            if(counter1==1)
            {
                value1 = !value1;
                counter1++;
            }
            else if(counter1==3)
            {
                value1 = !value1;
                counter1 = 0;
            }
            else
            {
                counter1++;
            }

            if (counter2 == 3)
            {
                value2 = !value2;
                counter2++;
            }
            else if (counter2 == 7)
            {
                value2 = !value2;
                counter2 = 0;
            }
            else
            {
                counter2++;
            }

            if (counter3 == 7)
            {
                value3 = !value3;
                counter3++;
            }
            else if (counter3 == 15)
            {
                value3 = !value3;
                counter3 = 0;
            }
            else
            {
                counter3++;
            }


            Rule rule = new Rule(Value, Value1, Value2, Value3);

            Rules.Add(rule);

           
            
        }

        private void chooseDepartmentForEachRule(List<Rule> Rules)
        {
            foreach (var item in Rules)
            {
                countCs = 0;
                countIs = 0;
                countIt = 0;
                if(item.ans1==0)
                {
                    countIs++;
                    countIt++;
                }
                else
                {
                    countCs++;
                }
                if(item.ans2==0)
                {
                    countCs++;
                    countIs++;
                }
                else
                {
                    countIt++;
                }
                if(item.ans3==0)
                {
                    countIt++;
                    countCs++;
                }
                else
                {
                    countIs++;
                }
                if (item.ans4 == 0)
                {
                    countIt++;
                    countCs++;
                }
                else
                {
                    countIs++;
                }

                if((countCs==countIt)&&(countCs==countIs))
                {
                    item.CS = 1;
                    item.IT = 1;
                    item.IS = 1;
                }
                else if ((countCs > countIt) && (countCs > countIs))
                {
                    item.CS = 1;
                }
                else if ((countCs < countIt) && (countIt > countIs))
                {
                    item.IT = 1;
                }
                else if ((countIs > countIt) && (countCs < countIs))
                {
                    item.IS = 1;
                }
                else if ((countCs == countIt) && (countCs > countIs))
                {
                    item.CS = 1;
                    item.IT = 1;
                }
                else if ((countCs == countIs) && (countCs > countIt))
                {
                    item.CS = 1;
                    item.IS = 1;
                }
                else if ((countIt == countIs) && (countIt > countCs))
                {
                    item.IT = 1;
                    item.IS = 1;
                }
                else
                {
                    MessageBox.Show("cs" + countCs + "it" + countIt + "is" + countIs);
                  
                }

            }
        }

        private void fillDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 7;

            dgv.Rows.Add("Programming", "Networks", "Databases", "Designing", "Cs", "Is", "It");


            foreach (var item in Rules)
            {
                dgv.Rows.Add(item.ans1, item.ans2, item.ans3, item.ans4, item.CS, item.IS, item.IT);
            }
        }

        private void fillDataGridView0(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 14;

            dgv.Rows.Add("Programming high", "Programming low", "Networks high", "Networks low", "Databases high", "Databases low", "Designing high", "Designing low", "Cs high", "Cs low", "Is high", "Is low", "It high", "It low");


            foreach (var item in infRules)
            {
                dgv.Rows.Add(item.ansh1,item.ansl1,item.ansh2,item.ansl2,item.ansh3,item.ansl3,item.ansh4,item.ansl4,item.csh,item.csl,item.Ish,item.Isl,item.ith,item.itl);
            }
        }




        List<float> nums = new List<float>();
       
        private void inference (Answer a,List<Rule> rules)
        {
            foreach (var item in Rules)
            {
                InferencedRule infRule = new InferencedRule();
                if(item.ans1==1)
                {
                    infRule.ansh1 = a.ans1ht;
                    nums.Add(infRule.ansh1);
                }
                else
                {
                    infRule.ansl1 = a.ans1lt;
                    nums.Add(infRule.ansl1);
                }
                if (item.ans2 == 1)
                {
                    infRule.ansh2 = a.ans2ht;
                    nums.Add(infRule.ansh2);
                }
                else
                {
                    infRule.ansl2 = a.ans2lt;
                    nums.Add(infRule.ansl2);
                }
                if (item.ans3 == 1)
                {
                    infRule.ansh3 = a.ans3ht;
                    nums.Add(infRule.ansh3);
                }
                else
                {
                    infRule.ansl3 = a.ans3lt;
                    nums.Add(infRule.ansl3);
                }
                if (item.ans4 == 1)
                {
                    infRule.ansh4 = a.ans4ht;
                    nums.Add(infRule.ansh4);
                }
                else
                {
                    infRule.ansl4 = a.ans4lt;
                    nums.Add(infRule.ansl4);
                }
               
                if (item.IS == 1)
                {
                    float min = nums[0];
                    foreach (var item0 in nums)
                    {
                        if (min >= item0) min = item0;
                    }
                    infRule.Ish = min;
               
                }
                else
                {
                    float min = nums[0];
                    foreach (var item0 in nums)
                    {
                        if (min >= item0) min = item0;
                    }
                    infRule.Isl = min;
                 
                }
                if (item.CS == 1)
                {
                    float min = nums[0];
                    foreach (var item0 in nums)
                    {
                        if (min >= item0) min = item0;
                    }
                    infRule.csh = min;
                  

                }
                else
                {
                    float min = nums[0];
                    foreach (var item0 in nums)
                    {
                        if (min >= item0) min = item0;
                    }
                    infRule.csl = min;
                 
                }
                if (item.IT == 1)
                {
                    float min = nums[0];
                    foreach (var item0 in nums)
                    {
                        if (min >= item0) min = item0;
                    }
                    infRule.ith = min;
                }
                else
                {
                    float min = nums[0];
                    foreach (var item0 in nums)
                    {
                        if (min >= item0) min = item0;
                    }
                    infRule.itl = min;
                }
                infRules.Add(infRule);
                nums.Clear();
            }

            CompareHighAndLowValues(infRules);
        }

        private void CompareHighAndLowValues(List<InferencedRule> infRules)
        {
            var items = new List<KeyValuePair<string, float>>();
            foreach (var item in infRules)
            {
                items.Add(new KeyValuePair<string, float>("item.csh", item.csh));
                items.Add(new KeyValuePair<string, float>("item.csl", item.csl));
                items.Add(new KeyValuePair<string, float>("item.ith", item.ith));
                items.Add(new KeyValuePair<string, float>("item.itl", item.itl));
                items.Add(new KeyValuePair<string, float>("item.Ish", item.Ish));
                items.Add(new KeyValuePair<string, float>("item.Isl", item.Isl));
            }

            var lookup = items.ToLookup(kvp => kvp.Key, kvp => kvp.Value);

            float maxCs = lookup["item.csh"].Max();
            float maxIt = lookup["item.ith"].Max();
            float maxIs = lookup["item.Ish"].Max();

             float minCs = lookup["item.csl"].Max();
            float minIt = lookup["item.itl"].Max();
            float minIs = lookup["item.Isl"].Max();

         

            label6.Text += "High  Cs " + maxCs + " It" + maxIt + " Is" + maxIs;
            label10.Text += "Low  Cs " + minCs + " It" + minIt + " Is" + minIs;

        }

       

     


    }
}
