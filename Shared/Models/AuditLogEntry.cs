﻿using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

/// <summary>
/// Auth: Audit trail for user actions.
/// </summary>
public partial class AuditLogEntry
{
    public Guid? InstanceId { get; set; }

    public Guid Id { get; set; }

    public string? Payload { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string IpAddress { get; set; } = null!;
}
