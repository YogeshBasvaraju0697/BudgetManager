 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager
{
    class Transaction
    {
        //Proprties of transaction
        private int transactionNum;
        private double amount;
        private string transactionType;
        private string category;
        private string note;
        

        //Constructor for the class Transaction
        public Transaction(int transactionNum, double amount, string transactionType,
            string category,string note)
        {
            this.transactionNum = transactionNum;
            this.amount = amount;
            this.transactionType = transactionType;
            this.category = category;
            this.note = note;
        }
        //override Constructor for the class Transaction
        public Transaction()
        {

        }
        // method to set the transaction number
        public void settransactionNum(int trans)
        {
            transactionNum = trans;
        }
        // method to get the transaction number
        public int gettransactionNum()
        {
            return transactionNum;
        }
        // method to set the amount
        public void setamount(double amt)
        {
            amount = amt;
        }
        //method to get amount
        public double getamount()
        {
            return amount;
        }

        //method to set transactionType
        public void settransactionType(string type)
        {
            transactionType = type;
        }
        //method to get transactionType
        public string gettransactionType()
        {
            return transactionType;
        }

        //method to set category
        public void setcategory(string cat)
        {
            category = cat;
        }

        //method to get category
        public string getcategory()
        {
            return category;
        }

        //method to set note
        public void setnote(string not)
        {
            note = not;
        }

        //method to get note
        public string getnote()
        {
            return note;
        }
    }
}
