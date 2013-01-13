using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

///http://codebetter.com/patricksmacchia/2010/06/28/elegant-infoof-operators-in-c-read-info-of/
public static class LinqOp{
        public static MethodInfo MethodOf<T>(Expression<Func<T>> expression) {
 
      var body = (MethodCallExpression)expression.Body;
 
      return body.Method;
 
   }
        public static MethodInfo MethodOf(Expression<Action> expression) {
 
      var body = (MethodCallExpression)expression.Body;
 
      return body.Method;
 
   }
 
   public static ConstructorInfo ConstructorOf<T>(Expression<Func<T>> expression) {
 
      var body = (NewExpression)expression.Body;
 
      return body.Constructor;
 
   }
 
   public static PropertyInfo PropertyOf<T>(Expression<Func<T>> expression) {
 
      var body = (MemberExpression)expression.Body;
 
      return (PropertyInfo)body.Member;
 
   }
 
   public static FieldInfo FieldOf<T>(Expression<Func<T>> expression) {
 
      var body = (MemberExpression)expression.Body;
 
      return (FieldInfo)body.Member;
 
   }
 
}
