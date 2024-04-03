// See https://aka.ms/new-console-template for more information

using MentalDesk.AsyncVoid;

AsyncVoid.RunSafely(AsyncTask1, exception => Console.WriteLine("Caught one!"));
AsyncVoid.RunSafely(AsyncTask2, exception => Console.WriteLine("Caught another!"));

// Block so we can wait for async operations to complete
Console.WriteLine("Press Enter to exit");
Console.ReadLine();
Console.WriteLine("Bye!");

static async void AsyncTask1()
{
    await Task.Delay(200);
    throw new Exception("Exceptional");
}

static async void AsyncTask2()
{
    await Task.Delay(200);
    throw new Exception("Super exceptional");
}