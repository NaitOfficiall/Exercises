using System;

enum AccountType {
    Guest,
    User,
    Moderator
}

// TODO: define the 'Permission' enum
[Flags]
enum Permission {
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch(accountType)
        {
            case AccountType.Guest:
                return Permission.Read;
            case AccountType.User:
                return Permission.Read | Permission.Write;
            case AccountType.Moderator:
                return Permission.Read| Permission.Write| Permission.Delete;
            default:
                return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
       return current.HasFlag(check);
    }
}
