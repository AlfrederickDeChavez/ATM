using System;
using System.Diagnostics.Contracts;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum() 
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName() 
    {
        return lastName;
    }

    public double getBalance() 
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Enter amount to deposit: ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Enter amount to withdraw: ");
            double withdrawal = double.Parse(Console.ReadLine());
            // Check if the user has enough money

            if (currentUser.getBalance() > withdrawal)
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
                Console.WriteLine("You are good to go! Thank you.");

            }

            else
            {
                Console.WriteLine("Insuffucient Balance :(");
            }
        }

        void balance(cardHolder currentUser) 
        {
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("2354671890475893", 1234, "Eren", "Jaeger", 150.31));
        cardHolders.Add(new cardHolder("5454264520475893", 4321, "Annie", "Leonhart", 321.13));
        cardHolders.Add(new cardHolder("3454679876545893", 9999, "Levi", "Ackerman", 105.59));
        cardHolders.Add(new cardHolder("4764676790475893", 2468, "Erwin", "Smith", 851.85));
        cardHolders.Add(new cardHolder("7254046262675893", 4826, "Pieck", "Finger", 54.27));

        //Prompt user
        Console.WriteLine("Welcome to ATM on Titan");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our database

                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else 
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                }

            }

            catch 
            {
                Console.WriteLine("Card not recognized. Please try again.");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if(currentUser.getPin() == userPin) { break; }
                else 
                {
                    Console.WriteLine("Incorrect PIN. Please try again. ");
                }
            }

            catch 
            {
                Console.WriteLine("Incorrect PIN. Please try again. ");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try 
            {
                option = int.Parse(Console.ReadLine());
            }

            catch {
                Console.WriteLine("Invalid number. ");
            }

            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        } while(option != 4);

        Console.WriteLine("Thank you have a nice day!");
    }
}