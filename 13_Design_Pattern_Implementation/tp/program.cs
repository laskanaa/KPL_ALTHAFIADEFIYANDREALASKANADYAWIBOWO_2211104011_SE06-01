public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string message);
}

public class NewsPublisher : ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

public class SubscriberA : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Subscriber A received: {message}");
    }
}

public class SubscriberB : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Subscriber B received: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var publisher = new NewsPublisher();
        var sub1 = new SubscriberA();
        var sub2 = new SubscriberB();

        publisher.Attach(sub1);
        publisher.Attach(sub2);

        publisher.Notify("Berita hari ini: Cuaca cerah!");

        publisher.Detach(sub1);
        publisher.Notify("Berita kedua: Hujan deras!");
    }
}