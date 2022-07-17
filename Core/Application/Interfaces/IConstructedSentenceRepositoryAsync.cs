using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Interfaces
{
  public interface IConstructedSentenceRepositoryAsync
  {
    Task<ConstructedSentenceDto[]> GetAll();
    Task AddSentence(string sentence);
  }
}
