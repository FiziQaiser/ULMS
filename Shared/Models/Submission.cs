using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Submission
{
    public long SubmissionId { get; set; }

    public long PostId { get; set; }

    public long ClassroomId { get; set; }

    public long StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? SubmissionUrl { get; set; }
}
