using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Domain;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class ConstructedSentenceRepositoryAsync : GenericRepositoryAsync<ConstructedSentenceEntity>, IConstructedSentenceRepositoryAsync
  {
    private readonly DbSet<ConstructedSentenceEntity> _constructedSentenceEntity;
    public ConstructedSentenceRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
      _constructedSentenceEntity = dbContext.Set<ConstructedSentenceEntity>();
    }

    public async Task<ConstructedSentenceDto[]> GetAll()
    {
      List<ConstructedSentenceDto> constructedSentenceDtos = new List<ConstructedSentenceDto>();
     var result = await GetAllAsync();
     foreach (var constructedSentenceEntity in result)
     {
       constructedSentenceDtos.Add(new ConstructedSentenceDto()
       {
         Id = constructedSentenceEntity.Id,
         Value = constructedSentenceEntity.Value,
         DateTime = constructedSentenceEntity.DateTimeStamp
       });
     }

     return constructedSentenceDtos.ToArray();
    }

    public async Task AddSentence(string sentence)
    {
      ConstructedSentenceEntity entity = new ConstructedSentenceEntity();
      entity.Value = sentence;
      entity.DateTimeStamp = DateTime.Now;

      await AddAsync(entity);
    }
  }
}
