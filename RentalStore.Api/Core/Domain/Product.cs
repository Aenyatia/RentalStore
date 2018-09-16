namespace RentalStore.Api.Core.Domain
{
	public class Product
	{
		public int ProductId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Genre { get; set; }
		public decimal Price { get; set; }
		public int InStock { get; set; }
	}
}
