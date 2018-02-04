using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace WhoDunnit.Extensions
{
    static public class LambdaExpressionExtensions
    {
        public static MemberInfo GetMemberInfo(this LambdaExpression expression)
        {
            var body = expression.Body;

            if (body == null)
                return null;

            if (body.NodeType == ExpressionType.Convert || body.NodeType == ExpressionType.ConvertChecked)
                body = ((UnaryExpression)body).Operand;

            if (body.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression)body).Member;

            return null;
        }
    }
}
