using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models.Output
{
    /// <summary>
    /// Основная модель задания
    /// </summary>
    public class PopugTaskView
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        [Display(Name = "Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Содержимое задачи (собственно, текст)
        /// </summary>
        [Display(Name = "Текст задачи")]
        public string Content { get; set; }

        /// <summary>
        /// Ответственный за задачу
        /// </summary>
        [Display(Name = "Ответственный за задачу")]
        public int? Responsible { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        [Display(Name = "Статус задачи")]
        public Infrastructure.TaskStatus Status { get; set; }
    }
}
