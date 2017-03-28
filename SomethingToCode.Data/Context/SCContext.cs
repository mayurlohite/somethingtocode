using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Masters;
using SomethingToCode.Core.Domain.Users;
using SomethingToCode.Data.Mapping.Articles;
using SomethingToCode.Data.Mapping.Masters;
using SomethingToCode.Data.Mapping.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Context
{
    public class SCContext : DbContext
    {
        public SCContext()
        {
            Database.SetInitializer<SCContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAchivement> UserAchivements { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserWork> UserWorks { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }


        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Users
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserAchivementMapping());
            modelBuilder.Configurations.Add(new UserEducationMapping());
            modelBuilder.Configurations.Add(new UserSkillMapping());
            modelBuilder.Configurations.Add(new UserWorkMapping());

            //Masters
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new TagMapping());
            modelBuilder.Configurations.Add(new ExceptionLoggerMapping());

            //Article Mapping
            modelBuilder.Configurations.Add(new ArticleCategoryMapping());
            modelBuilder.Configurations.Add(new ArticleCommentMapping());
            modelBuilder.Configurations.Add(new ArticleMapping());
            modelBuilder.Configurations.Add(new ArticleTagMapping());
        }
    }
}
