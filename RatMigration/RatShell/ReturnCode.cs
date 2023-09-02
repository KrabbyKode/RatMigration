namespace RatMigration.RatShell
{
    // Define an enumeration named 'ReturnCode' to represent various return status codes.
    public enum ReturnCode
    {
        Unknown = -1,           // Represents an unknown or undefined return code.
        Success = 0,            // Represents a successful execution or operation.
        CommandNotFound = 1,    // Represents that a command was not found or does not exist.
        CommandExists = 2,      // Represents that a command already exists.
        NotEnoughArgs = 3,      // Represents that there are not enough command arguments provided.
        TooManyArgs = 4,        // Represents that there are too many command arguments provided.
    }
}
