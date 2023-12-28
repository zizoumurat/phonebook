﻿using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;
using PersonService.Application.Services;
using PersonService.Domain.Validation;
using PersonService.Persistance.AutoMapper;
using Shouldly;

namespace PersonService.UnitTest.Features.ContactInformationFeatures.Commands;

public class CreateCICommandUnitTest
{
    private readonly Mock<IContactInformaionService> _contactInformationService;
    private readonly IMapper _mapper;

    public CreateCICommandUnitTest()
    {
        _contactInformationService = new();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = new Mapper(configuration);
    }

    [Fact]
    public async Task CreateCICommandResponseShouldNotBeNull()
    {
        var command = new CreateCICommand("", "09999999999", "test@test.com", "Konya");
        var handler = new CreateCICommandHandler(_contactInformationService.Object, _mapper);

        var response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.message.ShouldNotBeNullOrEmpty();
    }

    [Fact]
    public async Task ShouldHaveErrorWhenEmailIsInvalid()
    {
        var validator = new CreateCICommandValidator();
        var command = new CreateCICommand("", "09999999999", "invalidEmail", "Konya");

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(r => r.email)
            .WithErrorMessage(ValidationMessages.InvalidEmail);
    }

    [Fact]
    public async Task ShouldHaveErrorWhenPhoneIsEmpty()
    {
        var validator = new CreateCICommandValidator();
        var command = new CreateCICommand("", "", "abc@abc.com", "Konya");

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(r => r.phoneNumber)
            .WithErrorMessage(ValidationMessages.PhoneNumberRequired);
    }

    [Fact]
    public async Task ShouldHaveErrorWhenLocationIsEmpty()
    {
        var validator = new CreateCICommandValidator();
        var command = new CreateCICommand("", "0000000000", "abc@abc.com", "");

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(r => r.location)
            .WithErrorMessage(ValidationMessages.LocationRequired);
    }

}
