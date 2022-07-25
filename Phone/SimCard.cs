using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    public class SimCard
    {
        public Guid SimCardID;
        private SimCardStatuses simCardStatus;

        public SimCardStatuses SimCardStatus
        {
            get
            { 
                return simCardStatus; 
            }
            set
            {  
                simCardStatus = value;
                Notify?.Invoke(value.ToString(), SimCardID.ToString());
            }
        }

        public SimCard()
        {
            SimCardID = Guid.NewGuid();
        }

        public delegate void SimCardStatusChange(string status, string ID);
        public event SimCardStatusChange Notify;
    }

    public enum SimCardStatuses {Active, Inactive, Flight, Call}


}
