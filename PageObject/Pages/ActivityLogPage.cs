using PageObject.CustomElements.ListElements;

namespace PageObject.Pages
{
    public class ActivityLogPage : HomePage
    {
        public ItemsList<ActivityLog> ActivityLogList => DefaultItemsList<ActivityLog>();
    }
}
