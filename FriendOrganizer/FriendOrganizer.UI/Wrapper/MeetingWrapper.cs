using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Wrapper
{
    public class MeetingWrapper : ModelWrapper<Meeting>
    {
        protected readonly IEventAggregator EventAggregator;

        public MeetingWrapper(Meeting model, IEventAggregator eventAggregator) : base(model)
        {
            EventAggregator = eventAggregator;
        }

        public int Id { get { return Model.Id; } }

        public string Title
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public DateTime DateFrom
        {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
                if (DateTo < DateFrom)
                {
                    DateTo = DateFrom;
                }
                EventAggregator.GetEvent<AfterDateUpdateEvent>().Publish(new AfterDateUpdateEventArgs { Id= Id});
            }
        }

        public DateTime DateTo
        {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
                if (DateTo < DateFrom)
                {
                    DateFrom = DateTo;
                }
                EventAggregator.GetEvent<AfterDateUpdateEvent>().Publish(new AfterDateUpdateEventArgs { Id = Id });
            }
        }
    }
}
