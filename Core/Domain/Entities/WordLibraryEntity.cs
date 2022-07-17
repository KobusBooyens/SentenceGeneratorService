using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class WordLibraryEntity
  {
    public int Id { get; set; }
    public int WordTypeId { get; set; }
    [Required,StringLength(50)]
    public string Name { get; set; }

    public virtual WordTypeEntity WordType { get; set; }
  }
}
