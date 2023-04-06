using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.Domain.Strategies.EdgesFiltration.Abstract;

public interface IEdgeFilterStrategy
{
    //пока шо эта хрень возвращает список планет с отфильтрованными гранями,
    //потому что с текущей структурой класса планеты нельзя у нее удалять грани извне.
    //TODO: надо бы подредачить или класс планеты, или стратегии генерации граней,
    //чтобы они возвращали список сгенереных граней

    List<Planet> Filter(List<Planet> planets);
}
