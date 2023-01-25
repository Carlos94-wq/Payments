using AutoMapper;
using Payments.Core.CustomEntities;
using Payments.Core.Dtos;
using Payments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Infra.Mapping
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<PaymentInsert, PAYMENT>();
            CreateMap<PaymentUpdate, PAYMENT>();
            CreateMap<UserCredentials, USER>();
        }
    }
}
