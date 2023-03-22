// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("ConsoleApp staring...");

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5239/success-request")
    .Build();

connection.On<string>("SuccessRequest", (message) => {
    Console.WriteLine(message);

    return Task.CompletedTask;
});

await connection.StartAsync();

Console.WriteLine("ConsoleApp started.");

while(true)
{
    await Task.Delay(1000);
}
