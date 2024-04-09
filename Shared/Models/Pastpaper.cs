using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Pastpaper
{
    public long Id { get; set; }

    public long? CourseId { get; set; }

    public string? FileName { get; set; }

    public string? Url { get; set; }
}
