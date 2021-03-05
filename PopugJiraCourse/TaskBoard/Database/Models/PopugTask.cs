using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoard.Database.Models
{
    [Table("PopugTasks", Schema = "dbo")]
    public class PopugTask
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Содержимое задачи (собственно, текст)
        /// </summary>
        [Column("Content")]
        public string Content { get; set; }

        /// <summary>
        /// Ответственный за задачу
        /// </summary>
        [Column("Responsible")]
        public int? Responsible { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        [Column("Status")]
        public Infrastructure.TaskStatus Status { get; set; }
    }
}
