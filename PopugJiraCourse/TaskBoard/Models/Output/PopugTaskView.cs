using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models.Output
{
    /// <summary>
    /// �������� ������ �������
    /// </summary>
    public class PopugTaskView
    {
        /// <summary>
        /// ������������� ������
        /// </summary>
        [Display(Name = "�������������")]
        public int Id { get; set; }

        /// <summary>
        /// ���������� ������ (����������, �����)
        /// </summary>
        [Display(Name = "����� ������")]
        public string Content { get; set; }

        /// <summary>
        /// ������������� �� ������
        /// </summary>
        [Display(Name = "������������� �� ������")]
        public int? Responsible { get; set; }

        /// <summary>
        /// ������ ������
        /// </summary>
        [Display(Name = "������ ������")]
        public Infrastructure.TaskStatus Status { get; set; }
    }
}
