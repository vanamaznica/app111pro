using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Song
{
    public string name { get; set; }
    public string duration { get; set; }
    public string style { get; set; }
}

class Album
{
    public string name { get; set; }
    public string artist { get; set; }
    public int year { get; set; }
    public string duration { get; set; }
    public string studio { get; set; }

    public List<Song> songs { get; set; } = new List<Song>();

    public void Input()
    {
        Console.WriteLine("album name:");
        name = Console.ReadLine();

        Console.WriteLine("artist:");
        artist = Console.ReadLine();

        Console.WriteLine("year:");
        year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("duration:");
        duration = Console.ReadLine();

        Console.WriteLine("studio:");
        studio = Console.ReadLine();

        Console.WriteLine("number of songs:");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Song s = new Song();

            Console.WriteLine("song name:");
            s.name = Console.ReadLine();

            Console.WriteLine("song duration:");
            s.duration = Console.ReadLine();

            Console.WriteLine("song style:");
            s.style = Console.ReadLine();

            songs.Add(s);
        }
    }

    public void Print()
    {
        Console.WriteLine(name);
        Console.WriteLine(artist);
        Console.WriteLine(year);
        Console.WriteLine(duration);
        Console.WriteLine(studio);

        foreach (Song s in songs)
        {
            Console.WriteLine(s.name);
            Console.WriteLine(s.duration);
            Console.WriteLine(s.style);
        }
    } 
    public void Save()
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText("album.json", json);
    }

    public static Album Load()
    {
        string json = File.ReadAllText("album.json");
        return JsonSerializer.Deserialize<Album>(json);
    }
}

class Program
{
    static void Main()
    {
        Album album = new Album();

        album.Input();
        album.Print();
        album.Save();
        album = Album.Load();
        album.Print();
    }
}