using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Questions : BaseEntity
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public string TypeQuestions { get; set; }

        public List<Answer> Answer { get; set; }       

        public Chapter Chapter { get; set; }

        public Guid? ChapterId { get; set; }
    }
}
