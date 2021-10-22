# dat250-gruppe5-voteapp

### Add postgresql

Using standard postgresql database and opening port  5432

`docker run -p 5432:5432 --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgres`


#### Creating the database and tables
- migrations from ef tools Ie. `add-migration mymigration` and `update-database`
