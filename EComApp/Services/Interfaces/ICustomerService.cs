using EComApp.DTOs;

namespace EComApp.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<ApiResponse<CustomerResponseDTO>> RegisterCustomer(CustomerRegistrationDTO registerCustomer);
        public Task<ApiResponse<LoginResponseDTO>> CustomerLogin(CustomerLoginDto customerLoginDto);
        public Task<ApiResponse<CustomerResponseDTO>> UpdateCustomerDetails(CustomerUpdateDTO customerUpdate);
        public Task<ApiResponse<CustomerResponseDTO>> UpdatePassword(ChangePasswordDTO changePassword);

    }
}
