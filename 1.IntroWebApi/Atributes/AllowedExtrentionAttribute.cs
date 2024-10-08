﻿using System.ComponentModel.DataAnnotations;

namespace _1.IntroWebApi.Atributes
{
    public class AllowedExtrentionAttribute : ValidationAttribute
    {
        private readonly string[] _extentions;
        public AllowedExtrentionAttribute(string[] extentions)
        {
            _extentions = extentions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                if (!_extentions.Contains(extention.ToLower()))
                {
                    return new ValidationResult($"This photo is not allowed{string.Join(", ", _extentions)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
