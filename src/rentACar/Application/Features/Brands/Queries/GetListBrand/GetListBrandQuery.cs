using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListBrand;

public class GetListBrandQuery : IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; } = null!;

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Brand> brands = await _repository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

            BrandListModel mappedBrands = _mapper.Map<BrandListModel>(brands);
            return mappedBrands;
        }
    }
}