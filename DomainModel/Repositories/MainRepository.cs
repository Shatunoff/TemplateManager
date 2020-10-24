using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Presentation;

namespace DomainModel
{
    public class MainRepository : IMainRepository
    {
        public void AddPrintFormLog(IPrintForm printForm)
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(printForm);
                    transaction.Commit();
                }
            }
        }

        public void UpdatePrintFormLog(IPrintForm printForm)
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(printForm);
                    transaction.Commit();
                }
            }
        }
    }
}
