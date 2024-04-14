using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models;

public class SubscribeViewModel
{
    [Display(Name = "Email", Prompt = "Your Email")]
    [Required]
    public string Email { get; set; } = null!;
    [Display(Name = "Daily NewsLetter")]
    public bool DailyNewsletter { get; set; }
    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; }
    [Display(Name = "Week In Review")]
    public bool WeekInReview { get; set; }
    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; }
    [Display(Name = "Start UpWeekly")]
    public bool StartupsWeekly { get; set; }
    [Display(Name = "Podcasts")]
    public bool Podcasts { get; set; }

}
