using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff_Tools
{
    public class Rule
    {
        Stack<string> ruleWizard;
        string completeRule = "";
        string lOrM = "";
        string controlType = "";

        public string GetCompleteRule() { return completeRule; }
        public void SetRuleWizard(Stack<string> input)
        {
            ruleWizard = input;
        }

        public string GetControlType() { return controlType; }
        public string returnLOrM()
        {
            return lOrM;
        }
        public void CreateRuleFromStack()
        {
            if (ruleWizard.Count < 4)
            {
                return;
            }
            int ruleWizardCount = ruleWizard.Count();
            for (var i = 0; i < ruleWizardCount; i++)
            {
                if (i == 0)
                {
                    completeRule = completeRule.Insert(0,ruleWizard.Peek());
                }

                if (i > 0)
                {
                    completeRule = completeRule.Insert(0, ruleWizard.Peek() + ",");
                }
                ruleWizard.Pop();
            }
            
        }
        
        public string CreateDisplayRule()
        {
            string[] ruleArray = completeRule.Split(',');
            string tempRule = "Control Type : " + ruleArray[0] + Environment.NewLine + "Machine Type : " + ruleArray[1] + Environment.NewLine + "Additional Criteria : " + ruleArray[2]; ;
            

            return tempRule;
        }

        public void CalcLOrM(Stack<string> inputStack)
        {
            if (inputStack.Count < 1)
            {
                return;
            }
            
            if (inputStack.Count > 1)
            {
                for (var i = 0; i < inputStack.Count() - 1; i++)
                {
                    inputStack.Pop();
                }
            }
            if (inputStack.Peek().Contains("|"))
            {
                int charPos = inputStack.Peek().IndexOf("|");
                lOrM = inputStack.Peek().Substring(4, 1);
                if (charPos > 6)
                {
                    lOrM = inputStack.Peek().Substring(charPos - 2, 1);
                }
                
                controlType = inputStack.Peek();
                return;
            }
            if (inputStack.Peek().Length > 6)
            {
                lOrM = inputStack.Peek().Substring(inputStack.Peek().Length - 2, 1);
                controlType = inputStack.Peek();
            }
            else
            {
                lOrM = inputStack.Peek().Substring(4, 1);
                controlType = inputStack.Peek();
            }
        }
    }
}
