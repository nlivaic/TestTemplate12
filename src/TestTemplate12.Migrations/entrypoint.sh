./src/wait-for-it.sh testtemplate12.sql:5432 --timeout=0 --strict -- sleep 5s && dotnet ./TestTemplate12.Migrations.dll