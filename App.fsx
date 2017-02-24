#load "MiniSuave.fsx"
open MiniSuave

(*
  I'd like to say "Hello GET" with the StatusCode Ok for all my get requests
*)

let myApp = filter Get (OK "Hello GET")