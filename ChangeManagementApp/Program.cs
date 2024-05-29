using ChangeManagementApp.Entities;

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

                Console.WriteLine("\nLütfen bir komut girin (durumekle, durumsil, sonrakidurum, itemekle, itemsil, sonrakiitemdurum, exit):");
                string command = Console.ReadLine().ToLower();
                Console.Clear(); // Konsolu temizle
                switch (command)
                {
                    case "durumekle":
                        AddNewState(change);
                        break;

                    case "durumsil":
                        DeleteState();
                        break;
                    case "sonrakidurum":
                        MoveToNextState(change);
                        break;                  

                    case "itemekle":
                        AddNewItem(change);
                        break;

                    case "sonrakiitemdurum":
                        ChangeItemState(change);
                        break;

                    case "itemsil":
                        DeleteItem(change);
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

        static void AddNewState(Change change)
        {
            if (change.State == 0)
            {
                Console.WriteLine("Yeni bir durum ekleyin:");
                string newState = Console.ReadLine() ?? "";

                int order;
                while (true)
                {
                    Console.WriteLine("Durumun hangi sırada olduğunu ekleyin:");
                    string orderInput = Console.ReadLine() ?? "";

                    if (int.TryParse(orderInput, out order) && order >= 1 && order <= StateList.ChangeStates.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçerli bir sıra numarası girin.");
                    }
                }

                StateList.AddState(newState, order);
            }
            else
            {
                Console.WriteLine("Değişiklik durumu 'dev' olmadığı için yeni drurum eklenemez.");
            }
        }

        static void DeleteState()
        {
            Console.WriteLine("Silmek istediğiniz durumu seçin:");
            for (int i = 2; i < StateList.ChangeStates.Count; i += 2)
            {
                Console.WriteLine($"{i / 2}. {StateList.ChangeStates[i]}");
            }

            int index;
            while (true)
            {
                Console.WriteLine("Silmek istediğiniz durumun numarasını girin:");
                string input = Console.ReadLine();
                Console.Clear(); // Konsolu temizle
                if (int.TryParse(input, out index) && index >= 0 && index * 2 < StateList.ChangeStates.Count)
                {
                    StateList.DeleteState((index * 2)-1);
                    break;
                }
                else
                {
                    Console.WriteLine("Geçerli bir sıra numarası girin.");
                }
            }
        }
        static void MoveToNextState(Change change,bool isAll=false)
        {
            int currentStateIndex = change.State;
            if (currentStateIndex % 2 != 0 && !isAll)
            {
                Console.WriteLine("Durum değiştirebilmek için ilk önce itemlerin durumları değişmelidir.");
            }
            else if (currentStateIndex < StateList.ChangeStates.Count - 1)
            {
                int nextState =currentStateIndex + 1;
                change.State = nextState;
                if (!isAll) 
                {
                    change.UpdateState(); 
                }
              
                Console.WriteLine($"Değişiklik durumu {StateList.ChangeStates[nextState]} olarak güncellendi.");
            }
            else
            {
                Console.WriteLine("Bu değişiklik artık son durumda.");
            }
        }
        static void ChangeItemState(Change change)
        {
            while (true)
            {
                ShowChangeAndItems(change);

                Console.WriteLine("Durumunu değiştirmek istediğiniz öğenin numarasını seçin (çıkmak için 'exit' yazın):");
                string input = Console.ReadLine();
                Console.Clear(); // Konsolu temizle

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (int.TryParse(input, out int index) && index-1 >= 0 && index-1 < change.Items.Count)
                {
                    ChangeItem item = change.Items[index-1];
                    int currentStateIndex = item.State;

                    if (currentStateIndex % 2 == 1 && currentStateIndex < StateList.ChangeItemsStates.Count - 1)
                    {
                        item.State = currentStateIndex + 1;
                        Console.WriteLine($"Öğe {item.Name} durumu {StateList.ChangeItemsStates[ item.State]} olarak güncellendi.");

                        // Tüm öğelerin durumu kontrol edilir
                        if (AllItemsInEvenState(change.Items))
                        {
                            MoveToNextState(change,true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu öğenin durumu değiştirilemez.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçerli bir numara girin.");
                }
            }
        }

        static bool AllItemsInEvenState(List<ChangeItem> items)
        {
            foreach (var item in items)
            {
                int stateIndex = item.State;
                if (stateIndex % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void AddNewItem(Change change)
        {
            if (change.State == 0)
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
        static void DeleteItem(Change change)
        {
            Console.WriteLine("Silmek istediğiniz öğenin numarasını seçin:");
            for (int i = 0; i < change.Items.Count; i++)
            {
                Console.WriteLine($"{i+1}. {change.Items[i].Name}");
            }

            int index;
            while (true)
            {
                Console.WriteLine("Silmek istediğiniz öğenin numarasını girin:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out index) && index >= 0 && index < change.Items.Count)
                {
                    change.Items.RemoveAt(index-1);
                    Console.WriteLine("Öğe başarıyla silindi.");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçerli bir numara girin.");
                }
            }
        }


        static void ShowChangeAndItems(Change change)
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine($"Değişiklik Durumu: {StateList.ChangeStates[change.State]}");

            Console.WriteLine("Değişiklik Ögeleri Durumu:");
            Console.WriteLine("+----+--------------------------+----------------+");
            Console.WriteLine("| No | Değişiklik Öğesi         | Durum          |");
            Console.WriteLine("+----+--------------------------+----------------+");

            for (int i = 0; i < change.Items.Count; i++)
            {
                var item = change.Items[i];
                Console.WriteLine($"| {i+1,-2} | {item.Name,-24} | {StateList.ChangeItemsStates[item.State],-14} |");
            }

            Console.WriteLine("+----+--------------------------+----------------+\n\n\n");
        }

    }
}
