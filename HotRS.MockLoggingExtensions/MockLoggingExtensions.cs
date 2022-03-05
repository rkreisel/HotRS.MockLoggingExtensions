using Microsoft.Extensions.Logging;
using Moq;

namespace HotRS.MockLoggingExtensions
{
    public static class MockLoggingExtensions
    {
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

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public static void VerifyLogContent<T>(this Mock<ILogger<T>> mockLogger, string value, Func<Times> times, ComparisonType compType = ComparisonType.Equals)
        {
            ArgumentNullException.ThrowIfNull(value);
            ArgumentNullException.ThrowIfNull(compType);
            switch (compType)
            {
                case ComparisonType.Equals:
                    mockLogger.Verify(x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),

                        It.Is<It.IsAnyType>((v, _) => v.ToString().Equals(value)),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                        times);
                    break;
                case ComparisonType.Contains:
                    mockLogger.Verify(x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, _) => v.ToString().Contains(value)),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                        times);
                    break;
                case ComparisonType.StartsWith:
                    mockLogger.Verify(x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, _) => v.ToString().StartsWith(value)),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                        times);
                    break;
                case ComparisonType.EndsWith:
                    mockLogger.Verify(x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, _) => v.ToString().EndsWith(value)),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                        times);
                    break;
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}