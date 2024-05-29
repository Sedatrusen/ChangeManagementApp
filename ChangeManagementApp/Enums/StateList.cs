using ChangeManagementApp.Entities;
using System.Collections.Generic;

namespace ChangeManagementApp
{
    public static class StateList
    {
        public static List<String> ChangeStates { get; private set; }
        public static List<String> ChangeItemsStates { get; private set; }


        static StateList()
        {
            ChangeStates =
            [
               "dev",
               "testApproved",
               "test",
               "preprodApproved",
               "preprod"
            ];
            ChangeItemsStates =
          [
               "dev",
               "testReady",
               "test",
               "preprodReady",
               "preprod"
          ];
        }

        public static void AddState(string stateName, int order)
        {
            var newState = new State(stateName);
            ChangeStates.Insert(order, newState.stateApproved);
            ChangeStates.Insert(order+1,newState.Name);
            ChangeItemsStates.Insert(order, newState.stateReady);
            ChangeItemsStates.Insert(order+1,newState.Name);
            PrintStates();
        }
        static void PrintStates()
        {
            int maxLength = Math.Max(ChangeStates.Count, ChangeItemsStates.Count);

            Console.WriteLine("+----------------+----------------+");
            Console.WriteLine("| Change States  | Item States    |");
            Console.WriteLine("+----------------+----------------+");

            for (int i = 0; i < maxLength; i++)
            {
                string changeState = i < ChangeStates.Count ? ChangeStates[i] : "";
                string itemState = i < ChangeItemsStates.Count ? ChangeItemsStates[i] : "";

                Console.WriteLine($"| {changeState,-14} | {itemState,-14} |");
            }

            Console.WriteLine("+----------------+----------------+");
        }
        public static void DeleteState(int index)
        {
            ChangeStates.RemoveAt(index);
            ChangeStates.RemoveAt(index); // Remove Approved

            ChangeItemsStates.RemoveAt(index);
            ChangeItemsStates.RemoveAt(index); // Remove Ready
                                               
            PrintStates() ;
        }
    }
}
