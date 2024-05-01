using System.ComponentModel.DataAnnotations;

namespace LuckyCat.DataBase.Entity;

public class BaseEntity
{
    public virtual DateTime CreatedOn { get; set; }

    [Required]
    [StringLength(50)]
    public virtual string CreatedBy { get; set; }

    public virtual DateTime? ModifyOn { get; set; }

    [StringLength(50)]
    public virtual string ModifyBy { get; set; }
}