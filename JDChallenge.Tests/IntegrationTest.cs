using JDChallenge.Business.Permissions.Commands;
using JDChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace JDChallenge.Tests;

public class IntegrationTest
{
    private WebApplicationFactory<Program> _application;
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _application = new CustomWebApplicationFactory<Program>();
        _httpClient = _application.CreateClient();
    }

    [Test]
    public async Task GetPermissions()
    {
        var response = await _httpClient.GetAsync("permissions");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var content = await response.Content.ReadAsStringAsync();
        var permissions = JsonConvert.DeserializeObject<IEnumerable<Permission>>(content);
        Assert.That(permissions, Is.Not.Null);
    }

    [Test, Order(1)]
    public async Task RequestPermission()
    {
        var data = new UpdatePermission() { Id = 1, EmployeeId = 1, PermissionTypeId = 1 };
        var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("permissions", stringContent);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

    [Test, Order(2)]
    public async Task ModifyPermission()
    {
        var data = new UpdatePermission() { Id = 1, EmployeeId = 1, PermissionTypeId = 1 };
        var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("permissions", stringContent);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}