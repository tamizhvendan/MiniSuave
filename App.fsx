#load "MiniSuave.fsx"
open MiniSuave

(* I'd like to set MimeType *)
let myApp = GET (OK "Hello PUT")

// http://bit.ly/fs_value_restriction