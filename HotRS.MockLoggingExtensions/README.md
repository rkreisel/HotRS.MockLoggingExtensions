# HotRS.MockLoggingExtensions
This nuget provides an extension to a MOQ Logger<T> object, which simplifies the context to verify the existence that a specified string was logged.

Example:

```c#
mockLogger.VerifyLogContent("expectedstring", Times.Once, MockLoggerExtensions.ComparisonType.StartsWith);
```

Note: You must change the creation of the logger to:

```c#
Create<ILogger<classname>>(MockBehavior.Loose)
```

Follow/Contribute to the project:
https://github.com/rkreisel/HotRS.MockLoggingExtensions
