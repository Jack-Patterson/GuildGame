$dllName = "GuildGameTestMod.dll"
$localPathToDll = ".\bin\Debug\netstandard2.1/" + $dllName
$localPathToCopyLocation = "C:\Users\jackp\AppData\LocalLow\Halcyon\Guild Game\Mods\Mod1/" + $dllName

Write-Output "Moving $dllName to $localPathToCopyLocation."
Copy-Item -Path $localPathToDll -Destination $localPathToCopyLocation -Force
Write-Output "Move of file $dllName completed."