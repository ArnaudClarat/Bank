using System.Text.Json;

public class BankStateService(string filePath)
{
    private readonly string _filePath = filePath;
    private static readonly JsonSerializerOptions s_writeOptions = new() { WriteIndented = true };

    public async Task<BankState> LoadStateAsync()
    {
        if (!File.Exists(_filePath))
        {
            // Créer un fichier vide s'il n'existe pas
            var emptyState = new BankState();
            await SaveStateAsync(emptyState);
            return emptyState;
        }

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<BankState>(json) ?? new BankState();
    }

    public async Task SaveStateAsync(BankState state)
    {
        var json = JsonSerializer.Serialize(state, s_writeOptions);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
