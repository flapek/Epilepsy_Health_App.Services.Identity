Write-Host "Start publishing project..."
dotnet build ..\ -r linux-x64 -c Release
$result = dotnet publish ..\ -r linux-x64 -c Release -o ..\Publish

if ($LASTEXITCODE -eq 0) {
    Write-Host "Finish success" -ForegroundColor Green
    return 0
} else {
    Write-Host "Error: " -ForegroundColor Red
    $ErrorString = $result -join [System.Environment]::NewLine
    Write-Host $ErrorString -ForegroundColor Red
    return 1
}