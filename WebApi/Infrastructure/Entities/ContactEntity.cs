﻿namespace Infrastructure.Entities;

public class ContactEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string? Service { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}
