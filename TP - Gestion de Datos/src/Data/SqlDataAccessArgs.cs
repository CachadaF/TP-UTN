using System;
using System.Collections.Generic;

namespace Data
{
    public class SqlDataAccessArgs
    {

        // Sirve para setear los argumentos de una query
        // Se usa SqlDataAccessArgs.CreateWith("@FirstName", "Pablo").Arguments
        public static SqlDataAccessArgs CreateWith(string name, object value)
        {
            return new SqlDataAccessArgs(name, value);
        }

        // Se agregan elementos
        // Se usa SqlDataAccessArgs.CreateWith("@FirstName", "Pablo")
        //                 .And("@LastName", "Kerestezachi").Arguments)
        public SqlDataAccessArgs And(string name, object value)
        {
            this.args[name] = value;
            return this;
        }

        public IDictionary<string, object> Arguments
        {
            get { return this.args; }
        }

        private SqlDataAccessArgs(string name, object value)
        {
            this.args[name] = value;
        }

        private IDictionary<string, object> args = new Dictionary<string, object>();
    }
}