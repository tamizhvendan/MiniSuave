#load "MiniSuave.fsx"
open MiniSuave

let myApp = 
  SetHeader "Content-Type" "text/plain" (Path "/hello" (GET (OK "Hello GET")))

let myNewApp =
  OK "Hello GET"
  |> GET
  |> Path "/hello"
  |> SetHeader "Content-Type" "text/plain"
