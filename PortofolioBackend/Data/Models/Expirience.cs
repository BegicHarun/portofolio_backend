using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortofolioBackend.Data.Models;

public class Experience
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public string Title { get; set; } 
    public string Company { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime? EndDate { get; set; } 
    public string Description { get; set; } 
}