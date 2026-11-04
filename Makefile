export ASPNETCORE_ENVIRONMENT ?= Development

EF_FLAGS = --project src/OpenCore.Infrastructure \
		   --startup-project src/OpenCore.Api

.PHONY: migration-add migration-remove db-update

migration-add:
	dotnet ef migrations add $(name) $(EF_FLAGS) --output-dir Persistence/Migrations

migration-remove:
	dotnet ef migrations remove $(EF_FLAGS)

db-update:
	dotnet ef database update $(EF_FLAGS)
