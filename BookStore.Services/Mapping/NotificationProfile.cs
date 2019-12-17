using AutoMapper;
using BookStore.Common.ViewModels.NotificationController;
using BookStore.DAL.Models.Entitys;

namespace BookStore.Services.Mapping
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationsByUserIdViewItem>();

            CreateMap<CreateNotificationRequestView, Notification>()
                .ForMember(destination => destination.PersonId, source => source.MapFrom(src => src.PersonId));
        }
    }
}
