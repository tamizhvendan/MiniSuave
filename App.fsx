#load "MiniSuave.fsx"
open MiniSuave

let hello = 
  Path "/hello" (GET (OK "Hello headers"))
  |> SetHeader "Content-Type" "text/plain"

let hi =
  Path "/hi" (GET (OK "Hi"))

let myApp = 
  Choose [hi; hello]
