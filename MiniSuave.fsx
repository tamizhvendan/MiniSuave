type StatusCode = Ok | NotFound | InternalError
type HttpMethod = Get | Post | Put
 
type HttpRequest = {
  HttpMethod : HttpMethod
}

type HttpResponse = {
  Content : string
  StatusCode : StatusCode
}

let response statusCode content (req : HttpRequest) = async {
  return Some {Content = content; StatusCode = statusCode}
}

let OK = response Ok
let NOT_FOUND = response NotFound
let INTERNAL_ERROR = response InternalError
let httpMethodFilter httpMethod (app : Async<HttpResponse>) request = async {
  match request.HttpMethod = httpMethod with
  | true -> 
    let! res = app
    return Some res
  | _ -> return None
}
  
let GET = httpMethodFilter Get
let POST = httpMethodFilter Post  
let PUT = httpMethodFilter Put 
  
let execute app req = 
  let res = app req |> Async.RunSynchronously
  match res with
  | Some r -> printfn "%A" r
  | None -> printfn "No response found"