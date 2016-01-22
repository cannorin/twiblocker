module twiblocker.Main

open System
open Suave
open Suave.Http
open Suave.Filters
open Suave.Successful
open Suave.Web
open System.Net
open Suave.Operators 

[<EntryPoint>]
let main argv =
    printfn "starting server..."

    let config = 
      let port = System.Environment.GetEnvironmentVariable("PORT")
      let ip127  = IPAddress.Parse("127.0.0.1")
      let ipZero = IPAddress.Parse("0.0.0.0")
      { defaultConfig with 
          logger = Logging.Loggers.saneDefaultsFor Logging.LogLevel.Verbose
          bindings=[ (if port = null then HttpBinding.mk HTTP ip127 (uint16 8080)
                      else HttpBinding.mk HTTP ipZero (uint16 port)) ] }

    startWebServer config (Successful.OK "Hello World!")

    printfn "exiting server..."
    0