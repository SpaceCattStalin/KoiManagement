using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Customer
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public byte? IsActive { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<KoiCoassignment> KoiCoassignments { get; set; } = new List<KoiCoassignment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
