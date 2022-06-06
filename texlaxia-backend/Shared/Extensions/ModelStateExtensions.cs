using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Telaxia_Backend.Shared.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(m => m.Value.Errors)
            .Select(p => p.ErrorMessage)
            .ToList();
    }
}