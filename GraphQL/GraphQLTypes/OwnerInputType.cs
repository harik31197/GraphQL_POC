using GraphQL.Types;

namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{
    public class OwnerInputType : InputObjectGraphType
    {
        public OwnerInputType()
        {
            Name = "ownerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("phone");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("dob");
            Field<NonNullGraphType<StringGraphType>>("address");
        }
    }
}
