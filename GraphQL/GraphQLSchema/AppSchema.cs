using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using GraphQL_DotNetCore.GraphQL.GraphQLQueries;
using System;

namespace GraphQL_DotNetCore.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();

            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
