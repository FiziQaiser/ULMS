﻿using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Presence
{
    public long Id { get; set; }

    public long ChannelId { get; set; }

    public bool Check { get; set; }

    public DateTime InsertedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Channel Channel { get; set; } = null!;
}
