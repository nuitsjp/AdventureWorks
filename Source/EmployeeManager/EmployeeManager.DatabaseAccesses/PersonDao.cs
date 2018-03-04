using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class PersonDao
    {
        private ITransactionContext _transactionContext;

        public PersonDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public virtual Person FindById(int businessEntityId)
            => _transactionContext.Connection.Get(new Person {BusinessEntityID = businessEntityId});

        public virtual void Update(Person person)
            => _transactionContext.Connection.Update(person);

        public virtual void Insert(Person person)
            => _transactionContext.Connection.Insert(person);
    }
}