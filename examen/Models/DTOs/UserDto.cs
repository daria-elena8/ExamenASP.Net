﻿namespace examen.Models.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;

        public string Email { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
