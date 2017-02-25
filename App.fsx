#load "MiniSuave.fsx"
open MiniSuave

let myApp = 
  SetHeader (Path "/hello" (GET (OK "Hello GET"))) "Content-Type" "text/plain"
