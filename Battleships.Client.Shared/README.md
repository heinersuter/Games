# Generate Battleships API Client

1. Install dotnet tool Kiota
```bash
dotnet tool install microsoft.openapi.kiota
```

2. Run the Battleships.Server project to start the API server


3. Generate the client code
```bash
dotnet kiota generate --language CSharp --class-name BattleshipsClient --namespace-name Battleships.Client.Shared.Generated --openapi http://localhost:5600/openapi/v1.json --output Generated --exclude-backward-compatible
```