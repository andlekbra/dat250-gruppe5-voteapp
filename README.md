# dat250-gruppe5-voteapp

### Add postgresql

Using standard postgresql database and opening port  5432

`docker run -p 5432:5432 --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgres`


#### Creating the database and tables
- migrations from ef tools Ie. `add-migration mymigration` and `update-database`

### About identity server
- https://docs.identityserver.io/en/latest/intro/big_picture.html

### Edit form
- https://blazor-university.com/forms/
- https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0
