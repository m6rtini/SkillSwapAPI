using FluentValidation;

public class CreateSkillRequestValidator : AbstractValidator<CreateSkillRequestDto>
{
    public CreateSkillRequestValidator()
    {
        RuleFor(x => x.RequestText).NotEmpty().MinimumLength(5);
    }
}
