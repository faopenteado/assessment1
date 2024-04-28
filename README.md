## To execute the Front End project:
```
npm install
ng serve
```

At the file `src/app/services/api.service.ts` change the value of the variable `baseUrl` to the URL of the API project.

## To execute de API project:

Change at `appsettings.json` the value of the connection string to the local database. 
It is configured to create the tables and database at the execution of the project, but, if it fails, open the power shell for developers, and type `dotnet ef update database`


 
