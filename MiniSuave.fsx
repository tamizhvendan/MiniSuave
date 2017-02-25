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
let httpMethodFilter httpMethod (app : Async<HttpResponse>) request =
  match request.HttpMethod = httpMethod with
  | true -> Some app
  | _ -> None
let GET = httpMethodFilter Get
let POST = httpMethodFilter Post  
let PUT = httpMethodFilter Put 
  
let execute app req = 
  match app req with
  | Some res -> 
    res 
    |> Async.RunSynchronously
    |> printfn "%A"
  | None -> printfn "No response found"