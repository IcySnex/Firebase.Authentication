using Firebase.Authentication.Models;
using Firebase.Authentication.Types;

namespace Firebase.Authentication.Tests.Internal;

internal class JsonHelper
{
    [Test]
    public void Enum_Serialize()
    {
        // Mock model
        FederatedUserIdentifier model = new(Provider.Google, "some-id");

        // Serialize
        string json = Authentication.Internal.Json.JsonHelper.Serialize(model);

        // Write result
        TestData.Write(json);
    }


    [Test]
    public void Enum_Deserialize()
    {
        // Mock json
        string json = "{\"providerId\":\"google.com\",\"rawId\":\"some-id\"}";

        // Deserialize
        FederatedUserIdentifier model = Authentication.Internal.Json.JsonHelper.Deserialize<FederatedUserIdentifier>(json);

        // Write result
        TestData.Write(model);
    }
}