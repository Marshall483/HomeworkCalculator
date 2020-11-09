﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string Title { get; set; }

        [Display(Name = "Release Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"[A-Z]+[a-zA-Z]*$")]
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18, 2)"), Range(1,100), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(30), Required, RegularExpression(@"[A-Z]+[a-zA-Z0-9]*$")]
        public string Raiting { get; set; }

    }
}
