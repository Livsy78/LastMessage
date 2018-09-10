using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;
using System.Data.Linq.Mapping; // [Table(..)]
using System.Linq.Expressions; // Expression

namespace LastMessage.DB
{

    public abstract class BaseTemplate<T> where T: BaseTemplate<T> // , DbColumn
    {

        protected static dbml.LastMessageDataContext db = new dbml.LastMessageDataContext();
        protected static Table<T> table = db.GetTable<T>();


        //public virtual int ID { get; set; } // throws  Class member BaseTemplate`1.ID is unmapped.
        private int _ID
        {
            get
            {
                return (int)this.GetType().GetProperty("ID").GetValue(this, null);
            }
            set 
            {
                this.GetType().GetProperty("ID").SetValue(this, value);
            }
        }

        public static T Get(int id)
        {
            // Как ни старался, по-другому не получается.
            // Основная проблема - мэппинг пропертей на поля таблицы (Class member is unmapped), так что ID должен быть в конечном классе
            // Получилось через динамический LINQ-запрос, если будет проседать производительность - в конечном классе делаем обычный
            // public static new T Get(int id) {return table.SingleOrDefault(r=> r.ID==id);}

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "r");   // r => r
            Expression condition = Expression.Property(parameterExpression, "ID");   // r => r.ID
            condition = Expression.Equal(condition, Expression.Constant(id)); // r => r.ID == id
            var lambda = Expression.Lambda<Func<T, bool>>(condition, parameterExpression);
            T obj = table.SingleOrDefault(lambda.Compile());
            return obj;
        }

        public static T GetByFieldValue<TField>(string fieldName, TField fieldValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "r");   // r => r
            Expression condition = Expression.Property(parameterExpression, fieldName);   // r => r.fieldName
            condition = Expression.Equal(condition, Expression.Constant(fieldValue)); // r=>r.fieldName == fieldValue
            var lambda = Expression.Lambda<Func<T, bool>>(condition, parameterExpression);
            T obj = table.SingleOrDefault(lambda.Compile());

            return obj;
        }

        public static T GetByFieldValue(string fieldName, string fieldValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "r");   // r => r
            Expression condition = Expression.Property(parameterExpression, fieldName);   // r => r.fieldName
            condition = Expression.Call(condition, typeof(T).GetProperty(fieldName).PropertyType.GetMethod("ToString", Type.EmptyTypes)); // r=>r.fieldName.ToString()  // implement ToString(format)?
            condition = Expression.Equal(condition, Expression.Constant(fieldValue)); // r=>r.fieldName.ToString() == fieldValue
            var lambda = Expression.Lambda<Func<T, bool>>(condition, parameterExpression);
            T obj = table.SingleOrDefault(lambda.Compile());

            return obj;
        }

        public static T[] GetAll()
        {
            T[] obj = table.ToArray();

            return obj;
        }

        public static T[] GetAllByFieldValue<TField>(string fieldName, TField fieldValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "r");   // r => r
            Expression condition = Expression.Property(parameterExpression, fieldName);   // r => r.fieldName
            condition = Expression.Equal(condition, Expression.Constant(fieldValue)); // r=>r.fieldName == fieldValue
            var lambda = Expression.Lambda<Func<T, bool>>(condition, parameterExpression);
            T[] obj = table.Where(lambda.Compile()).ToArray();

            return obj;
        }

        public static T[] GetAllByFieldValue(string fieldName, string fieldValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "r");   // r => r
            Expression condition = Expression.Property(parameterExpression, fieldName);   // r => r.fieldName
            condition = Expression.Call(condition, typeof(T).GetProperty(fieldName).PropertyType.GetMethod("ToString", Type.EmptyTypes)); // r=>r.fieldName.ToString()  // implement ToString(format)?
            condition = Expression.Equal(condition, Expression.Constant(fieldValue)); // r=>r.fieldName.ToString() == fieldValue
            var lambda = Expression.Lambda<Func<T, bool>>(condition, parameterExpression);
            T[] obj = table.Where(lambda.Compile()).ToArray();

            return obj;
        }

        public static string[] GetAllUniqueValuesOfField(string fieldName)
        {
            // create lambda expression "r => r.fieldName"
            // http://blog.zwezdin.com/ru/96
            // http://habrahabr.ru/post/181065/
            // http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=EN-US&k=k(System.Linq.Expressions.Expression);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&rd=true
            // http://msdn.microsoft.com/en-us/library/bb349020(v=vs.110).aspx
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "r");   // r => r
            Expression condition = Expression.Property(parameterExpression, fieldName);   // r => r.fieldName
            condition = Expression.Call(condition, typeof(T).GetProperty(fieldName).PropertyType.GetMethod("ToString", Type.EmptyTypes));  // r=>r.fieldName.ToString()  // implement ToString(format)?
            var lambda = Expression.Lambda<Func<T, string>>(condition, parameterExpression);

            string[] keysUniqueArray = table
                .GroupBy(lambda.Compile())  .AsQueryable() // wtf?
                .OrderBy(r => r.Key)
                .Select(r => r.Key)
                .ToArray()
            ;

            return keysUniqueArray;
        }


        public T Save()
        {
            db.Connection.Open();

            db.Transaction = db.Connection.BeginTransaction();

            /*TMP*/int id=_ID;
            
            try
            {
                T obj = Get(_ID);
                if (obj == null)
                {
                    // insert record
                    //this.ID = -1; // !?!?!?
                    table.InsertOnSubmit((T)this);
                }
                else
                {
                    // update record
                    //this._ID = obj._ID; // !?!?!?
                    //table.Attach((T)this, obj);  // true as 2nd param - raises exception
                }

                db.SubmitChanges(); //after submit, otherwise ID will NOT be updated

                db.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (db.Transaction != null)
                    db.Transaction.Rollback();

                throw e;
            }

            db.Connection.Close();

            return (T)this;
        }

        public void Delete()
        {
            T obj = Get(_ID);
            table.DeleteOnSubmit(obj);  // cant delete 'this' : ERROR: Cannot remove an entity that has not been attached.
            db.SubmitChanges();
        }
    }


}
