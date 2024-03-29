﻿using Microsoft.AspNetCore.Identity;

namespace BlogProject.Core.Entities;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ImageUrl { get; set; }
    public IEnumerable<Blog> Blogs { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<BlogLike> Likes { get; set; }
}


