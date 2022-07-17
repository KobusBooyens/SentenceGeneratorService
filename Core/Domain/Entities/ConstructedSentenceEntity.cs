using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class ConstructedSentenceEntity
  {
    public int Id { get; set; }
    [Required, StringLength(500)]
    public string Value { get; set; }
    public DateTime DateTimeStamp { get; set; }
  }
}
