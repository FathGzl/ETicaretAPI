using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz")
                .MaximumLength(150).MinimumLength(1).WithMessage("Lütfen Ürün Adını 1 ile 150 karakter arası giriniz.");

            RuleFor(p => p.Stock)
                .NotEmpty().NotNull().WithMessage("Lütfen Stok Bilgisini Boş Geçmeyiniz")
                .Must(s => s >= 0).WithMessage("Lütfen Stok Bilgisini 0 dan Büyük Giriniz");

            RuleFor(p => p.Stock)
               .NotEmpty().NotNull().WithMessage("Lütfen Fiyat Bilgisini Boş Geçmeyiniz")
               .Must(s => s >= 0).WithMessage("Lütfen Fiyat Bilgisini 0 dan Büyük Giriniz");

        }
    }
}
