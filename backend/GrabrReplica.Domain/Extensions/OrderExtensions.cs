using GrabrReplica.Domain.Entities;

namespace GrabrReplica.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static bool CheckAccessToOperations(this Order order, string userId)
        {
            return order.OrderByUserId == userId;
        } 
    }
}