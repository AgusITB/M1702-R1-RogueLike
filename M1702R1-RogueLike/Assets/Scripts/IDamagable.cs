﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IDamagable
    {
        public void TakeDamage(int damage);
        public void Die();
        public void AnimateHit();


    }
}
