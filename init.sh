#!/bin/bash
set -e

# Esperar a que SQL Server esté listo
/wait-for-it.sh localhost:1433 -t 60 -- echo "SQL Server está listo"

# Ejecutar scripts SQL
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "4n6ur3c0ntr4s3n4@Fir3" -i /usr/src/scripts/create_database.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "4n6ur3c0ntr4s3n4@Fir3" -i /usr/src/scripts/create_table_usuario.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "4n6ur3c0ntr4s3n4@Fir3" -i /usr/src/scripts/seed_data.sql