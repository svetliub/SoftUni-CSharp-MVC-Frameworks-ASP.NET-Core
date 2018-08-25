namespace MagicOfSewing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArticleCategory
    {
        public ArticleCategory()
        {
            this.Articles = new List<Article>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
