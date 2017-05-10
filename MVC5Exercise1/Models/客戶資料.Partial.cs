namespace MVC5Exercise1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料
    {
    }

    /// <summary>
    /// Model 欄位資料驗證
    /// https://dotblogs.com.tw/mantou1201/2013/04/18/101814
    /// https://dotblogs.com.tw/mantou1201/archive/2013/04/16/101657.aspx
    /// https://dotblogs.com.tw/mantou1201/archive/2013/05/07/103108.aspx
    /// https://dotblogs.com.tw/mantou1201/2013/09/29/122045
    /// </summary>
    public partial class 客戶資料MetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "客戶名稱必填")]
        public string 客戶名稱 { get; set; }
        
        [RegularExpression(@"^\d{8}$",ErrorMessage = "統一編號需為8位數字")]  // 統一編號需：匹配8個數字
        [StringLength(8, ErrorMessage="欄位長度不得大於 8 個字元")]
        [Required(ErrorMessage = "統一編號必填")]
        public string 統一編號 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "電話必填")]
        public string 電話 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 傳真 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string 地址 { get; set; }
        
        [EmailAddress(ErrorMessage = "請輸入正確的電子信箱")]
        [StringLength(250, MinimumLength = 6, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string Email { get; set; }
    
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}
