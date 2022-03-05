# HotRS.MockLoggingExtensions
This nuget provides an extension to a MOQ Logger<T> object, which simplifies the context to verify the existence that a specified string was logged.

Example:

```c#
mockLogger.VerifyLogContent("expectedstring", Times.Once, MockLoggerExtensions.ComparisonType.StartsWith);
```

