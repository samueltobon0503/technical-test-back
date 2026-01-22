using CleanArch.Application.External.SendGridEmail;
using CleanArch.Domain.Models.SendGridEmail;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace CleanArch.External.SendGridEmail
{
    public class SendGridEmailService : ISendGridEmailService
    {
        private readonly IConfiguration _configuration;
        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Execute(SendGridEmailRequestModel model)
        {
            string apiKey = _configuration["SendGridEmailKey"];
            string apiUrl = "https://api.sendgrid.com/v3/mail/send";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            client.DefaultRequestHeaders.Add("Accept", $"application/json");

            string emainContent = JsonConvert.SerializeObject(model);

            var response = await client.PostAsync(apiUrl, new StringContent(emainContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
