using System.Collections.Generic;
using System.Linq;

namespace LINQSamples
{
  public class SamplesViewModel
  {
    #region Constructor
    public SamplesViewModel()
    {
      // Load all Product Data
      Products = ProductRepository.GetAll();
    }
    #endregion

    #region Properties
    public bool UseQuerySyntax { get; set; } = true;
    public List<Product> Products { get; set; }
    public string ResultText { get; set; }
    #endregion

    #region WhereExpression
    /// <summary>
    /// Filter products using where. If the data is not found, an empty list is returned
    /// </summary>
    public void WhereExpression()
    {
      string search = "L";

      if (UseQuerySyntax) {
        // Query Syntax
        Products = (from prod in Products
                    where prod.Name.StartsWith(search)
                    select prod).ToList();
      }
      else {
        // Method Syntax
        Products = Products.Where(prod => prod.Name.StartsWith(search)).ToList();
      }

      ResultText = $"Total Products: {Products.Count}";
    }
    #endregion

    #region WhereTwoFields
    /// <summary>
    /// Filter products using where with two fields. If the data is not found, an empty list is returned
    /// </summary>
    public void WhereTwoFields()
    {
      string search = "L";
      decimal cost = 100;

      if (UseQuerySyntax) {
        // Query Syntax
        Products = (from prod in Products
                    where prod.Name.StartsWith(search) && prod.StandardCost > cost
                    select prod).ToList();
      }
      else {
        // Method Syntax
        Products = Products
          .Where(prod => prod.Name.StartsWith(search) && prod.StandardCost > cost).ToList();
      }

      ResultText = $"Total Products: {Products.Count}";
    }
    #endregion

    #region WhereExtensionMethod
    /// <summary>
    /// Filter products using a custom extension method
    /// </summary>
    public void WhereExtensionMethod()
    {
      string search = "Red";

      if (UseQuerySyntax) {
        // Query Syntax
        Products = (from prod in Products
                    select prod).ByColor(search).ToList();
      }
      else {
        // Method Syntax
        Products = Products.ByColor(search).ToList();
      }

      ResultText = $"Total Products: {Products.Count}";
    }
    #endregion

    #region First
    /// <summary>
    /// Locate a specific product using First(). First() searches forward in the collection.
    /// NOTE: First() throws an exception if the result does not produce any values
    /// </summary>
    public void First()
    {
      string search = "Red";
      Product value;

      try {
        if (UseQuerySyntax) {
          // Query Syntax
          value = (from prod in Products
                   select prod)
                   .First(prod => prod.Color == search);
        }
        else {
          // Method Syntax
          value = Products.First(prod => prod.Color == search);
        }

        ResultText = $"Found: {value}";
      }
      catch {
        ResultText = "Not Found";
      }

      Products.Clear();
    }
    #endregion

    #region FirstOrDefault
    /// <summary>
    /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
    /// NOTE: FirstOrDefault() returns a null if no value is found
    /// </summary>
    public void FirstOrDefault()
    {
      string search = "Red";
      Product value;

      if (UseQuerySyntax) {
        // Query Syntax
        value = (from prod in Products
                 select prod)
                 .FirstOrDefault(prod => prod.Color == search);
      }
      else {
        // Method Syntax
        value = Products.FirstOrDefault(prod => prod.Color == search);
      }

      if (value == null) {
        ResultText = "Not Found";
      }
      else {
        ResultText = $"Found: {value}";
      }

      Products.Clear();
    }
    #endregion

    #region Last
    /// <summary>
    /// Locate a specific product using Last(). Last() searches from the end of the list backwards.
    /// NOTE: Last returns the last value from a collection, or throws an exception if no value is found
    /// </summary>
    public void Last()
    {
      string search = "Red";
      Product value;

      try {
        if (UseQuerySyntax) {
          // Query Syntax
          value = (from prod in Products
                   select prod)
                   .Last(prod => prod.Color == search);
        }
        else {
          // Method Syntax
          value = Products.Last(prod => prod.Color == search);
        }

        ResultText = $"Found: {value}";
      }
      catch {
        ResultText = "Not Found";
      }

      Products.Clear();
    }
    #endregion

    #region LastOrDefault
    /// <summary>
    /// Locate a specific product using LastOrDefault(). LastOrDefault() searches from the end of the list backwards.
    /// NOTE: LastOrDefault returns the last value in a collection or a null if no values are found
    /// </summary>
    public void LastOrDefault()
    {
      string search = "Red";
      Product value;

      if (UseQuerySyntax) {
        // Query Syntax
        value = (from prod in Products
                 select prod)
                 .LastOrDefault(prod => prod.Color == search);
      }
      else {
        // Method Syntax
        value = Products.LastOrDefault(prod => prod.Color == search);
      }

      if (value == null) {
        ResultText = "Not Found";
      }
      else {
        ResultText = $"Found: {value}";
      }

      Products.Clear();
    }
    #endregion

    #region Single
    /// <summary>
    /// Locate a specific product using Single().
    /// NOTE: Single() expects only a single element to be found in the collection, otherwise an exception is thrown
    /// </summary>
    public void Single()
    {
      int search = 706;
      Product value;

      try {
        if (UseQuerySyntax) {
          // Query Syntax
          value = (from prod in Products
                   select prod)
                   .Single(prod => prod.ProductID == search);
        }
        else {
          // Method Syntax
          value = Products.Single(prod => prod.ProductID == search);
        }

        ResultText = $"Found: {value}";
      }
      catch {
        ResultText = "Not Found, or multiple elements found";
      }

      Products.Clear();
    }
    #endregion

    #region SingleOrDefault
    /// <summary>
    /// Locate a specific product using SingleOrDefault()
    /// NOTE: SingleOrDefault() returns a single element found in the collection, or a null value if none found in the collection, if multiple values are found an exception is thrown.
    /// </summary>
    public void SingleOrDefault()
    {
      int search = 706;
      Product value;

      try {
        if (UseQuerySyntax) {
          // Query Syntax
          value = (from prod in Products
                   select prod)
                   .SingleOrDefault(prod => prod.ProductID == search);
        }
        else {
          // Method Syntax
          value = Products.SingleOrDefault(prod => prod.ProductID == search);
        }

        if (value == null) {
          ResultText = "Not Found";
        }
        else {
          ResultText = $"Found: {value}";
        }
      }
      catch {
        ResultText = "Multiple elements found";
      }

      Products.Clear();
    }
    #endregion
  }
}