using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModel;

public record GetListModelQuery(PageRequest PageRequest) : IRequest<ModelListModel>;

public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
{
    private readonly IModelRepository _repository;
    private readonly IMapper _mapper;

    public GetListModelQueryHandler(IModelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _repository.GetListAsync(include:
            m => m.Include(c => c.Brand)!,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);

        ModelListModel mappedModels = _mapper.Map<ModelListModel>(models);
        return mappedModels;
    }
}