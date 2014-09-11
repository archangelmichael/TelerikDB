CREATE PROC usp_FindTotalIncomeByName (@start_date date,  @end_date date, @company_name nvarchar(50))
AS
SELECT SUM(details.Quantity*details.UnitPrice) AS TotalIncome
FROM Suppliers s
INNER JOIN Products p
ON s.SupplierID = p.SupplierID
INNER JOIN [ORDER Details] details
ON details.ProductID = p.ProductID
INNER JOIN Orders o
ON details.OrderID = o.OrderID
WHERE s.CompanyName = @company_name AND ((o.OrderDate) >= @start_date AND (o.OrderDate) <= @end_date);