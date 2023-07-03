using GraphQL.Types;

namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{
    public class OwnerAccountsInputType : InputObjectGraphType
    {
        public OwnerAccountsInputType()
        {
            Name = "ownerAccountsInput";
            Field<NonNullGraphType<StringGraphType>>("ownerName");
            Field<NonNullGraphType<StringGraphType>>("accountType");            
        }    
    }
}
