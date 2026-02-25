using EComApp.AppDbContext;
using EComApp.DTOs;
using EComApp.Models;
using EComApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EComApp.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly EComDbContext _eComDbContext;
        public CustomerService(EComDbContext eComDbContext)
        {
            _eComDbContext = eComDbContext;
        }
        public async Task<ApiResponse<LoginResponseDTO>> CustomerLogin(CustomerLoginDto customerLoginDto)
        {
            try
            {
                var user = await _eComDbContext.Customers.FirstOrDefaultAsync(c => c.Email == customerLoginDto.Email);
                if(user == null || user.Password != customerLoginDto.Password)
                {
                    return new ApiResponse<LoginResponseDTO>(401, "Invalid email or password");
                }
                var response = new LoginResponseDTO
                {
                    CustomerId = user.Id,
                    CustomerName = user.FirstName + " " + user.MiddleName + " " + user.LastName,
                    Message = "Login Successfull"
                };

                return new ApiResponse<LoginResponseDTO>(200, response);

            }
            catch(Exception e)
            {
                return new ApiResponse<LoginResponseDTO>(500, "Internal Server Error");
            }
        }

        public async Task<ApiResponse<CustomerResponseDTO>> RegisterCustomer(CustomerRegistrationDTO registerCustomer)
        {
            try
            {
                var user = await _eComDbContext.Customers.FirstOrDefaultAsync(c => c.Email == registerCustomer.Email);
                if(user != null)
                {
                    return new ApiResponse<CustomerResponseDTO>(409, "User already registered with this Email");
                }
                user = new Customer
                {
                    FirstName = registerCustomer.FirstName,
                    MiddleName = registerCustomer.MiddleName,
                    LastName = registerCustomer.LastName,
                    PhoneNumber = registerCustomer.Phone,
                    Password = registerCustomer.Password,
                    Email = registerCustomer.Email,
                    DateOfBirth = registerCustomer.DateOfBirth,
                    IsActive = true
                };
                await _eComDbContext.Customers.AddAsync(user);
                await _eComDbContext.SaveChangesAsync();
                CustomerResponseDTO crd = new CustomerResponseDTO()
                {
                    FirstName = registerCustomer.FirstName,
                    MiddleName = registerCustomer.MiddleName,
                    LastName = registerCustomer.LastName,
                    Phone = registerCustomer.Phone,
                    Email = registerCustomer.Email,
                    DateOfBirth = registerCustomer.DateOfBirth
                };
                return new ApiResponse<CustomerResponseDTO>(201, crd);
            }
            catch (Exception e)
            {
                return new ApiResponse<CustomerResponseDTO>(500, "Internal Server Error");
            }
        }

        public Task<ApiResponse<CustomerResponseDTO>> UpdateCustomerDetails(CustomerUpdateDTO customerUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<CustomerResponseDTO>> UpdatePassword(ChangePasswordDTO changePassword)
        {
            throw new NotImplementedException();
        }
    }
}
