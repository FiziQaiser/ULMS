using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Book
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public string? Uploadedby { get; set; }

    public string? Url { get; set; }
}
