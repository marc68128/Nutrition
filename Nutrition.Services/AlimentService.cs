using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nutrition.Dtos;
using Nutrition.Enums;
using Nutrition.Repositories.Contracts;
using Nutrition.Services.Contracts;

namespace Nutrition.Services
{
    internal class AlimentService : IAlimentService
    {
        private readonly IMapper _mapper;
        private readonly IAlimentRepository _alimentRepository;

        public AlimentService(IMapper mapper, IAlimentRepository alimentRepository)
        {
            _mapper = mapper;
            _alimentRepository = alimentRepository;
        }

        public List<AlimentDto> GetAll()
        {
            return _alimentRepository.GetAll().Select(a => _mapper.Map<AlimentDto>(a)).ToList();
        }

        public List<AlimentDto> GetByCategory(EnumAlimentCategory category)
        {
            return _alimentRepository.GetByCategory(category).Select(a => _mapper.Map<AlimentDto>(a)).ToList();
        }
    }
}
