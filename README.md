MentalDesk.AsyncVoid
====================

This package allows you to catch exceptions from `async void` methods, rather than let them crash your application.

For a full explanation, see:
- https://www.jamescrosswell.dev/posts/catching-async-void-exceptions/

## Installation

To get started, add `MentalDesk.AsyncVoid` to your project by running the following command:

```bash
dotnet add package MentalDesk.AsyncVoid
```

## Usage

Most typically, you'd use this if you needed to run some asynchronous code from within an event handler in a UI application (such as WinForms, WinUI or UWP). In that case, you'd need to change the event handler to be an async void :-(

```csharp

```