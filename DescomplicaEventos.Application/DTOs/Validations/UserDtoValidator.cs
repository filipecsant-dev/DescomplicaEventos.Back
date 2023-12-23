using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace DescomplicaEventos.Application.DTOs.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Email BlaBla!");
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Nome deve ser informado!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Password deve ser informado!");

            RuleFor(x => x.Idade)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Idade deve ser informado!");
            
            RuleFor(x => x.Idade)
                .NotEmpty()
                .When(m => m.Idade < 1)
                .WithMessage("O campo Idade não pode ser menor que 1");
                
        }
    }
}