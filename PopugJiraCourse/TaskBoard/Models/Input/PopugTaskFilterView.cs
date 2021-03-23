using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Models.Input
{
#nullable enable
    /// <summary>
    /// �������� ������ �������� ��� �������
    /// </summary>
    /// <remarks>
    /// �� ���� ������, ��� ����:
    /// 1) ��������
    /// 2) ������� � ������-�������
    /// </remarks>
    [BindProperties(SupportsGet = true)]
    public class PopugTaskFilterView
    {
        /// <summary>
        /// ������ �� �������������� ������
        /// </summary>
        [Display(Name = "�� ��������������")]
        [FromQuery(Name = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// ����� �� ������ ������
        /// ����� ����� �������������� ������ �� ���������
        /// </summary>
        [Display(Name = "�� ������ ������")]
        [FromQuery(Name = "content")]
        public string? Content { get; set; }

        /// <summary>
        /// ������ �� �������������� �� ������
        /// </summary>
        /// <remarks>
        /// ������ ������ - ������ �� ���������� ��� �����, �� ����������� � ����-����
        /// �����, ��� ��� ������ ����� �������� ����� ������ �� �������
        /// </remarks>
        [Display(Name = "�� �������������� �� ������")]
        [FromQuery(Name = "responsible")]
        public int? Responsible { get; set; }

        /// <summary>
        /// ������ �� ������� ������
        /// </summary>
        [Display(Name = "�� ������� ������")]
        [FromQuery(Name = "status")]
        public Infrastructure.TaskStatus? Status { get; set; }
    }
#nullable enable
}
