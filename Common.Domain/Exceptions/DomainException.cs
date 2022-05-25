using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Domain.Exceptions
{
    public abstract class DomainException: Exception
    {
        public new string Source { get; }
        public Enum ErrorCode { get; }
        public new string Message { get; }

        protected DomainException(string source, Enum errorCode, string message, Exception innerException = null)
            : base($"{source} | {errorCode} | {message}", innerException)
        {
            Source = source;
            ErrorCode = errorCode;
            Message = message ?? GetDescriptionOrNull(errorCode) ?? throw new Exception("No description");
        }

        private static string GetDescriptionOrNull(Enum errorCode)
        {
            var memberInfo = errorCode
                .GetType()
                .GetMember(errorCode.ToString())
                .FirstOrDefault();

            return memberInfo?
                .GetCustomAttributes(typeof(DescriptionAttribute), true)
                .Cast<DescriptionAttribute>()
                .SingleOrDefault()?.Description;
        }

        #region ISerialization

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Source = info.GetString("DomainException.Source");
            this.Message = info.GetString("DomainException.Message");

            var errorCodeType = Type.GetType(info.GetString("DomainException.ErrorCodeTypeName"));
            var errorCodeValue = info.GetString("DomainException.ErrorCode");
            this.ErrorCode = (Enum)Enum.Parse(errorCodeType, errorCodeValue);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DomainException.Source", this.Source);
            info.AddValue("DomainException.Message", this.Message);
            info.AddValue("DomainException.ErrorCodeTypeName", this.ErrorCode?.GetType().AssemblyQualifiedName);
            info.AddValue("DomainException.ErrorCode", this.ErrorCode);
            base.GetObjectData(info, context);
        }

        #endregion
    }
}
