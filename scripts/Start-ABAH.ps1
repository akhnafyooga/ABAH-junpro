$ErrorActionPreference = 'Stop'
$configPath = Join-Path $PSScriptRoot 'database.local.json'
$exe = Join-Path $PSScriptRoot 'app/ABAH.Desktop.exe'
if (!(Test-Path -LiteralPath $exe)) { throw 'Extract the entire release ZIP before launching ABAH.' }
if (!(Test-Path -LiteralPath $configPath)) {
    Copy-Item (Join-Path $PSScriptRoot 'database.example.json') $configPath
}
$config = Get-Content -LiteralPath $configPath -Raw | ConvertFrom-Json
$port = 0
if ([string]::IsNullOrWhiteSpace($config.Host) -or [string]::IsNullOrWhiteSpace($config.Database) -or
    [string]::IsNullOrWhiteSpace($config.Username) -or ![int]::TryParse([string]$config.Port, [ref]$port) -or
    $port -lt 1 -or $port -gt 65535) { throw "Check the host, port, database and username in $configPath." }
Write-Host "Connecting to $($config.Host):$port / $($config.Database) as $($config.Username)"
$password = Read-Host 'PostgreSQL password (leave blank only if your demo server allows it)' -AsSecureString
$credentials = New-Object System.Management.Automation.PSCredential($config.Username, $password)
$settings = New-Object System.Data.Common.DbConnectionStringBuilder
$settings['Host'] = [string]$config.Host
$settings['Port'] = $port
$settings['Database'] = [string]$config.Database
$settings['Username'] = [string]$config.Username
$settings['Password'] = $credentials.GetNetworkCredential().Password
$previous = $env:ABAH_POSTGRES_CONNECTION
try {
    $env:ABAH_POSTGRES_CONNECTION = $settings.ConnectionString
    & $exe
} finally {
    $env:ABAH_POSTGRES_CONNECTION = $previous
    $settings.Clear()
    $password.Dispose()
}
