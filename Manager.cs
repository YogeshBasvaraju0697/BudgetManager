using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager
{
    class Manager
    {

        //properties of Manager class
        private List<Transaction> transactions;
        string[] categories = new string[20];
        private double[] budgets = new double[20];
        private int categoryCount = 0;
        private int transactionCount = 0 ;

      //constructor
        public  Manager()
        {

            categories[0] = "Groceries";
            categories[1] = "Bills";
            categories[2] = "Salary";
            categories[3] = "shopping";
            categories[4] = "Transport";
            categories[5] = "Entertainment";
            categories[6] = "charity";
            categories[7] = "Eating Out";
            categories[8] = "holidays";
            categories[9] = "Personal Care";


            categoryCount = 10;
            transactions = new List<Transaction>();
            transactionCount = 0;


        }

        //Main menu method 
        public void manage()
        {
            int choice=8;
            do//used do- while loop to execute the menu
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("***** MENU *****");
                Console.ForegroundColor= ConsoleColor.DarkMagenta;
                Console.WriteLine("================");
                Console.ResetColor();
                Console.WriteLine("1-See List of Transaction.");
                Console.WriteLine("2-Enter New Transaction.");
                Console.WriteLine("3-Edit Transaction.");
                Console.WriteLine("4-Delete Transaction.");
                Console.WriteLine("5-See List of Category.");
                Console.WriteLine("6-Enter Budget.");
                Console.WriteLine("7-Track Progress.");
                Console.WriteLine("8-Exit.\n");

                //Eror handling if typed the invalid context
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException)//catching the error running manage method again
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid! Select from any of the provided options (eg. 1, 2, 3, 4.)\n");
                    Console.ResetColor();
                    continue;
                }

                //if else condition statement to do the right task
                if (choice == 8)
                    break;

                Console.WriteLine("------------------------\n");
                if (choice == 1)
                {
                    showTransactions();
                }
                else if (choice == 2)
                {
                    getTransaction();
                }
                else if (choice == 3)
                {
                    editTransaction();
                }
                else if (choice == 4)
                {
                    deleteTransaction();
                }
                else if (choice == 5)
                {
                    seeCategories();
                }
                else if (choice == 6)
                {
                    manageBudgets();
                }
                else if (choice == 7)
                {
                    trackProgress();
                }
                else
                if (choice <= 0 || choice > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid! Select from any of the provided options (eg. 1, 2, 3, 4.)\n");
                    Console.ResetColor();
                    Console.WriteLine("\n------------------------\n");
                }
            } while (true);
            
        }

        //void method to list the transaction
        public void showTransactions()
        {
            Console.WriteLine("Transaction#\tTransaction Amount\ttransaction Category\tTransaction Type\tNote");
            transactionCount = 1;
            foreach (Transaction item in transactions)
            {
                item.settransactionNum(transactionCount++);
                
                Console.WriteLine($"\t{item.gettransactionNum()}\t\t{item.getamount()}\t\t{item.getcategory()}\t\t {item.gettransactionType()}" + "\t\t"+
                                   $"\t{item.getnote()}");
            }
            Console.WriteLine();
        }


        //method to add the transaction
        public void getTransaction()
        {

            try
            {
                double amt;
                string type, cat, note;

                Console.Write("Transaction Amount: ");
                amt = double.Parse(Console.ReadLine());

              
                Console.WriteLine("Transaction Type(income or expense) ");
                
                type = Console.ReadLine();

                Console.WriteLine("\n==Categories==");
                for (int i = 0; i < categoryCount; i++)
                {
                    Console.WriteLine($"{categories[i]}");
                }
                Console.Write("\nSelect a Transaction Category: ");

                cat = Console.ReadLine();


                Console.Write("\nNote: ");
                note = Console.ReadLine();


                transactions.Add(new Transaction( ++transactionCount,amt, type, cat, note));
            }
            catch (System.FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input. Please try again..");
                Console.ResetColor();
            }


        }


        //
        public void editTransaction()
        {
            showTransactions();
            try
            {

                Console.Write("Which transaction you want to edit: ");
                int editNum = int.Parse(Console.ReadLine());
                --editNum;

                Console.Write("Transaction Amount: ");
                transactions.ElementAt(editNum).setamount(double.Parse(Console.ReadLine()));



                Console.Write("Transaction Type(income or expense): ");
                transactions.ElementAt(editNum).settransactionType(Console.ReadLine());



                Console.WriteLine("\n==Categories==\n");
                for (int i = 0; i < categoryCount; i++)
                {
                    Console.WriteLine($"{categories[i]}");
                }
                Console.Write("\nSelect a Transaction Category: ");



                transactions.ElementAt(editNum).setcategory(Console.ReadLine());



                Console.Write("\nNote: ");
                transactions.ElementAt(editNum).setnote(Console.ReadLine());

            }
            catch(System.FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input. Please try again..");
                Console.ResetColor();
                editTransaction();

            }

        }

           
       //method to delet the trnasaction
        public void deleteTransaction()
        {
         
            try
            {
                showTransactions();
                Console.Write("Which transaction you want to delete: ");
                int deleteNum = int.Parse(Console.ReadLine());
                --deleteNum;  // predecrement to compare with transactioncount
                transactions.RemoveAt(deleteNum);
                Console.WriteLine("Transaction Deleted.");

            }
            catch (System.ArgumentOutOfRangeException) 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input. Please try again..");
                Console.ResetColor();
                
                deleteTransaction();



            }
            catch(System.FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input. Please try again..");
                Console.ResetColor();

                deleteTransaction();


            }

        }


        //Method to show the categories and add the categories
        public void seeCategories()
        {
            Console.WriteLine("\n==Categories==\n");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{categories[i]}");
            }

            Console.WriteLine("Would you like to add the catagory");
            Console.WriteLine("Type Y/N");
            string record = Console.ReadLine();
             if (record == "Y" || record == "y")
            {
                Console.WriteLine("Specify the catagory name ");
                string cat = Console.ReadLine();

                categories.Append(cat);
               
            }
            else
            {
                Console.WriteLine("------------------------------------");
            }
            

           
        }


        //setting budget for each category
        public void manageBudgets()
        {
            for(int i=0;i<categoryCount;i++)
            {
                Console.Write($"Budget for '{categories[i]}': ");
                budgets[i] = double.Parse(Console.ReadLine());

                
            }
        }


        //executing the budget for each category
        public void trackProgress()
        {


            for (int i = 0; i < categoryCount; i++)
            {
                Console.WriteLine($"Budget for {categories[i]} is {budgets[i]}");
            }

        }
    }
}
