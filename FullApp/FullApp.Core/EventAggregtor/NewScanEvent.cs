using FullApp.Core.SystemEventsArgs;
using Prism.Events;

namespace FullApp.Core.EventAggregtor
{
    public class NewScanEvent : PubSubEvent<KeyboardEventArgs> {}
}
