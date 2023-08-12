using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum,int pin, string firstName, string lastName, double balance)
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
            Console.WriteLine("\nPlease choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you for chosing us. Your new balance is: {currentUser.getBalance()}");
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw: ");
            double withdrawl = Double.Parse(Console.ReadLine());
            // Check if user has enough money
            if (currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            { 
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("You're good to go! Thank you.");
            }
        }
        
        void balance(cardHolder currentUser)
        {
            Console.WriteLine($"Your current balance is: {currentUser.getBalance()}");
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("453277281827395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("453277236176485", 4321, "Michelle", "Smith", 324.59));
        cardHolders.Add(new cardHolder("783458341347823", 9999, "Marcos", "Silva", 482.13));
        cardHolders.Add(new cardHolder("376417349834659", 7890, "William", "Jones", 500.95));
        cardHolders.Add(new cardHolder("577732984330238", 8492, "Ashley", "Willson", 57.50));

        // Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("\nPlease insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not reconized. Please try again."); }
            }
            catch { Console.WriteLine("Card not reconized. Please try again."); }
        }
        
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against our db
                if(currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorret pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorret pin. Please try again."); }
        }

        Console.WriteLine($"\nWelcome {currentUser.getFirstName()}!");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { Console.Clear(); deposit(currentUser); }
            else if(option == 2) { Console.Clear(); withdraw(currentUser); }
            else if(option == 3) { Console.Clear(); balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day.");
    }
}