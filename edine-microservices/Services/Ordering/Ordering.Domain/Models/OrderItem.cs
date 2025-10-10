using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Models;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; private set; } = default;
    public Guid ProductId {get; private set;} = default;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
}
