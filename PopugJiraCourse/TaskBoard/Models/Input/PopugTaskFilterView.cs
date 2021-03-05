using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Models.Input
{
#nullable enable
    /// <summary>
    /// Основная модель фильтров для заданий
    /// </summary>
    /// <remarks>
    /// Не буду делать, ибо лень:
    /// 1) пейджинг
    /// 2) фильтры с мульти-выбором
    /// </remarks>
    [BindProperties(SupportsGet = true)]
    public class PopugTaskFilterView
    {
        /// <summary>
        /// Фильтр по идентификатору задачи
        /// </summary>
        [Display(Name = "По идентификатору")]
        [FromQuery(Name = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Поиск по тексту задачи
        /// Здесь будет использоваться фильтр по вхождению
        /// </summary>
        [Display(Name = "По тексту задачи")]
        [FromQuery(Name = "content")]
        public string? Content { get; set; }

        /// <summary>
        /// Фильтр по ответственному за задачу
        /// </summary>
        /// <remarks>
        /// Тонкий момент - делать ли фильтрацию для задач, не привязанных к кому-либо
        /// Думаю, что эта задача будет решаться через фильтр по статусу
        /// </remarks>
        [Display(Name = "По ответственному за задачу")]
        [FromQuery(Name = "responsible")]
        public int? Responsible { get; set; }

        /// <summary>
        /// Фильтр по статусу задачи
        /// </summary>
        [Display(Name = "По статусу задачи")]
        [FromQuery(Name = "status")]
        public Infrastructure.TaskStatus? Status { get; set; }
    }
#nullable enable
}
