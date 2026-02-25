using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passagens.Search.Infrastructure.Persistence.Entities;

public class VooEntity
{
    public Guid Id { get; set; }

    public Guid SnapshotId { get; set; }
    public PesquisaSnapshotEntity Snapshot { get; set; } = default!;

    public string Companhia { get; set; } = default!;
    public string NumeroVoo { get; set; } = default!;

    // Em dinheiro, decimal é o padrão
    public decimal Valor { get; set; }

    // Duração em minutos facilita consulta (e é mais consistente)
    public int DuracaoMinutos { get; set; }
}
