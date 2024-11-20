using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class KoiBreedType
{
    public int BreedTypeId { get; set; }

    public string? BreedName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();
}
