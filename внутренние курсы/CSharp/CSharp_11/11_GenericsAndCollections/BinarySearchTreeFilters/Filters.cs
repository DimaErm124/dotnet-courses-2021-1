using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BinarySearchTreeFilters
{
    public class Filters<T> where T : IComparable<T>
    {
        private const string IndexOf = nameof(IndexOf);
        private const string Match = nameof(Match);
        private const string Value = nameof(Value);

        private static readonly Type _type = typeof(T);

        private readonly ParameterExpression _element = Expression.Parameter(_type);

        private readonly IEnumerable<T> _sourceCollections;

        private IEnumerable<T> _targetCollections;
        
        public Filters(IEnumerable<T> collections)
        {
            _sourceCollections = collections;
         
            Reset();
        }

        private MemberExpression InitParameter(string paramName)
        {
            MemberInfo memberInfo = _type.GetProperty(paramName);

            return Expression.MakeMemberAccess(_element, memberInfo);
        }

        public void ElementsEqualItem(string paramName, object item)
        {
            MemberExpression param = InitParameter(paramName);

            ConstantExpression dataConstant = Expression.Constant(item);

            AddWhereExpression(Expression.Equal(param, dataConstant));
        }

        public void ElementsGreaterThanItem(string paramName, object item)
        {
            MemberExpression param = InitParameter(paramName);

            ConstantExpression dataConstant = Expression.Constant(item);

            AddWhereExpression(Expression.GreaterThan(param, dataConstant));
        }

        public void ElementsGreaterThanOrEqualItem(string paramName, object item)
        {
            MemberExpression param = InitParameter(paramName);

            ConstantExpression dataConstant = Expression.Constant(item);

            AddWhereExpression(Expression.GreaterThanOrEqual(param, dataConstant));
        }

        public void ElementsLessThanItem(string paramName, object item)
        {
            MemberExpression param = InitParameter(paramName);

            ConstantExpression dataConstant = Expression.Constant(item);

            AddWhereExpression(Expression.LessThan(param, dataConstant));
        }

        public void ElementsLessThanOrEqualItem(string paramName, object item)
        {
            MemberExpression param = InitParameter(paramName);

            ConstantExpression dataConstant = Expression.Constant(item);

            AddWhereExpression(Expression.LessThanOrEqual(param, dataConstant));
        }
        
        public void ElementsBetweenItems(string paramName, object minBorder, object maxBorder, bool minBorderInclusive = false, bool maxBorderInclusive = false)
        {
            if (minBorderInclusive)
                ElementsGreaterThanOrEqualItem(paramName, minBorder);
            else
                ElementsGreaterThanItem(paramName, minBorder);

            if (maxBorderInclusive)
                ElementsLessThanOrEqualItem(paramName, maxBorder);
            else
                ElementsLessThanItem(paramName, maxBorder);
        }

        public void ElementsContainsSubstring(string paramName, string substring)
        {
            MemberExpression param = InitParameter(paramName);

            ConstantExpression dataConstant = Expression.Constant(substring);
            ConstantExpression lessThanZero = Expression.Constant(-1);

            Type stringType = typeof(string);

            MethodInfo method = stringType.GetMethod(IndexOf, new Type[] { stringType});

            AddWhereExpression(Expression.NotEqual(Expression.Call(param, method, dataConstant), lessThanZero));
        }
        
        public void ElementsWithRegexPattern(string paramName, Regex regex)
        {
            MemberExpression param = InitParameter(paramName);

            ConstantExpression regexExp = Expression.Constant(regex);
            
            MethodInfo method = typeof(Regex).GetMethod(Match, new Type[] { typeof(string) });
            MethodCallExpression callExpression = Expression.Call(regexExp, method, param);
                        
            MemberInfo valueInfo = typeof(Match).GetProperty(Value);
            MemberExpression value = Expression.MakeMemberAccess(callExpression, valueInfo);

            AddWhereExpression(Expression.Equal(param, value));
        }

        private void AddWhereExpression(BinaryExpression expression)
        {
            Expression<Func<T, bool>> whereExpression = Expression.Lambda<Func<T, bool>>(expression, _element);

            _targetCollections = _targetCollections.Where(whereExpression.Compile());
        }

        public IEnumerable<T> Apply()
        {
            var returningColl = _targetCollections;

            Reset();

            return returningColl;
        }

        public void Reset()
        {
            _targetCollections = _sourceCollections;
        }
    }
}