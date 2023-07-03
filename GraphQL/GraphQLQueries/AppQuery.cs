using GraphQL;
using GraphQL.Types;
using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.GraphQL.GraphQLTypes;
using System;

namespace GraphQL_DotNetCore.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository ownerRepository, IAccountRepository accountRepository)
        {

            Field<ListGraphType<AccountType>>(
                "accounts", resolve: context => accountRepository.GetAllAccounts()
                );
        
            Field<ListGraphType<OwnerType>>(
                "owners", resolve: context =>
                {
                  try
                  {
                    var ownRep = ownerRepository.GetAllOwners();
                    return ownRep;

                  }
                  catch(Exception ex)
                  {
                    throw new Exception(ex.Message.ToString());
                  }
                }
                );    
      
                Field<ListGraphType<OwnerType>>(
                "ownerswithtype", resolve: context =>
                {
                  try
                  {
                    var ownRep = ownerRepository.GetAllOwners();
                    return ownRep;

                  }
                  catch(Exception ex)
                  {
                    throw new Exception(ex.Message.ToString());
                  }
                }
                ); 

            Field<OwnerType>(
                "owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                  var ownRep = ownerRepository.GetOwnerById(context.GetArgument<int>("id"));
                  if(ownRep == null)
                  {
                    context.Errors.Add(new ExecutionError("Invalid id"));
                    return null;

                  }
                  return ownRep;
                });

        }
    }
}
