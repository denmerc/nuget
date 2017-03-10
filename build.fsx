// include Fake libs
// #I @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6"
#r "./packages/FAKE/tools/FakeLib.dll"
// #r "System.Xml.dll"

open Fake
// open System
// open System.Xml

// Directories
let buildDir  = "./build/"
let deployDir = "./deploy/"
let artifactsNuGetDir = @"./artifacts/nuget/"
let artifactsBuildDir = "./artifacts/build/"

// Filesets
let appReferences  =
    !! "/**/*.csproj"
    ++ "/**/*.fsproj"

// version info
let version = "0.1"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; deployDir]
)

Target "Build" (fun _ ->
    // compile all projects below src/app/
    MSBuildDebug buildDir "Build" appReferences
    |> Log "AppBuild-Output: "
)

Target "BuildNuGet" (fun _ ->
   
    // let doc = Linq.XDocument.Load("./src/RemoteOp/remoteOp.nuspec")
    // let vers = doc.Descendants(XName.Get("version", doc.Root.Name.NamespaceName)) 
        // ProjectFile = "./src/RemoteOp/RemoteOp.fsproj"

    NuGet (fun p -> 
    {p with
        Version = version
        OutputPath = deployDir
        WorkingDir = buildDir
        })  "./src/RemoteOp/remoteOp.nuspec"
)

Target "Deploy" (fun _ ->
    !! (buildDir + "/**/*.*")
    -- "*.zip"
    |> Zip buildDir (deployDir + "ApplicationName." + version + ".zip")
)

// Build order
"Clean"
  ==> "Build"
  ==> "Deploy"

// start build
RunTargetOrDefault "Build"
