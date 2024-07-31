@echo off
if not "%1"=="" (
    dotnet ef migrations add %1 -p .\PetConnect.Infrastructure\ -s .\PetConnect.API\ --context PetConnectWriteDbContext
    echo Success!
)
exit /b