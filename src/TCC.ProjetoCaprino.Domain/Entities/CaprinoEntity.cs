﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.ProjetoCaprino.Domain.Entities;

public class CaprinoEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Origin { get; set; }
    public string? Color { get; set; }

    public bool IsDeleted { get; set; } = false;

    internal void Update(string name, string origin, string color)
    {
        Name = name;
        Origin = origin;
        Color = color;
    }
    internal void Delete()
    {
        IsDeleted = true;
    }
}

