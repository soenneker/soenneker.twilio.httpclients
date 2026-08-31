[![](https://img.shields.io/nuget/v/soenneker.twilio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.twilio.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.twilio.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.twilio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Twilio.HttpClients
Provides an owned, cached `HttpClient` transport for Twilio's REST API.

## Installation

```bash
dotnet add package Soenneker.Twilio.HttpClients
```

This package supplies the transport used by `Soenneker.Twilio.OpenApiClientUtil`. It sets the Twilio API base URL but intentionally leaves authentication to the API-specific client layer.

## Configuration

The default base URL is `https://api.twilio.com/`. Override it only when routing through a compatible endpoint:

```json
{
  "Twilio": {
    "ClientBaseUrl": "https://api.twilio.com/"
  }
}
```

## Registration

```csharp
using Soenneker.Twilio.HttpClients.Registrars;

services.AddTwilioOpenApiHttpClientAsSingleton();
```

Use `AddTwilioOpenApiHttpClientAsScoped()` when the transport owner should follow the current scope. Each owner has a distinct cached client and removes only that client when disposed.

## Usage

```csharp
using Soenneker.Twilio.HttpClients.Abstract;

HttpClient httpClient = await twilioHttpClient.Get(cancellationToken);
```

Reuse the returned client and do not dispose it directly. For authenticated Twilio OpenAPI calls, prefer `Soenneker.Twilio.OpenApiClientUtil`, which owns credential application and the generated request adapter.
