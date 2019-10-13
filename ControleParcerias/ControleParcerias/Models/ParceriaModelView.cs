using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ControleParcerias.Models
{
    public class ParceriaModelView : IValidatableObject
    {
         public int Codigo { get; set; }

        [Required(ErrorMessage = "Título  é obrigatório")]
        [DataType(DataType.Text)]
        [StringLength(255, MinimumLength = 0)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição  é obrigatória")]
        [DataType(DataType.Text)]
        [StringLength(16, MinimumLength = 0)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.Url)]
        [StringLength(1000, MinimumLength = 0)]
        [Display(Name = "Url da página do parceiro")]
        public string URLPagina { get; set; }

        [Required(ErrorMessage = "Empresa  é obrigatória")]
        [DataType(DataType.Text)]
        [StringLength(40, MinimumLength = 0)]
        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Data Início é obrigatória")]
        [DataType(DataType.Date)]       
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }


        [Required(ErrorMessage = "Data Término é obrigatória")]
        [DataType(DataType.Date)]      
        [Display(Name = "Data de término")]
        public DateTime DataTermino { get; set; }

        
        [Display(Name = "Quantidade de Likes")]
        public int QtdLikes { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data e hora de cadastro")]
        public DateTime DataHoraCadastro { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataTermino < DataInicio)
            {
                yield return
                  new ValidationResult(errorMessage: "Data Inicial não pode ser maior que a de término",
                                       memberNames: new[] { "DataTermino", "DataInicio" });
            }
            if ((DataTermino - DataTermino).Days < 5)
            {
                yield return
                  new ValidationResult(errorMessage: "O perído de parceria deve ter mais de 5 dias",
                                       memberNames: new[] { "DataTermino", "DataInicio" });
            }
           


        }
    }
}