using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Answer : BaseEntity
    {
        public int Index { get; set; }

        public string Text { get; set; }        

        public Questions Questions { get; set; }

        public Guid? QuestionsId { get; set; }

    }
}
