using HotRS.MockLoggingExtensions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using TestApp;

namespace UnitTests
{
    [TestFixture]
    public class LoggingTesterTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<LoggingTester>> mockLogger;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<LoggingTester>>(MockBehavior.Loose);
        }

        private LoggingTester CreateLoggingTester()
        {
            return new LoggingTester(this.mockLogger.Object);
        }
        #region Base
        [Test]
        public void LogError_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLog(Times.Once);
        }
        #endregion

        #region Equals
        [Test]
        public void LogError_Equals_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"Error", Times.Once, MockLoggingExtensions.ComparisonType.Equals);
        }

        [Test]
        public void LogError_Equals_IgnoreCase_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"ERROR", Times.Once, MockLoggingExtensions.ComparisonType.Equals, StringComparison.OrdinalIgnoreCase);
        }
        #endregion

        #region Contains
        [Test]
        public void LogError_Contains_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"Error", Times.Once, MockLoggingExtensions.ComparisonType.Contains);
        }

        [Test]
        public void LogError_Contains_IgnoreCase_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"ERROR", Times.Once, MockLoggingExtensions.ComparisonType.Contains, StringComparison.OrdinalIgnoreCase);
        }
        #endregion

        #region StartsWith
        [Test]
        public void LogError_StartsWith_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"Error", Times.Once, MockLoggingExtensions.ComparisonType.StartsWith);
        }

        [Test]
        public void LogError_StartsWith_IgnoreCase_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"ERROR", Times.Once, MockLoggingExtensions.ComparisonType.StartsWith, StringComparison.OrdinalIgnoreCase);
        }
        #endregion

        #region EndsWith
        [Test]
        public void LogError_EndsWithh_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"Error", Times.Once, MockLoggingExtensions.ComparisonType.EndsWith);
        }

        [Test]
        public void LogError_EndsWith_IgnoreCase_Succeeds()
        {
            // Arrange
            var loggingTester = this.CreateLoggingTester();
            string message = "Error";

            // Act
            loggingTester.LogError(message);

            // Assert
            mockLogger.VerifyLogContent($"ERROR", Times.Once, MockLoggingExtensions.ComparisonType.EndsWith, StringComparison.OrdinalIgnoreCase);
        }
        #endregion
    }
}
