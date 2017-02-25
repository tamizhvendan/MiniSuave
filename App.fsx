#load "MiniSuave.fsx"
open MiniSuave

let hello = 
  GET >=> Path "/hello" >=> OK "hello" >=> SetHeader "X-My-Header" "foo"

let hi = POST >=> Path "/hi" >=> OK "hello POST"

let myApp = Choose[hello; hi]