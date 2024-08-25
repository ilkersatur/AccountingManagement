using Accounting.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.CompanyEntities
{
    public sealed class UniformChartOfAccount :Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; } //Ana Grup, Grup, Muavin
    }
}
