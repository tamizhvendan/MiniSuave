// I'd like to send "Hello, World!" with the Status Code OK
// I want it async 
#load "MiniSuave.fsx"
open MiniSuave

let myApp = OK "Hello, World!"