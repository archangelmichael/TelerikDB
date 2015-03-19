namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Class1
    {
        private ICollection<Class1> items;

        public Class1()
        {
            this.Id = Guid.NewGuid();
            this.items = new HashSet<Class1>();
        }

        [Key]
        public Guid Id { get; set; }

        public int ID { get; set; }

        /// <summary>
        /// One to one connection
        /// </summary>
        public int ItemID { get; set; }

        public virtual Class1 Item { get; set; }

        /// <summary>
        /// Many to Many connection
        /// </summary>
        public virtual ICollection<Class1> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }


    }
}
