﻿using FluentAssertions;
using Microsoft.Extensions.Options;
using saledev.Authentication.JwtBearer;
using Xunit;

namespace saledev.Authentication.UnitTests;

public class AuthenticationServiceTests
{
    //private readonly PagedInfo _pagedInfo = new PagedInfo(0, 10, 1, 3);

    [Fact]
    public void GenerateNewToken()
    {
        var options = Options.Create(new AuthenticationOptions()
        {
            Secret = "test123",
            HoursTokenIsValid = 24
        });
        var service = new AuthenticationService(options);
        var userId = new Guid();
        var claim = new Claim()
        {
            UserId = userId.ToString(),
            Roles = new List<string> { "Admin", "Customer" }
        };

        var token = service.EncodeClaim(claim);
        token.Should().NotBeEmpty();

        var decodedClaim = service.DecodeClaim(token);
        decodedClaim.Should().NotBeNull();

        decodedClaim.Should().BeEquivalentTo(claim);
    }

/*
    [Fact]
    public void InitializesStronglyTypedObjectValue()
    {
        var expectedObject = new TestObject();
        var result = new PagedResult<TestObject>(_pagedInfo, expectedObject);

        Assert.Equal(expectedObject, result.Value);
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }

    private class TestObject
    {
    }

    [Fact]
    public void InitializesValueToNullGivenNullConstructorArgument()
    {
        var result = new PagedResult<object>(_pagedInfo, null);

        Assert.Null(result.Value);
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(123)]
    [InlineData("test value")]
    public void InitializesStatusToOkGivenValue(object value)
    {
        var result = new PagedResult<object>(_pagedInfo, value);

        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(123)]
    [InlineData("test value")]
    public void InitializesValueUsingFactoryMethodAndSetsStatusToOk(object value)
    {
        var result = Result<object>
            .Success(value)
            .ToPagedResult(_pagedInfo);

        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal(value, result.Value);
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }

    [Fact]
    public void InitializesStatusToErrorGivenErrorFactoryCall()
    {
        var result = Result<object>
            .Error()
            .ToPagedResult(_pagedInfo);

        Assert.Equal(ResultStatus.Error, result.Status);
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }

    [Fact]
    public void InitializesStatusToErrorAndSetsErrorMessageGivenErrorFactoryCall()
    {
        string errorMessage = "Something bad happened.";
        var result = Result<object>
            .Error(errorMessage)
            .ToPagedResult(_pagedInfo);

        Assert.Equal(ResultStatus.Error, result.Status);
        Assert.Equal(errorMessage, result.Errors.First());
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }

    [Fact]
    public void InitializesStatusToInvalidAndSetsErrorMessagesGivenInvalidFactoryCall()
    {
        var validationErrors = new List<ValidationError>
            {
                new ValidationError
                {
                    Identifier = "name",
                    ErrorMessage = "Name is required"
                },
                new ValidationError
                {
                    Identifier = "postalCode",
                    ErrorMessage = "PostalCode cannot exceed 10 characters"
                }
            };
        // TODO: Support duplicates of the same key with multiple errors
        var result = Result<object>
            .Invalid(validationErrors)
            .ToPagedResult(_pagedInfo);

        result.Status.Should().Be(ResultStatus.Invalid);
        result.ValidationErrors.Should().ContainEquivalentOf(new ValidationError { ErrorMessage = "Name is required", Identifier = "name" });
        result.ValidationErrors.Should().ContainEquivalentOf(new ValidationError { ErrorMessage = "PostalCode cannot exceed 10 characters", Identifier = "postalCode" });
        result.PagedInfo.Should().Be(_pagedInfo);
    }

    [Fact]
    public void InitializesStatusToNotFoundGivenNotFoundFactoryCall()
    {
        var result = Result<object>
            .NotFound()
            .ToPagedResult(_pagedInfo);

        Assert.Equal(ResultStatus.NotFound, result.Status);
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }

    [Fact]
    public void InitializesStatusToForbiddenGivenForbiddenFactoryCall()
    {
        var result = Result<object>
            .Forbidden()
            .ToPagedResult(_pagedInfo);

        Assert.Equal(ResultStatus.Forbidden, result.Status);
        Assert.Equal(_pagedInfo, result.PagedInfo);
    }
*/
}
