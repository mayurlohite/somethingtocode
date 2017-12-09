using PagedList;
using SomethingToCode.Core.Domain.Masters.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.DbServices.Masters.Tags
{
    public class TagService
    {
        void Insert(Tag tag);

        void Update(Tag tag);

        void Delete(Tag tag);

        Tag GetTagById(long TagID);

        Tag GetTagBySlugUrl(string slugUrl, bool? isEnable = true);

        IPagedList<Tag> GetAllTags(int? page, bool? isEnable = true);

        IPagedList<Tag> GetTagsByUserId(int? page, long UserID, bool? isEnable = true);

        IPagedList<Tag> GetTagsBySearchCriteria(int? page, long? UserID, string categoryName, bool? isEnable = true);
    }
}
