Function CreateSubFolders($dir){
    $lib = $dir + '\lib'
    New-Item -ItemType Directory -Force -Path $lib
    Copy-Item 'bin\Release\JanglinGlassdoor.dll' $lib
    Copy-Item 'bin\Release\JanglinGlassdoor.dll.config' $lib
    Copy-Item 'bin\Release\RestApiSdk.dll' $lib
    Copy-Item 'bin\Release\JanglinGlassdoor.pdb' $lib
    Copy-Item 'bin\Release\RestApiSdk.pdb' $lib
}

Function RemoveSubFolders($dir){
    $lib = $dir + '\lib'
    Remove-Item -Recurse -Force $lib
}

try{
    $scriptpath = $MyInvocation.MyCommand.Path
    $dir = Split-Path $scriptpath
    $dir += '\Glassdoor'
    Push-Location $dir

	#This file could change name with a NuGet update for the NuGet command line package!
    Copy-Item ..\packages\NuGet.CommandLine.3.3.0\tools\NuGet.exe NuGet.exe

    CreateSubFolders($dir)

	& .\NuGet.exe pack JanglinGlassdoor.nuspec
}
finally{
    Remove-Item NuGet.exe
    #Remove-Item JanglinGlassdoorApiSdk.1.1.0.nupkg
    RemoveSubFolders($dir)
}
