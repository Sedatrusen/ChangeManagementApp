using System.Collections.Generic;
using ChangeManagementApp.Enums;

namespace ChangeManagementApp.Entities
{
    public class Change
    {
        public string Name { get; private set; }
        public State State { get; set; }
        public List<ChangeItem> Items { get; private set; }

        public Change(string name)
        {
            Name = name;
            State = StateList.States[0]; // Default state is the first one in the list
            Items = new List<ChangeItem>();
        }

        public void AddChangeItem(ChangeItem item)
        {
            Items.Add(item);
        }

        public void UpdateState()
        {
            foreach (var item in Items)
            {
                if (item.State != (ChangeItemState)Enum.Parse(typeof(ChangeItemState), $"{State.Name}Ready"))
                {
                    item.State = (ChangeItemState)Enum.Parse(typeof(ChangeItemState), $"{State.Name}Ready");
                }
            }
        }
    }
}
