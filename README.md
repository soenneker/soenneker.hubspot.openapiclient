[![](https://img.shields.io/nuget/v/soenneker.hubspot.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hubspot.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hubspot.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hubspot.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.hubspot.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hubspot.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hubspot.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.hubspot.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.HubSpot.OpenApiClient

Call HubSpot endpoints through a Kiota-generated client with typed request builders and models.

## Install

```bash
dotnet add package Soenneker.HubSpot.OpenApiClient
```

## Create a client

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.HubSpot.OpenApiClient;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.hubapi.com/")
};
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", privateAppAccessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new HubSpotOpenApiClient(adapter);
```

The `HttpClient` supplies private-app authentication, so the Kiota adapter uses anonymous authentication. Reuse the transport rather than constructing one per request, and dispose it when its owning application component shuts down.

For application registration, per-token client reuse, and coordinated transport ownership, use `Soenneker.HubSpot.OpenApiClientUtil` instead of constructing the generated client directly.

## Call an endpoint

```csharp
using Soenneker.HubSpot.OpenApiClient.Models;

CollectionResponsePublicOwnerForwardPaging? owners =
    await client.Crm.Owners.TwoZeroTwoSixZeroThree.GetAsync(
        cancellationToken: cancellationToken);
```

The generated surface mirrors HubSpot's combined OpenAPI description. Names such as `TwoZeroTwoSixZeroThree` are generated representations of versioned path segments; follow the request-builder properties from areas such as `Crm`, `Marketing`, `Cms`, `Files`, and `Conversations` to the desired operation.

HTTP failures are surfaced through Kiota exceptions. Nullable results indicate that an endpoint returned no response body.

This repository contains generated code. Put reusable helpers and behavior changes in a separate package so regeneration does not overwrite them.
