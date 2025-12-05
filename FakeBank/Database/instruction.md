1. RUN THIS COMMAND TO SET UP THE DATABASE

docker build -t db_fake_bank .

docker run -d --name db_fake_bank -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=fake_bank db_fake_bank

2. PARAMETERS TO CONNECT:

Host: localhost 
Port: 5432
Username: appuser
Password: super_secure_password
Database: fake_bank

3. TO CONNECT TO DATABASE USE COMMAND

docker exec -it db_fake_bank psql -U appuser -d fake_bank

4. USE THIS COMMAND TO CHECK DATABASE STRUCTURE CORECTNESS

\connect fake_bank - connect to database fake_bank
\l - databases list
\dt - tables list
\du - users list