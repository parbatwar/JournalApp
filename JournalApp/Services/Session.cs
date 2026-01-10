using JournalApp.Models;

namespace JournalApp.Services
{
    public class Session
    {
        public AppUser? CurrentUser { get; set; }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
