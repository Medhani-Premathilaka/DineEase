using DineEase;

public static class PageFactory
{
    public static ShowPage CreatePage(string role)
    {
        switch (role)
        {
            case "ADMIN":
                return (ShowPage)new AdminHomePage();
            case "USER":
                return (ShowPage)new userViewFood();

            // Add more cases as needed
            default:
                return (ShowPage)new Form1();
        }
    }
}