using System.ComponentModel.DataAnnotations;

namespace ContosoShoe.models
{
    //public class ProductViewModel
    ////{

    ////    [Display(Name = "Product ID")]
    ////    [Required]
    ////    public int ProductID { get; set; }
    ////    [Required]
    ////    [Display(Name = "Product Name")]
    ////    [MaxLength(50)]
    ////    //[Remote("checkduplicate","product","ProductName",HttpMethod="GET")]
    ////    public string ProductName { get; set; }
    ////    [Required]
    ////    string ProductDescription { get; set; }
    ////    [Display(Name = "Product Category ID")]
    ////    public int ProductCategoryID { get; set; }
    ////    [Display(Name = "Product Subcategory ID")]
    ////    [Required]
    ////    public int ProductSubCategoryID { get; set; }
    ////    [Required]
    ////    [Display(Name = "Product Color")]
    ////    public string ProductColor { get; set; }
    ////    [Required]
    ////    [Range(50, 5000)]
    ////    [Display(Name = "Product Price")]
    ////    public int ProductPrice { get; set; }
    ////    //[DataType(DataType.ImageUrl)]
    ////    [Required]
    ////    [Display(Name = "Image")]
    ////    public string ProductImageUrl { get; set; } = "";
    ////    [Required]
    ////    [Display(Name = "Product Quantity Left")]
    ////    public int ProductQuantityLeft { get; set; }
    ////    [Required]
    ////    [Range(3, 13)]
    ////    [Display(Name = "Product Size")]
    ////    public int ProductSize { get; set; }
    ////    [Required]
    ////    [Display(Name = "Gender Category")]
    ////    public string GenderCategory { get; set; }
    ////    //[Required]
    ////    public IFormFile ProductImage { get; set; } = null;
    ////    //[Required]
    ////    [Range(1, 100)]
    ////    public int ProductQuantityAdded { get; set; } = 0;
    ////}

    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Price { get; set; }
    //    public string Description { get; set; }
    //    public string ImageUrl { get; set; }
    //}
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductSize { get; set; }
        public string GenderCategory { get; set; }
        public byte[]? ProductImage { get; set; } 
        public int ProductSubCategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductColor { get; set; }
        public int ProductQuantityAdded { get; set; }
    }

}