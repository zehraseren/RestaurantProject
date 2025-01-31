Create Trigger SumMoneyCases
On Orders
After Update
As
Declare @Description Nvarchar(Max)
Declare @OrderId int
Declare @TotalPrice Decimal(18,2)
Select @Description = Description From inserted
Select @OrderID = OrderId From inserted
Select @TotalPrice= TotalPrice From inserted
if(@Description = 'Hesap Kapatýldý')
Begin
Update MoneyCases Set TotalAmount = TotalAmount + @TotalPrice
End;