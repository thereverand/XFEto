using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Xamarin.Forms.Support {

    static public class Expressions {

        /// <summary>
        /// Returns a MemberInfo instance for the member depicted in the Expression
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note: The expression provided is never evaluated. Just inspected.
        /// Think of it as a depiction of a member not an Expression using that member.
        /// </para>
        /// </remarks>
        /// <typeparam name="TObject">The Type of the target object</typeparam>
        /// <typeparam name="TReturn">The return Type of the depicted member</typeparam>
        /// <param name="member">An Expression depicting the desired member</param>
        /// <returns>The depicted member</returns>
        public static MemberInfo MemberExpressionToMember<TObject, TReturn>(Expression<Func<TObject, TReturn>> member) {
            return ExpressionToMember(member.Body);
        }

        public static MemberInfo MemberExpressionToMember<TReturn>(Expression<Func<TReturn>> member) {
            return ExpressionToMember(member.Body);
        }

        internal static MemberInfo ExpressionToMember(Expression member) {
            var exp = member as MemberExpression;
            if (exp != null) return exp.Member;
            var cConvert = member as UnaryExpression;
            if (cConvert != null && cConvert.NodeType == ExpressionType.Convert) {
                exp = cConvert.Operand as MemberExpression;
            }

            if (exp == null)
                throw new ArgumentException("Not a Member Expression", "member");
            return exp.Member;
        }
    }
}