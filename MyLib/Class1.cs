using System;

namespace MyLib
{
    public class Class1
    {
        //        Tài khoản: phuongvvse151263
        //Mật khẩu:  j2v9XGzE
        //==============================================================================================================================================================================================================================================
        //Scaffold-DbContext "Server=.;Database= department_db;Uid=sa;Pwd=1234567890;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataAccess
        //==============================================================================================================================================================================================================================================
        /*
         * Phân quyền
         string adminid = HttpContext.Session.GetString("ADMIN_ID");
                    if (adminid == null)
                    {
                        return RedirectToPage("../Index");
                    }
         <form asp-area="" asp-page="Index" method="get" class="d-flex" >
                            <input type="text" name="SearchString" placeholder="Search..." />
                            <button>
                                <ion-icon name="search-outline" class="search-icon" />
                            </button>
                        </form>
         */
        //Startup.cs
        //ConfigureServices(){
        //services.AddRazorPages();
        //services.AddDbContext<department_dbContext>(
        //                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        //            services.AddMvc();
        //            services.AddMvc().AddRazorPagesOptions(options =>
        //            {
        //                options.Conventions.AddPageRoute("/Posts/Index", "");
        //            });
        //services.Configure<RouteOptions>(r =>
        //            {
        //                r.LowercaseUrls = true;
        //            });
        //services.AddSession();
        //services.AddHttpContextAccessor();
        //services.AddTransient<ICommentRepository, CommentRepository>();
        //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //}

        //Configure(){
        //app.UseSession();
        //}
        //==============================================================================================================================================================================================================================================
        //Login.cshtml

        //@{
        //    ViewData["Title"] = "Login";
        //}

        //<div class="container-fluid w-50 my-login-container">
        //    <h2 class="text-center font-weight-bold" style="font-size: 38px; margin-bottom: 20px">
        //        Login here
        //    </h2>
        //    @if (ViewData["LoginMessage"] != null)
        //    {
        //        <p class="text-danger text-center font-weight-bold">@ViewData["LoginMessage"]</p>
        //    }

        //    <form method="post">
        //        <div class="form-group">
        //            <label class="mb-2" for="exampleInputEmail1">Email</label>
        //            <input type="email" class="form-control" id="exampleInputEmail1" asp-for="@Model.UserLogin.Email" aria-describedby="emailHelp">
        //        </div>
        //        <div class="form-group">
        //            <label class="mb-2" for="exampleInputPassword1">Password</label>
        //            <input type="password" class="form-control" id="exampleInputPassword1" asp-for="@Model.UserLogin.Password">
        //        </div>
        //        <button type="submit" class="btn btn-primary w-100 p-2">Login</button>
        //    </form>
        //</div>
        //==============================================================================================================================================================================================================================================
        //Login.cshtml.cs
        //using LibraryWeb.Model;
        //using LibraryWeb.Repository;
        //using Microsoft.AspNetCore.Http;
        //using Microsoft.AspNetCore.Mvc;
        //using Microsoft.AspNetCore.Mvc.RazorPages;
        //using System;

        //namespace MyWeb.Pages
        //{
        //    public class LoginModel : PageModel
        //    {
        //        [BindProperty]
        //        public User UserLogin { get; set; }

        //        public IUserRepository userRepo;

        //        public LoginModel()
        //        {
        //            userRepo = new UserRepository();
        //        }

        //        public IActionResult OnGet()
        //        {
        //            string role = HttpContext.Session.GetString("ROLE");
        //            if (role!= null)
        //            {
        //                return RedirectToPage("./Posts/Index");
        //            }

        //            return Page();
        //        }

        //        public IActionResult OnPost()
        //        {
        //            User tmp = userRepo.CheckLogin(UserLogin.Email, UserLogin.Password);
        //            if (tmp == null)
        //            {
        //                ViewData["LoginMessage"] = "Email and password is not valid!";
        //                return Page();
        //            }
        //            else
        //            {
        //                string role = userRepo.CheckRole(tmp);
        //                HttpContext.Session.SetString("CURRENT_USER_ID", tmp.UserId.ToString());
        //                HttpContext.Session.SetString("CURRENT_USER_FULLNAME", $"{tmp.FirstName} {tmp.LastName}");
        //                HttpContext.Session.SetString("CURRENT_USER_AVATAR", tmp.Avatar);
        //                if (role.Equals("ADMIN"))
        //                {
        //                    HttpContext.Session.SetString("ROLE", "ADMIN");
        //                }
        //                else if (role.Equals("MANAGER"))
        //                {
        //                    HttpContext.Session.SetString("ROLE", "MANAGER");
        //                }
        //                else if (role.Equals("RESIDENT"))
        //                {
        //                    HttpContext.Session.SetString("ROLE", "RESIDENT");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("This user role is not supported!");
        //                }
        //                return Redirect("/Posts/Index");
        //            }
        //        }

