using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Classroom
{
    public long ClassroomId { get; set; }

    public long UserId { get; set; }

    public string? ClassroomName { get; set; }
}
