#load "MiniSuave.fsx"
open MiniSuave

(* I'd like to set MimeType *)
let myApp = PUT (OK "Hello GET")