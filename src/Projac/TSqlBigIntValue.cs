using System.Data;
using System.Data.SqlClient;

namespace Projac
{
    /// <summary>
    /// Represents a T-SQL BIGINT parameter value.
    /// </summary>
    public class TSqlBigIntValue : ITSqlParameterValue
    {
        private readonly long _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="TSqlBigIntValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public TSqlBigIntValue(long value)
        {
            _value = value;
        }

        /// <summary>
        /// Creates a <see cref="SqlParameter" /> instance based on this instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>
        /// A <see cref="SqlParameter" />.
        /// </returns>
        public SqlParameter ToSqlParameter(string parameterName)
        {
            return new SqlParameter(
                parameterName,
                SqlDbType.BigInt,
                8,
                ParameterDirection.Input,
                false,
                0,
                0,
                "",
                DataRowVersion.Default,
                _value);
        }

        bool Equals(TSqlBigIntValue other)
        {
            return _value == other._value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TSqlBigIntValue)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}