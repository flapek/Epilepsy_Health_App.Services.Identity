try {
    $currentLocation = Get-Location
    Set-Location ..\
    
    Write-Host "Start docker run..." -ForegroundColor Blue
    docker run -p 8001:8000 services.epilepsy_health_app.identity -d
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Finish success" -ForegroundColor Green
        Set-Location $currentLocation
        return 0  
    } else {
        Write-Host "Error!!!" -ForegroundColor Red
        Set-Location $currentLocation
        return 1
    }   

           
}
catch {
    Write-Host "Error: doker run don't pass" -ForegroundColor Red
    Set-Location $currentLocation
    return 1   
}