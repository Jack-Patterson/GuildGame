$dllName = "GuildGameApi.dll"
$localPathToDll = ".\bin\Debug\net6.0/" + $dllName
$localPathToCopyLocation = "..\..\GuildGame\Assets\API\" + $dllName

Write-Output "Moving $dllName to $localPathToCopyLocation."
Copy-Item -Path $localPathToDll -Destination $localPathToCopyLocation -Force
Write-Output "Move of file $dllName completed."