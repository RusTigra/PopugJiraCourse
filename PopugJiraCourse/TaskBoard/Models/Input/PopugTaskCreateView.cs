using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models.Input
{
    /// <summary>
    /// �������� ������ �������� �������
    /// </summary>
    public class PopugTaskCreateView
    {
        /// <summary>
        /// ���������� ������ (����������, �����)
        /// </summary>
        [Display(Name = "����� ������")]
        public string Content { get; set; }
    }
}
