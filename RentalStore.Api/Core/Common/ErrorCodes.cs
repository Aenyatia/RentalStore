namespace RentalStore.Api.Core.Common
{
	public static class ErrorCodes
	{
		public static string ProductNotFound => "ProductNotFound";
		public static (string, string) InvalidCredentials => ("InvalidCredentials", "Invalid username or password");
	}
}
