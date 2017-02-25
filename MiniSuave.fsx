type StatusCode = Ok | NotFound | InternalError
type HttpMethod = Get | Post | Put
 
type HttpRequest = {
  HttpMethod : HttpMethod
}

type HttpResponse = {
  Content : string
  StatusCode : StatusCode
}

let response statusCode content = async {
  return {Content = content; StatusCode = statusCode}
}

let OK = response Ok
let NOT_FOUND = response NotFound
let INTERNAL_ERROR = response InternalError
let GET app request = 
  match request.HttpMethod with
  | Get -> Some app  
  | _ -> None  
let POST app request = 
  match request.HttpMethod with
  | Post -> Some app  
  | _ -> None  
let PUT app request = 
  match request.HttpMethod with
  | Put -> Some app  
  | _ -> None  
let execute app req = 
  match app req with
  | Some res -> 
    res 
    |> Async.RunSynchronously
    |> printfn "%A"
  | None -> printfn "No response found"