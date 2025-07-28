using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Aplication.Dtos;

public class BrandCreateDto
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string LogoUrl { get; set; }
    public string Description { get; set; }
}
