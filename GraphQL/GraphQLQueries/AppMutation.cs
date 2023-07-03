using GraphQL;
using GraphQL.Types;
using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using GraphQL_DotNetCore.GraphQL.GraphQLTypes;

namespace GraphQL_DotNetCore.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository ownerRepository, IAccountRepository accountRepository)
        {
            Field<OwnerType>(
                "createOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");

                    var dbOwner = ownerRepository.GetOwnerByName(owner.Name);
                    if (dbOwner != null)
                    {
                        context.Errors.Add(new ExecutionError("Owner Name already exists in DB!"));
                        return null;
                    }

                    return ownerRepository.CreateOwner(owner);
                });
        
            Field<OwnerType>(
                "updateOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");

                    var dbOwner = ownerRepository.GetOwnerByName(owner.Name);
                    if (dbOwner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't found owner id in db"));
                        return null;
                    }

                    return ownerRepository.UpdateOwner(dbOwner, owner);
                });

            Field<StringGraphType>(
                "deleteOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerName" }),
                resolve: context =>
                {
                    var ownerName = context.GetArgument<string>("ownerName");
                    var dbOwner = ownerRepository.GetOwnerByName(ownerName);
                    if (dbOwner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't found owner in db"));
                        return null;
                    }

                    if (ownerRepository.CheckOwnerLinkExists(ownerName) != null)
                    {
                        context.Errors.Add(new ExecutionError("Can't able to delete owner linked with accounts"));
                        return null;
                    }

                    ownerRepository.DeleteOwner(dbOwner);
                    return $"The owner with the Id : {ownerName} has been successfully deleted from db";
                });

            Field<OwnerType>(
                "linkOwnerAccounts",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerAccountsInputType>> { Name = "ownerAccounts" }),
                resolve: context =>
                {
                    var ownerAccounts = context.GetArgument<OwnerAccountsDetail>("ownerAccounts");

                    if (ownerRepository.GetOwnerByName(ownerAccounts.OwnerName) == null)
                    {
                        context.Errors.Add(new ExecutionError("Owner Name not available"));
                        return null;
                    }

                    if (accountRepository.GetAccountByType(ownerAccounts.AccountType) == null)
                    {
                        context.Errors.Add(new ExecutionError("Account Type not available"));
                        return null;
                    }

                    if (ownerRepository.CheckOwnerAccounts(ownerAccounts) != null)
                    {
                        context.Errors.Add(new ExecutionError("This account type is already linked with owner."));
                        return null;
                    }

                    return ownerRepository.CreateOwnerAccounts(ownerAccounts);
                });
            //Field<LoginInputType>(
            //  "loginInput",
            //  arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LoginInputType>> { Name = "loginInput" }),
            //  resolve:context =>
            //  {
            //    var ownerName = context.GetArgument<string>("ownerName");
            //    return "Welcome token";

            //  });

        }
    }
}
