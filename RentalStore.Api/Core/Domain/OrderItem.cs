namespace RentalStore.Api.Core.Domain
{
	public class OrderItem
	{
		public Product Product { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
