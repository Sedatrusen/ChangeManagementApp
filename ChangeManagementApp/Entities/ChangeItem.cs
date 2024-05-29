

namespace ChangeManagementApp.Entities
{
    public class ChangeItem
    {
        public string Name { get; set; }
        public int State { get; set; }

        public ChangeItem(string name)
        {
            Name = name;
            State = 0;
        }
    }
}
