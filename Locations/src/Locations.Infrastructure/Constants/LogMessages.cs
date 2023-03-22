using Locations.Domain.Abstractions;

namespace Locations.Infrastructure.Constants;

public class LogMessages
{
    public partial class Error
    {
        public static string ErrorWhenCallingProvider(string provider) => $"Something went wrong when calling external Location provider. Provider={provider}";

        public const string DatabaseErrorOnSaving =
            "An error ocurred when trying to save or update new records in database.";

        public const string DatabaseErrorOnReading = "An error ocurred when trying to retrieve records from dataase.";
    }
    
    public partial class Info
    {
        public static string EntityInserted<TEntity>(TEntity entity) where TEntity : Entity=> $"New Entity={typeof(TEntity).Name} inserted wih Id: {entity.Id}";
    }
}