﻿using System;

namespace CustomerApi.DTOs;

public class UserToken
{
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
}
