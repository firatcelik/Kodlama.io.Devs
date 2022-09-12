using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities;

//generate user social media account
public class UserSocialMediaAddress : Entity
{
    public int UserId { get; set; }
    public string GithubUrl { get; set; }

    public virtual User? User { get; set; }

    public UserSocialMediaAddress()
    {
    }

    public UserSocialMediaAddress(int id, int userId, string githubUrl) : this()
    {
        Id = id;
        UserId = userId;
        GithubUrl = githubUrl;
    }
}
