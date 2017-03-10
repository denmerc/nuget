// #I @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6"
// #I @"..\..\packages\FAKE\tools"
#r @".\lib\FakeLib.dll"
open System
open Fake

// let LogLevelParam = getBuildParamOrDefault "loglevel" "DEBUG"
// let AppRootPath = getBuildParamOrDefault "path" @"S:\Program Files\APL\PRICEXPERT\"
let AppRootPath = @"S:\Program Files\APL\PRICEXPERT\"
let configPath = System.IO.Path.Combine [|AppRootPath ; "APLPX.exe.config" |]
printfn "args-%A" fsi.CommandLineArgs
match fsi.CommandLineArgs with
    | [| loglevelparam; path |] ->
        // printfn "running script: %s" scriptName
        updateAppSetting "LogLevel" "YAYARG!" configPath
    | _ -> 
        printfn "%A" fsi.CommandLineArgs    
        updateAppSetting "LogLevel" "DEFAULT" configPath


// TEST
// let path = System.IO.Path.Combine [|__SOURCE_DIRECTORY__ ; "app.config" |]

// updateAppSetting "LogLevel" "Trace" path


