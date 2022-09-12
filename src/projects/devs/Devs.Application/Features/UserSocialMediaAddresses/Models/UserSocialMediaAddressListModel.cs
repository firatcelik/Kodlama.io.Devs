using Core.Persistence.Paging;
using Devs.Domain.Entities;

namespace Devs.Application.Features.UserSocialMediaAddresses.Models;

/// <summary>
/// Kullanıcı Sosyal Medya Adresi için kullanılan model
/// </summary>
public class UserSocialMediaAddressListModel : BasePageableModel
{
    public IList<UserSocialMediaAddress> Items { get; set; }
}