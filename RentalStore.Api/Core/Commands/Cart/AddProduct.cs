namespace RentalStore.Api.Core.Commands.Cart
{
	public class AddProduct
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public string UserId { get; set; }
	}
}
