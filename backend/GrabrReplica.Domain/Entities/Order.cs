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

        public string ProductImage { get; set; }
        public decimal FinalPrice { get; private set; }
        public decimal Reward { get; set; }
        public int Count { get; set; }
        public bool IsConfirmed { get; private set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        public Order(string name, string description, string orderByUserId, decimal productPrice, string productLink,
            decimal reward, int count,
            string productImage =
                @"https://drop.ndtv.com/TECH/product_database/images/104201774205PM_635_google_pixel_2_xl.jpeg?downsize=770:*&output-quality=70&output-format=webp")
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
            FinalPrice = productPrice * count + reward;
            ProductImage = productImage;
        }

        public void UpdateOrder(string name, string description, decimal productPrice, string productLink,
            decimal reward, int count,
            string productImage =
                "https://drop.ndtv.com/TECH/product_database/images/104201774205PM_635_google_pixel_2_xl.jpeg?downsize=770:*&output-quality=70&output-format=webp")
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ProductPrice = productPrice;
            ProductLink = productLink ?? throw new ArgumentNullException(nameof(productLink));
            Reward = reward;
            DeliveryStatus = DeliveryStatus.Open;
            Count = count < 1 ? throw new ArgumentException(nameof(count)) : count;
            FinalPrice = productPrice * count + reward;
            ProductImage = productImage;
        }

        public void DeliverymanConfirm()
        {
            DeliveryStatus = DeliveryStatus == DeliveryStatus.CustomerConfirmed
                ? DeliveryStatus.Closed
                : DeliveryStatus.DeliverymanConfirmed;
        }

        public void CustomerConfirm()
        {
            DeliveryStatus = DeliveryStatus == DeliveryStatus.DeliverymanConfirmed
                ? DeliveryStatus.Closed
                : DeliveryStatus.CustomerConfirmed;
        }

        public void SetDeliver(string deliveryMan) =>
            DeliveryManUserId = deliveryMan ?? throw new ArgumentNullException(nameof(deliveryMan));

        public void CancelDeliver() => DeliveryManUserId = null;

        public void CloseDelivery() => DeliveryStatus = DeliveryStatus.Closed;

        public void ConfirmOrder() => IsConfirmed = true;

        public void DeclineOrder() => IsConfirmed = false;

        protected Order()
        {
        }
    }
}