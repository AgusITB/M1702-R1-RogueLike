﻿using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICollectable
{
    public void CollectItem(ICollector collector, Item item);
}
