﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    [Serializable]
    public class Discourse : List<Sentence>
    {
    }
}
