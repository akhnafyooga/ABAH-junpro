param([string]$Output = 'artifacts')
$ErrorActionPreference = 'Stop'
$repo = Split-Path $PSScriptRoot
$root = [System.IO.Path]::GetFullPath((Join-Path $repo $Output))
$stage = Join-Path $root ('stage-' + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $stage -Force | Out-Null
$app = Join-Path $stage app
dotnet publish (Join-Path $repo 'src/ABAH.Desktop/ABAH.Desktop.csproj') -c Release -r win-x64 --self-contained true -o $app -p:RestoreSources=https://api.nuget.org/v3/index.json
if ($LASTEXITCODE) { throw 'ABAH publish failed.' }
Copy-Item (Join-Path $repo 'database') $stage -Recurse
Copy-Item (Join-Path $repo 'scripts/Start-ABAH.ps1'), (Join-Path $repo 'scripts/database.example.json'), (Join-Path $repo 'README.md') $stage
Copy-Item (Join-Path $repo 'docs') $stage -Recurse
$zip = Join-Path $root 'ABAH-Module10-win-x64.zip'
Compress-Archive -Path (Join-Path $stage '*') -DestinationPath $zip -Force
Write-Host $zip
