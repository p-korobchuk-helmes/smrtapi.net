# smrtapi.net
C# client for Speechmatics real time API

## Installation
```powershell
Install-Package Speechmatics.Realtime.Client -Version 0.5.1
```

## Sample code
```csharp
namespace DemoApp
{
    public class Program
    {
        private const string SampleAudio = "2013-8-british-soccer-football-commentary-alex-warner.mp3";

        // ReSharper disable once UnusedParameter.Local
        public static void Main(string[] args)
        {
            var builder = new StringBuilder();

            using (var stream = File.Open(SampleAudio, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    /*
                     * The API constructor is passed the websockets URL, callbacks for the messages it might receive,
                     * the language to transcribe (as a .NET CultureInfo object) and stream to read data from.
                     */
                    var api = new SmRtApi("wss://api.rt.speechmatics.io:9000/",
                        s => builder.Append(s),
                        stream,
                        new SmRtApiConfig("en-US")
                    );
                    // Run() will block until the transcription is complete.
                    api.Run();
                    Console.WriteLine(builder.ToString());
                }
                catch (AggregateException e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.ReadLine();
        }
    }
}
```
