using System;
using System.Runtime.Serialization;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.PCL.Transports.Global {
    [DataContract]
    public class ReturnSet<T> {
        [DataMember]
        public T ReturnValue { get; set; }

        public bool HasValue => ReturnValue != null;

        public bool HasError => Exception != "" || ErrorCode != ErrorCodes.NONE;

        [DataMember]
        public string Exception { get; set; }

        [DataMember]
        public ErrorCodes ErrorCode { get; set; }

        public ReturnSet() {
            Exception = string.Empty;
            ErrorCode = ErrorCodes.NONE;
        }

        public ReturnSet(T value) : this(value, string.Empty, ErrorCodes.NONE) { }

        public ReturnSet(T value, Exception exception, ErrorCodes errorCode) : this(value, exception.ToString(), errorCode) { }

        public ReturnSet(Exception exception) : this(exception, ErrorCodes.UNCATEGORIZED) { }

        public ReturnSet(ErrorCodes errorCode) : this(string.Empty, errorCode) { }

        public ReturnSet(Exception exception, ErrorCodes errorCode) : this(exception.ToString(), errorCode) { }

        public ReturnSet(string exception, ErrorCodes errorCode) {
            Exception = exception;
            ErrorCode = errorCode;
        }

        public ReturnSet(T value, string exception, ErrorCodes errorCode) {
            ReturnValue = value;
            Exception = exception;
            ErrorCode = errorCode;
        }
    }
}