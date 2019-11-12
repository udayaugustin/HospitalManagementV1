using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.Model.RequestModel
{
    public class UserUpdate
    {
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string AppId { get; set; }

        public string UserStatus { get; set; }

        public DateTimeOffset ActivateDate { get; set; }

        public DateTimeOffset ExpireDate { get; set; }
    }
}
