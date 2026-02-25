using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passagens.Search.Infrastructure.Persistence.Entities;

public class PesquisaEntity
{
    public Guid Id { get; set; }

    public string AeroportoOrigem { get; set; } = default!;
    public string AeroportoDestino { get; set; } = default!;

    public DateOnly DataIda { get; set; }
    public DateOnly DataVolta { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public List<PesquisaSnapshotEntity> Snapshots { get; set; } = new();
}
