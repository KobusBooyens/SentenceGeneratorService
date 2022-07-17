using System.ComponentModel.DataAnnotations;

namespace Domain
{
  public class WordTypeEntity
  {
    public WordTypeEntity()
    {
      this.WordLibraries = new List<WordLibraryEntity>();
    }

    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Description { get; set; }

    public ICollection<WordLibraryEntity> WordLibraries { get; set; }
  }
}