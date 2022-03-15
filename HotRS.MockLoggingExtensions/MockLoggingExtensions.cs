namespace HotRS.MockLoggingExtensions;
/// <summary>
/// A simple extension to simplify tehr Verification of specific log messages
/// </summary>
public static class MockLoggingExtensions
{
    /// <summary>
    /// The available comparison types
    /// </summary>
    public enum ComparisonType
    {
        Equals,
        Contains,
        StartsWith,
        EndsWith
    }

    public static void VerifyLog<T>(this Mock<ILogger<T>> mockLogger, Func<Times> times)
    {
        mockLogger.Verify(x => x.Log(
            It.IsAny<LogLevel>(),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
    }

//#pragma warning disable CS8602 // Dereference of a possibly null reference.
    /// <summary>
    /// An extension method for a generic MOQ Logger to verify if a given string was logged.
    /// Note: You must change the creation of the logger to Create<ILogger<LoggingTester>>(MockBehavior.Loose)
    /// Example:
    /// mockLogger.VerifyLogContent($"Order number { request.OrderNumber}: Invalid request recieved with errors", Times.Once, MockLoggerExtensions.ComparisonType.StartsWith);
    /// </summary>
    /// <typeparam name="T">A generic logger type</typeparam>
    /// <param name="mockLogger">A logger instance</param>
    /// <param name="value">The string to verify</param>
    /// <param name="times">The number of times it should be found</param>
    /// <param name="compType">The comparison type ([Equals], Contains, StartsWith, or EndsWith)</param>
    /// <param name="strComp">The string comparison modifier. Defualts to StringComparison.Ordinal (which is the .net default)</param>
    public static void VerifyLogContent<T>(this Mock<ILogger<T>> mockLogger, string value, Func<Times> times, ComparisonType compType = ComparisonType.Equals, StringComparison strComp = StringComparison.Ordinal)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(compType);
        switch (compType)
        {
            case ComparisonType.Equals:
                mockLogger.Verify(x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Equals(value, strComp)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                    times);
                break;
            case ComparisonType.Contains:
                mockLogger.Verify(x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains(value, strComp)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                    times);
                break;
            case ComparisonType.StartsWith:
                mockLogger.Verify(x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().StartsWith(value, strComp)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                    times);
                break;
            case ComparisonType.EndsWith:
                mockLogger.Verify(x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().EndsWith(value, strComp)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                    times);
                break;
        }
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
