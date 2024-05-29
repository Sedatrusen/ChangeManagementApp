using ChangeManagementApp.Entities;
using System.Collections.Generic;

namespace ChangeManagementApp
{
    public static class StateList
    {
        public static List<State> States { get; private set; }

        static StateList()
        {
            States = new List<State>
            {
                new State("dev"),
                new State("test"),
                new State("preprod")
            };
        }

        public static void AddState(string stateName)
        {
            States.Add(new State(stateName));
        }
    }
}
