using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace TaskBoard.Infrastructure
{
    /// <summary>
    /// статус таска
    /// </summary>
    public enum TaskStatus : int
    {
        [EnumMember(Value = "new")]
        [Display(Name = "Новая", Description = "Новая/свободная задача")]
        New = 0,

        [EnumMember(Value = "taken")]
        [Display(Name = "В работе", Description = "Задача, взятая в работу")]
        Taken = 1,

        [EnumMember(Value = "closed")]
        [Display(Name = "Закрытая", Description = "Закрытая/выполненная задача")]
        Closed = 2
    }
}
