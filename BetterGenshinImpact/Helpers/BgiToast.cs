using System;
using BetterGenshinImpact.Service.Interface;
using System.Windows;

namespace BetterGenshinImpact.Helpers;

public static class BgiToast
{
    public static void Success(string message)
        => Wpf.Ui.Violeta.Controls.Toast.Success(GetOwner(), TranslationHelper.T(message, MissingTextSource.Toast));

    public static void Information(string message)
        => Wpf.Ui.Violeta.Controls.Toast.Information(GetOwner(), TranslationHelper.T(message, MissingTextSource.Toast));

    public static void Warning(string message)
        => Wpf.Ui.Violeta.Controls.Toast.Warning(GetOwner(), TranslationHelper.T(message, MissingTextSource.Toast));

    public static void Error(string message)
        => Wpf.Ui.Violeta.Controls.Toast.Error(GetOwner(), TranslationHelper.T(message, MissingTextSource.Toast));

    private static FrameworkElement GetOwner()
    {
        return Application.Current?.MainWindow ?? throw new InvalidOperationException("Main window is not available.");
    }
}
