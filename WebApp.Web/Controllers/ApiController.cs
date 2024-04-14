using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
    public class ApiController(HttpClient client) : Controller
    {
        private readonly HttpClient _client = client;

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeViewModel form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jsonContent = JsonSerializer.Serialize(form);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var response = await _client.PostAsync("https://localhost:7012/api/Subscribe", content);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("Home", "Default");
                    else
                        return RedirectToAction("NotAvailable", "Default");
                } catch { }
            }
            return RedirectToAction("Home", "Default");
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jsonContent = JsonSerializer.Serialize(form);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var response = await _client.PostAsync("https://localhost:7012/api/Contact", content);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("Home", "Default");
                    else
                        return RedirectToAction("NotAvailable", "Default");
                } catch { }
            }
            return RedirectToAction("Contact", "Default");
        }
    }
}
