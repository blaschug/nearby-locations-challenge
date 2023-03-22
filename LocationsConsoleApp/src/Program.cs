// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("ConsoleApp staring...");

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5001/success-request")
    .WithAutomaticReconnect()
    .Build();

connection.On<string>("SuccessRequest", (message) => {
    Console.WriteLine("Successfully request done: \n" + message);

    return Task.CompletedTask;
});

try
{
    await connection.StartAsync();
    
    Console.WriteLine("ConsoleApp started and listening.");

    while(true)
    {
        await Task.Delay(1000);
    }
}
catch (Exception e)
{
    Console.WriteLine("WebApi should be running before run this one.");
}
