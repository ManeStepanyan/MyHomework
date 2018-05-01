/* 1. Return all rows and only a subset of the columns (Name, ProductNumber, ListPrice) from the Product table. 
Change ListPrice column heading to ‘Price’ */
use AdventureWorks2
select [Name],ProductNumber,ListPrice as Price
from Production.Product
/* 2. Find all the employees from HumanResources.Employee table who were hired after 2009-01-01 */
select *
from HumanResources.Employee
where HireDate > '2009-01-01'
/* 3. Return only the rows for Product from Production.Product 
table that have a product line of ‘S’ and that have days to manufacture that is less than 5. Sort by ascending order. */
select *
from Production.Product
where ProductLine='S' AND DaysToManufacture<5
order by [Name]
/* 4. Retrieve employees job titles from HumanResources.Employee table without duplicates. */
select distinct HumanResources.Employee.JobTitle
from HumanResources.Employee
/* 5. Find the total q order quantity of each sales order from Sales.SalesOrderDetail table. */
select SalesOrderID,SUM(OrderQty) as totalQuantity
from sales.SalesOrderDetail
group by SalesOrderID
/* 6. Put the results into groups after retrieving only the rows with list prices greater than $900. */ 
-- first variant (as the requirement of this task was not clear there are two variants)
select ProductModelID,ListPrice
from Production.Product
where ListPrice> CAST(900 as money)
group by ProductModelID , ListPrice
-- second variant
select ProductModelID
from Production.Product
where ListPrice> CAST(900 as money)
group by ProductModelID

/* 7.By using HAVING clause group the rows in the Sales.SalesOrderDetail table
 by product ID and eliminate products whose average order quantities are more than 4. */
 select ProductID, AVG(OrderQty) as AVG
 from Sales.SalesOrderDetail
 group by ProductID
 having AVG(OrderQty)<=4
 /* 8.Write uspGetEmployeeManagersPerDepartment stored procedure that returns direct managers of employees who work at specified department.  */
  go
 create procedure _uspGetEmployeeManagersPerDepartment @BusinessEntityID int, @Department varchar
 -- department doesn't play any role here, so i won't use it
as
   WITH [CTE](BusinessEntityID, OrganizationNode, FirstName, LastName, JobTitle)
   AS (
       SELECT  e.BusinessEntityID, e.OrganizationNode, p.FirstName, p.LastName, e.JobTitle -- Getting the Employee
       FROM HumanResources.Employee as e
           INNER JOIN Person.Person as p
           ON p.BusinessEntityID = e.BusinessEntityID
       WHERE e.BusinessEntityID = @BusinessEntityID )

   SELECT [CTE].BusinessEntityID, [cte].JobTitle,[CTE].FirstName, [CTE].LastName,
   p.FirstName as 'ManagerFirstName', p.LastName AS 'ManagerLastName', e.Gender AS 'ManagerGender'
   FROM CTE INNER JOIN HumanResources.Employee e
       ON CTE.OrganizationNode.GetAncestor(1) = e.OrganizationNode
       INNER JOIN Person.Person p
       ON p.BusinessEntityID = e.BusinessEntityID
go