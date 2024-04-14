﻿namespace WebApp.Lib.Entities;

public class AddressEntity
{
    public int Id { get; set; }
    public string Address1 { get; set; } = null!;
    public string? Address2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
