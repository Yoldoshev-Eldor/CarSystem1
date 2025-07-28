using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Aplication.Dtos;

public class BrandDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string LogoUrl { get; set; }
    public string Description { get; set; }
}
