using Infrastructure.Entities;
using Infrastructure.Models;
using System;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class SubscribeFactory
{
    public static SubscribeEntity Create(Subscribe sub)
    {

        try
        {
            var entity = new SubscribeEntity
            {
                Email = sub.Email,
                DailyNewsletter = sub.DailyNewsletter,
                AdvertisingUpdates = sub.AdvertisingUpdates,
                WeekInReview = sub.WeekInReview,
                EventUpdates = sub.EventUpdates,
                Podcasts = sub.Podcasts,
                StartupsWeekly = sub.StartupsWeekly,
                Created = DateTime.Now,
                Modified = DateTime.Now,
            };

            return entity;

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }
}
