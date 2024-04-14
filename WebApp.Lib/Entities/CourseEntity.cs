﻿namespace WebApp.Lib.Entities;

public class CourseEntity
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal OriginalPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int Hours { get; set; }
    public string? LikesInProcent { get; set; }
    public string? NumbersOfLikes { get; set; }
    public bool IsDigital { get; set; }
    public bool IsBestSeller { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public string? ImageUrl { get; set; }
    public string? BigImageUrl { get; set; }
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
}
