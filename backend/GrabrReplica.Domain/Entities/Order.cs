using System;
using System.ComponentModel.DataAnnotations.Schema;
using GrabrReplica.Domain.Enums;
using GrabrReplica.Domain.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GrabrReplica.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrderByUserId { get; set; }
        public string DeliveryManUserId { get; set; }
        public virtual User OrderBy { get; set; }
        public virtual User DeliveryMan { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductLink { get; set; }
        public decimal FinalPrice { get; private set; }
        public decimal Reward { get; set; }
        public int Count { get; set; }
        public bool IsConfirmed { get; private set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        public Order(string name, string description, string orderByUserId, decimal productPrice, string productLink,
            decimal reward, int count)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            OrderByUserId = orderByUserId ?? throw new ArgumentNullException(nameof(orderByUserId));
            ProductPrice = productPrice;
            ProductLink = productLink ?? throw new ArgumentNullException(nameof(productLink));
            Reward = reward;
            DeliveryStatus = DeliveryStatus.Open;
            Count = count < 1 ? throw new ArgumentException(nameof(count)) : count;
            IsConfirmed = false;
            FinalPrice = (reward + productPrice) * count;
        }

        public void UpdateOrder(string name, string description, decimal productPrice, string productLink,
            decimal reward, int count)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ProductPrice = productPrice;
            ProductLink = productLink ?? throw new ArgumentNullException(nameof(productLink));
            Reward = reward;
            DeliveryStatus = DeliveryStatus.Open;
            Count = count < 1 ? throw new ArgumentException(nameof(count)) : count;
            FinalPrice = (reward + productPrice) * count;
        }

        public void SetDeliver(User deliveryMan) =>
            DeliveryMan = deliveryMan ?? throw new ArgumentNullException(nameof(deliveryMan));

        public void ChangeProductPrice(decimal productPrice)
        {
            ProductPrice = productPrice;
            FinalPrice = (Reward + productPrice) * Count;
        }

        public void CloseDelivery() => DeliveryStatus = DeliveryStatus.Closed;
        
        public void ConfirmOrder() => IsConfirmed = true;

        public void DeclineOrder() => IsConfirmed = false;

        protected Order()
        {
        }
    }
}