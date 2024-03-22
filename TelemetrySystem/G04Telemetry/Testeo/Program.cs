using G04Telemetry;
 void main()
{
    Tracker.Init();
    bool end = false;
    Int32 n =0;
    while (!end)
    {
      ConsoleKeyInfo key= Console.ReadKey();
        Console.Clear();

        switch (key.KeyChar)
        {
            case 'a':

                Console.WriteLine("Se añade el evento: " + n);
            Tracker.Instance().addEvent(new BaseEvent(n++));
                break;
            case 'd':
                BaseEvent bE=Tracker.Instance().removeEvent();
                Console.WriteLine("Se ha eliminado el primer evento que era: "+bE.getIDEvent()+" con fecha "+bE.getTimeStamp());
                break;
            case 'l':
                Console.WriteLine("Quedan: " + Tracker.Instance().getNumberOFEvents());
                break;
            default:
                if(key.Key==ConsoleKey.Escape)
                    end= true;
                    break;
        }

    }
    Console.WriteLine("Fin del programa");
}

main();
