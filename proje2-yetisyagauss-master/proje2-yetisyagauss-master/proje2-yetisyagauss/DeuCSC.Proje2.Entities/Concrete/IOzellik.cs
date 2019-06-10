using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeuCSC.Proje2.Entities.Concrete
{
    public interface IOzellik
    {
        int id { get; set; }
        string Ozellik { get; set; }
        // Ozellik otele aitse false odaya aitse true döner
        bool OtelOrOda { get; set; }
    }
}
