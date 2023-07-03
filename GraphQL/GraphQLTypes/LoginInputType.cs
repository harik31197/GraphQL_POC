using GraphQL_DotNetCore.Models;
using GraphQL.Types;


namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{
  public class LoginInputType: InputObjectGraphType<LoginInput>
  {
    public LoginInputType()
    {
      Name = "loginInput";
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("email");


    }
  }
}