        //        public IActionResult OnGetLogout()
        //        {
        //            Console.WriteLine("Da logout!");
        //	    HttpContext.Session.Remove("CURRENT_USER_ID");
        //            HttpContext.Session.Remove("CURRENT_USER_FULLNAME");
        //            HttpContext.Session.Remove("ROLE");
        //            HttpContext.Session.Clear();
        //            return Page();
        //        }
        //    }
        //}

        //==============================================================================================================================================================================================================================================
        //UserDAO.cs
        //private static UserDAO instance = null;
        //        private static readonly object instanceLock = new object();
        //        private UserDAO() { }

        //        public static UserDAO Instance
        //        {
        //            get
        //            {
        //                lock (instanceLock)
        //                {
        //                    if (instance == null)
        //                    {
        //                        instance = new UserDAO();
        //                    }
        //                }
        //                return instance;
        //            }
        //        }
        //context.Entry(user).State = EntityState.Modified; EDIT USER
        //context.SaveChanges();
        //==============================================================================================================================================================================================================================================
        //VALIDATION
        //public class AddressValidation : ValidationAttribute
        //    {
        //        public AddressValidation()
        //        {
        //            ErrorMessage = "*** Sorry, your address must be more than 5 characters, please!";
        //        }

        //        public override bool IsValid(object value)
        //        {
        //            return value != null && value.ToString().Trim().Length >= 5;
        //        }
        //    }

        //==============================================================================================================================================================================================================================================
        //MODEL
        //public class UserLogin
        //{
        //    public string UserId { get; set; }
        //    public string Password { get; set; }
        //}
        //Post.cs

        //    public partial class Post
        //    {
        //        public Post()
        //        {
        //            Comments = new HashSet<Comment>();
        //            Likes = new HashSet<Like>();
        //        }

        //        public Guid PostId { get; set; }
        //        public Guid UserPostId { get; set; }
        //        [Display(Name = "Select Group")]
        //        public Guid? GroupPostId { get; set; }
        //        public Guid PostTypeId { get; set; }

        //        [Display(Name = "Post Title")]
        //        [TitleValidation]
        //        public string Title { get; set; }
        //        public int LikesTotal { get; set; }
        //        public int CommentsTotal { get; set; }

        //        [Range(0, Int32.MaxValue)]
        //        public int Views { get; set; }

        //        [TagsValidation]
        //        public string Tags { get; set; } // Nhớ Trim trước khi save db

        //        [Display(Name = "Post Content")]
        //        [PostContentValidation]
        //        public string PostContent { get; set; }
        //        public DateTime CreatedDate { get; set; }
        //        public DateTime? LastModified { get; set; }
        //        public DateTime? ApprovedDate { get; set; }
        //        public string Reason { get; set; }
        //        public int Status { get; set; } // Status: 4 || 5 || 7 || 8 || 9

        //        public virtual Group GroupPost { get; set; }
        //        public virtual PostType PostType { get; set; }
        //        public virtual Status StatusNavigation { get; set; }
        //        public virtual User UserPost { get; set; }
        //        public virtual ICollection<Comment> Comments { get; set; }
        //        public virtual ICollection<Like> Likes { get; set; }

        //        public List<string> GetTagsList()
        //        {
        //            return new List<string>(Tags.Trim().Split(" "));
        //        }

        //    }
        //==============================================================================================================================================================================================================================================
        //READ JSON FILE
        //.cshtml.cs
        //return RedirectToPage("./Index");

        //private Account GetAccountAdmin()
        //        {
        //            Account acc = null;
        //            using (StreamReader r = new StreamReader("appsettings.json"))
        //            {
        //                string json = r.ReadToEnd();
        //                IConfiguration config = new ConfigurationBuilder()
        //                                        .SetBasePath(Directory.GetCurrentDirectory())
        //                                        .AddJsonFile("appsettings.json", true, true)
        //                                        .Build();
        //                string email = config["Account:Email"];
        //                string password = config["Account:Password"];
        //                acc = new Account();
        //                acc.Email = email;
        //                acc.Password = password;
        //            }
        //            return acc;
        //        }
        //==============================================================================================================================================================================================================================================
        //"Account": {
        //    "Email": "admin@fstore.com",
        //    "Password": "admin@@"
        //  },
        //  "AllowedHosts": "*",
        //  "ConnectionStrings": {
        //    "DefaultConnection": "Persist Security Info=False;User ID=sa;Password=Vvp06062001-;Initial Catalog=NorthwindCopyDB;Data Source=.;Connection Timeout=100000"
        //  }
















    }
}
