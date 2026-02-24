namespace Redarbor.Domain.Entities;

public class Employee
{
    public int Id { get; private set; }  

    public int CompanyId { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public int PortalId { get; private set; }
    public int RoleId { get; private set; }
    public int StatusId { get; private set; }
    public string Username { get; private set; }
    public string Name { get; private set; }
    public string Fax { get; private set; }
    public string Telephone { get; private set; }
    public DateTime? LastLogin { get; private set; }

    public DateTime CreatedOn { get; private set; }
    public DateTime? UpdatedOn { get; private set; }
    public DateTime? DeletedOn { get; private set; }

    protected Employee() { } // EF

    public void UpdateEmail(string email)
    {
        Email = email;
        SetUpdated();
    }

    public void UpdateCompany(int companyId)
    {
        CompanyId = companyId;
        SetUpdated();
    }

    public void UpdatePortal(int portalId)
    {
        PortalId = portalId;
        SetUpdated();
    }

    public void UpdateRole(int roleId)
    {
        RoleId = roleId;
        SetUpdated();
    }

    public void UpdateStatus(int statusId)
    {
        StatusId = statusId;
        SetUpdated();
    }

    public void UpdateUsername(string username)
    {
        Username = username;
        SetUpdated();
    }

    public void UpdateName(string name)
    {
        Name = name;
        SetUpdated();
    }

    public void UpdateFax(string fax)
    {
        Fax = fax;
        SetUpdated();
    }

    public void UpdateTelephone(string telephone)
    {
        Telephone = telephone;
        SetUpdated();
    }

    public void UpdatePassword(string hashedPassword)
    {
        Password = hashedPassword;
        SetUpdated();
    }


    public Employee(
        int companyId,
        string email,
        string password,
        int portalId,
        int roleId,
        int statusId,
        string username,
        string name,
        string fax,
        string telephone)
    {
        CompanyId = companyId;
        Email = email;
        Password = password;
        PortalId = portalId;
        RoleId = roleId;
        StatusId = statusId;
        Username = username;
        Name = name;
        Fax = fax;
        Telephone = telephone;
        CreatedOn = DateTime.UtcNow;
    }

    public void DeleteOn()
    {
        DeletedOn = DateTime.UtcNow;
        UpdatedOn = DateTime.UtcNow;
    }

    public void RegisterLogin()
    {
        LastLogin = DateTime.UtcNow;
    }

    private void SetUpdated()
    {
        UpdatedOn = DateTime.UtcNow;
    }

}