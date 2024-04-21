using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Attendance
{
    public long AttendanceId { get; set; }

    public long ClassroomId { get; set; }

    public long? StudentId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Status { get; set; }
}
