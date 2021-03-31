

.PHONY: all
all:build test

test:
	dotnet test

build:
	dotnet build

clean:
	dotnet clean

run:
	dotnet run