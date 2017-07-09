using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Masters;
using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.Core.Domain.Masters.Tag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Users
{
    public class User : BaseEntity
    {
        private ICollection<Category> _categories;
        private ICollection<Article> _articles { get; set; }
        private ICollection<Tag> _tags { get; set; }
        private ICollection<ArticleComment> _articleComments { get; set; }
        private ICollection<UserWork> _userWorks { get; set; }
        private ICollection<UserAchivement> _userAchivements { get; set; }
        private ICollection<UserEducation> _userEducations { get; set; }
        private ICollection<UserSkill> _userSkills { get; set; }

        public long UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Website { get; set; }

        public string StatusMessage { get; set; }

        public string AboutMe { get; set; }

        public string avtar { get; set; }

        public bool IsEmailVerified { get; set; }

        public bool IsApproved { get; set; }

        public string Hash { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsSuperAdmin { get; set; }




        public virtual ICollection<Category> Categories
        {
            get { return _categories ?? (_categories = new List<Category>()); }
            protected set { _categories = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return _tags ?? (_tags = new List<Tag>()); }
            protected set { _tags = value; }
        }

        public virtual ICollection<Article> Articles
        {
            get { return _articles ?? (_articles = new List<Article>()); }
            protected set { _articles = value; }
        }

        public virtual ICollection<ArticleComment> ArticleComments
        {
            get { return _articleComments ?? (_articleComments = new List<ArticleComment>()); }
            protected set { _articleComments = value; }
        }
        public virtual ICollection<UserWork> UserWorks
        {
            get { return _userWorks ?? (_userWorks = new List<UserWork>()); }
            protected set { _userWorks = value; }
        }
        public virtual ICollection<UserAchivement> UserAchivements
        {
            get { return _userAchivements ?? (_userAchivements = new List<UserAchivement>()); }
            protected set { _userAchivements = value; }
        }
        public virtual ICollection<UserEducation> UserEducations
        {
            get { return _userEducations ?? (_userEducations = new List<UserEducation>()); }
            protected set { _userEducations = value; }
        }
        public virtual ICollection<UserSkill> UserSkills
        {
            get { return _userSkills ?? (_userSkills = new List<UserSkill>()); }
            protected set { _userSkills = value; }
        }

    }
}