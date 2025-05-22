using System;
using System.Collections.Generic;

class SayaTubeVideo
{
    private static Random random = new Random();
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null) throw new ArgumentNullException("Title tidak boleh null.");
        if (title.Length > 200) throw new ArgumentException("Title tidak boleh lebih dari 200 karakter.");

        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0) throw new ArgumentException("Play count tidak boleh negatif.");
        if (count > 25000000) throw new ArgumentException("Play count maksimal 25.000.000 per panggilan.");

        if ((long)playCount + count > int.MaxValue)
            throw new OverflowException("Penambahan play count akan melebihi batas maksimum int.");

        playCount += count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}\n");
    }

    public int GetPlayCount()
    {
        return playCount;
    }

    public string GetTitle()
    {
        return title;
    }
}

class SayaTubeUser
{
    private static Random random = new Random();
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string username)
    {
        if (username == null) throw new ArgumentNullException("Username tidak boleh null.");
        if (username.Length > 100) throw new ArgumentException("Username tidak boleh lebih dari 100 karakter.");

        this.id = random.Next(10000, 99999);
        this.username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null) throw new ArgumentNullException("Video tidak boleh null.");
        if (video.GetPlayCount() >= int.MaxValue) throw new ArgumentException("Play count video terlalu besar.");

        uploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {username}");
        for (int i = 0; i < Math.Min(uploadedVideos.Count, 8); i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            Console.WriteLine($"  Play Count: {uploadedVideos[i].GetPlayCount()}");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Althafia");

            List<string> filmTitles = new List<string>
            {
                "Review Film Black Panther oleh Althafia",
                "Review Film Avengers: Endgame oleh Althafia",
                "Review Film Iron Man oleh Althafia",
                "Review Film Thor: Ragnarok oleh Althafia",
                "Review Film Spider-Man: No Way Home oleh Althafia",
                "Review Film Spider-Man: Homecoming oleh Althafia",
                "Review Film Guardians of the Galaxy oleh Althafia",
                "Review Film Spider-Man: Far from Home oleh Althafia",
                "Review Film Marvel's the Avengers oleh Althafia",
                "Review Film Shang-Chi and the Legend of the Ten Rings oleh Althafia"
            };

            foreach (var title in filmTitles)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
                try
                {
                    video.IncreasePlayCount(new Random().Next(1000, 5000));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error saat menambah play count: {e.Message}");
                }
            }

            user.PrintAllVideoPlaycount();
            Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");

            // Optional: Uji overflow
            SayaTubeVideo testVideo = new SayaTubeVideo("Test Overflow Video");
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    testVideo.IncreasePlayCount(int.MaxValue / 10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Overflow Detected: {e.Message}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unhandled Exception: {e.Message}");
        }
    }
}
