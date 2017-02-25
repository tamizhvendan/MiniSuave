type StatusCode = Ok | NotFound | InternalError
type HttpMethod = Get | Post | Put
type Header = string * string

type HttpRequest = {
  HttpMethod : HttpMethod
  Path : string
}

type HttpResponse = {
  Content : string
  StatusCode : StatusCode
  Headers : Header list
}

type Context = {
  Request : HttpRequest
  Response : HttpResponse
}

type WebPart = Context -> Async<Context option>
let response statusCode content ctx  = async {
  let newResponse = {ctx.Response with Content = content; StatusCode = statusCode }
  return Some {ctx with Response = newResponse}
}
let OK = response Ok
let NOT_FOUND = response NotFound
let INTERNAL_ERROR = response InternalError
let filter iff ctx = async {
  match iff ctx.Request with
  | true -> return Some ctx
  | _ -> return None
}

let SetHeader key value ctx = async {
  let newResponse = {ctx.Response with Headers = (key,value) :: ctx.Response.Headers}
  return Some {ctx with Response = newResponse}
}
  
let GET = filter (fun request -> request.HttpMethod = Get)
let POST = filter (fun request -> request.HttpMethod = Post)  
let PUT = filter (fun request -> request.HttpMethod = Put) 
let Path path  = filter (fun request -> request.Path = path)  

let rec Choose handlers ctx = async {
  match handlers with
  | [] -> return None
  | x :: xs ->
    let! res = x ctx
    match res with
    | Some r -> return Some r
    | _ -> return! Choose xs ctx
}

let compose w1 w2 ctx = async {
  let! result = w1 ctx
  match result with
  | Some ctx -> return! w2 ctx
  | _ -> return None
}

let (>=>) = compose

let execute (app : WebPart) req = 
  let ctx = {Request = req; Response = {StatusCode = NotFound; Content = ""; Headers = []}}
  let res = app ctx |> Async.RunSynchronously
  match res with
  | Some r -> printfn "%A" r.Response
  | None -> printfn "No response found"