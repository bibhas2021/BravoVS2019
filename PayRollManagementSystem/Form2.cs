using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace PayRollManagementSystem
{
    public partial class Form2 : Form
    {

        System.Collections.Generic.Stack operandStack;
System.Collections.Generic.Stack operatorStack ; 
       
/* 
* FUNCTIONS
*/
// Public Constructor
//public Expression();
// Public Accessor Functions
public string ExpressionString();
public int Result();
// Public Interface Functions 
// for Expression Solving
public int SolveExpression();

// Private Functions

private bool precedence(string oper1, string oper2);
private bool isdigit(string symbol) ;
private int power(int a , int n );
private int operate(string symbol, int opnd1, int opnd2);
        public Form2()
        {
            InitializeComponent();
        }

        public void PostFix()
        {
            int index = 0;
            string c = "";
            string topSymb = "";
            this.postFixString = "";
            while (index < this.ExpressionString.Length)
            {
                c = this.expressionString.Substring(index, 1);
                if (isdigit(c))
                {
                    this.operandStack.Push(c);
                    this.postFixString += this.operandStack.Peek().ToString();
                }
                else
                {
                    while (this.operatorStack.Count != 0 &&
                    this.precedence(this.operatorStack.Peek().ToString(), c))
                    {
                        if ((this.operatorStack.Peek().ToString() == "(") ||
                        (this.operatorStack.Peek().ToString() == ")"))
                        {
                            topSymb = this.operatorStack.Pop().ToString();
                            continue;
                        }
                        else
                        {
                            topSymb = this.operatorStack.Pop().ToString();
                            this.operandStack.Push(topSymb);
                            this.postFixString += this.operandStack.Peek().ToString();
                        }// end of Stack Peek else
                    }// end of while 
                    this.operatorStack.Push(c);
                }//end of isdigit() else 
                index++;
            } // end of while 
            int nochange = 0;
            while (this.operatorStack.Count != 0)
            {
                if ((this.operatorStack.Peek().ToString() == "(") ||
                (this.operatorStack.Peek().ToString() == ")"))
                {
                    topSymb = this.operatorStack.Pop().ToString();
                    continue;
                }
                else
                {
                    topSymb = this.operatorStack.Pop().ToString();
                    this.operandStack.Push(topSymb);
                    this.postFixString += this.operandStack.Peek().ToString();
                }// end of StackPeek else 
            }// end of while 
        }//end of PostFix()

        private int Evaluate()
        {
            string c = "";
            int opnd1 = 0, opnd2 = 0, dataValue = 0;
            int index = 0;
            this.operandStack = new Stack();
            while (index < this.postFixString.Length)
            {
                c = this.postFixString.Substring(index, 1);
                if (isdigit(c))
                {
                    this.operandStack.Push(c);
                } // end of if(isdigit)
                else
                {
                    try
                    {
                        opnd2 = Int32.Parse(this.operandStack.Pop().ToString());
                        opnd1 = Int32.Parse(this.operandStack.Pop().ToString());
                        if (opnd1 == 0 && opnd2 == 0)
                        {
                            dataValue = 0;
                        }
                        else
                        {
                            dataValue = operate(c, opnd1, opnd2);
                        } // end of try 
                    }
                    catch
                    {
                    }
                    this.operandStack.Push(dataValue);
                } //end of isdigit(else)
                index++;
            } //end of while
            return dataValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expressionString = textBox1.Text;
            PostFix();
           result= Evaluate();
           MessageBox.Show(result);
        } // end of Evaluate() 
    }
}