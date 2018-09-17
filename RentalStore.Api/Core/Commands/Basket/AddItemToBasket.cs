namespace RentalStore.Api.Core.Commands.Basket
{
	public class AddItemToBasket
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public string UserIdentity { get; set; }
	}
}
