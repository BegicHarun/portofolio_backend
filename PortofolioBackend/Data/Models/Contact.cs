using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortofolioBackend.Data.Models;

public class Contact
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Message { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
}