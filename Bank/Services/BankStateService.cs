using System.Text.Json;

public class BankStateService(string filePath = "")
{
    public required string FilePath { get; init; } = filePath;
    private static readonly JsonSerializerOptions s_writeOptions = new() { WriteIndented = true };

    public async Task<BankState> LoadStateAsync()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("bankState.json not found there, creating it");
            // Créer un fichier vide s'il n'existe pas
            var emptyState = new BankState();
            await SaveStateAsync(emptyState);
            return emptyState;
        }

        Console.WriteLine("Chargement des données");
        var json = await File.ReadAllTextAsync(FilePath);
        return JsonSerializer.Deserialize<BankState>(json) ?? new BankState();
    }

    public async Task SaveStateAsync(BankState state)
    {
        Console.WriteLine("Sauvegarde des données");
        string directory = Path.GetDirectoryName(FilePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        var json = JsonSerializer.Serialize(state, s_writeOptions);
        await File.WriteAllTextAsync(FilePath, json);
    }
}
