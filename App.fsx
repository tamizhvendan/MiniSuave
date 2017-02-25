#load "MiniSuave.fsx"
open MiniSuave

(*
  I'd like to say "Hello GET" with the StatusCode Ok for all my get requests
*)

// let myApp = GET (OK "Hello GET")

(* How about Hello POST *)
let myApp = PUT (OK "Hello GET")