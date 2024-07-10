﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Domain.Common;
public abstract class BaseEntity<T>
{
    public T Id { get; set; }
}
