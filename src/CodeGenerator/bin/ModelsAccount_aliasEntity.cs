


using System;
using System.ComponentModel.DataAnnotations.Schema;
//EFX Code Generation Template 1.0
//author:Tibos
//blog:www.cnblogs.com/Tibos
//Entity Code Generation Template
namespace FLShop.BusinessModel.Model
{
    [Table("account_alias")]
	//Account_aliasEntity;
	public class Account_aliasEntity:BaseEntity
    {

        /// <summary>
		/// 
        /// </summary>
        public virtual int id
        {
            get; 
            set; 
        }  
        
        /// <summary>
		/// 
        /// </summary>
        public virtual string alias
        {
            get; 
            set; 
        }  
        
        /// <summary>
		/// 
        /// </summary>
        public virtual System.DateTime create_time
        {
            get; 
            set; 
        }  
        
        /// <summary>
		/// 
        /// </summary>
        public virtual string remark
        {
            get; 
            set; 
        }  
        
    }
}
