using System;
using System.ComponentModel.DataAnnotations;
using CSharpVitamins;
using Kontena.EventSourcing;

namespace Kontena.PurchaseService.Models
{
    public class Purchase
        : IEventPayload
    {
        public string Id { get; }

        [Required]
        public string ProductId { get; }

        [Required]
        public string CustomerId { get; }

        [Required]
        public decimal Total { get; }

        public DateTime TransactionDate { get; }

        public Purchase(
            string id,
            string productId,
            string customerId,
            decimal total,
            DateTime transactionDate
        )
        {
            Id = id;
            ProductId = productId;
            CustomerId = customerId;
            Total = total;
            TransactionDate = transactionDate;
        }

        public Purchase WithNewId()
        {
            return new Purchase(
                id: CSharpVitamins.ShortGuid.NewGuid(),
                productId: ProductId,
                customerId: CustomerId,
                total: Total,
                transactionDate: DateTime.UtcNow
            );
        }
    }
}