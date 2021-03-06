﻿using CodeFirst.Data.Attributes;
using System;

namespace CodeFirst.Data.Entities.Auth.AuthEntites
{
    public abstract class AuthBase
    {
        public long? Id { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime CreatedDateTime { get; set; }
    }
}