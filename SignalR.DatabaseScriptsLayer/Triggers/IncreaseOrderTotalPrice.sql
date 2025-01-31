CREATE TRIGGER IncreaseOrderTotalPrice
On OrderDetails
After Insert
As
Declare @OrderId int
Declare @OrderPrice decimal
Select @OrderId = OrderId From inserted
Select @orderPrice = TotalPrice From inserted
Update Orders Set TotalPrice = TotalPrice + @OrderPrice Where OrderId=@OrderId