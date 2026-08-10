using Newtonsoft.Json.Linq;

namespace SqlInjectionSample.Models
{
    // Use Recaptcha
    public class GoogleRecaptcha
    {
        public bool Verify(string googleResponse)
        {
            var sec = "6Ley -_ cZAAAAAAqELUPjXfxNA9SjGpQnZ6RUUofu";
            HttpClient client = new();
            var result = client.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={sec}&response={googleResponse}", null).Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                return false;
            var content = result.Content.ReadAsStringAsync().Result;
            dynamic jsonData = JObject.Parse(content);
            if (jsonData.Success == "true")
                return true;
            return false;
        }
    }
}
