using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models.Input
{
    /// <summary>
    /// Основная модель создания задания
    /// </summary>
    public class PopugTaskCreateView
    {
        /// <summary>
        /// Содержимое задачи (собственно, текст)
        /// </summary>
        [Display(Name = "Текст задачи")]
        public string Content { get; set; }
    }
}
