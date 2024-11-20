﻿using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int KoiId { get; set; }

    public int? Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual KoiFish Koi { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
