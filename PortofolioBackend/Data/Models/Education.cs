using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortofolioBackend.Data.Models;

public class Education
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public string Degree { get; set; } 
    public string Institution { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; } 
}