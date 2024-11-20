using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class KoiCoassignment
{
    public int CoassignmentId { get; set; }

    public int UserId { get; set; }

    public int KoiId { get; set; }

    public decimal? AgreedPrice { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual KoiFish Koi { get; set; } = null!;

    public virtual Customer User { get; set; } = null!;
}
