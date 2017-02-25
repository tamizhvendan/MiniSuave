#load "MiniSuave.fsx"
open MiniSuave

(* I'd like to set MimeType *)
let myApp = Path "/hello" (GET (OK "Hello GET"))
