using System;

namespace IHIS.Framework
{
    /// <summary>
    /// Property를 Bind Variable로 사용할 수 있는지를 나타내는 특성입니다.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataBindableAttribute : System.Attribute
    {
        //true, false를 관리하지 않고 이 Attribute가 있으면 DataBinding 가능
        public DataBindableAttribute()
        {
        }
    }
}
