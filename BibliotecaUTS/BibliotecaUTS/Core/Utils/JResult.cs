using Newtonsoft.Json;

namespace Lab.Web
{
	public class JResult
	{
		public static readonly JResult Successful = new JResult();

		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
		public object Value { get; set; }

		[JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; set; }

		[JsonProperty("redirect", NullValueHandling = NullValueHandling.Ignore)]
		public string Redirect { get; set; }

		public JResult(bool success = true)
		{
			Success = success;
		}
	}
}