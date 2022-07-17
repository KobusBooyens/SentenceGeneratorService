using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Dtos;
using Application.Interfaces;
using Domain;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class WordTypeRepositoryAsync : GenericRepositoryAsync<WordTypeEntity>, IWordTypeRepositoryAsync
  {
    private readonly DbSet<WordTypeEntity> _wordTypeEntity;
    public WordTypeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
      _wordTypeEntity = dbContext.Set<WordTypeEntity>();
    }

    public async Task<WordTypeDto[]> GetAllWordTypes()
    {
      var wordTypeEntities = await _wordTypeEntity
        .Include(r => r.WordLibraries)
        .ToArrayAsync();

      if (!wordTypeEntities.Any())
      {
        throw new InvalidOperationException("WordTyp did not return any results");
      }

      List<WordTypeDto> wordTypeDtos = new List<WordTypeDto>();
      foreach (var wordTypeEntity in wordTypeEntities)
      {
        wordTypeDtos.Add(new WordTypeDto()
        {
          WordType = wordTypeEntity.Description,
          WordLibrary = PopulateWordLibraries(wordTypeEntity.WordLibraries)
        });
      }

      return wordTypeDtos.ToArray();
    }

    public async Task SeedData()
    {
      List<WordTypeEntity> wordTypeEntities = new List<WordTypeEntity>();

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Nouns",
        WordLibraries = new List<WordLibraryEntity>()
        {
            new WordLibraryEntity() { Name = "fox" },
            new WordLibraryEntity() { Name = "dog" },
            new WordLibraryEntity() { Name = "giraffe" },
            new WordLibraryEntity() { Name = "owl" },
            new WordLibraryEntity() { Name = "bird" },
            new WordLibraryEntity() { Name = "sweater" },
            new WordLibraryEntity() { Name = "house" },
            new WordLibraryEntity() { Name = "cat" },
            new WordLibraryEntity() { Name = "doughnut" },
            new WordLibraryEntity() { Name = "ball" },
            new WordLibraryEntity() { Name = "room" },
            new WordLibraryEntity() { Name = "tree" },
            new WordLibraryEntity() { Name = "grassland" },
            new WordLibraryEntity() { Name = "garden" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Verbs",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "jumps" },
          new WordLibraryEntity() { Name = "ran" },
          new WordLibraryEntity() { Name = "flew" },
          new WordLibraryEntity() { Name = "fit" },
          new WordLibraryEntity() { Name = "chose" },
          new WordLibraryEntity() { Name = "ate" },
          new WordLibraryEntity() { Name = "bounced" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Adjectives",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "big" },
          new WordLibraryEntity() { Name = "brown" },
          new WordLibraryEntity() { Name = "lazy" },
          new WordLibraryEntity() { Name = "tall" },
          new WordLibraryEntity() { Name = "wild" },
          new WordLibraryEntity() { Name = "red" },
          new WordLibraryEntity() { Name = "pink" },
          new WordLibraryEntity() { Name = "big" },
          new WordLibraryEntity() { Name = "grey" },
          new WordLibraryEntity() { Name = "tiny" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Adverb",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "hurriedly" },
          new WordLibraryEntity() { Name = "silently" },
          new WordLibraryEntity() { Name = "gracefully" },
          new WordLibraryEntity() { Name = "slowly" },
          new WordLibraryEntity() { Name = "perfectly" },
          new WordLibraryEntity() { Name = "luckily" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Pronoun",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "her" },
          new WordLibraryEntity() { Name = "they" },
          new WordLibraryEntity() { Name = "his" },
          new WordLibraryEntity() { Name = "we" },
          new WordLibraryEntity() { Name = "I" },
          new WordLibraryEntity() { Name = "is" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Preposition",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "over" },
          new WordLibraryEntity() { Name = "at" },
          new WordLibraryEntity() { Name = "to" },
          new WordLibraryEntity() { Name = "in" },
          new WordLibraryEntity() { Name = "of" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Conjunction",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "or" },
          new WordLibraryEntity() { Name = "but" },
          new WordLibraryEntity() { Name = "yet" },
          new WordLibraryEntity() { Name = "because" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Determiner",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "the" },
          new WordLibraryEntity() { Name = "first" },
          new WordLibraryEntity() { Name = "this" },
          new WordLibraryEntity() { Name = "a" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Exclamation",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "Finally" },
          new WordLibraryEntity() { Name = "Please" },
          new WordLibraryEntity() { Name = "Wow" },
          new WordLibraryEntity() { Name = "Ouch" },
          new WordLibraryEntity() { Name = "Well" }
        }
      });

      wordTypeEntities.Add(new WordTypeEntity()
      {
        Description = "Punctuation",
        WordLibraries = new List<WordLibraryEntity>()
        {
          new WordLibraryEntity() { Name = "," },
          new WordLibraryEntity() { Name = "." },
          new WordLibraryEntity() { Name = "!" },
          new WordLibraryEntity() { Name = ";" },
          new WordLibraryEntity() { Name = "-" },
          new WordLibraryEntity() { Name = "?" },
          new WordLibraryEntity() { Name = ";" }
        }
      });

      await AddRangeAsync(wordTypeEntities.ToArray());
    }

    private string[] PopulateWordLibraries(ICollection<WordLibraryEntity> wordLibraries)
    {
      List<string> wordLibraryList = new List<string>();
      foreach (var wordLibrary in wordLibraries)
      {
        wordLibraryList.Add(wordLibrary.Name);
      }

      return wordLibraryList.ToArray();
    }
  }
}
