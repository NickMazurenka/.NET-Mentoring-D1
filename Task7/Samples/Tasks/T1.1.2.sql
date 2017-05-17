select OrderID, ShippedDate = case when ShippedDate IS NULL then 'Not Shipped' else convert(CHAR(10), ShippedDate, 110) end
from Northwind.Orders
where ShippedDate IS NULL