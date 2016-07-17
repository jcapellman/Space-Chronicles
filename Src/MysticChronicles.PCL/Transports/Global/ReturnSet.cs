using System;
using System.Runtime.Serialization;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.PCL.Transports.Global {
    [DataContract]
    public class ReturnSet<T> {
        [DataMember]
        public T ReturnValue { get; set; }

        public bool HasValue => ReturnValue != null;

        public bool HasError => Exception != "" || ErrorCode != ERROR_CODES.NONE;

        [DataMember]
        public string Exception { get; set; }

        [DataMember]
        public ERROR_CODES ErrorCode { get; set; }

        public ReturnSet() {
            Exception = string.Empty;
            ErrorCode = ERROR_CODES.NONE;
        }

        public ReturnSet(T value) : this(value, string.Empty, ERROR_CODES.NONE) { }

        public ReturnSet(T value, Exception exception, ERROR_CODES errorCode) : this(value, exception.ToString(), errorCode) { }

        public ReturnSet(Exception exception) : this(exception, ERROR_CODES.UNCATEGORIZED) { }

        public ReturnSet(ERROR_CODES errorCode) : this(string.Empty, errorCode) { }

        public ReturnSet(Exception exception, ERROR_CODES errorCode) : this(exception.ToString(), errorCode) { }

        public ReturnSet(string exception, ERROR_CODES errorCode) {
            Exception = exception;
            ErrorCode = errorCode;
        }

        public ReturnSet(T value, string exception, ERROR_CODES errorCode) {
            ReturnValue = value;
            Exception = exception;
            ErrorCode = errorCode;
        }
    }
}