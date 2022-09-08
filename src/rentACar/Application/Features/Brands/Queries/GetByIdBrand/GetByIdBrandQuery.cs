using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetByIdBrand;

public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
{
    public int Id { get; set; }

    public class GetBrandByIdQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _businessRules;

        public GetBrandByIdQueryHandler(IBrandRepository repository, IMapper mapper,
            BrandBusinessRules businessRules)
        {
            _repository = repository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            Brand? brand = await _repository.GetAsync(b => b.Id == request.Id);

            _businessRules.BrandShouldExistWhenRequested(brand);

            BrandGetByIdDto mappedBrand = _mapper.Map<BrandGetByIdDto>(brand);
            return mappedBrand;
        }
    }
}