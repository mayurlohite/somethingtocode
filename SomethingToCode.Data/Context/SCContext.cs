using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.Core.Domain.Masters.Exception;
using SomethingToCode.Core.Domain.Masters.Tag;
using SomethingToCode.Core.Domain.Users;
using SomethingToCode.Data.Mapping.Articles;
using SomethingToCode.Data.Mapping.Masters.Catelog;
using SomethingToCode.Data.Mapping.Masters.Exception;
using SomethingToCode.Data.Mapping.Masters.Tag;
using SomethingToCode.Data.Mapping.Users;
using System.Data.Entity;

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
        public DbSet<ArticleComment> ArticleComments { get; set; }


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
            modelBuilder.Configurations.Add(new ArticleCommentMapping());
            modelBuilder.Configurations.Add(new ArticleMapping());
           
        }
    }
}
