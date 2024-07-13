﻿using Chen.DomainCommons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    /// <summary>
    /// 用户与用户间的关注关系表
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="ToUserId"></param>
    public record UserAttentionUser(long UserId, long ToUserId) : DomainEvents
    {
    }
}
