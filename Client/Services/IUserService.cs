using System;

namespace ULMS.Shared.Models
{
    public interface IUserService
    {
        event EventHandler<UserChangedEventArgs> UserChanged;

        void SetLoggedInUser(Account user);
        Account GetLoggedInUser();
    }

    public class UserChangedEventArgs : EventArgs
    {
        public Account User { get; }

        public UserChangedEventArgs(Account user)
        {
            User = user;
        }
    }
}