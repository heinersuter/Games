using System.Text.Json;
using Battleships.Client.Shared.Generated;
using Battleships.Client.Shared.Generated.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

var adapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider())
{
    BaseUrl = "http://localhost:5600"
};

var client = new BattleshipsClient(adapter);

var game1 = await client.Game.Join.PostAsync(new PostGameJoinRequest { PlayerName = "Alice" });
Console.WriteLine($"Status: '{game1.Status}' You: '{game1.You.Name}' Opponent: '{game1.Opponent?.Name}'");

var game2 = await client.Game.Join.PostAsync(new PostGameJoinRequest { PlayerName = "Bob" });
Console.WriteLine($"Status: '{game2.Status}' You: '{game2.You.Name}' Opponent: '{game2.Opponent?.Name}'");

game1 = await client.Game.Ships.PostAsync(new PostShipsRequest
    {
        Ships =
        [
            new ShipDto { Size = 1, Cells = [new CellLocationDto { Column = "A", Row = 1 }] },
            new ShipDto
            {
                Size = 2,
                Cells = [new CellLocationDto { Column = "C", Row = 1 }, new CellLocationDto { Column = "C", Row = 2 }],
            },
        ],
    },
    p => p.QueryParameters.PlayerSecret = game1.You.Secret
);
Console.WriteLine($"Status: '{game1.Status}' You: '{game1.You.Name}' Opponent: '{game1.Opponent?.Name}'");

game2 = await client.Game.Ships.PostAsync(new PostShipsRequest
    {
        Ships =
        [
            new ShipDto { Size = 1, Cells = [new CellLocationDto { Column = "A", Row = 1 }] },
            new ShipDto
            {
                Size = 2,
                Cells = [new CellLocationDto { Column = "C", Row = 1 }, new CellLocationDto { Column = "C", Row = 2 }],
            },
        ],
    },
    p => p.QueryParameters.PlayerSecret = game2.You.Secret
);
Console.WriteLine($"Status: '{game2.Status}' You: '{game2.You.Name}' Opponent: '{game2.Opponent?.Name}'");
