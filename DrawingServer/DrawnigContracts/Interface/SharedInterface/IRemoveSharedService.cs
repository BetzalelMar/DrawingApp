using Contracts.DTO;
using DrawnigContracts.DTO.SharedDTO.SharedRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface.SharedInterface
{
    public interface IRemoveSharedService
    {
        public Response RemoveShaerd(RemoveShaerdRequest request);

    }
}
