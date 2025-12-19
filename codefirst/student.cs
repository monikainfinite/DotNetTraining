using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//for primary key
using System.ComponentModel.DataAnnotations.Schema;//for not having identity
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirst
{//validations
    //required,range,maxlength,minlength,phone,regular expression,url,email,zip
    [Table("Studentstbl")]//we can assign table name 
 public class student
    {//if we dont auto increment for sid then 
        [Key]//primary key
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//no identity 
        [Required(ErrorMessage ="please enter studentid")]
        public int studentId {  get; set; }
        [Required(ErrorMessage = "please enter studentname")]
        [RegularExpression("^[a-zA-Z]+$",ErrorMessage ="only alphabets allowed")]
        [Column("sid")] //we can specify our own column name 
        public string Studentname { get; set; }//if we want only alphabets we will use regular expressions
        [Column("stuname", TypeName = "varchar")]
        [MaxLength(30)]//its like varchar(30)

        public DateTime DOB { get; set; }

        [EmailAddress (ErrorMessage="pls enter valid mail")]
        [Column("stuemail", TypeName = "varchar")]
        [MaxLength(40)]//its like varchar(30)
        public string Email { get; set; }
        [Range(1,12,ErrorMessage ="pls enter valid class")]
        public int Class {  get; set; }

    }
}
