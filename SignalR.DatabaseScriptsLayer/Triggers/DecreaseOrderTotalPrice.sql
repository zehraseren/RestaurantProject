CREATE TRIGGER DecreaseOrderTotalPrice
On OrderDetails
After Delete
As
Declare @OrderId int
Declare @OrderPrice decimal
Select @OrderId = OrderId From deleted
Select @orderPrice = TotalPrice From deleted
Update Orders Set TotalPrice = TotalPrice - @OrderPrice Where OrderId=@OrderId