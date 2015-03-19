using Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Application.Web.Models
{
    public class OrderModel
    {
        public static Expression<Func<Order, OrderModel>> FromOrder
        {
            get
            {
                return o => new OrderModel
                {
                    Id = o.Id,
                    Firstname = o.Firstname,
                    Lastname = o.Lastname,
                    Phone = o.Phone,
                    Email = o.Email,
                    Brand = o.Brand,
                    Registration = o.Registration,
                    Maintenance = o.Maintenance,
                    Checkdate = o.Checkdate.ToString(),
                    Information = o.Information
                };
            }
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(18)]
        public string Phone { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(10)]
        public string Registration { get; set; }

        [Required]
        [MaxLength(100)]
        public string Maintenance { get; set; }


        [Required]
        public string Checkdate { get; set; }

        [MaxLength(250)]
        public string Information { get; set; }

        public override string ToString()
        {
            return string.Format("Нова резервация {0} Име: {1}{0} Фамилия: {2}{0} Телефон за връзка: {3}{0} Имейл: {4}{0}" +
                "Модел: {5}{0} Регистрация: {6}{0} Вид обслужване: {7}{0} Дата и час: {8}{0} Допълнителна информация: {9}{0}",
                Environment.NewLine,
                this.Firstname,
                this.Lastname,
                this.Phone,
                this.Email,
                this.Brand,
                this.Registration,
                this.Maintenance,
                DateTime.Parse(this.Checkdate).ToString("d M yyyy HH:mm:ss"),
                this.Information);
        }
    }
}