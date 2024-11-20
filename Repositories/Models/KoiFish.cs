using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class KoiFish
{
    public int KoiId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Origin { get; set; }

    public decimal? Size { get; set; }

    public string? Color { get; set; }

    public int? StockQuantity { get; set; }

    public byte? IsListed { get; set; }

    public decimal? Price { get; set; }

    public int? BreedTypeId { get; set; }

    public virtual KoiBreedType? BreedType { get; set; }

    public virtual ICollection<KoiCoassignment> KoiCoassignments { get; set; } = new List<KoiCoassignment>();

    public virtual ICollection<KoiImage> KoiImages { get; set; } = new List<KoiImage>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
