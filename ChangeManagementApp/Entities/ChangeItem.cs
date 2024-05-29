using ChangeManagementApp.Enums;

namespace ChangeManagementApp.Entities
{
    public class ChangeItem
    {
        public string Name { get; set; }
        public ChangeItemState State { get; set; }

        public ChangeItem(string name)
        {
            Name = name;
            State = ChangeItemState.Dev;
        }
    }
}
