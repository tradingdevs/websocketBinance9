using apiBinance.Bussines;
using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Sockets;

internal static class Program
{
    private const string ApiKey = "";
    private const string Secret = "";
    static async Task Main(string[] args)
    {
        var credentials = new ApiCredentials(ApiKey, Secret);

        using IBinanceSocketClient binanceSocketClient = new BinanceSocketClient(options => {
            options.AutoReconnect = true;
            options.ApiCredentials = credentials;
        });


            try
            {
                using MarketBussines market = new MarketBussines(binanceSocketClient);

                // Iniciar la conexión al WebSocket
                await market.Start("LTCUSDT");
                Console.WriteLine("Presione Enter para terminar");
                Console.ReadLine();
            }
            catch (Exception ex) // Otros errores generales
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

    }
}
