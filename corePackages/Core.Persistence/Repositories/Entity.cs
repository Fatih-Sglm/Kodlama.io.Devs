﻿using Core.Domain.Base;

namespace Core.Persistence.Repositories;

public abstract class Entity<T> : IEntity
{
    public T Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}