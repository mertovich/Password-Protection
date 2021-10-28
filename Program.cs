using System;


namespace Password_Protection
{
    class Program
    {
        static void Main(string[] args)
        {
            String choice;
            char ch;
            
            Data data = new Data();
            DataManager dataManager = new DataManager();

            do
            {
                Console.WriteLine($"------password manager------");
                Console.WriteLine($"[1] Show my saved passwords");
                Console.WriteLine($"[2] Enter new password");
                Console.WriteLine($"[3] Search password");
                Console.WriteLine($"[4] Delete the password you want");
                Console.WriteLine($"Please select transaction number : ");
                choice = Convert.ToString(Console.ReadLine());
                Console.WriteLine(choice);

                switch (choice)
                {
                    case "1":
                        dataManager.readData();
                        break;
                    case "2":
                        Console.WriteLine($"Enter your password name : ");
                        data.name = Convert.ToString(Console.ReadLine());
                        Console.WriteLine($"Enter the password you want to save (must be at least 6 characters): ");
                        String password = Convert.ToString(Console.ReadLine());
                        if (password.Length >= 6)
                        {
                            data.password = password;
                            dataManager.addData(data);
                        }
                        else
                        {
                            Console.WriteLine($"The password you entered must be longer than 6 characters.\n");
                            Console.WriteLine($"Enter the password you want to save (must be at least 6 characters): ");
                            password = Convert.ToString(Console.ReadLine());
                            data.password = password;
                            dataManager.addData(data);
                        }
                        break;
                    case "3":
                        Console.WriteLine($"Enter the name of the password you want to search : ");
                        String select = Convert.ToString(Console.ReadLine());
                        dataManager.selectData(select);
                        break;
                    case "4":
                        dataManager.readData();
                        Console.WriteLine($"Enter the 'id' number of the data you want to delete:");
                        int selectRw = Convert.ToInt16(Console.ReadLine());
                        dataManager.deleteData(selectRw);
                        break;
                    default:
                        Console.WriteLine($"You have chosen an incorrect transaction.");
                        break;
                }
                
                Console.WriteLine($"Do you want to continue? [Y/n]");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == 'y');
          
            
            Console.WriteLine("App end");
        }
    }
}