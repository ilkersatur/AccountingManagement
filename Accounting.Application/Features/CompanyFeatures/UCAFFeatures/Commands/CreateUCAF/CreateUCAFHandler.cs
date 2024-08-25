﻿using Accounting.Application.Services.CompanyServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFHandler : IRequestHandler<CreateUCAFRequest, CreateUCAFResponse>
    {
        private readonly IUCAFService _ucafService;

        public CreateUCAFHandler(IUCAFService ucafService)
        {
            _ucafService = ucafService;
        }

        public async Task<CreateUCAFResponse> Handle(CreateUCAFRequest request, CancellationToken cancellationToken)
        {
            await _ucafService.CreateUcafAsync(request);

            return new();
        }
    }
}
