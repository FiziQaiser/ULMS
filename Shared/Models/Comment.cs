using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Comment
{
    public long CommentId { get; set; }

    public long PostId { get; set; }

    public long ClassroomId { get; set; }

    public string? SenderName { get; set; }

    public string? SenderComment { get; set; }
}
