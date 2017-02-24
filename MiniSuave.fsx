type StatusCode = Ok | NotFound | InternalError
type HttpMethod = Get

type HttpRequest = {
  HttpMethod : HttpMethod
}

type HttpResult = {
  Content : string
  StatusCode : StatusCode
}

let response statusCode content = async {
  return {Content = content; StatusCode = statusCode}
}

let OK = response Ok

let NOT_FOUND = response NotFound

let INTERNAL_ERROR = response InternalError

let filter request app = async {
  match request with
  | Get -> return! app
}
   

let execute app = 
  app
  |> Async.RunSynchronously
  |> printfn "%A"