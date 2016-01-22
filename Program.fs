module twiblocker.Main

open System
open Nancy
open Nancy.Hosting

type DemoApp () =
    inherit NancyModule ()
    do
        let Get = base.Get
        Get.["/"] <- fun parameters -> "Hello from F#/Nancy on Heroku!" :> obj

[<EntryPoint>]
let main args = 
    let env_port = Environment.GetEnvironmentVariable("PORT")
    let port = if env_port = null then "1234" else env_port

    let nancy_host = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:" + port))
    nancy_host.Start()
    while true do Console.ReadLine() |> ignore
    0