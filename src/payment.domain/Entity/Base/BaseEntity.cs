﻿namespace AG.PaymentApp.Domain.Entity.Bases
{
    using System;

    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
