using PoissonSoft.Crex24Api;

namespace CrexApi.Example
{
    interface ICredentialsProvider
    {
        Crex24ApiClientCredentials GetCredentials();
    }
}
