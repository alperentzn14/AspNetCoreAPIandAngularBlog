﻿using System;
using System.Collections.Generic;

namespace AngularBlogCoreAPI.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; } = null!;
        public string ContentMain { get; set; } = null!;
        public DateTime PublishDate { get; set; }

        public virtual Article Article { get; set; } = null!;
    }
}
