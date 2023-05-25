﻿using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.EntityDto
{
    public class EntityDto<TKey>
    {
        private const string dateFormat = "dd/MM/yyyy HH:mm:ss zz";
        public EntityDto(BaseEntity<TKey> entity)
        {
            Id = entity.Id;
            CreatedUtc = entity.CreatedUtc.ToString(dateFormat);
            UpdatedUtc = entity.UpdatedUtc.ToString(dateFormat);
        }
        public TKey Id { get; set; }
        public string CreatedUtc { get; set; }
        public string UpdatedUtc { get; set; }
    }
}