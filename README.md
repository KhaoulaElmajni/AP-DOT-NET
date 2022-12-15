# <strong style="color:blue; opacity: 0.80">AP DOT NET CORE</strong>:mortar_board::computer: 
# <span style="color:green "> 1.Présentation de l'activité pratique</span>
 * <strong style="color:dark">Partie 1 :100: 
Partie 1 :  Créer une application DotNet Core de type console qui permet gérer des comptes (id, curency, balance)
   - Créer la classe Account
   - Créer l'interface AccountService avec les opérations :
         . AddNewAccount
         . GetAllAccounts
         . GetAccountById
         . GetDebitedAccounts
         . GetBalanceAVG()
   - Créer une implémentation de cette interface utilisant une collection de type Dictionary
   - Tester l'application

 * <strong style="color:dark">Partie 2 :
 Créer une application DotNet Core de type WebAPI qui permet gérer des produits appartenant à des catégories

# <span style="color:green "> 2.Partie de réalisation </span>
1. 	installation du .Net version 6.0
	
![](https://i.imgur.com/B59VUWa.png)

2. consultation de version

![](https://i.imgur.com/FMh8JSr.png)





3. Partie 1 :  
	Créer une application DotNet Core de type console qui permet gérer des comptes (id, curency, balance)


![](https://i.imgur.com/XjvSldp.png)

![](https://i.imgur.com/7zRTY9i.png)

![](https://i.imgur.com/kJy07ES.png)

   - Créer la classe Account

```csharp!
using System.Text.Json;

namespace FIRSTAPP.Service
{
    public class Account
    {
        public int id { get; set; }
        public string? currency { get; set; }
        public double balance { get; set; }

        public Account(){}

        public Account(int id, string currency, double balance)
        {
            this.id = id;
            this.currency = currency;
            this.balance = balance;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

```

   - Créer l'interface AccountService avec les opérations :
         . AddNewAccount
         . GetAllAccounts
         . GetAccountById
         . GetDebitedAccounts
         . GetBalanceAVG()

```csharp!
namespace FIRSTAPP.Service
{
    public interface AccountService
    {
        Account GetAccountById(int id);
        Account AddNewAccount(Account account1);
        List<Account> GetAllAccounts();
        Account UpdateAccount(Account account1);
        void DeleteAccount(int id);

        List<Account> GetDebitedAccounts();
        double balanceAVG();
    }
}
```

   - Créer une implémentation de cette interface utilisant une collection de type Dictionary

```csharp!
namespace   FIRSTAPP.Service
{
    class AccountServiceImpl : AccountService
    {
        private Dictionary<int,Account> accounts = new Dictionary<int, Account>() ;

        public void DeleteAccount(int id)
        {
            Account account = GetAccount(id);
            accounts.Remove(account.id);
        }

        public List<Account> GetAllAccounts()
        {
            return accounts.Values.ToList();
        }

        public Account GetAccount(int id)
        {
            //return accounts.Find(account => account.id == id);
            return this.accounts[id];
    
        }

        public Account UpdateAccount(Account account1)
        {
            Account account = GetAccount(account1.id);
            account.balance = account1.balance;
            account.currency = account1.currency;
            return account;
        }

        public List<Account> GetDebitedAccounts()
        {
            return this.accounts.Values.Where(account => account.balance < 0).ToList();
        }

        public double balanceAVG()
        {
            return this.accounts.Values.Average(account => account.balance);
        }

        public Account GetAccountById(int id)
        {
            return accounts.Values.ToList().Find(account => account.id == id);
        }

        public void AddNewAccount(Account account1)
        {
            accounts.Add(account1.id,account1);
        }
    }
}
```

   - Tester l'application

```csharp!
// See https://aka.ms/new-console-template for more information
using FIRSTAPP.Service;

Console.WriteLine("Hello, World!");
Console.WriteLine("Test Dot Net core!");
Console.WriteLine("your name :");
String name = Console.ReadLine();
Console.WriteLine("Hello, " + name);

Account account = new Account(1, "USD", 1000);

Console.WriteLine(account.ToString());

AccountService accountService = new AccountServiceImpl();
accountService.AddNewAccount(account);
accountService.AddNewAccount(new Account(2, "USD", 2000));
accountService.AddNewAccount(new Account(3, "USD", 3000));
accountService.AddNewAccount(new Account(4, "USD", 4000));
accountService.AddNewAccount(new Account(5, "USD", 5000));
accountService.AddNewAccount(new Account(6, "USD", 6000));

accountService.GetAllAccounts().ForEach(account => Console.WriteLine(account.ToString()));

accountService.GetDebitedAccounts().ForEach(account => Console.WriteLine(account.ToString()));

Console.WriteLine(accountService.balanceAVG());

Console.WriteLine(accountService.GetAccountById(1).ToString());

accountService.DeleteAccount(1);
```

> Résultat de l'exécution
	
![](https://i.imgur.com/nIMX5Hs.png)


4. Partie 2 :
 Créer une application DotNet Core de type WebAPI qui permet gérer des produits appartenant à des catégories

![](https://i.imgur.com/Eu0b2jl.png)

* <strong style="color:dark"> Diagramme de classe
	
![](https://i.imgur.com/iVn4Zva.png)
 
EntityFrameworkCore
	
![](https://i.imgur.com/HdQKRLX.png)

![](https://i.imgur.com/xhdhrEV.png)

![](https://i.imgur.com/bWxX0Pl.png)

# <span style="color:green "> 4.Les technologies utilisées</span>	

Add Connection String =>
"ProductsDB": "Server=localhost;Database=products-db;Uid=root;Pwd="
	
![](https://i.imgur.com/6BZNyT9.png)

# **Models**
**Product**

```csharp!
namespace MyProductWebApi.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }

        public virtual Category? Category { get; set; }
    }
}
```
	
**Category**
	
```csharp!
namespace MyProductWebApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
```
	
# **Controllers**
	
**ProductsController**
	
```csharp!
namespace MyProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context
            )
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            Category category = new Category();

            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        //loading related data
        [HttpGet("GetProductsFromCategoryId")]
        public async Task<Product?> GetProductsFromCategoryId(int? categoryId)
        {
            return await _context.Products
                .Include(p => p.ProductId)
                .Where(p => p.CategoryId == categoryId)
                .FirstOrDefaultAsync();
        }


    
    }
}
```
	
**CategoriesController**
	
```csharp!
namespace MyProductsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ProductsContext _context;

        public CategoryController(ProductsContext context
            )
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
           // Category category = new Category();

            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

    }
}
```
	
****
	
# **Structure du projet**

![](https://i.imgur.com/AkTpkNo.png)

	

Packages installés =>
> dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
	
> dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0

Install & Update dotnet EF tool =>
> dotnet tool install --global dotnet-ef --version 6.0.0

> dotnet tool update --global dotnet-ef 

Scaffold MySQL Database =>
> dotnet ef dbcontext scaffold Name=ProductsDB Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data --namespace MyProductWebApi.Models --context-namespace MyProductWebApi.Data --context ProductsContext -f --no-onconfiguring


Documentation Swagger
	
![](https://i.imgur.com/BXLGfCV.png)
	
# **Category**
	
* GET
	
![](https://i.imgur.com/Ezl3xGe.png)

![](https://i.imgur.com/ew1viUd.png)

	
* POST

![](https://i.imgur.com/cUeVWYR.png)
![](https://i.imgur.com/0uytixL.png)

	
* PUT
	
![](https://i.imgur.com/wRLL0Te.png)
![](https://i.imgur.com/iFjkTlQ.png)


* DELETE
	
![](https://i.imgur.com/sK3omlT.png)

____
	
# **Product**

* GET
	
![](https://i.imgur.com/Esg4cAt.png)
	
![](https://i.imgur.com/ZRyodM4.png)

	
* POST

![](https://i.imgur.com/faihTSj.png)
![](https://i.imgur.com/hT9gjtj.png)

	
* PUT
	
![](https://i.imgur.com/5ycixQr.png)
![](https://i.imgur.com/wXEQuCv.png)


* DELETE

![](https://i.imgur.com/iLMte9N.png)

	
# <span style="color:green">3.Les Technologies utilisées</span>
####  <span style="color:#0036ad"> 1.Java</span>
 * <strong style="color:dark">* <strong style="color:dark">Entity Framework (EF) Core est une version légère, extensible, open source et multiplateforme de la célèbre technologie d'accès aux données Entity Framework.

EF Core peut servir de mappeur objet-relationnel (O/RM), qui :

* Permet aux développeurs .NET de travailler avec une base de données à l'aide d'objets .NET.
* Élimine le besoin de la plupart du code d'accès aux données qui doit généralement être écrit.

*voir également à propos* [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/):link: 


	    
* <strong style="color: dark ; opacity: 0.80">Enfin nous tenons à remercier le seul et unique, notre professeur Mr YOUSFI Mohamed *Docteur & professeur à l'ENSET MEDIA* pour son soutien et son encouragement envers nous, aussi pour nous avoir donné cette opportunité d'améliorer nos compétences et de connaître les nouvelles technologies comme celles qui nous avons travaillé.

*voir également à propos* Mr [YOUSSFI Mohamed](https://www.linkedin.com/in/mohamed-youssfi-3ab0811b/)
</strong>
	
> Created by :[name=ELMAJNI KHAOULA]
[time=Mon,2022,12,01][color=#EF0101]
>*voir également à propos de moi* [ELMAJNI Khaoula](https://www.linkedin.com/in/khaoula-elmajni/)