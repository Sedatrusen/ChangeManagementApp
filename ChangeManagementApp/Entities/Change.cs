
namespace ChangeManagementApp.Entities
{
    public class Change
    {
        public string Name { get; private set; }
        public int State { get; set; }
        public List<ChangeItem> Items { get; private set; }

        public Change(string name)
        {
            Name = name;
            State = 0; // Default state is the first one in the list
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
                    item.State +=1;
            }
        }
    }
}
