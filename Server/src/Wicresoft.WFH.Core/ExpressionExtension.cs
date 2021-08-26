namespace Wicresoft.WFH.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return left.Compose(right, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        public static Expression<T> Compose<T>(this Expression<T> left, Expression<T> right, Func<Expression, Expression, Expression> merge)
        {
            var map = left.Parameters.Select((e, i) => new { e, p = right.Parameters[i] }).ToDictionary(p => p.p, p => p.e);

            var arg = ParameterRebinder.ReplaceParameters(map, right.Body);

            return Expression.Lambda<T>(merge(left.Body, arg), left.Parameters);
        }

        public static string GetPath(this Expression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.MemberAccess:
                    {
                        var text = ((MemberExpression)exp).Expression.GetPath() ?? string.Empty;
                        if (text.Length > 0)
                        {
                            text += ".";
                        }
                        return text + ((MemberExpression)exp).Member.Name;
                    }
                case ExpressionType.Convert:
                case ExpressionType.Quote:
                    return ((UnaryExpression)exp).Operand.GetPath();
                case ExpressionType.Lambda:
                    return ((LambdaExpression)exp).Body.GetPath();
                default:
                    return null;
            }
        }
    }

    public sealed class ParameterRebinder : ExpressionVisitor
    {
        private readonly IDictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(IDictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map;
        }

        public static Expression ReplaceParameters(IDictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression parameterExpression;

            if (this.map.TryGetValue(p, out parameterExpression))
            {
                p = parameterExpression;
            }

            return base.VisitParameter(p);
        }
    }
}
