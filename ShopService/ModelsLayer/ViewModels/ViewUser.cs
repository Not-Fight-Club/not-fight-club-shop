using System;

namespace ModelsLayer.ViewModels
{
  public class ViewUser
  {

    public Guid? UserId { get; set; }
    public string UserName { get; set; }
    public string Pword { get; set; }
    public string Email { get; set; }
    public DateTime? Dob { get; set; }
    public int? Bucks { get; set; }
    public bool Active { get; set; }
    public DateTime LastLogin { get; set; }
  }
}