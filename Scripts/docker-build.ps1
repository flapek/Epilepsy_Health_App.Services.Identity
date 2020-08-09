$currentLocation = Get-Location
Set-Location ..\

try {
    Write-Host "Start docker build..." -ForegroundColor Blue
    $result = docker build -t services.epilepsy_health_app.identity .

    if ($LASTEXITCODE -eq 0) {
        Write-Host "Finish success" -ForegroundColor Green
        Set-Location $currentLocation
        return 0   
    } else {
        Write-Host "Error:" -ForegroundColor Red
        $ErrorString = $result -join [System.Environment]::NewLine
        Write-Host $ErrorString -ForegroundColor Red
        Set-Location $currentLocation
        return 1
    }   
}
catch {
    Set-Location $currentLocation
    Write-Host "Error!!" -foreground Red    
    Write-Host "Scripts fail, check it!" -foreground Red
}

