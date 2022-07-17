using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
  public interface IWordLibraryRepositoryAsync
  {
    Task<string[]> GetByWordType(string wordType);
  }
}
