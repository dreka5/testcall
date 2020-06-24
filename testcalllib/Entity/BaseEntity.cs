using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace testcallLib.Entity
{
    /// <summary>
    /// Базовый клас для сущностей
    /// </summary>
    public abstract class BaseEntity
    {
        public ClaimsPrincipal User { get; set; }
        public int owner { get; set; }
        public DBtestcall_Context GetDB => new PrimaryContext().CreateDbContext();
    }
}
