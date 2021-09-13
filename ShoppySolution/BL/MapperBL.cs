using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MapperBL : Profile
    {
        public MapperBL()
        {
            CreateMap<AddressDO, Address>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.OrderDeliveryAddresses, opt => opt.MapFrom(src => src.OrderDeliveryAddresses))
                .ForMember(dest => dest.OrderInvoiceAddresses, opt => opt.MapFrom(src => src.OrderInvoiceAddresses))
                .ReverseMap();

            CreateMap<AdminDO, Admin>().ReverseMap();

            CreateMap<BankDO, Bank>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.BankInstallments, opt => opt.MapFrom(src => src.BankInstallments))
                .ReverseMap();

            CreateMap<BankInstallmentDO, BankInstallment>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank))
                .ReverseMap();

            CreateMap<BasketDO, Basket>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<BrandDO, Brand>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();

            CreateMap<CategoryDO, Category>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();

            CreateMap<CityDO, City>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();

            CreateMap<OrderDO, Order>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
                .ForMember(dest => dest.InvoiceAddress, opt => opt.MapFrom(src => src.InvoiceAddress))
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Orderitems, opt => opt.MapFrom(src => src.Orderitems))
                .ReverseMap();

            CreateMap<OrderitemDO, Orderitem>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<PageDO, Page>().ReverseMap();

            CreateMap<PaymentDO, Payment>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Shipping, opt => opt.MapFrom(src => src.Shipping))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ReverseMap();

            CreateMap<ProductDO, Product>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.Baskets, opt => opt.MapFrom(src => src.Baskets))
                .ForMember(dest => dest.Orderitems, opt => opt.MapFrom(src => src.Orderitems))
                .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages))
                .ForMember(dest => dest.Wishlists, opt => opt.MapFrom(src => src.Wishlists))
                .ReverseMap();

            CreateMap<ProductImageDO, ProductImage>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ReverseMap();

            CreateMap<ProvinceDO, Province>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities))
                .ReverseMap();

            CreateMap<ResetpasswordDO, Resetpassword>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<SettingDO, Setting>().ReverseMap();

            CreateMap<ShippingDO, Shipping>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments))
                .ReverseMap();

            CreateMap<SliderDO, Slider>().ReverseMap();

            CreateMap<UnitDO, Unit>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();

            CreateMap<UserDO, User>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Baskets, opt => opt.MapFrom(src => src.Baskets))
                .ForMember(dest => dest.Orderitems, opt => opt.MapFrom(src => src.Orderitems))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments))
                .ForMember(dest => dest.Resetpasswords, opt => opt.MapFrom(src => src.Resetpasswords))
                .ForMember(dest => dest.Wishlists, opt => opt.MapFrom(src => src.Wishlists))
                .ReverseMap();

            CreateMap<WishlistDO, Wishlist>()
                // Dealing with the relationship of the table
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
        }
    }
}
