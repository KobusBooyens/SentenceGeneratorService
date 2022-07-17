using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  internal class WordLibraryRepositoryAsync  : GenericRepositoryAsync<WordLibraryEntity>, IWordLibraryRepositoryAsync
  {
    private readonly DbSet<WordLibraryEntity> _wordLibraryEntity;
    public WordLibraryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
      _wordLibraryEntity = dbContext.Set<WordLibraryEntity>();
    }

    public async Task<string[]> GetByWordType(string wordType)
    {
     var wordLibraries= await _wordLibraryEntity
        .Where(r => r.WordType.Description == wordType)
        .Select(r => r.Name)
        .ToArrayAsync();

     if (!wordLibraries.Any())
     {
       throw new InvalidOperationException($"WordLibrary did not return any results for WordType: {wordType}.");
     }

     return wordLibraries;
    }
  }
}
