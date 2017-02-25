type StatusCode = Ok | NotFound | InternalError
type HttpMethod = Get | Post | Put
 
type HttpRequest = {
  HttpMethod : HttpMethod
  Path : string
}

type HttpResponse = {
  Content : string
  StatusCode : StatusCode
}

type Handler = HttpRequest -> Async<HttpResponse option>
let response statusCode content (req : HttpRequest)  = async {
  return Some {Content = content; StatusCode = statusCode}
}

let OK = response Ok
let NOT_FOUND = response NotFound
let INTERNAL_ERROR = response InternalError
let httpMethodFilter iff app request : Async<HttpResponse option> = async {
  match iff request with
  | true -> return! app request
  | _ -> return None
}
  
let GET = httpMethodFilter (fun request -> request.HttpMethod = Get)
let POST = httpMethodFilter (fun request -> request.HttpMethod = Post)  
let PUT = httpMethodFilter (fun request -> request.HttpMethod = Put) 
let Path path  = httpMethodFilter (fun request -> request.Path = path)  
let execute (app : Handler) req = 
  let res = app req |> Async.RunSynchronously
  match res with
  | Some r -> printfn "%A" r
  | None -> printfn "No response found"