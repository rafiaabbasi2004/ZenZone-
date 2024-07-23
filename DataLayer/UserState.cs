// UserState.cs
using System;

public class UserState
{
    public bool IsLoggedIn { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }

    public void LogIn(string email, string firstName)
    {
        Email = email;
        FirstName = firstName;
        IsLoggedIn = true;
    }

    public void LogOut()
    {
        Email = string.Empty;
        FirstName = null;
        IsLoggedIn = false;
    }
    private List<string> playedMedia = new List<string>();

    public async Task LogPlayedMedia(string media)
    {
        if (!playedMedia.Contains(media))
        {
            playedMedia.Add(media);
            // Optionally, save the played media to a database or persistent storage
            await SavePlayedMediaToDatabase();
        }
    }

    public List<string> GetPlayedMedia()
    {
        return playedMedia ?? new List<string>(); // Ensure playedMedia is never null
    }

    private Task SavePlayedMediaToDatabase()
    {
        // Implement saving logic here
        return Task.CompletedTask;
    }
}