using GraphQL.Types;
using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using GraphQL_DotNetCore.Repository;
using GraphQL.DataLoader;
using System;

namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{ 
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id).Description("Id property from the owner object.");
            Field(x => x.Name).Description("Name property from the owner object.");
            Field(x => x.DOB, nullable: true).Description("DOB property from the owner object.");
            Field(x => x.Address).Description("Address property from the owner object.");
            Field(x => x.Email).Description("Email property from the owner object.");
            Field(x => x.Phone).Description("Phone property from the owner object.");
            Field<ListGraphType<AccountType>>(
                "accounts",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => repository.GetAccountsByOwnerId(context.Source.Id)
                );
        }
    }
}
