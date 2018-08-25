namespace MagicOfSewing.Common.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArticleConciseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }
        
        public string Author { get; set; }

        public string ShortContent { get; set; }

        public DateTime PublishDateTime { get; set; }
    }
}
