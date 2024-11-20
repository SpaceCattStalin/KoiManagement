using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class KoiImage
{
    public int ImageId { get; set; }

    public int KoiId { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsPrimary { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual KoiFish Koi { get; set; } = null!;
}
