﻿using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class ReadSubCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public int CategoryId { get; set; }

    }
}
