using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.UserViewModels
{
    public class BlockedUsersListViewModel
    {
        public BlockedUsersListViewModel()
        {
            this.Users = new List<BlockedUserViewModel>();
        }

        public List<BlockedUserViewModel> Users { get; set; }
    }
}
