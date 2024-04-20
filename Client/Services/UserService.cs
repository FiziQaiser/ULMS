using System;
using ULMS.Shared.Models;

using System;

public class UserService : IUserService
{
    private Account _loggedInUser;

    public event EventHandler<UserChangedEventArgs>? UserChanged;

    public UserService()
    {
        // Set a default value for _loggedInUser if needed
        _loggedInUser = new Account(); // Example: Creating a new empty Account
    }

    public void SetLoggedInUser(Account user)
    {
        _loggedInUser = user;
        OnUserChanged(new UserChangedEventArgs(user));
    }

    public Account GetLoggedInUser()
    {
        return _loggedInUser;
    }

    protected virtual void OnUserChanged(UserChangedEventArgs e)
    {
        UserChanged?.Invoke(this, e);
    }
}

