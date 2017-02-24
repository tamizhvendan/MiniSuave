#load "MiniSuave.fsx"
open MiniSuave

(* That's great. But, I don't have anything to say *)
//let myApp = NOT_FOUND "I don't have!"

(* Wow! But Something went wrong while processing. 
   How do I communicate it?
 *)
 let myApp = INTERNAL_ERROR "Something went wrong!"