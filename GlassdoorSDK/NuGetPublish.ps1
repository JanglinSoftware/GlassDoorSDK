Function CreateSubFolders($dir){
    $lib = $dir + '\lib\net45'
    New-Item -ItemType Directory -Force -Path  $lib
	Copy-Item Glassdoor\bin\Release\GlassdoorSdk.dll $lib\GlassdoorSdk.dll

 #   $lib = $dir + '\lib\portable-net40+sl5+wp80+win8+wpa81'
 #   New-Item -ItemType Directory -Force -Path  $lib
	#Copy-Item GlassDoorUniversalSdk\bin\Release\GlassdoorSdk.dll $lib\GlassdoorSdk.dll

    $lib = $dir + '\lib\portable-net45+dnxcore50'
    New-Item -ItemType Directory -Force -Path  $lib
	Copy-Item GlassDoorUniversalSdk\bin\Release\GlassdoorSdk.dll $lib\GlassdoorSdk.dll

    $lib = $dir + '\tools'
    New-Item -ItemType Directory -Force -Path  $lib
	Copy-Item install.ps1 $lib\install.ps1
}

try{
    $scriptpath = $MyInvocation.MyCommand.Path
    $dir = Split-Path $scriptpath
    Push-Location $dir
    
    CreateSubFolders($dir + '\NuGet')

	Push-Location 'NuGet'

    #This file could change name with a NuGet update for the NuGet command line package!
    Copy-Item ..\packages\NuGet.CommandLine.4.0.1\tools\NuGet.exe NuGet.exe
    Copy-Item ..\Glassdoor.nuspec Glassdoor.nuspec

	& .\NuGet.exe pack Glassdoor.nuspec
	& .\NuGet.exe setApiKey ec102be3-f205-454b-a412-d87ff0c9008c
	& .\NuGet.exe push JanglinGlassdoorApiSdk.2.0.1.nupkg 
}
finally{
	Push-Location '..'
    Remove-Item -Recurse -Force NuGet
}
