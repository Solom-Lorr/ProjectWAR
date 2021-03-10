// Generated by ProtoGen, Version=2.4.1.521, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48.  DO NOT EDIT!
#pragma warning disable 1591, 0612, 3021

#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbd = global::Google.ProtocolBuffers.Descriptors;

namespace FrameWork
{
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class AuthSessionTokenReplyProto
    {
        #region Extension registration

        public static void RegisterAllExtensions(pb::ExtensionRegistry registry)
        {
        }

        #endregion Extension registration

        #region Static variables

        internal static pbd::MessageDescriptor internal__static_login_proto_AuthSessionTokenReply__Descriptor;
        internal static pb::FieldAccess.FieldAccessorTable<global::FrameWork.AuthSessionTokenReply, global::FrameWork.AuthSessionTokenReply.Builder> internal__static_login_proto_AuthSessionTokenReply__FieldAccessorTable;

        #endregion Static variables

        #region Descriptor

        public static pbd::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }

        private static pbd::FileDescriptor descriptor;

        static AuthSessionTokenReplyProto()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                "Ch93YXIvQXV0aFNlc3Npb25Ub2tlblJlcGx5LnByb3RvEgtsb2dpbi5wcm90" +
                "bxokZ29vZ2xlL3Byb3RvYnVmL2NzaGFycF9vcHRpb25zLnByb3RvIpoDChVB" +
                "dXRoU2Vzc2lvblRva2VuUmVwbHkSQgoLcmVzdWx0X2NvZGUYASACKA4yLS5s" +
                "b2dpbi5wcm90by5BdXRoU2Vzc2lvblRva2VuUmVwbHkuUmVzdWx0Q29kZSK8" +
                "AgoKUmVzdWx0Q29kZRIPCgtSRVNfU1VDQ0VTUxAAEhwKGFJFU19QUk9UT0NP" +
                "TF9VTlNVUFBPUlRFRBABEhsKF1JFU19QUk9EVUNUX1VOU1VQUE9SVEVEEAIS" +
                "GwoXUkVTX0FDQ09VTlRfQVVUSF9GQUlMRUQQAxIaChZSRVNfQUNDT1VOVF9U" +
                "RVJNSU5BVEVEEAQSFwoTUkVTX0FDQ09VTlRfRVhQSVJFRBAFEhkKFVJFU19B" +
                "Q0NPVU5UX1NVU1BFTkRFRBAGEiUKIVJFU19BQ0NPVU5UX1NFQ09OREFSWV9B" +
                "VVRIX05FRURFRBAHEh4KGlJFU19BQ0NPVU5UX0FMUkVBRFlfT05MSU5FEAgS" +
                "FAoQUkVTX1NZU1RFTV9FUlJPUhAJEhgKFFJFU19FTkNSWVBUSU9OX0VSUk9S" +
                "EApCKsI+JwoJRnJhbWVXb3JrEhpBdXRoU2Vzc2lvblRva2VuUmVwbHlQcm90" +
                "bw==");
            pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate (pbd::FileDescriptor root)
            {
                descriptor = root;
                internal__static_login_proto_AuthSessionTokenReply__Descriptor = Descriptor.MessageTypes[0];
                internal__static_login_proto_AuthSessionTokenReply__FieldAccessorTable =
                    new pb::FieldAccess.FieldAccessorTable<global::FrameWork.AuthSessionTokenReply, global::FrameWork.AuthSessionTokenReply.Builder>(internal__static_login_proto_AuthSessionTokenReply__Descriptor,
                        new string[] { "ResultCode", });
                pb::ExtensionRegistry registry = pb::ExtensionRegistry.CreateInstance();
                RegisterAllExtensions(registry);
                global::Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.RegisterAllExtensions(registry);
                return registry;
            };
            pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
                new pbd::FileDescriptor[] {
          global::Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.Descriptor,
                }, assigner);
        }

        #endregion Descriptor
    }

    #region Messages

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class AuthSessionTokenReply : pb::GeneratedMessage<AuthSessionTokenReply, AuthSessionTokenReply.Builder>
    {
        private AuthSessionTokenReply()
        {
        }

        private static readonly AuthSessionTokenReply defaultInstance = new AuthSessionTokenReply().MakeReadOnly();
        private static readonly string[] _authSessionTokenReplyFieldNames = new string[] { "result_code" };
        private static readonly uint[] _authSessionTokenReplyFieldTags = new uint[] { 8 };

        public static AuthSessionTokenReply DefaultInstance
        {
            get { return defaultInstance; }
        }

        public override AuthSessionTokenReply DefaultInstanceForType
        {
            get { return DefaultInstance; }
        }

        protected override AuthSessionTokenReply ThisMessage
        {
            get { return this; }
        }

        public static pbd::MessageDescriptor Descriptor
        {
            get { return global::FrameWork.AuthSessionTokenReplyProto.internal__static_login_proto_AuthSessionTokenReply__Descriptor; }
        }

        protected override pb::FieldAccess.FieldAccessorTable<AuthSessionTokenReply, AuthSessionTokenReply.Builder> InternalFieldAccessors
        {
            get { return global::FrameWork.AuthSessionTokenReplyProto.internal__static_login_proto_AuthSessionTokenReply__FieldAccessorTable; }
        }

        #region Nested types

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static partial class Types
        {
            public enum ResultCode
            {
                RES_SUCCESS = 0,
                RES_PROTOCOL_UNSUPPORTED = 1,
                RES_PRODUCT_UNSUPPORTED = 2,
                RES_ACCOUNT_AUTH_FAILED = 3,
                RES_ACCOUNT_TERMINATED = 4,
                RES_ACCOUNT_EXPIRED = 5,
                RES_ACCOUNT_SUSPENDED = 6,
                RES_ACCOUNT_SECONDARY_AUTH_NEEDED = 7,
                RES_ACCOUNT_ALREADY_ONLINE = 8,
                RES_SYSTEM_ERROR = 9,
                RES_ENCRYPTION_ERROR = 10,
            }
        }

        #endregion Nested types

        public const int ResultCodeFieldNumber = 1;
        private bool hasResultCode;
        private global::FrameWork.AuthSessionTokenReply.Types.ResultCode resultCode_ = global::FrameWork.AuthSessionTokenReply.Types.ResultCode.RES_SUCCESS;

        public bool HasResultCode
        {
            get { return hasResultCode; }
        }

        public global::FrameWork.AuthSessionTokenReply.Types.ResultCode ResultCode
        {
            get { return resultCode_; }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!hasResultCode) return false;
                return true;
            }
        }

        public override void WriteTo(pb::ICodedOutputStream output)
        {
            int size = SerializedSize;
            string[] field_names = _authSessionTokenReplyFieldNames;
            if (hasResultCode)
            {
                output.WriteEnum(1, field_names[0], (int)ResultCode, ResultCode);
            }
            UnknownFields.WriteTo(output);
        }

        private int memoizedSerializedSize = -1;

        public override int SerializedSize
        {
            get
            {
                int size = memoizedSerializedSize;
                if (size != -1) return size;

                size = 0;
                if (hasResultCode)
                {
                    size += pb::CodedOutputStream.ComputeEnumSize(1, (int)ResultCode);
                }
                size += UnknownFields.SerializedSize;
                memoizedSerializedSize = size;
                return size;
            }
        }

        public static AuthSessionTokenReply ParseFrom(pb::ByteString data)
        {
            return ((Builder)CreateBuilder().MergeFrom(data)).BuildParsed();
        }

        public static AuthSessionTokenReply ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry)
        {
            return ((Builder)CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
        }

        public static AuthSessionTokenReply ParseFrom(byte[] data)
        {
            return ((Builder)CreateBuilder().MergeFrom(data)).BuildParsed();
        }

        public static AuthSessionTokenReply ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry)
        {
            return ((Builder)CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
        }

        public static AuthSessionTokenReply ParseFrom(global::System.IO.Stream input)
        {
            return ((Builder)CreateBuilder().MergeFrom(input)).BuildParsed();
        }

        public static AuthSessionTokenReply ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry)
        {
            return ((Builder)CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
        }

        public static AuthSessionTokenReply ParseDelimitedFrom(global::System.IO.Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AuthSessionTokenReply ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AuthSessionTokenReply ParseFrom(pb::ICodedInputStream input)
        {
            return ((Builder)CreateBuilder().MergeFrom(input)).BuildParsed();
        }

        public static AuthSessionTokenReply ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry)
        {
            return ((Builder)CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
        }

        private AuthSessionTokenReply MakeReadOnly()
        {
            return this;
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AuthSessionTokenReply prototype)
        {
            return new Builder(prototype);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public sealed partial class Builder : pb::GeneratedBuilder<AuthSessionTokenReply, Builder>
        {
            protected override Builder ThisBuilder
            {
                get { return this; }
            }

            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            internal Builder(AuthSessionTokenReply cloneFrom)
            {
                result = cloneFrom;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private AuthSessionTokenReply result;

            private AuthSessionTokenReply PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    AuthSessionTokenReply original = result;
                    result = new AuthSessionTokenReply();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public override bool IsInitialized
            {
                get { return result.IsInitialized; }
            }

            protected override AuthSessionTokenReply MessageBeingBuilt
            {
                get { return PrepareBuilder(); }
            }

            public override Builder Clear()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
                return this;
            }

            public override Builder Clone()
            {
                if (resultIsReadOnly)
                {
                    return new Builder(result);
                }
                else
                {
                    return new Builder().MergeFrom(result);
                }
            }

            public override pbd::MessageDescriptor DescriptorForType
            {
                get { return global::FrameWork.AuthSessionTokenReply.Descriptor; }
            }

            public override AuthSessionTokenReply DefaultInstanceForType
            {
                get { return global::FrameWork.AuthSessionTokenReply.DefaultInstance; }
            }

            public override AuthSessionTokenReply BuildPartial()
            {
                if (resultIsReadOnly)
                {
                    return result;
                }
                resultIsReadOnly = true;
                return result.MakeReadOnly();
            }

            public override Builder MergeFrom(pb::IMessage other)
            {
                if (other is AuthSessionTokenReply)
                {
                    return MergeFrom((AuthSessionTokenReply)other);
                }
                else
                {
                    base.MergeFrom(other);
                    return this;
                }
            }

            public override Builder MergeFrom(AuthSessionTokenReply other)
            {
                if (other == global::FrameWork.AuthSessionTokenReply.DefaultInstance) return this;
                PrepareBuilder();
                if (other.HasResultCode)
                {
                    ResultCode = other.ResultCode;
                }
                this.MergeUnknownFields(other.UnknownFields);
                return this;
            }

            public override Builder MergeFrom(pb::ICodedInputStream input)
            {
                return MergeFrom(input, pb::ExtensionRegistry.Empty);
            }

            public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry)
            {
                PrepareBuilder();
                pb::UnknownFieldSet.Builder unknownFields = null;
                uint tag;
                string field_name;
                while (input.ReadTag(out tag, out field_name))
                {
                    if (tag == 0 && field_name != null)
                    {
                        int field_ordinal = global::System.Array.BinarySearch(_authSessionTokenReplyFieldNames, field_name, global::System.StringComparer.Ordinal);
                        if (field_ordinal >= 0)
                            tag = _authSessionTokenReplyFieldTags[field_ordinal];
                        else
                        {
                            if (unknownFields == null)
                            {
                                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                            }
                            ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
                            continue;
                        }
                    }
                    switch (tag)
                    {
                        case 0:
                            {
                                throw pb::InvalidProtocolBufferException.InvalidTag();
                            }
                        default:
                            {
                                if (pb::WireFormat.IsEndGroupTag(tag))
                                {
                                    if (unknownFields != null)
                                    {
                                        this.UnknownFields = unknownFields.Build();
                                    }
                                    return this;
                                }
                                if (unknownFields == null)
                                {
                                    unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                                }
                                ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
                                break;
                            }
                        case 8:
                            {
                                object unknown;
                                if (input.ReadEnum(ref result.resultCode_, out unknown))
                                {
                                    result.hasResultCode = true;
                                }
                                else if (unknown is int)
                                {
                                    if (unknownFields == null)
                                    {
                                        unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                                    }
                                    unknownFields.MergeVarintField(1, (ulong)(int)unknown);
                                }
                                break;
                            }
                    }
                }

                if (unknownFields != null)
                {
                    this.UnknownFields = unknownFields.Build();
                }
                return this;
            }

            public bool HasResultCode
            {
                get { return result.hasResultCode; }
            }

            public global::FrameWork.AuthSessionTokenReply.Types.ResultCode ResultCode
            {
                get { return result.ResultCode; }
                set { SetResultCode(value); }
            }

            public Builder SetResultCode(global::FrameWork.AuthSessionTokenReply.Types.ResultCode value)
            {
                PrepareBuilder();
                result.hasResultCode = true;
                result.resultCode_ = value;
                return this;
            }

            public Builder ClearResultCode()
            {
                PrepareBuilder();
                result.hasResultCode = false;
                result.resultCode_ = global::FrameWork.AuthSessionTokenReply.Types.ResultCode.RES_SUCCESS;
                return this;
            }
        }

        static AuthSessionTokenReply()
        {
            object.ReferenceEquals(global::FrameWork.AuthSessionTokenReplyProto.Descriptor, null);
        }
    }

    #endregion Messages
}

#endregion Designer generated code