#!/bin/sh
dotnet ef migrations add $1 --verbose -o Persistence/Migrations -s ../FreelaDev.MsPayments.Api