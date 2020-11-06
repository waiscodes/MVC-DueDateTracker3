﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDueDateTracker.Models
{
    [Table("borrow")]
    public class Borrow
    {
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "int(10)")]
        public int BookID { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckedOutDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReturnedDate { get; set; }

        [ForeignKey(nameof(BookID))]
        [InverseProperty(nameof(Models.Book.Borrows))]
        public virtual Book Book { get; set; }
    }
}
