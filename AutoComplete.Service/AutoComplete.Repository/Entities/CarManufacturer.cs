﻿namespace AutoComplete.Repository.Entities;

public class CarManufacturer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
}

