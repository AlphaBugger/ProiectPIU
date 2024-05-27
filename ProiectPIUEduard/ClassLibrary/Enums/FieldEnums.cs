using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldClass
{
    public enum FieldType
    {
        Wheat,
        Corn,
        Barley,
        Soybean,
        Oat,
        Other
    }

    public enum SoilType
    {
        Clay,
        Sand,
        Loam,
        Silt,
        Peat,
        Other
    }

    [Flags]
    public enum Actions
    {
        None = 0,
        Watering = 1 << 0,
        PesticideApplication = 1 << 1,
        Fertilization = 1 << 2,
        Plowing = 1 << 3,
        Harvesting = 1 << 4
    }
}
