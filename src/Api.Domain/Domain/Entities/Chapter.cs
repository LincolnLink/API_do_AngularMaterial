using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Chapter: BaseEntity
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public List<Questions> Questions { get; set; }
    }
}
