using G04Telemetry;
 void main()
{
    Tracker.Init("Testeo",10);
    bool end = false;
    UInt32 n =6;
    Tracker.Instance().startSession();
    while (!end)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.Clear();
        //Como se llama cuando le das al input se enviara cada 10 teclas pero en el de verdad ira por tiempo que es como esta programado
        Tracker.Instance().update(1);
        switch (key.KeyChar)
        {
            case 'a':
                Console.WriteLine("Se añade el evento: " + n);
                Tracker.Instance().addEvent(new BaseEvent(n++));
                break;
            case 'd':
                BaseEvent bE = Tracker.Instance().removeEvent();
                Console.WriteLine("Se ha eliminado el primer evento que era: " + bE.getIDEvent() + " con fecha " + bE.getTimeStamp());
                break;
            case 'c':
                Console.WriteLine("Quedan: " + Tracker.Instance().getNumberOFEvents());
                break;
            case 's':
                Tracker.Instance().startSession();
                break;
            case 'l':
                Queue<BaseEvent> events = Tracker.Instance().getEvents();
                while (events.Any())
                {
                    Console.WriteLine(events.Dequeue().getIDEvent());
                }
                break;

            default:
                if (key.Key == ConsoleKey.Escape)
                    end = true;
                break;
        }

    }
    Console.WriteLine("Fin del programa");
}

main();
