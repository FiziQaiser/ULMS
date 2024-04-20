using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Post
{
    public int PostId { get; set; }

    public long ClassroomId { get; set; }

    public string? SenderName { get; set; }

    public string? PostDescription { get; set; }

    public string? PostAttachment { get; set; }

    public bool IsSubmissionPost { get; set; }
}
