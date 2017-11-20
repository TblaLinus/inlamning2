using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Event
{
    class AfterDateUpdateEvent : PubSubEvent<AfterDateUpdateEventArgs>
    {
    }

    public class AfterDateUpdateEventArgs
    {
        public int Id { get; set; }
    }
}
