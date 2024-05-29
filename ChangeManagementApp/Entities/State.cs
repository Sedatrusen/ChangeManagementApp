using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeManagementApp.Entities
{
    public class State(string stateName)
    {
        public string Name = stateName;
        public string stateReady = stateName + "Ready";
        public string stateApproved = stateName + "Approved";
    }
}
