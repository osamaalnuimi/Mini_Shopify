﻿namespace Mini_Shopify.Entities.Models.Dto
{
    public class RegisterationRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
