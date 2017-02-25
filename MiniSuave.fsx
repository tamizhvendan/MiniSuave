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

let filter f app request = 
  match f request with
  | true -> Some app
  | _ -> None
let GET = (fun request -> request.HttpMethod = Get)
let PUT = (fun request -> request.HttpMethod = Put)
let POST = (fun request -> request.HttpMethod = Post)
let execute app req = 
  match app req with
  | Some res -> 
    res 
    |> Async.RunSynchronously
    |> printfn "%A"
  | None -> printfn "No response found"