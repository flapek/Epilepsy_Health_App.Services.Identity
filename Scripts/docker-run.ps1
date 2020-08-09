$currentLocation = Get-Location
Set-Location ..\

$currentLocation = Get-Location
Set-Location ..\

try {
    Write-Host "Start docker run..." -ForegroundColor Blue
    docker run -p 8001:8000 services.epilepsy_health_app.identity -d
    
    Write-Host "Finish success" -ForegroundColor Green
    Set-Location $currentLocation
    return 0       
}
catch {
    Write-Host "Error: doker run don't pass" -ForegroundColor Red
    Set-Location $currentLocation
    return 1   
}