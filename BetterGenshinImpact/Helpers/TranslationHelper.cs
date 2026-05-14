using System;
using BetterGenshinImpact.Service.Interface;

namespace BetterGenshinImpact.Helpers;

public static class TranslationHelper
{
    public static string T(string text, MissingTextSource source = MissingTextSource.Unknown)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        try
        {
            return App.GetService<ITranslationService>()?.Translate(text, TranslationSourceInfo.From(source)) ?? text;
        }
        catch
        {
            return text;
        }
    }

    public static string Format(string template, MissingTextSource source, params object?[] args)
    {
        var translatedTemplate = T(template, source);
        if (args.Length == 0)
        {
            return translatedTemplate;
        }

        var translatedArgs = new object?[args.Length];
        for (var i = 0; i < args.Length; i++)
        {
            translatedArgs[i] = args[i] is string text ? T(text, source) : args[i];
        }

        try
        {
            return string.Format(translatedTemplate, translatedArgs);
        }
        catch (FormatException)
        {
            return translatedTemplate;
        }
    }

    public static string TranslateMultiline(string text, MissingTextSource source)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var lines = text.Replace("\r\n", "\n").Split('\n');
        for (var i = 0; i < lines.Length; i++)
        {
            lines[i] = T(lines[i], source);
        }

        return string.Join(Environment.NewLine, lines);
    }
}
