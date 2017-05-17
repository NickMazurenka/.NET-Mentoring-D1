select 'Order Number' = OrderID, 'Shipped Date' = case when ShippedDate IS NULL then 'Not Shipped' else convert(CHAR(10), ShippedDate, 110) end from Northwind.Orders
where ShippedDate > '1998-04-06'
or ShippedDate is null