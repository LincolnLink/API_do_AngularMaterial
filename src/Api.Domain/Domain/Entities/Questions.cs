using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Questions : BaseEntity
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public List<Answer> answers { get; set; }
    }
}
