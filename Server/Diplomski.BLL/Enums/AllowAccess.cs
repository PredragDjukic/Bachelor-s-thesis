namespace Diplomski.BLL.Enums;

[Flags]
public enum AllowAccess
{
    Default             = 0b_0000_0001,
    NotEmailVerified    = 0b_0000_0010,
    NotPhoneVerified    = 0b_0000_0100,
    Deactivated         = 0b_0000_1000,

    All                 = NotEmailVerified | NotPhoneVerified | Deactivated
}
