using Accounting.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Accounting.Application.Services.CompanyServices;
using Accounting.Domain;
using Accounting.Domain.CompanyEntities;
using Accounting.Domain.Repositories.UCAFRepositories;
using Accounting.Persistance.Context;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Persistance.Services.CompanyServices
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContectService _contectService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public UCAFService(IUCAFCommandRepository commandRepository, IContectService contectService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _contectService = contectService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFRequest request)
        {
            _context = (CompanyDbContext)_contectService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);

            await _commandRepository.AddAsync(uniformChartOfAccount);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
