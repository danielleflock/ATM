using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    decimal balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, decimal balance)
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

    public decimal getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
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

    public void setBalance(decimal newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options: ");
            Console.WriteLine();
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Make a withdrawal");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine();
            Console.WriteLine("Enter deposit amount: ");
            Console.WriteLine();
            decimal deposit = decimal.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine();
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
            Console.WriteLine();
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine();
            Console.WriteLine("Enter withdrawal amount: ");
            Console.WriteLine();
            decimal withdrawal = decimal.Parse(Console.ReadLine());
            //check if user has enough for withdrawal
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine();
                Console.WriteLine("Here is your money, your new balance is " + currentUser.getBalance());
                Console.WriteLine();
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine();
            Console.WriteLine("Current balance: " + currentUser.getBalance());
            Console.WriteLine();
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4475284567390056", 1234, "Kalee", "Harris", 579.32m));
        cardHolders.Add(new cardHolder("7895348912874028", 5678, "Jessica", "Holden", 1368.47m));
        cardHolders.Add(new cardHolder("4510692050387734", 9012, "Cameron", "Olson", 739.21m));
        cardHolders.Add(new cardHolder("8603883528443510", 3456, "Nancy", "Smith", 3758.29m));
        cardHolders.Add(new cardHolder("3829557400185647", 7890, "Chris", "Johnson", 274.23m));

        //Prompt user
        Console.WriteLine("=================================");
        Console.WriteLine("Welcome to WorldWide ATM");
        Console.WriteLine("=================================");
        Console.WriteLine();
        Console.WriteLine("Please insert your debit card: ");
        Console.WriteLine();
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check user against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Please enter your pin: ");
        Console.WriteLine();
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check user against db           
                if (currentUser.getPin() == userPin) { break; }

                else {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect Pin. Please try again"); }
            }
            catch {
                Console.WriteLine();
                Console.WriteLine("Incorrect Pin. Please try again"); }
        }
        Console.WriteLine();
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName());
        Console.WriteLine();
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
            Console.WriteLine();
            Console.WriteLine("Thank you! Have a nice day!");
        
    }
}
