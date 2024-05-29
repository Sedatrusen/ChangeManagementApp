using ChangeManagementApp.Entities;
using ChangeManagementApp.Enums;

namespace ChangeManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var change = new Change("Örnek Değişiklik");

            change.AddChangeItem(new ChangeItem("Örnek Değişiklik Ögesi 1"));
            change.AddChangeItem(new ChangeItem("Örnek Değişiklik Ögesi 2"));
            change.AddChangeItem(new ChangeItem("Örnek Değişiklik Ögesi 3"));

            PrintWelcomeMessage();

            while (true)
            {
                ShowChangeAndItems(change);

                Console.WriteLine("\nLütfen bir komut girin (addstate, nextstate, statehazir, stateonaylandi, ekle, exit):");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "addstate":
                        AddNewState();
                        break;

                    case "nextstate":
                        MoveToNextState(change);
                        break;

                    case "statehazir":
                        UpdateItemState(change, $"{change.State.Name}Ready");
                        break;

                    case "stateonaylandi":
                        UpdateItemState(change, $"{change.State.Name}Approved");
                        break;

                    case "ekle":
                        AddNewItem(change);
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Geçersiz komut.");
                        break;
                }
            }
        }

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*                                         *");
            Console.WriteLine("*           CHANGE MANAGEMENT APP         *");
            Console.WriteLine("*                                         *");
            Console.WriteLine("*******************************************\n");
        }

        static void AddNewState()
        {
            Console.WriteLine("Yeni bir durum ekleyin:");
            string newState = Console.ReadLine();
            StateList.AddState(newState);
        }

        static void MoveToNextState(Change change)
        {
            int currentStateIndex = StateList.States.FindIndex(s => s.Name == change.State.Name);

            if (currentStateIndex < StateList.States.Count - 1)
            {
                State nextState = StateList.States[currentStateIndex + 1];
                change.State = nextState;
                change.UpdateState();
                Console.WriteLine($"Değişiklik durumu {nextState.Name} olarak güncellendi.");
            }
            else
            {
                Console.WriteLine("Bu değişiklik artık son durumda.");
            }
        }

        static void UpdateItemState(Change change, string itemState)
        {
            foreach (var item in change.Items)
            {
                item.State = (ChangeItemState)Enum.Parse(typeof(ChangeItemState), itemState);
            }

            Console.WriteLine($"Tüm değişiklik ögeleri durumu {itemState} olarak güncellendi.");
        }

        static void AddNewItem(Change change)
        {
            if (change.State.Name == "dev")
            {
                Console.WriteLine("Yeni bir değişiklik öğesi ekleyin:");
                string newItemName = Console.ReadLine();
                change.AddChangeItem(new ChangeItem(newItemName));
            }
            else
            {
                Console.WriteLine("Değişiklik durumu 'dev' olmadığı için yeni öğe eklenemez.");
            }
        }

        static void ShowChangeAndItems(Change change)
        {
            Console.WriteLine($"Değişiklik Durumu: {change.State.Name}");

            Console.WriteLine("Değişiklik Ögeleri Durumu:");
            Console.WriteLine("+--------------------------+----------------+");
            Console.WriteLine("| Değişiklik Öğesi         | Durum          |");
            Console.WriteLine("+--------------------------+----------------+");

            foreach (var item in change.Items)
            {
                Console.WriteLine($"| {item.Name,-24} | {item.State,-14} |");
            }

            Console.WriteLine("+--------------------------+----------------+");
        }
    }
}
