using BeeDone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeDone.Data
{
    public interface ITacheDataProvider
    {
        List<Tache> GetTaches();
    }
}
