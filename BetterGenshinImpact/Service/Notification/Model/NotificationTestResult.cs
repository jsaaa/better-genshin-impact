using BetterGenshinImpact.Helpers;
using BetterGenshinImpact.Service.Interface;

namespace BetterGenshinImpact.Service.Notification.Model;

public class NotificationTestResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;

    public static NotificationTestResult Success()
    {
        return new NotificationTestResult
        {
            IsSuccess = true,
            Message = TranslationHelper.T("通知成功", MissingTextSource.Notification)
        };
    }

    public static NotificationTestResult Error(string message)
    {
        return new NotificationTestResult
        {
            IsSuccess = false,
            Message = TranslationHelper.T(message, MissingTextSource.Notification)
        };
    }
}
