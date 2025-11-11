using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.CoreBusiness.Validations
{
    public class Products_EnsurePriceIsGreatherThenInventoriesCost: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if (product != null) {
                if (!ValidatePricing(product))
                {
                    return new ValidationResult(
                        $"The product price must be greater than the total cost of its inventories: {TotalInventoriesCost(product).ToString("c")}!",
                       new List<string>(){validationContext.MemberName});
                } }
            return ValidationResult.Success;
        }
        private double TotalInventoriesCost(Product product)
        {
            if(product == null || product.ProductInventories==null) { return 0; }
            return product.ProductInventories.Sum(x => x.Inventory?.Price * x.InvetoryQuantity??0);
        }
        bool ValidatePricing(Product product)
        {
            if (product.ProductInventories == null || product.ProductInventories.Count <= 0) { return true; }
            if(TotalInventoriesCost(product) > product.Price)   
            {
                return false;
               }
            return true;
        }
    }
}
