#!/bin/sh
dotnet ef migrations add $1 -o Persistence/Migrations -s ../FreelaDev.MsProjects.Api