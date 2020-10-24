using NHibernate;
using Presentation;

namespace DomainModel
{
    public class EmailRepository : IEmailRepository
    {
        public void AddEmailLog(IEmail email)
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(email);
                    transaction.Commit();
                }
            }
        }
    }
}
