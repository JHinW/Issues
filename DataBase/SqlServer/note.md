# sql server


**stored Procedure**
https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-a-stored-procedure
```sql
    USE AdventureWorks2012;  
    GO  
    CREATE PROCEDURE HumanResources.uspGetEmployeesTest2   
        @LastName nvarchar(50),   
        @FirstName nvarchar(50)   
    AS   

        SET NOCOUNT ON;  
        SELECT FirstName, LastName, Department  
        FROM HumanResources.vEmployeeDepartmentHistory  
        WHERE FirstName = @FirstName AND LastName = @LastName  
        AND EndDate IS NULL;  
    GO
```


**SET NOCOUNT**  
https://docs.microsoft.com/en-us/sql/t-sql/statements/set-nocount-transact-sql  

