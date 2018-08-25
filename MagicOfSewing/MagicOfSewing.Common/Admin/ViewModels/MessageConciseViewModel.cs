namespace MagicOfSewing.Common.Admin.ViewModels
{
    using System;

    public class MessageConciseViewModel
    {
        public int Id { get; set; }
            
        public string Name { get; set; }
        
        public string Subject { get; set; }
        
        public DateTime SendTime { get; set; }

        public bool IsAnswered { get; set; }
    }
}
